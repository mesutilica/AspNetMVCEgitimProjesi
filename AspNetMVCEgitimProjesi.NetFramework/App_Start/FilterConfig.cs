using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // web.config de system.web altına <customErrors mode="On"></customErrors> ekleyerek global hata yakalamayı etkinleştirebiliriz.
        }
    }
}
