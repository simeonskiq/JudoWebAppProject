using JudoApp.Web.ViewModels.Product;

namespace JudoApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> IndexGetAllOrderedByNameAsync();

        Task AddProductAsync(AddProductFormModel model);

        Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(Guid id);

        Task<EditProductFormModel?> GetProductForEditByIdAsync(Guid id);

        Task<bool> EditProductAsync(EditProductFormModel model);

        Task<DeleteProductViewModel?> GetProductForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteProductAsync(Guid id);
    }
}
