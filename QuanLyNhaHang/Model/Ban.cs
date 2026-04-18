using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public enum TrangThaiBan
    {
        Trong,
        CoKhach,
        DatTruoc,
        Dong
    }

    public class Ban
    {
        public int Id { get; set; }
        public string SoBan { get; set; }
        public int SoCho { get; set; }
        public TrangThaiBan TrangThai { get; set; } = TrangThaiBan.Trong;

        public Ban() { }

        public Ban(int id, string soBan, int soCho, TrangThaiBan trangThai)
        {
            Id = id;
            SoBan = soBan;
            SoCho = soCho;
            TrangThai = trangThai;
        }

        public override string ToString() => $"Bàn {SoBan} ({TrangThai})";
    }
}