﻿using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using TestTemplate15.Core.Events;

namespace TestTemplate15.WorkerServices.FooService
{
    public class FooConsumer(ILogger<FooConsumer> Logger) : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context)
        {
            Logger.LogInformation("Talking from FooConsumer.");
            return Task.CompletedTask;
        }
    }
}
