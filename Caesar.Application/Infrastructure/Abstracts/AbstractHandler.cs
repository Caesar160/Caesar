namespace Caesar.Application.Infrastructure.Abstracts;

using AutoMapper;
using Interfaces;
using MediatR;

public abstract class AbstractHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly ICurrentUserService _currentUserService;
    protected readonly ICaesarDbContext _dbContext;
    protected readonly IMapper _mapper;

    protected AbstractHandler(ICaesarDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
    {
        this._dbContext = dbContext;
        this._mapper = mapper;
        this._currentUserService = currentUserService;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
