namespace NLayerCore.UnitOfWork
{
    public interface IUnitOfWork
    {
         //UnitOfWork Nedir?
         //Bu pattern, iş katmanında yapılan her değişikliğin anlık olarak database e yansıması yerine,
         // işlemlerin toplu halde tek bir kanaldan gerçekleşmesini sağlar.
        Task CommitAsync();
        void Commit();
    }
}