using Domain.EventHandlers.Events;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EventHandlers
{
    public class FileLineHandler : IEventHandler<FileLineEvent>
    {

        public Task Execute(FileLineEvent fileLineEvent, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine($"FileName: {fileLineEvent.FileName} | File Content: {fileLineEvent.Content}");
            return Task.CompletedTask;
        }
    }
}
