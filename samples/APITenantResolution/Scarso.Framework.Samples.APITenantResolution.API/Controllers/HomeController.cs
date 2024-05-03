using Microsoft.AspNetCore.Mvc;
using Scarso.Framework.Domain.MultiTenancy.Services;

namespace Scarso.Framework.Samples.APITenantResolution.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(ICurrentTenant currentTenant) : ControllerBase
{
    private readonly ICurrentTenant _currentTenant = currentTenant;

    [HttpGet(Name = "GetCurrentTenant")]
    public IActionResult Get()
    {
        if (!_currentTenant.HasValue)
            return NotFound();

        return new JsonResult(new
        {
            TenantId = _currentTenant.Value!.Id,
            TenantSubDomain = _currentTenant.Value.SubDomain,
        });
    }
}
