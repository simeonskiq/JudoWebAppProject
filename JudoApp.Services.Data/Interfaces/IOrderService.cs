namespace JudoApp.Services.Data.Interfaces
{
    using JudoApp.Data.Models;
    using JudoApp.Web.ViewModels.Order;

    public interface IOrderService
    {
        Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrderedByNumberAsync();

        Task<IEnumerable<OrderIndexViewModel>> GetOrdersByUserIdAsync(Guid userId);

        Task AddOrderAsync(AddOrderFormModel model, Guid userId, List<CartItem> cartItems);

        Task<EditOrderFormModel?> GetOrderForEditByIdAsync(Guid id);

        Task<bool> EditOrderAsync(EditOrderFormModel model);

        Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteOrderAsync(Guid id);
    }
}
