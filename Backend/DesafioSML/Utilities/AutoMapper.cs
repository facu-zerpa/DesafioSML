using AutoMapper;
using DesafioSML.Data;
using DesafioSML.Models.DTO;

namespace DesafioSML.Utilities
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerCreateDTO>();
        }
    }
}
