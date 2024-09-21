namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{
    public abstract class BaseAssetDrawer<T> : BaseGraphicsDrawer
    {
        protected T asset;
        public BaseAssetDrawer(T asset)
        {
            this.asset = asset;
        }
    }
}
