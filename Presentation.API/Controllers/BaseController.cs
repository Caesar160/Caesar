namespace Caesar.Presentation.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private ISender _mediator;
    protected ISender Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<ISender>();
}
