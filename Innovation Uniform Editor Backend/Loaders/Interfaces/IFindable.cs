namespace Innovation_Uniform_Editor.Classes.Loaders.Interfaces
{
    public interface IFindable<TType, TId>
    {
        TType FindBy(TId id);
        void DeleteBy(TId id);
    }
}
