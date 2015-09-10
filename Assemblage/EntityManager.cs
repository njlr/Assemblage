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

        public T Create<T>(T entity) where T : IEntity
        {
            if (entityWrappers.Any(x => x.Equals(entity)))
            {
                throw new InvalidOperationException("The entity has already been registered. ");
            }

            var wrapper = new EntityWrapper(entity);

            entityWrappers.Add(wrapper);

            wrapper.Initialize();

            return entity;
        }

        public T Destroy<T>(T entity) where T : IEntity
        {
            foreach (var i in entityWrappers)
            {
                if (i.Entity.Equals(entity))
                { 
                    entityWrappers.Remove(i);

                    i.Destroy();

                    return entity;
                }
            }

            throw new InvalidOperationException("The entity has not been registered. ");
        }

        public void Destroy()
        {
            foreach (var i in entityWrappers)
            {
                i.Destroy();
            }

            entityWrappers.Clear();
        }

        public void Dispose()
        {
            entityWrappers.Clear();
        }
    }
}
