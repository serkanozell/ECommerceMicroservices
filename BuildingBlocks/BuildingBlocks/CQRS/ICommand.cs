﻿namespace BuildingBlocks.CQRS
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}