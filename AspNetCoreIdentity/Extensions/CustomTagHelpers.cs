using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace AspNetCoreIdentity.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-role-type")]
    [HtmlTargetElement("*", Attributes = "supress-by-role-value")]
    public class ApagaElementoByRoleTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApagaElementoByRoleTagHelper(
            IHttpContextAccessor contextAccessor,
            RoleManager<IdentityRole> roleManager)
        {
            _contextAccessor = contextAccessor;
            _roleManager = roleManager;
        }

        [HtmlAttributeName("supress-by-role-type")]
        public string IdentityRoleClaimType { get; set; }

        [HtmlAttributeName("supress-by-role-value")]
        public string IdentityRoleClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarRolesUsuario(_contextAccessor.HttpContext, _roleManager, IdentityRoleClaimValue, IdentityRoleClaimType);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("a", Attributes = "disable-by-role-type")]
    [HtmlTargetElement("a", Attributes = "disable-by-role-value")]
    public class DesabilitaLinkByRoleTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DesabilitaLinkByRoleTagHelper(
            IHttpContextAccessor contextAccessor, 
            RoleManager<IdentityRole> roleManager)
        {
            _contextAccessor = contextAccessor;
            _roleManager = roleManager;
        }

        [HtmlAttributeName("disable-by-role-type")]
        public string IdentityRoleClaimType { get; set; }

        [HtmlAttributeName("disable-by-role-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarRolesUsuario(_contextAccessor.HttpContext, _roleManager, IdentityClaimValue, IdentityRoleClaimType);

            if (temAcesso) return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "Você não tem permissão"));
        }
    }

    [HtmlTargetElement("*", Attributes = "supress-by-action")]
    public class ApagaElementoByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByActionTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            //pega o nome da action dentro de um request
            var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActionName.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}