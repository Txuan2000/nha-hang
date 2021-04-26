using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace QLNhaHang
{
    class Utilities
    {
        SqlConnection con;
        public Utilities()
        {
           string constr = @"Data Source=DESKTOP-DHL2NL5\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=true";
            con = new SqlConnection(constr);
        }
        //Lay du lieu ra bang
        public DataTable hienthiHD()
        {
            DataTable table = new DataTable();
            string sql = "select hoadon.mahoadon,ngaylap,tennhanvien,tenkhachhang,sum(soluong*Gia) as 'tien' " +
                "from hoadon,KhachHang,NhanVien,ChiTietHoaDon,MonAn " +
                "where HoaDon.MaHoaDon=ChiTietHoaDon.MaHoaDon " +
                "and ChiTietHoaDon.MaMonAn=MonAn.MaMonAn " +
                "and hoadon.makhachhang=khachhang.makhachhang " +
                "and hoadon.manhanvien=nhanvien.manhanvien " +
                "group by HoaDon.MaHoaDon,ngaylap,tennhanvien,tenkhachhang ";
            SqlDataAdapter adap = new SqlDataAdapter(sql,con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //lay du lieu chi tiet hoa don
        public DataTable hienthichitietHD(string mahd)
        {
            con.Open();
            DataTable table = new DataTable();
            
            string sql = "select mamenu,tenmonan,soluong from chitiethoadon "
                +"inner join monan on monan.mamonan=chitiethoadon.mamonan " +
                "where mahoadon='"+mahd+"'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("mahd", mahd);
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //lay du lieu chi tiet mon an

        //lay du lieu ban an
        public DataTable danhsachban()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from banan";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
    }
}
