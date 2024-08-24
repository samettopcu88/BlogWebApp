using ENTITY.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleModel>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleModel>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleModel> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task CreateArticleAsync(ArticleAddModel ArticleAddModel);
        Task<string> UpdateArticleAsync(ArticleUpdateModel ArticleUpdateModel);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<ArticleListModel> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<ArticleListModel> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);
    }
}
