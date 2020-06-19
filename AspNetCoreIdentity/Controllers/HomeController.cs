using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //select* from[dbo].[AspNetUsers]
        //select* from[dbo].[AspNetRoles]
        //select* from[dbo].[AspNetUserRoles]
        //select* from[dbo].[AspNetRoleClaims]
        //todo = adicionar em @addTagHelper "*,AspNetCoreIdentity" no _ViewImports

        public IActionResult Privacy()
        {
            return View();
        }

       // [ClaimsAuthorize("Produto", "Visualizar")]
        public IActionResult Secret()
        {
            return View();
        }

 
       // [ClaimsAuthorize("Produto", "Excluir")]
        public IActionResult Vendedor()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
