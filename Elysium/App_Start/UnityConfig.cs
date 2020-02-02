namespace Elysium
{
    using Elysium.HelperInterfaces;
    using Elysium.Helpers;
    using Elysium.Manager.Interfaces;
    using Elysium.Manager.Members;
    using Elysium.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using System;
    using System.Data.Entity;
    using System.Web;
    using Unity;
    using Unity.Injection;

    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => System.Web.HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IEmployeeManager, EmployeeManager>();
            container.RegisterType<IEmployeeSettingsManager, EmployeeSettingsManager>();
            container.RegisterType<IEmployeeHistoryManager, EmployeeHistoryManager>();

            container.RegisterType<IEmployeeHelper, EmployeeHelper>();
            container.RegisterType<IEmployeeSettingsHelper, EmployeeSettingsHelper>();
            container.RegisterType<IEmployeeHistoryHelper, EmployeeHistoryHelper>();

            Elysium.Manager.UnityConfig.RegisterTypes(container);
        }
    }
}