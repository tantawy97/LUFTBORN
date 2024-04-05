using Application.BussinessLogic.Items.Command.Add;
using Application.BussinessLogic.Items.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.BussinessLogic.Items.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<AddCommand, Item>();
        }


    }
}
