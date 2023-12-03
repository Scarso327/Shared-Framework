using Microsoft.AspNetCore.Mvc;
using Scarso.Framework.Domain.MultiTenancy.Services;

namespace Scarso.Framework.Samples.APITenantResolution.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(ICurrentTenant currentTenant) : ControllerBase
{
    private readonly ICurrentTenant _currentTenant = currentTenant;

    [HttpGet(Name = "GetCurrentTeannt")]
    public IActionResult Get()
    {
        if (_currentTenant.Tenant is null)
            return NotFound();

        return new JsonResult(new
        {
            TenantId = _currentTenant.Tenant.Id,
            TenantSubDomain = _currentTenant.Tenant.SubDomain,
        });
    }
}
