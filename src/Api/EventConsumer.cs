using Domain.Interfaces;
using Infrastructure.Interfaces;

namespace Api
{
    public class EventConsumer<T> : BackgroundService
    {
        private readonly ISubscribe _subscribe;
        private readonly IEventHandler<T> _eventHandler;

        public EventConsumer(ISubscribe subscribe, IEventHandler<T> eventHandler)
        {
            _subscribe = subscribe;
            _eventHandler = eventHandler;
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken){
           return _subscribe.Subscribe<T>(_eventHandler.Execute, cancellationToken);
        }
      
    }
}
