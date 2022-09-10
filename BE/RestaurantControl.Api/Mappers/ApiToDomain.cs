﻿using AutoMapper;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Api.Mappers;

public class ApiToDomain : Profile
{
    public ApiToDomain()
    {
        CreateMapForTable();
    }

    private void CreateMapForTable()
    {
        CreateMap<TableDto, Table>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Number,
                opt => opt.MapFrom(src => src.Number))
            .ForMember(
                dest => dest.WaiterId,
                opt => opt.MapFrom(src => src.WaiterId))
            .ForMember(
                dest => dest.OrderId,
                opt => opt.MapFrom(src => src.OrderId))
            .ForMember(
                dest => dest.PositionX,
                opt => opt.MapFrom(src => src.PositionX))
            .ForMember(
            dest => dest.PositionY,
            opt => opt.MapFrom(src => src.PositionY));
    }
}