using ENTITY.Entities;
using ENTITY.Models.Categories;

namespace SERVICE.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesNonDeleted();
        Task<List<CategoryModel>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryModel>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddModel categoryAddDto);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateModel categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
    }
}
