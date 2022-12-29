using ChatApp.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChatApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        private static IServiceCollection servicesList;

        public static IServiceCollection AddServiceImplementation(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                List<TypeInfo> classTypes = assembly.ExportedTypes.Select(t => IntrospectionExtensions.GetTypeInfo(t)).Where(t => t.IsClass && !t.IsAbstract).ToList();

                foreach (var type in classTypes)
                {
                    if (type.GetInterface(typeof(IBaseChatApp).Name) != null)
                    {
                        var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                        foreach (var interfaceType in interfaces.Where(_ => _ != typeof(IBaseChatApp)))
                        {
                            if (services.Any(_ => _.ServiceType == interfaceType))
                            {
                                services.Remove(services.First(_ => _.ServiceType == interfaceType));
                            }
                            services.AddScoped(interfaceType.AsType(), type.AsType());
                        }
                    }
                }
            }

            servicesList = services;

            return services;
        }

        public static IServiceProvider Provider
        {
            get
            {
                return servicesList.BuildServiceProvider();
            }

            set { }
        }

    }
}
