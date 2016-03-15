using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Calculator.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(BundleValues.AppBasics)
                .Include("~/Scripts/jquery-1.9.1.js")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/bootstrap.js")
                );

            // Code removed for clarity.
            BundleTable.EnableOptimizations = true;
        }

        public class BundleValues
        {
            public const string AppBasics = "~/bundles/appbasics";
        }
    }
}