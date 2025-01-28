namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{
    public abstract class BaseAssetDrawer<T> : BaseGraphicsDrawer
    {
        protected T asset;
        public override bool HasAsset()
        {
            return asset != null;
        }
        public virtual void ChangeAsset(T newAsset)
        {
            asset = newAsset;
        }
        public BaseAssetDrawer(T asset)
        {
            this.asset = asset;
        }
        public BaseAssetDrawer()
        {
        }
    }
}
