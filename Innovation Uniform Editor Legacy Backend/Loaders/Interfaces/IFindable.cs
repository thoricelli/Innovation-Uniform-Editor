namespace Innovation_Uniform_Editor_Backend.Loaders.Interfaces
{
    public interface IFindable<TType, TId>
    {
        TType FindBy(TId id);
        void DeleteBy(TId id);
    }
}
