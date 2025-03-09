﻿namespace JudoApp.Services.Data
{

    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Order;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : BaseService, IOrderService
    {
        private readonly IRepository<Order, Guid> orderRepository;

        public OrderService(IRepository<Order, Guid> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrderedByNumberAsync()
        {
            IEnumerable<OrderIndexViewModel> orders = await this.orderRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .OrderBy(a => a.OrderNumber)
                .To<OrderIndexViewModel>()
                .ToArrayAsync();

            return orders;
        }

        public async Task AddOrderAsync(AddOrderFormModel model)
        {
            Order orders = new Order();
            AutoMapperConfig.MapperInstance.Map(model, orders);

            await this.orderRepository.AddAsync(orders);
        }

        public async Task<EditOrderFormModel?> GetOrderForEditByIdAsync(Guid id)
        {
            EditOrderFormModel? orderModel = await this.orderRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<EditOrderFormModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return orderModel;
        }

        public async Task<bool> EditOrderAsync(EditOrderFormModel model)
        {
            Order orderEntity = AutoMapperConfig.MapperInstance
                .Map<EditOrderFormModel, Order>(model);

            bool result = await this.orderRepository.UpdateAsync(orderEntity);

            return result;
        }

        public async Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id)
        {
            DeleteOrderViewModel? orderToDelete = await this.orderRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<DeleteOrderViewModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return orderToDelete;
        }

        public async Task<bool> SoftDeleteOrderAsync(Guid id)
        {
            Order? orderToDelete = await this.orderRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (orderToDelete == null)
            {
                return false;
            }

            orderToDelete.IsDeleted = true;
            return await this.orderRepository.UpdateAsync(orderToDelete);
        }
    }
}