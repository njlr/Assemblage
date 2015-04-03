
namespace Assemblage
{
    public interface IEntity
    {
        void OnInitialize();

        void OnUpdate(float dt);

        void OnDestroy();
    }
}
