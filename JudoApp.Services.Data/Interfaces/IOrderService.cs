namespace JudoApp.Services.Data.Interfaces
{
    using JudoApp.Web.ViewModels.Order;

    public interface IOrderService
    {
        Task<IEnumerable<OrderIndexViewModel>> IndexGetAllOrderedByNumberAsync();

        Task AddOrderAsync(AddOrderFormModel model);

        Task<EditOrderFormModel?> GetOrderForEditByIdAsync(Guid id);

        Task<bool> EditOrderAsync(EditOrderFormModel model);

        Task<DeleteOrderViewModel?> GetOrderForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteOrderAsync(Guid id);
    }
}
