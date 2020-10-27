using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ISinhVienRepository
    {
        Tb_SinhVien SinhVienGet(string TenSinhVien);
        Tb_SinhVien SinhVienGet_byID(int id);
        bool SinhVienCreate(Tb_SinhVien model);
        bool SinhVienUpdate(Tb_SinhVien model);
        bool SinhVienDelete(string id);
        List<Tb_SinhVien> SinhVienSearch(int pageIndex, int pageSize, out long total, string TenSinhVien, int SoDienThoai);
    }
}
