using UnityEditor;

namespace HeartfieldEditor
{
    public abstract class Editor<Asset> : Editor where Asset : EditorAsset
    {
        static EditorAssetBase<Asset> baseAsset = new EditorAssetBase<Asset>();
        public static Asset GetAsset => baseAsset.GetAsset;

        protected virtual void OnEnable()
        {
            baseAsset.LoadAsset();
        }

        protected virtual void OnDisable()
        {
            baseAsset.SaveAsset();
        }
    }
}