using System;
using UnityEditor;

namespace HeartfieldEditor
{
    public struct EditorAssetBase<Asset> where Asset : EditorAsset
    {
        static Asset asset;

        internal Asset GetAsset
        {
            get
            {
                if (asset == null)
                    asset = (Asset)Activator.CreateInstance(typeof(Asset));

                return asset;
            }
        }

        string AssetKey => $"{GetType().Name}_{GetAsset.GetType().Name}";

        internal void SaveAsset()
        {
            var data = EditorJsonUtility.ToJson(GetAsset);
            EditorPrefs.SetString(AssetKey, data);
            GetAsset.hasChangesNotSaved = false;
        }

        internal void LoadAsset()
        {
            var data = EditorPrefs.GetString(AssetKey);

            if (string.IsNullOrEmpty(data))
                GetAsset.RevertDefults();
            else
                EditorJsonUtility.FromJsonOverwrite(data, GetAsset);
        }

        internal void ClearWindowAsset()
        {
            EditorPrefs.DeleteKey(AssetKey);
        }
    }
}