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
        [Route("[controller]/[action]")]
        public IActionResult GetbyId(int id)
        {
            var magazines = _context.Magazines.FirstOrDefault(x => x.Id == id);
            var timeEnd = _context.Semesters.FirstOrDefault(x => x.Id == magazines.SemesterId);
            ViewBag.Magazines = magazines;
            ViewBag.TimeStart = magazines.ClosureDate.ToString("yyyy/MM/dd");
            ViewBag.TimeEnd = timeEnd.FinalClosureDate.ToString("yyyy/MM/dd");
            var daynow = DateTime.UtcNow.Date;

            int year = int.Parse(ViewBag.TimeEnd.Split("/")[0]);
            var month = int.Parse(ViewBag.TimeEnd.Split("/")[1]);
            var day = int.Parse(ViewBag.TimeEnd.Split("/")[2]);
            DateTime dayEnd = new DateTime(year, month, day);
            ViewBag.Deadline = DateTime.Compare(daynow, dayEnd);

            var check = _context.Articles.FirstOrDefault(x => x.MagazineId == magazines.Id);
            if(check!= null && check.Status == "Submit")
            {
                var map = new ArticleViewModel();
                map.Id = check.Id;  
                map.UserId = check.UserId;
                map.Name = check.Name;
                map.Description = check.Description;
                map.Status = check.Status;
                map.MagazineId = magazines.Id;
                map.TimeEnd = timeEnd.FinalClosureDate.ToString("yyyy/MM/dd");
                map.TimeStart  = magazines.ClosureDate.ToString("yyyy/MM/dd");
                map.TimeSubmit = check.SubmitDate.ToString("yyyy/MM/dd");
                return RedirectToAction("SubmitArticle","ArticleModel", map);
            }
            else
            {
                return View();
            }
          
        }
        [Route("Identity/[controller]/[action]")]
        public IActionResult CreateArticle(int id)
        {
            var magazines = _context.Magazines.FirstOrDefault(x => x.Id == id);

            ViewBag.Magazines = magazines;
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
            input.Status = "Submit";
            _context.Articles.Add(input);
            await _context.SaveChangesAsync();
            var lastArticle = _context.Articles.ToList().Last();
            var document = new DocumentModel();
            document.File = "test";
            document.Image = "test";
            document.ArticleId = lastArticle.Id;
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return RedirectToAction("SubmitArticle", "ArticleModel", input);
        }
        [Route("[controller]/[action]")]
        public IActionResult SubmitArticle(ArticleViewModel input)
        {
            var file = _context.Documents.FirstOrDefault(x => x.ArticleId == input.Id);
            ViewBag.Articles = input;
            ViewBag.File = file;
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult Edit(int id)
        {
            var data = _context.Articles.FirstOrDefault(x => x.Id == id);
            var model = new Models.ArticleModel();
            model = data;
            var file = _context.Documents.FirstOrDefault(x => x.ArticleId == id);
            ViewBag.File = file;
            return View("Edit",model);
        }
        [Route("[controller]/[action]")]
        public async Task<IActionResult> EditData(Models.ArticleModel input)
        {
            var data = _context.Articles.FirstOrDefault(x => x.Id == input.Id);
            data.Name = input.Name;
            data.Description = input.Description;
            _context.Articles.Update(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("SubmitArticle", "ArticleModel", data);
        }
        [Route("[controller]/[action]")]
        public async Task<IActionResult> DeleteView(int id)
        {
            var data = _context.Articles.FirstOrDefault(x => x.Id == id);
            var file = _context.Documents.FirstOrDefault(i => i.ArticleId == data.Id);
            _context.Documents.Remove(file);
            await _context.SaveChangesAsync();
            _context.Articles.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction( "Index" ,"Magazines");
        }
    }
}
