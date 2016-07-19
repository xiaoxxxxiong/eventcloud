﻿using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Modules;
using Abp.Web.Mvc;
using EventCloud.Api;
using EventCloud.Web.Navigation;

namespace EventCloud.Web
{
    [DependsOn(
        typeof(EventCloudDataModule), 
        typeof(EventCloudApplicationModule), 
        typeof(EventCloudWebApiModule),
        typeof(AbpWebMvcModule)
        )]
    public class EventCloudWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<EventCloudNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
