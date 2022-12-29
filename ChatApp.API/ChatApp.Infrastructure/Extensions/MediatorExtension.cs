using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace ChatApp.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static IServiceCollection AddMediatorHandler(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => IntrospectionExtensions.GetTypeInfo(t)).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType
                    && (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)
                    || i.GetGenericTypeDefinition() == typeof(IRequestHandler<>))))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }

            }
            return services;
        }


    }
}
