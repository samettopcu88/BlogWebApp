using ENTITY.Models.Cetegories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Models.Articles
{
    public class ArticleAddModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public IFormFile Photo { get; set; }

        public IList<CategoryModel> Categories { get; set; }
    }
}
