using System;

namespace Assemblage
{
    public static class EntityFactory
    {
        public static IEntity CreateEntity(Action initializeAction, Action<float> updateAction, Action destroyAction)
        {
            return new DelegateEntity(initializeAction, updateAction, destroyAction);
        }
    }
}
