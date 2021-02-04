using System;

namespace SOPHIA_Core.Messeges
{
    public abstract  class Messege
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        public Messege()
        {
            MessageType = GetType().Name;
        }
    }
}
