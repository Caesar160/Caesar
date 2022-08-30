﻿namespace Caesar.Application.Mappings;

using System.Reflection;
using Aggregates.Customers.Commands.CreateCustomer;
using Aggregates.Customers.Commands.UpdateCustomer;
using AutoMapper;
using Domain.Entities;
using Stripe;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        this.CreateMap<CreateCustomerCommand, Customer>();
        this.CreateMap<Customer, CustomerCreateOptions>();
        this.CreateMap<CreateCustomerCommand, CustomerCreateOptions>();
        this.CreateMap<CreateCustomerCommand, User>();
        this.CreateMap<User, CreateCustomerCommand>();
        this.CreateMap<UpdateCustomerCommand, User>();
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) ||
                                    i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
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

            methodInfo?.Invoke(instance, new object[] {this});
        }
    }
}
