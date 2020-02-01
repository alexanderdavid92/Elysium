using Elysium.Data.Interfaces;
using Elysium.Data.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Elysium.Manager
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer GetConfiguredContainer() => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            Func<Type, LifetimeManager> lifetimeManager = t => new TransientLifetimeManager();

            RegisterTypes(container, lifetimeManager);
        }

        public static void RegisterTypes(IUnityContainer container, Func<Type,LifetimeManager> defaultLifetime)
        {
            container.RegisterType<IEmployeeData, EmployeeData>();
            container.RegisterType<IEmployeeSettingsData, EmployeeSettingsData>();
            container.RegisterType<IEmployeeHistoryData, EmployeeHistoryData>();
        }
    }
}
