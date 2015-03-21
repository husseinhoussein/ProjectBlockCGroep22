using System.Web;
using System.Web.Optimization;


namespace TheGreenery.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) 
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}