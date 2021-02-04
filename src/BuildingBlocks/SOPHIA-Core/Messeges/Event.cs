using System;
using MediatR;
using SOPHIA_Core.Messeges;

namespace SOPHIA_Core.Mediator
{
    public class Event : Messege, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}