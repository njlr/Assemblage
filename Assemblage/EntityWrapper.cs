using System;

namespace Assemblage
{
    sealed class EntityWrapper
    {
        private readonly IEntity entity;

        private EntityState entityState;

        public IEntity Entity
        {
            get { return entity; }
        }

        public EntityState EntityState
        {
            get { return entityState; }
        }

        public EntityWrapper(IEntity entity)
            : base()
        {
            if (entity == null)
            {
                throw new ArgumentNullException("implementation", "Entity implementation must not be null. ");
            }

            this.entity = entity;

            entityState = Assemblage.EntityState.Inactive;
        }

        public void Initialize()
        {
            if (entityState != Assemblage.EntityState.Inactive)
            {
                throw new InvalidOperationException("Entity is not inactive. ");
            }

            entityState = Assemblage.EntityState.Active;

            entity.OnInitialize();
        }

        public void Update(float dt)
        {
            if (entityState != Assemblage.EntityState.Active)
            {
                throw new InvalidOperationException("Entity is not active. ");
            }

            entity.OnUpdate(dt);
        }

        public void Destroy()
        {
            if (entityState != Assemblage.EntityState.Active)
            {
                throw new InvalidOperationException("Entity is not active. ");
            }

            entityState = Assemblage.EntityState.Destroyed;

            entity.OnDestroy();
        }
    }
}
