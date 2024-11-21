using FluentValidation.Results;
using NetDevPack.Messaging;


namespace LuminoERP.Core.Mediator
{
    public interface IMediatorHandler
    {
        //e stands for Event
        Task PublishEvent<T>(T e) where T : Event;
        Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
    }
}
