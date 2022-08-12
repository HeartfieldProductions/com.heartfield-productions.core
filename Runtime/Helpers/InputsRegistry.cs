#if UNITY_INPUT_SYSTEM_INCLUDED
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Heartfield.Inputs
{
    [Flags]
    public enum Context
    {
        Started = 1 << 0,
        Performed = 1 << 1,
        Canceled = 1 << 2,
        All = Started | Performed | Canceled
    }

    public enum ActionMapType
    {
        Player,
        Car,
        UI,
        Mouse,
        Camera
    }

    public enum PlayerActionMap
    {
        Interact,
        Movement,
        Run,
        Sneak,
        Crouch,
        Inventory,
        WearShoes,
        SaveGame,
        LoadGame,
        LookAround,
        MouseMove,
        Door,
        Pause,
        Confirm,
        Drawing
    }

    public enum CarActionMap
    {
        Steer,
        Throttle,
        Reverse,
        Brake,
        Handbrake,
        Clutch,
        ShiftGear,
        Reset
    }

    public enum UiActionMap
    {
        Point,
        LeftClick,
        RightClick,
        Submit,
        Exit
    }

    public enum MouseActionMap
    {
        MousePosition,
        MouseLook,
        MouseScroll,
        LeftClick,
        RightClick,
        MiddleClick
    }

    public enum CameraActionMap
    {
        LookAround,
        LookBehind,
        ChangeCamera
    }

    public static class InputsRegistry
    {
        static Dictionary<object, InputActionReference> _actionMaps = new Dictionary<object, InputActionReference>();
        static List<InputActionReference> _allInputActionReference = new List<InputActionReference>();

        static InputsRegistry()
        {
            _allInputActionReference.AddRange(Resources.LoadAll<InputActionReference>("Inputs"));
            _actionMaps.Clear();

            if (_allInputActionReference == null || _allInputActionReference.Count == 0)
            {
                Debug.LogError("None Input Action was found");
                return;
            }

            var names = new List<Array>
            {
                Enum.GetValues(typeof(PlayerActionMap)),
                Enum.GetValues(typeof(CarActionMap)),
                Enum.GetValues(typeof(UiActionMap)),
                Enum.GetValues(typeof(MouseActionMap)),
                Enum.GetValues(typeof(CameraActionMap))
            };

            for (int i = 0; i < _allInputActionReference.Count; i++)
            {
                var input = _allInputActionReference[i];

                for (int j = 0; j < names.Count; j++)
                {
                    var nameArray = names[j];

                    for (int k = 0; k < nameArray.Length; k++)
                    {
                        var key = nameArray.GetValue(k);

                        if (input.name.EndsWith(key.ToString()))
                        {
                            if (_actionMaps.ContainsKey(key))
                                continue;

                            _actionMaps.Add(key, input);
                        }
                    }
                }
            }
        }

        static List<InputActionReference> GetInputActionReference(ActionMapType type)
        {
            var typeName = type.ToString();
            var inputRefList = new List<InputActionReference>();

            for (int i = 0; i < _allInputActionReference.Count; i++)
            {
                var inputActionRef = _allInputActionReference[i];

                if (inputActionRef.action.actionMap.name.StartsWith(typeName))
                    inputRefList.Add(inputActionRef);
            }

            return inputRefList;
        }

        static void ToggleActionMap(List<InputActionReference> actionMaps, bool enabled)
        {
            for (int i = 0; i < actionMaps.Count; i++)
            {
                var inputAction = actionMaps[i].ToInputAction();

                if (enabled)
                    inputAction.Enable();
                else
                    inputAction.Disable();
            }
        }

        public static void ForceEnable(ActionMapType actionMapType) => ToggleActionMap(GetInputActionReference(actionMapType), true);
        public static void ForceDisable(ActionMapType actionMapType) => ToggleActionMap(GetInputActionReference(actionMapType), false);

        static void ToggleContext<T>(T actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register)
        {
            if (!_actionMaps.ContainsKey(actionMap))
            {
                Debug.LogWarning($"{actionMap} does not exist");
                return;
            }

            var inputAction = _actionMaps[actionMap];

            if (ctx.HasFlag(Context.Started))
            {
                if (register)
                    inputAction.action.started += action;
                else
                    inputAction.action.started -= action;
            }

            if (ctx.HasFlag(Context.Performed))
            {
                if (register)
                    inputAction.action.performed += action;
                else
                    inputAction.action.performed -= action;
            }

            if (ctx.HasFlag(Context.Canceled))
            {
                if (register)
                    inputAction.action.canceled += action;
                else
                    inputAction.action.canceled -= action;
            }
        }

        public static void ToggleContext(Enum actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => ToggleContext<Enum>(actionMap, ctx, action, register);

        public static void ToggleContext(string actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => ToggleContext<string>(actionMap, ctx, action, register);
    }
}
#else
namespace Heartfield.Inputs
{
    public static class InputsRegistry { }
}
#endif