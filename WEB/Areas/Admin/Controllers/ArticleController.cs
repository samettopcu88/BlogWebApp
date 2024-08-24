using AutoMapper;
using ENTITY.Entities;
using ENTITY.Models.Articles;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SERVICE.Extensions;
using SERVICE.Services.Abstractions;
using WEB.Const;
using WEB.ResultMessages;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedArticle()
        {
            var articles = await articleService.GetAllArticlesWithCategoryDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddModel { Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add(ArticleAddModel articleAddModel)
        {
            var map = mapper.Map<Article>(articleAddModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddModel);
                toast.AddSuccessToastMessage(Messages.Article.Add(articleAddModel.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddModel { Categories = categories });


        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateModel = mapper.Map<ArticleUpdateModel>(article);
            articleUpdateModel.Categories = categories;

            return View(articleUpdateModel);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(ArticleUpdateModel articleUpdateModel)
        {

            var map = mapper.Map<Article>(articleUpdateModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateModel);
                toast.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var categories = await categoryService.GetAllCategoriesNonDeleted();
            articleUpdateModel.Categories = categories;
            return View(articleUpdateModel);
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });


            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });


            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
