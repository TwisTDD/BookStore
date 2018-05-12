using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBookStore.Models;
namespace MvcBookStore.Models
{
    public class GioHang
    {
        dbQLbansachDataContext data = new dbQLbansachDataContext();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public Double dDondia { get; set; }
        public int iSoLuong { get; set; }
        public Double dThanhTien 
        {
            get { return iSoLuong * dDondia; }

        }
    public GioHang(int Masach)
        {
            iMaSach = Masach;
            SACH sach = data.SACHes.Single(n => n.Masach == iMaSach);
            sTenSach = sach.Tensach;
            sAnhBia = sach.Hinhminhhoa;
            dDondia = double.Parse(sach.Dongia.ToString());
            iSoLuong = 1;
        }
    }
}