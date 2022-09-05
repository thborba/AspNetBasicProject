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
            System.Diagnostics.Debug.WriteLine("testetest");
           return _subscribe.Subscribe<T>(_eventHandler.Execute, cancellationToken);
        }
          

        //private Task OnEvent(T obj, CancellationToken cancellationToken)
        //{
        //    System.Diagnostics.Debug.WriteLine(obj?.ToString());
        //    return Task.CompletedTask;
    }
}
