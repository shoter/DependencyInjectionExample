using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Die.Library.Services
{
    public static class DependencyService
    {

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            return container;
        });

        // It does not need to be ocnfigured
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        
        public static T Resolve<T>()
        {
            T ret = default(T);

            //Thing do not need to be registered to be resolved.
            if (container.Value.IsRegistered(typeof(T)))
            {
                ret = container.Value.Resolve<T>();
            }

            //I do not like returning nothing. We have Resolve not TryResolve method here.
            return ret;
        }

        public static object Resolve(Type type)
        {
            return container.Value.Resolve(type);
        }
    }
}
