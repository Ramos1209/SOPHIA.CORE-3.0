using System;
using MediatR;

namespace SOPHIA_Core.Messeges
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