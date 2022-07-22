using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BrianTech008Api.Features
{
    
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
     
    }
}
