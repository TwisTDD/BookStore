using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;
namespace MvcBookStore.Controllers
{
    public class NguoidungController : Controller
    {
        dbQLbansachDataContext db = new dbQLbansachDataContext();
        //
        // GET: /Nguoidung/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection ,KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai= collection["Matkhaunhaplai"];
            var diachi = collection["DiachiKH"];
            var email= collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            var gioitinh = collection["Gioitinh"];
            if(String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi2"] = "Địa chỉ không được để trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi3"] = "Điện thoại khách hàng không được để trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi4"] = "Phải nhập tên đăng nhập";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi5"] = "Phải nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi6"] = "Phải nhập lại mật khẩu";
            }
            //if (String.IsNullOrEmpty(gioitinh))
            //{
            //    ViewData["Loi7"] = "Phải nhập giới tính";
            //}
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi8"] = "Phải nhập email";
            }
            else
            {
                kh.HoTenKH = hoten;
                kh.TenDN = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");

            }
            return this.Dangky();
        }


        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            { ViewData["Loi1"] = "Phải nhập tên đăng nhập"; }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TenDN == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index", "BookStore");
                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

	}
}