using ENTITY.Entities;
using ENTITY.Models.Categories;
using Microsoft.AspNetCore.Http;

namespace ENTITY.Models.Articles
{
    public class ArticleUpdateModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }

        public IList<CategoryModel> Categories { get; set; }
    }
}
