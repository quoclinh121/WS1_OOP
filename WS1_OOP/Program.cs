using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WS1_OOP
{

    class SinhVien
    {
        private string mMaSV;
        private string HoTen;
        private DateTime NgaySinh;
        private string DiaChi;
        private string DienThoai;

        public SinhVien()
        {
        }

        public SinhVien(string mMaSV, string hoTen, DateTime ngaySinh, string diaChi, string dienThoai)
        {
            this.mMaSV = mMaSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            DienThoai = dienThoai;
        }

        public string MMaSV { get => mMaSV; set => mMaSV = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string DienThoai1 { get => DienThoai; set => DienThoai = value; }

        public void XemThongTin()
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Ma so sinh vien: " + mMaSV);
            Console.WriteLine("Ho va ten: " + HoTen);
            Console.WriteLine("Ngay sinh: " + NgaySinh.ToShortDateString());
            Console.WriteLine("Dia chi: " + DiaChi);
            Console.WriteLine("Dien thoai: " + DienThoai);
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> danhSachSinhVien = new List<SinhVien>();
            SinhVien s = new SinhVien();
            int choice = 0;
            Boolean check = true;
            string sdt = null;

            while (true)
            {
                do
                {
                    Console.WriteLine("\n********Quan ly sinh vien********");
                    Console.WriteLine("1. Xem danh sach sinh vien");
                    Console.WriteLine("2. Them sinh vien");
                    Console.WriteLine("3. Tim sinh vien");
                    Console.WriteLine("4. Cap nhat thong tin sinh vien");
                    Console.WriteLine("5. Thoat");
                    try
                    {
                        Console.Write("Vui long chon: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                        check = true;
                    }
                    catch (Exception)
                    {
                        check = false;  
                    }
                    

                    if(choice < 1 || choice > 5 || !check)
                        Console.WriteLine("Vui long nhap lai!!!");
                } while (choice < 1 || choice > 5);

                switch (choice)
                {
                    case 1:
                        if(danhSachSinhVien.Count < 1)
                            Console.WriteLine("Danh sach sinh vien rong!!!");
                        else
                        {
                            foreach (var item in danhSachSinhVien)
                            {
                                item.XemThongTin();
                            }
                        }
                        break;
                    case 2:
                        if(danhSachSinhVien.Count == 50)
                        {
                            Console.WriteLine("So luong sinh vien khong duoc vuot qua 50");
                        } else
                        {
                            string msss = null;
                            DateTime NgaySinh = new DateTime();
                            
                            do
                            {
                                Console.Write("Nhap ma so sinh vien: ");
                                msss = Console.ReadLine();
                                foreach (var item in danhSachSinhVien)
                                {
                                    if (item.MMaSV.Equals(msss))
                                    {
                                        Console.WriteLine("Ma so sinh vien da ton tai. Vui long nhap lai!!");
                                        check = false;
                                        break;
                                    }
                                    else check = true;
                                }
                            } while (!check);

                            Console.Write("Nhap ho va ten: ");
                            string HoTen = Console.ReadLine();

                            do
                            {
                                Console.Write("Nhap ngay sinh: ");
                                string Ngay = Console.ReadLine();

                                if (!DateTime.TryParse(Ngay, out NgaySinh))
                                {
                                    check = false;
                                    Console.WriteLine("Hay nhap theo dinh dang: mm/dd/yyyy");
                                }
                                else check = true;
                            } while (!check);

                            Console.Write("Nhap dia chi: ");
                            string DiaChi = Console.ReadLine();

                            do
                            {
                                Console.Write("Nhap so dien thoai: ");
                                sdt = Console.ReadLine();

                                if (sdt.Length != 10)
                                {
                                    Console.WriteLine("So dien thoai phai co 10 chu so");
                                    check = false;
                                }
                                else
                                {
                                    if (!sdt.StartsWith("0"))
                                    {
                                        Console.WriteLine("So dien thoai phai bat dau bang so 0");
                                        check = false;
                                    }
                                    if (!Regex.IsMatch(sdt, "\\d*"))
                                    {
                                        Console.WriteLine("Khong duoc nhap ky tu chu vao so dien thoai");
                                        check = false;
                                    }
                                    else
                                        check = true;
                                }

                            } while (!check);

                            SinhVien sv = new SinhVien(msss, HoTen, NgaySinh, DiaChi, sdt);
                            danhSachSinhVien.Add(sv);
                            Console.WriteLine("Them sinh vien moi thanh cong!!!");
                        }
                        break;
                    case 3:
                        if(danhSachSinhVien.Count < 1)
                            Console.WriteLine("Danh sach rong!!!");
                        else
                        {
                            Console.Write("Nhap ma sinh vien can tim: ");
                            string mss = Console.ReadLine();
                            foreach (var item in danhSachSinhVien)
                            {
                                if(item.MMaSV.Equals(mss))
                                {
                                    item.XemThongTin();
                                    check = true;
                                    break;
                                } else
                                {
                                    check = false; 
                                }
                            }
                            if(!check)
                                Console.WriteLine("Khong tim thay sinh vien co MSSS: " + mss);
                        }
                        break;
                    case 4:
                        if (danhSachSinhVien.Count < 1)
                            Console.WriteLine("Danh sach rong!!!");
                        else
                        {
                            Console.Write("Nhap ma sinh vien can thay doi thong tin: ");
                            string mss = Console.ReadLine();
                            foreach (var item in danhSachSinhVien)
                            {
                                if (item.MMaSV.Equals(mss))
                                {
                                    Console.Write("Nhap ho va ten: ");
                                    item.HoTen1 = Console.ReadLine();

                                    do
                                    {
                                        Console.Write("Nhap ngay sinh: ");
                                        string Ngay = Console.ReadLine();
                                        DateTime d = new DateTime();
                                        if (!DateTime.TryParse(Ngay, out d))
                                        {
                                            check = false;
                                            Console.WriteLine("Hay nhap theo dinh dang: mm/dd/yyyy");
                                        }
                                        else
                                        {
                                            check = true;
                                            item.NgaySinh1 = d;
                                        }
                                    } while (!check);

                                    Console.Write("Nhap dia chi: ");
                                    item.DiaChi1 = Console.ReadLine();

                                    do
                                    {
                                        Console.Write("Nhap so dien thoai: ");
                                        sdt = Console.ReadLine();

                                        if (sdt.Length != 10)
                                        {
                                            Console.WriteLine("So dien thoai phai co 10 chu so");
                                            check = false;
                                        }
                                        else
                                        {
                                            if (!sdt.StartsWith("0"))
                                            {
                                                Console.WriteLine("So dien thoai phai bat dau bang so 0");
                                                check = false;
                                            }
                                            else if (!Regex.IsMatch(sdt, "\\d*"))
                                            {
                                                Console.WriteLine("Khong duoc nhap ky tu chu vao so dien thoai");
                                                check = false;
                                            } else check = true;
                                        }
                                        
                                    } while (!check);
                                    item.DienThoai1 = sdt;
                                    check = true;
                                    break;
                                }
                                if(!check)
                                    Console.WriteLine("Khong tim thay sinh vien co MSSS: " + mss);
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Tam biet!!!!!");
                        return;
                }
            }
        }
    }
}
