using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebEnterprise_1640.Data;
using WebEnterprise_1640.Models;

namespace WebEnterprise_1640.Areas.Identity.Pages.Magazines
{
    //Phần Khoa
    [Area("Identity")]
    public class MagazinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MagazinesController(ApplicationDbContext context)

        {
            _context = context;
        }
        [Route("[controller]")]
        public IActionResult Index(search search)
        {

            var manazines = new List<MagazineModel>();
            if (search.searchKey != null)
            {
                 manazines = _context.Magazines.Where(x => x.Name.Contains(search.searchKey)).ToList();
            }
            else
            {
                 manazines = _context.Magazines.ToList();
            }
            var semesters = _context.Semesters.ToList();
            var map = new List<SemesterModelView>();
            var manazines2 = new List<MagazineModel>();
            var manazines3 = new List<MagazineModel>();
            semesters.ForEach(i =>
            {
                var obj = new SemesterModelView();
                obj.Id = i.Id;
                obj.FinalClosureDate = i.FinalClosureDate.ToString("yyyy/MM/dd HH:mm");
                map.Add(obj);
            });
            manazines.ForEach(i =>
            {
                semesters.ForEach(e =>
                {
                    if (i.SemesterId == e.Id)
                    {
                        if(e.FinalClosureDate > DateTime.Now)
                        {
                            manazines2.Add(i);
                        }
                        else
                        {
                            manazines3.Add(i);
                        }
                    }
                });
            });
            ViewBag.Semeter = map;

            ViewBag.Manazines = manazines2;
            ViewBag.Manazine2 = manazines3;

            return View();
        }
    }
}
