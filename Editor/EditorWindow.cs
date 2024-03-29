using UnityEditor;

namespace HeartfieldEditor
{
    public abstract class EditorWindow<Asset> : EditorWindow where Asset : EditorAsset
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

        public override void SaveChanges()
        {
            base.SaveChanges();
            baseAsset.SaveAsset();
        }
    }
}