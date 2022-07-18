using UnityEngine;

namespace HeartfieldEditor
{
    public abstract class EditorAsset
    {
        public EditorAsset() { }

        [SerializeField] public bool hasChangesNotSaved;

        public abstract void RevertDefults();
    }
}