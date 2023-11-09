using AutoMapper;
using SCbank.Core.Entities;
using SCbank.Pl.Models;

namespace SCbank.Pl.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeViewModel>().ReverseMap();
        }
    }
}
