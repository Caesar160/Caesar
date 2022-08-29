﻿namespace Caesar.Application.Mappings
{
    using System.Reflection;
    using Aggregates.Customers.Commands.SignUp;
    using AutoMapper;
    using Stripe;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, CustomerCreateOptions>();
            CreateMap<CreateCustomerCommand, CustomerCreateOptions>();
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                .ToList();

            foreach (var type in types)
            {
                if (type.IsAbstract)
                {
                    continue;
                }

                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

