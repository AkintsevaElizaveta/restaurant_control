﻿using AutoMapper;
using RestaurantControl.Core.DataAccess.DbModels;
using RestaurantControl.Models.Auth;
using RestaurantControl.Models.Restaurant;

namespace RestaurantControl.Api.Mappers;

public class ApiToDomain : Profile
{
    public ApiToDomain()
    {
        CreateMapForUser();

        CreateMapForTable();
        CreateMapForWaiter();
        CreateMapForMenuCategory();
        CreateMapForMenuItem();
        CreateMapForOrder();
        CreateMapForOrderItem();
    }

    private void CreateMapForUser()
    {
        CreateMap<LoginDto, User>()
            .ForMember(
                dest => dest.Login,
                opt => opt.MapFrom(src => src.Login))
            .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password))
            .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(_ => DateTime.Now))
            .ForMember(
                dest => dest.ModifiedDate,
                opt => opt.MapFrom(_ => DateTime.Now));
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
            opt => opt.MapFrom(src => src.PositionY))
            .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(_ => DateTime.Now))
            .ForMember(
                dest => dest.ModifiedDate,
                opt => opt.MapFrom(_ => DateTime.Now));
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
                opt => opt.MapFrom(src => src.PhotoUrl))
            .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(_ => DateTime.Now))
            .ForMember(
                dest => dest.ModifiedDate,
                opt => opt.MapFrom(_ => DateTime.Now));
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
                dest => dest.TableId,
                opt => opt.MapFrom(src => src.TableId))
            .ForMember(
                dest => dest.WaiterId,
                opt => opt.MapFrom(src => src.WaiterId))
            .ForMember(
                dest => dest.IsClosed,
                opt => opt.MapFrom(src => src.IsClosed))
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems));
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
