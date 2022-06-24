using UnityEditor;

namespace HeartfieldEditor
{
    public abstract class EditorWindow<Asset> : EditorWindow where Asset : EditorWindowAsset
    {
        protected abstract Asset GetAsset { get; }
        protected abstract string AssetKey { get; }

        protected void SaveWindowAsset()
        {
            var data = EditorJsonUtility.ToJson(GetAsset);
            EditorPrefs.SetString(AssetKey, data);
        }

        protected void LoadWindowAsset()
        {
            var data = EditorPrefs.GetString(AssetKey);

            if (!string.IsNullOrEmpty(data))
                EditorJsonUtility.FromJsonOverwrite(data, GetAsset);
        }

        protected void ClearWindowAsset()
        {
            EditorPrefs.DeleteKey(AssetKey);
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
        }
    }
}