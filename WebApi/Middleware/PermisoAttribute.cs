using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class PermisoAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _permiso;

    public PermisoAttribute(string permiso)
    {
        _permiso = permiso;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var usuario = context.HttpContext.User;

        if (!usuario.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var tienePermiso = usuario.Claims.Any(c => c.Type == "Permiso" && c.Value == _permiso);

        if (!tienePermiso)
        {
            context.Result = new ForbidResult(); // Error 403
        }
    }
}
