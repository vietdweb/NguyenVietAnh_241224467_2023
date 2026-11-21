using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenVietAnh_241224467_2023.Models;
using System.Diagnostics;

namespace NguyenVietAnh_241224467_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext db;
        public HomeController(QlhangHoaContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var hangHoas = db.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(hangHoas);
        }
        public IActionResult HangHoaTheoLoai(int maloai)
        {
            var hangHoas = db.HangHoas.Where(h => h.MaLoai == maloai).ToList();
            return PartialView("HangHoaTheoLoai", hangHoas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
