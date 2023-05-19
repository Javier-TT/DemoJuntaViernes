namespace DemoJuntaViernes.Data.Repositorios
{
    /// <summary>
    /// El patrón repositorio genérico pretende extraer el factor común y 
    /// establecer un contrato que le de las bases comunes a nuestros repositorios. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<int> Create(TEntity entity);
    }
}
