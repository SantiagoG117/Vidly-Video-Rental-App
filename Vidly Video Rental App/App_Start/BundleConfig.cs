﻿using System.Web;
using System.Web.Optimization;

namespace Vidly_Video_Rental_App
{
    /// <summary>
    /// Pre-define different bundles of client-side assets
    /// </summary>
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

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/scripts/datatables/jquery.datatables.js",
                      "~/scripts/datatables/datatables.bootstrap4.js",
                      "~/scripts/typeahead.bundle.js",
                      "~/scripts/toastr.js"));

            // Generic styles of the application
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/content/dataTables/css/dataTables.bootstrap4.css", //Makes data tables looks like bootstrap tables
                      "~/content/typeahead.css",
                      "~/content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
