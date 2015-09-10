
namespace Assemblage
{
    public interface IEntityService
    {
        T Create<T>(T entity) where T : IEntity;

        T Destroy<T>(T entity) where T : IEntity;

        void Destroy();
    }
}
