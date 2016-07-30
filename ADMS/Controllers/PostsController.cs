using ADMS.Common;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Managers;
using ADMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADMS.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {

        private IPostManager _postManager;
        private ICategoryManager _categoryManager;

        public PostsController(IPostManager postManager, ICategoryManager categoryManager)
        {
            _postManager = postManager;
            _categoryManager = categoryManager;
        }

        // GET: Posts
        public ActionResult Index()
        {

            var posts = _postManager.GetAll()
                                      .OrderByDescending(x => x.PostedAt)
                                      .Select(item => new PostViewModel
                                      {
                                          PostId = item.PostId,
                                          Title = item.Title,
                                          Description = item.Description,
                                          ExpirationDate = item.ExpirationDate,
                                          PostedAt = item.PostedAt,
                                          PostedBy = item.PostedBy,
                                          UserName = item.AspNetUsers.FirstName + " " + item.AspNetUsers.LastName,
                                          Uploads = item.Upload.ToList()
                                      });                                     
            

            PostListViewModel postListmodel = new PostListViewModel();
            postListmodel.CurrentUser = Guid.Parse(GetUserFromUserName(User.Identity.Name).Id);
            postListmodel.Posts = posts;

            return View(postListmodel);
        }

        // GET: Create Post
        public ActionResult Create()
        {
            var postViewModel = new PostViewModel();

            postViewModel.Categories = _categoryManager.GetAllParentCategories();

            return View(postViewModel);
        }

        // Post: Create Post
        [HttpPost]
        public ActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {

                var user = GetUserFromUserName(User.Identity.Name).Id;

                var entity = new Post
                {
                    PostId = Guid.NewGuid(),
                    Title = post.Title,
                    Description = post.Description,
                    ExpirationDate = post.ExpirationDate,
                    PostedAt = DateTime.Now,
                    PostedBy = user,
                    CategoryId = post.CategoryId
                };

                _postManager.SavePost(entity);
            }

            post.Categories = _categoryManager.GetAllParentCategories();

            return JsonResultHelper.CreateJsonResult(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string> ("Result","OK")
            });
        }

        // GET: Edit Post
        public ActionResult Edit(Guid id)
        {
            var entity = _postManager.GetByID(id);
            var post = new PostViewModel
            {
                PostId = entity.PostId,
                Title = entity.Title,
                Description = entity.Description,
                ExpirationDate = entity.ExpirationDate
            };
            return View(post);
        }

        // Post: Create Post
        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var entity = _postManager.GetByID(post.PostId);

                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.ExpirationDate = post.ExpirationDate;

                _postManager.UpdatePost(entity);

                return RedirectToAction("Index");
            }

            return View(post);
        }

        
        public ActionResult Delete(Guid id)
        {
            _postManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}