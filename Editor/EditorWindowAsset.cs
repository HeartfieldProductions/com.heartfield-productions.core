using UnityEngine;

namespace HeartfieldEditor
{
    public abstract class EditorWindowAsset
    {
        [SerializeField] public bool hasChangesNotSaved;

        public abstract void RevertDefults();
    }
}