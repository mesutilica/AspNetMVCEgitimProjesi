using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.ApiKullanimi
{
    public class ApiKullanimiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ApiKullanimi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ApiKullanimi_default",
                "ApiKullanimi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}