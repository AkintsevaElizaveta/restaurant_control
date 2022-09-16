﻿using AutoMapper;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Api.Mappers;

public class ApiToDomain : Profile
{
    public ApiToDomain()
    {
        CreateMapForTable();
        CreateMapForWaiter();
        CreateMapForMenuCategory();
        CreateMapForMenuItem();
        CreateMapForOrder();
        CreateMapForOrderItem();
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

    private void CreateMapForWaiter()
    {
        CreateMap<WaiterDto, Waiter>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.PhotoUrl));
    }

    private void CreateMapForMenuCategory()
    {
        CreateMap<MenuCategoryDto, MenuCategory>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.MenuItems,
                opt => opt.MapFrom(src => src.MenuItems));
    }

    private void CreateMapForMenuItem()
    {
        CreateMap<MenuItemDto, MenuItem>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(
                dest => dest.MenuCategoryId,
                opt => opt.MapFrom(src => src.MenuCategoryId))
            .ForMember(
                dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.PhotoUrl));
    }

    private void CreateMapForOrder()
    {
        CreateMap<OrderDto, Order>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.IsClosed,
                opt => opt.MapFrom(src => src.IsClosed))
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(
                dest => dest.TableId,
                opt => opt.MapFrom(src => src.TableId))
            .ForMember(
                dest => dest.WaiterId,
                opt => opt.MapFrom(src => src.WaiterId));
    }

    private void CreateMapForOrderItem()
    {
        CreateMap<OrderItemDto, OrderItem>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.MenuItemId,
                opt => opt.MapFrom(src => src.MenuItemId))
            .ForMember(
                dest => dest.OrderId,
                opt => opt.MapFrom(src => src.OrderId));
    }
}
