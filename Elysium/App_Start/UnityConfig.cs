using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Elysium.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterTypes()
        {
            IUnityContainer container = new UnityContainer();
            //container.RegisterType<IEmployeeManager>
        }
    }
}