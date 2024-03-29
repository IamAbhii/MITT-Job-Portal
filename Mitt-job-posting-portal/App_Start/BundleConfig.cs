﻿using System.Web.Optimization;

namespace Mitt_job_posting_portal
{
  public class BundleConfig
  {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

      //jqueryUI
      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
          "~/Scripts/jquery-ui-{version}.js"));
      //css  
      bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
             "~/Content/themes/base/jquery-ui.css"));

      //chosen
      bundles.Add(new StyleBundle("~/Content/chosen").Include(
             "~/Content/chosen/chosen.min.css"));

      bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
          "~/Scripts/chosen/chosen.jquery.min.js"));
    }
  }
}
