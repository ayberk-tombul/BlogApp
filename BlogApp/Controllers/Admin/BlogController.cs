using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers.Admin
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext context;

        public BlogController(BlogDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index(BlogSearchModel model)
        {
            ViewBag.Active = "Blog";



            //if(model.CreatedDate == DateTime.MinValue && string.IsNullOrWhiteSpace(model.Title))
            //{
            //    return View();
            //}

            var query = this.context.Blogs.AsQueryable();


            if (model.CreatedDate != DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedDate.Date == model.CreatedDate);
            }

            if (!string.IsNullOrWhiteSpace(model.Title))
            {

                query = query.Where(x => x.Title.Contains(model.Title));
            }


            ViewBag.PageModel = new PageModel
            {
                ActivePage = model.ActivePage,

                PageCount = (int)Math.Ceiling((decimal)(query.Count()) / model.PageSize),
            };


            var blogs = query.Skip((model.ActivePage -1)*model.PageSize).Take(model.PageSize).ToList();

            /* 5 kayıtı nsıl geçiyor
             * Acaba ilk kayıdı hiç okumadan 2.Sayfa için 5 kayıt mı seçiyor
             * ilk 5 kaydıda mı okuyor mu ?
             
             */

            return View(blogs);
        }
    }
}
