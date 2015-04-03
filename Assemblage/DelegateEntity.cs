using System;

namespace Assemblage
{
    sealed class DelegateEntity : IEntity
    {
        private readonly Action initializeAction;
        private readonly Action<float> updateAction;
        private readonly Action destroyAction;

        public DelegateEntity(Action initializeAction, Action<float> updateAction, Action destroyAction)
            : base()
        {
            this.initializeAction = initializeAction;
            this.updateAction = updateAction;
            this.destroyAction = destroyAction;
        }

        public void OnInitialize()
        {
            if (initializeAction != null)
            {
                initializeAction();
            }
        }

        public void OnUpdate(float dt)
        {
            if (updateAction != null)
            {
                updateAction(dt);
            }
        }

        public void OnDestroy()
        {
            if (destroyAction != null)
            {
                destroyAction();
            }
        }
    }
}
