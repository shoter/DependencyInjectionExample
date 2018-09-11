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

        /// <summary>
        /// The unity container
        /// </summary>
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container
        /// </summary>
        /// <returns>An IUnityContainer</returns>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
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
