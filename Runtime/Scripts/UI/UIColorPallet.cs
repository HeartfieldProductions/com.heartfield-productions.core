using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Heartfield.UI
{
    [ExecuteInEditMode, RequireComponent(typeof(Canvas))]
    sealed class UIColorPallet : MonoBehaviour
    {
        [SerializeField, HideInInspector] List<Selectable> _selectables = new List<Selectable>();
        [SerializeField] ColorBlock colors;

        void Awake()
        {
            GetComponentsInChildren(true, _selectables);

            for (int i = 0; i < _selectables.Count; i++)
            {
                _selectables[i].colors = colors;
            }
        }

#if UNITY_EDITOR
        void Update()
        {
            if (Application.isPlaying)
                return;

            for (int i = 0; i < _selectables.Count; i++)
            {
                _selectables[i].colors = colors;
            }
        }
#endif
    }
}