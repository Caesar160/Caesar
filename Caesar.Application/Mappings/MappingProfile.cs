namespace Caesar.Application.Mappings
{
    using AutoMapper;
    using Caesar.Application.Aggregates.Customers.Commands.SignUp;
    using Caesar.Application.Models;
    using Stripe;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<Product>, List<Item>>();
            CreateMap<SignUpCustomerCommand, CustomerCreateOptions>();
        }
    }
}

