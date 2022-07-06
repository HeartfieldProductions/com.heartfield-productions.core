using System;
using UnityEditor;

namespace HeartfieldEditor
{
    public abstract class EditorWindow<Asset> : EditorWindow where Asset : EditorWindowAsset
    {
        static Asset asset;

        protected static Asset GetAsset
        {
            get
            {
                if (asset == null)
                    asset = (Asset)Activator.CreateInstance(typeof(Asset));

                return asset;
            }
        }

        string GetAssetKey => $"{GetType().Name}_{GetAsset.GetType().Name}";

        void SaveWindowAsset()
        {
            var data = EditorJsonUtility.ToJson(GetAsset);
            EditorPrefs.SetString(GetAssetKey, data);
        }

        void LoadWindowAsset()
        {
            var data = EditorPrefs.GetString(GetAssetKey);

            if (string.IsNullOrEmpty(data))
                GetAsset.RevertDefults();
            else
                EditorJsonUtility.FromJsonOverwrite(data, GetAsset);
        }

        protected void ClearWindowAsset()
        {
            EditorPrefs.DeleteKey(GetAssetKey);
        }

        protected virtual void OnEnable()
        {
            LoadWindowAsset();
        }

        protected virtual void OnDisable()
        {
            SaveWindowAsset();
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
            SaveWindowAsset();
            GetAsset.hasChangesNotSaved = false;
        }
    }
}