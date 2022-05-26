using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Heartfield.Inputs
{
    public enum Context
    {
        All = -1,
        Started = 0,
        Performed = 1,
        Canceled = 2
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
        MouseScroll
    }

    public enum CameraActionMap
    {
        LookAround,
        LookBehind
    }

    public static class InputsRegistry
    {
        static Dictionary<Enum, InputActionReference> _actionMaps = new Dictionary<Enum, InputActionReference>();
        static InputActionReference[] _allInputActionReference;

        static InputsRegistry()
        {
            _allInputActionReference = Resources.LoadAll<InputActionReference>("Inputs");
            _actionMaps.Clear();

            List<Array> names = new List<Array>
            {
                Enum.GetValues(typeof(PlayerActionMap)),
                Enum.GetValues(typeof(CarActionMap)),
                Enum.GetValues(typeof(UiActionMap)),
                Enum.GetValues(typeof(MouseActionMap)),
                Enum.GetValues(typeof(CameraActionMap))
            };

            for (int i = 0; i < _allInputActionReference.Length; i++)
            {
                var input = _allInputActionReference[i];

                for (int j = 0; j < names.Count; j++)
                {
                    var nameArray = names[j];

                    for (int k = 0; k < nameArray.Length; k++)
                    {
                        var value = nameArray.GetValue(k);

                        if (input.name.EndsWith(value.ToString()))
                            _actionMaps.Add((Enum)value, input);
                    }
                }
            }
        }

        static List<InputActionReference> GetInputActionReference(ActionMapType type)
        {
            var typeName = type.ToString();
            var inputRefList = new List<InputActionReference>();

            for (int i = 0; i < _allInputActionReference.Length; i++)
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

        static void RegisterContext(Enum actionMap, Action<InputAction.CallbackContext> action, Context ctx, bool register)
        {
            if (!_actionMaps.ContainsKey(actionMap))
                return;

            var inputAction = _actionMaps[actionMap];

            if (ctx == Context.All)
            {
                if (register)
                {
                    inputAction.action.started += action;
                    inputAction.action.performed += action;
                    inputAction.action.canceled += action;
                }
                else
                {
                    inputAction.action.started -= action;
                    inputAction.action.performed -= action;
                    inputAction.action.canceled -= action;
                }
            }
            else
            {
                if (ctx == Context.Started)
                {
                    if (register)
                        inputAction.action.started += action;
                    else
                        inputAction.action.started -= action;
                }

                if (ctx == Context.Performed)
                {
                    if (register)
                        inputAction.action.performed += action;
                    else
                        inputAction.action.performed -= action;
                }

                if (ctx == Context.Canceled)
                {
                    if (register)
                        inputAction.action.canceled += action;
                    else
                        inputAction.action.canceled -= action;
                }
            }
        }

        public static void ToggleActionEvent(PlayerActionMap actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => RegisterContext(actionMap, action, ctx, register);
        public static void ToggleActionEvent(CarActionMap actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => RegisterContext(actionMap, action, ctx, register);

        public static void ActionEvent(UiActionMap actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => RegisterContext(actionMap, action, ctx, register);
        public static void ActionEvent(MouseActionMap actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => RegisterContext(actionMap, action, ctx, register);
        public static void ActionEvent(CameraActionMap actionMap, Context ctx, Action<InputAction.CallbackContext> action, bool register) => RegisterContext(actionMap, action, ctx, register);
    }
}