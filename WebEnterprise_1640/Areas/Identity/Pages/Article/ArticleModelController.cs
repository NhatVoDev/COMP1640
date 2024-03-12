using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using WebEnterprise_1640.Data;
using WebEnterprise_1640.Models;


namespace WebEnterprise_1640.Areas.Identity.Pages.ArticleModel
{
    [Area("Identity")]
    public class ArticleModelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ArticleModelController(ApplicationDbContext context)

        {
            _context = context;
        }
        [Route("Identity/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Identity/[controller]/[action]")]
        public IActionResult CreateArticle()
        {
            return View();
        }
        public string CreateCookie(string cookieValue)
        {
            HttpContext.Response.Cookies.Append("user_id", "1");

            var userId = "";

            userId = HttpContext.Request.Cookies["user_id"];

            if (userId != null)
            {
                return userId;
            }
            else
            {
                return null;
            }
        }
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Create(Models.ArticleModel input)
        {
            var userId = CreateCookie("1");

            input.UserId = "1";
            input.Status = "true";
            //var document = new DocumentModel();
            //document.Id = input.Id;
            //document.Image = "dsadasd";
            //document.File = "sadasd";
            //input.Magazine = new MagazineModel();
            //input.Documents.Add(document);
            input.MagazineId = 8;
            _context.Articles.Add(input);
           await _context.SaveChangesAsync();

            return RedirectToAction("CreateArticle","ArticleMode");
        }
        public void CreateDocument(string cookieValue)
        {

        }
    }
}
