using Microsoft.AspNetCore.Mvc;
using WebEnterprise_1640.Data;
using WebEnterprise_1640.Models;

namespace WebEnterprise_1640.Areas.Identity.Pages.Magazines
{
    [Area("Identity")]
    public class MagazinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MagazinesController(ApplicationDbContext context)

        {
            _context = context;
        }
        [Route("[controller]")]
        public IActionResult Index()
        {
            ViewBag.Manazines = _context.Magazines.Where(x => x.SemesterId == 2 || x.SemesterId == 1).ToList();
            ViewBag.Manazine2 = _context.Magazines.Where(x => x.SemesterId == 3).ToList();
            var semesters = _context.Semesters.ToList();
            var map = new List<SemesterModelView>();
            semesters.ForEach(i => {
                var obj = new SemesterModelView();
                obj.Id = i.Id;
                obj.FinalClosureDate = i.FinalClosureDate.ToString("yyyy/MM/dd");
                map.Add(obj);
            });
            ViewBag.Semeter = map;
            return View();
        }
    }
}
