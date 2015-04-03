
namespace Assemblage
{
    public interface IEntityService
    {
        void Create(IEntity entity);

        void Destroy(IEntity entity);
    }
}
