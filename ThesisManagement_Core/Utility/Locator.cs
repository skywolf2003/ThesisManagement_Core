using System;
using System.Collections.Generic;

namespace ThesisManagement_Core.Utility
{
    public static class Locator
    {
        private readonly static Dictionary<Type, Func<object>>
            services = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> resolver)
        {
            Locator.services[typeof(T)] = () => resolver();
        }

        public static T Resolve<T>()
        {
            return (T)Locator.services[typeof(T)]();
        }

        public static void Reset()
        {
            Locator.services.Clear();
        }
    }
}
