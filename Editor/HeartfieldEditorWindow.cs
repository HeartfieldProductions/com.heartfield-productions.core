using UnityEditor;

namespace HeartfieldEditor
{
    public abstract class HeartfieldEditorWindow<Asset> : EditorWindow
    {
        protected abstract Asset AssetToSave { get; }
        protected abstract string AssetKey { get; }

        protected void SaveWindowAsset()
        {
            var data = EditorJsonUtility.ToJson(AssetToSave);
            EditorPrefs.SetString(AssetKey, data);
        }

        protected void LoadWindowAsset()
        {
            var data = EditorPrefs.GetString(AssetKey);

            if (!string.IsNullOrEmpty(data))
                EditorJsonUtility.FromJsonOverwrite(data, AssetToSave);
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