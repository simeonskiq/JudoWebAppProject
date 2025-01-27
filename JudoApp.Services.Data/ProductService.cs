namespace JudoApp.Services.Data
{
    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    public class ProductService : BaseService, IProductService
    {
        private readonly IRepository<Product, Guid> productRepository;

        public ProductService(IRepository<Product, Guid> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductIndexViewModel>> IndexGetAllOrderedByNameAsync()
        {
            IEnumerable<ProductIndexViewModel> products = await this.productRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .OrderBy(a => a.Name)
                .To<ProductIndexViewModel>()
                .ToArrayAsync();

            return products;
        }

        public async Task AddProductAsync(AddProductFormModel model)
        {
            Product product = new Product();
            AutoMapperConfig.MapperInstance.Map(model, product);

            await this.productRepository.AddAsync(product);
        }

        public async Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(Guid id)
        {
            Product? product = await this.productRepository
              .GetAllAttached()
              .Where(a => a.IsDeleted == false)
              .FirstOrDefaultAsync(a => a.Id == id);

            ProductDetailsViewModel? viewModel = null;
            if (product != null)
            {
                viewModel = new ProductDetailsViewModel()
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                };
            }

            return viewModel;
        }

        public async Task<EditProductFormModel?> GetProductForEditByIdAsync(Guid id)
        {
            EditProductFormModel? productModel = await this.productRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<EditProductFormModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return productModel;
        }

        public async Task<bool> EditProductAsync(EditProductFormModel model)
        {
            Product productEntity = AutoMapperConfig.MapperInstance
                .Map<EditProductFormModel, Product>(model);

            bool result = await this.productRepository.UpdateAsync(productEntity);

            return result;
        }

        public async Task<DeleteProductViewModel?> GetProductForDeleteByIdAsync(Guid id)
        {
            DeleteProductViewModel? productToDelete = await this.productRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<DeleteProductViewModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return productToDelete;
        }

        public async Task<bool> SoftDeleteProductAsync(Guid id)
        {
            Product? productToDelete = await this.productRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (productToDelete == null)
            {
                return false;
            }

            productToDelete.IsDeleted = true;
            return await this.productRepository.UpdateAsync(productToDelete);
        }
    }
}