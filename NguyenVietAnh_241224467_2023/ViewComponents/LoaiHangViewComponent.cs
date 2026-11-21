using Microsoft.AspNetCore.Mvc;
using NguyenVietAnh_241224467_2023.Models;
namespace NguyenVietAnh_241224467_2023.ViewComponents
{
    public class LoaiHangViewComponent: ViewComponent
    {
        private readonly QlhangHoaContext db;
        public LoaiHangViewComponent(QlhangHoaContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = db.LoaiHangs.ToList();
            return View("RenderLoaiHang", loaiHangs);
        }
    }
}
