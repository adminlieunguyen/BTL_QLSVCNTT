using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ItemRepository : IItemRepository
    {
        private IDatabaseHelper _dbHelper;
        public ItemRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool SinhVienCreate(Tb_SinhVien model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Tb_SinhVien_create",
                "@MaSinhVien    ", model.MaSinhVien,
                "@TenSinhVien 	", model.TenSinhVien,
                "@NgaySinh		", model.NgaySinh,
                "@GioiTinh		", model.GioiTinh,
                "@NoiSinh		", model.NoiSinh,
                "@QueQuan		", model.QueQuan,
                "@QuocTich		", model.QuocTich,
                "@DanToc		", model.DanToc,
                "@TonGiao		", model.TonGiao,
                "@NoiThuongTru	", model.NoiThuongTru,
                "@DoiTuongTroCap", model.DoiTuongTroCap,
                "@SoDienThoai	", model.SoDienThoai,
                "@Email			", model.Email,
                "@CMTND			", model.CMTND,
                "@DiaChiBaoTin	", model.DiaChiBaoTin,
                "@DiaChiTamTru	", model.DiaChiTamTru,
                "@TinhTrang		", model.TinhTrang,
                "@SV_MaLop		", model.SV_MaLop,
                "@Image         ", model.Image);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tb_SinhVien> GetSinhVien_All()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Tb_SinhVien_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tb_SinhVien>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tb_SinhVien SinhVienGet_byID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Tb_SinhVien_get_by_id",
                     "@MaSinhVien", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tb_SinhVien>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tb_SinhVien SinhVienGet(string HoTen)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[Tb_SinhVien_get_by_hoten]",
                     "@TenSinhVien", HoTen);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Tb_SinhVien>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SinhVienUpdate(Tb_SinhVien model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[Tb_SinhVien_update]",
                "@MaSinhVien    ", model.MaSinhVien,
                "@TenSinhVien 	", model.TenSinhVien,
                "@NgaySinh		", model.NgaySinh,
                "@GioiTinh		", model.GioiTinh,
                "@NoiSinh		", model.NoiSinh,
                "@QueQuan		", model.QueQuan,
                "@QuocTich		", model.QuocTich,
                "@DanToc		", model.DanToc,
                "@TonGiao		", model.TonGiao,
                "@NoiThuongTru	", model.NoiThuongTru,
                "@DoiTuongTroCap", model.DoiTuongTroCap,
                "@SoDienThoai	", model.SoDienThoai,
                "@Email			", model.Email,
                "@CMTND			", model.CMTND,
                "@DiaChiBaoTin	", model.DiaChiBaoTin,
                "@DiaChiTamTru	", model.DiaChiTamTru,
                "@TinhTrang		", model.TinhTrang,
                "@SV_MaLop		", model.SV_MaLop,
                "@Image         ", model.Image);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SinhVienDelete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[Tb_SinhVien_delete]",
                "@MaSinhVien", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tb_SinhVien> SinhVienSearch(int pageIndex, int pageSize, out long total, string TenSinhVien, int SoDienThoai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenSinhVien", TenSinhVien,
                    "@SoDienThoai", SoDienThoai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Tb_SinhVien>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
