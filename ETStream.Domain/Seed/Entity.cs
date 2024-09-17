using MediatR;

namespace ETStream.Domain.Seed
{
    public abstract class Entity {
        private Guid _id;
        private readonly List<INotification> _domainEvents;

        public virtual Guid Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        public List<INotification> DomainEvents => _domainEvents;

        public Entity(Guid? id = null)
        {
            _id = id ?? new Guid();
            _domainEvents = new List<INotification>();
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }
        
        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null)
                return;

            _domainEvents.Remove(eventItem);
        }
    }
}