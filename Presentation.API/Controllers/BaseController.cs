using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.Presentation.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private ISender mediator;
        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>();
    }
}
