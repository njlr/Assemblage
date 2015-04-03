using System;
using System.Collections.Generic;
using System.Linq;

namespace Assemblage
{
    public sealed class EntityManager : IEntityService, IDisposable
    {
        private readonly IList<EntityWrapper> entityWrappers;

        public EntityManager()
            : base()
        {
            entityWrappers = new List<EntityWrapper>(1024);
        }

        public void Update(float dt)
        {
            for (int i = 0; i < entityWrappers.Count; i++)
            {
                if (entityWrappers[i].EntityState == Assemblage.EntityState.Active)
                {
                    entityWrappers[i].Update(dt);
                }
            }
        }

        public void Create(IEntity entity)
        {
            if (entityWrappers.Any(x => x.Entity == entity))
            {
                throw new InvalidOperationException("The entity has already been registered. ");
            }

            var wrapper = new EntityWrapper(entity);

            wrapper.Initialize();

            entityWrappers.Add(wrapper);
        }

        public void Destroy(IEntity entity)
        {
            foreach (var i in entityWrappers)
            {
                if (i.Entity == entity)
                { 
                    entityWrappers.Remove(i);

                    i.Destroy();

                    return;
                }
            }

            //throw new InvalidOperationException("The entity has not been registered. ");
        }

        public void Dispose()
        {
            entityWrappers.Clear();
        }
    }
}
