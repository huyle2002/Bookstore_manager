using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL_QL_CUAHANGSACH
{
    class Banhang
    {
        Khachhang kh1 = new Khachhang();
        Sanpham sp1 = new Sanpham();
        private StreamReader sr;
        public Banhang()
        {
            docTephd();
            docTepct();
        }
        private string fileName = "Hoadonban.txt";
        private string tepchitiet = "ctHoadonban.txt";
        private struct hdb
        {
            public string ngayban, makh, mahd;
            public double tongtien;
        }
        private hdb[] ds;
        private struct cthdb
        {
            public int soluong;
            public string mahd, masach;
        }
        private cthdb[] cthd;
        private void docTephd()
        {
            sr = new StreamReader(fileName);
            ds = new hdb[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref ds, ds.Length + 1);
                ds[k].mahd = tmp[0];
                ds[k].makh = tmp[1];
                ds[k].tongtien = int.Parse(tmp[2]);
                ds[k].ngayban = tmp[3];
                k++;
            }
            sr.Close();
        }
        private void docTepct()
        {
            sr = new StreamReader(tepchitiet);
            cthd = new cthdb[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref cthd, cthd.Length + 1);
                cthd[k].mahd = tmp[0];
                cthd[k].masach = tmp[1];
                cthd[k].soluong = int.Parse(tmp[2]);
                k++;
            }
            sr.Close();
        }
        private void ketxuat()
        {
            StreamWriter f = File.CreateText(fileName);
            for (int i = 0; i < ds.Length; i++)
                f.WriteLine(ds[i].mahd + "#" + ds[i].makh + "#" + ds[i].tongtien + "#" + ds[i].ngayban);
            f.Close();
        }
        private void ketxuatct()
        {
            StreamWriter f = File.CreateText(tepchitiet);
            for (int i = 0; i < cthd.Length; i++)
                f.WriteLine(cthd[i].mahd + "#" + cthd[i].masach + "#" + cthd[i].soluong);
            f.Close();
        }
        private void hienthihoadon()
        {
            Console.WriteLine("╔════════╦═══════════════╦══════════════════════╦════════════════════════════╗");
            Console.WriteLine("║ MÃ HD  ║ MÃ KHÁCH HÀNG ║    TỔNG TIỀN         ║         NGÀY BÁN           ║");
            Console.WriteLine("╠════════╬═══════════════╬══════════════════════╬════════════════════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("║{0,-8}║ {1,-14}║ {2,-21}║      {3,-22}║", ds[i].mahd, ds[i].makh, ds[i].tongtien, ds[i].ngayban);
            }
            Console.WriteLine("╚════════╩═══════════════╩══════════════════════╩════════════════════════════╝");
        }
        private void xemchichitiet()
        {
            ConsoleKeyInfo KT;
            hienthihoadon();
            Console.Write("NHẬP MÃ HÓA ĐƠN: ");
            string TMP = Console.ReadLine();
            Console.Clear();
            int dem = 0;// đếm để xem có mã  hóa đơn đã nhập thật hay k
            Console.WriteLine("THÔNG TIN VỀ HÓA ĐƠN CÓ MÃ: " + TMP);
            Console.WriteLine("╔═══════════════╦═══════════════════╗");
            Console.WriteLine("║  MÃ SẢN PHẨM  ║      SỐ LƯỢNG     ║");
            Console.WriteLine("╠═══════════════╬═══════════════════╣");
            for (int i = 0; i < cthd.Length; i++)
            {
                if (TMP == cthd[i].mahd)
                { Console.WriteLine("║ {0,-14}║     {1,-14}║ ", cthd[i].masach, cthd[i].soluong); dem++; }
            }
            Console.WriteLine("╚═══════════════╩═══════════════════╝");
            if (dem == 0)
            {
                Console.Clear();
                Console.WriteLine("KHÔNG TỒN TẠI HÓA ĐƠN MUỐN TÌM ! ẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC!");
                Console.ReadKey();
                Console.Clear();
            }
            while (true)
            {
                Console.WriteLine("\t\t\t┌──────────────┐");
                Console.WriteLine("\t\t\t│THỬ LẠI       │");
                Console.WriteLine("\t\t\t├───┬──────────┤");
                Console.WriteLine("\t\t\t│A  │ CÓ       │");
                Console.WriteLine("\t\t\t├───┼──────────┤");
                Console.WriteLine("\t\t\t│B  │ KHÔNG    │");
                Console.WriteLine("\t\t\t├───┴──────────┤");
                Console.WriteLine("\t\t\t│ NHẬP:        │");
                Console.WriteLine("\t\t\t└──────────────┘");
                Console.SetCursorPosition(31, 7);
                KT = Console.ReadKey();
                Console.Clear();
                switch (KT.Key)
                {
                    case ConsoleKey.A: xemchichitiet(); break;
                    case ConsoleKey.B: menubh(); break;
                    default: break;
                }
            }
        }

        internal void Menu()
        {
            throw new NotImplementedException();
        }

        private void Them()
        {

            Console.WriteLine("------------------>THÊM HÓA ĐƠN BÁN SỐ: " + (ds.Length + 1));
            string K;
            string KT;
            double tongtien = 0;
            bool tmp2;
            kh1.Them();
            do
            {
                sp1.HienThi();
                Console.Write("\n NHẬP MÃ SÁCH: ");
                K = Console.ReadLine();
                Console.Clear();
                if (sp1.kiemTraTonTai(K))
                {
                    tmp2 = sp1.kiemTraTonTai(K);
                    Console.Write("\n NHẬP SỐ LƯỢNG: ");
                    int C = int.Parse(Console.ReadLine());
                    double tmp = sp1.Bansp(K, C);// nhập hàng chuyền vào K: mã sách, C: số lượng. để tính tiền:(giá tiền *số lượng); giảm số lượng đi
                    if (tmp != 0)
                    {
                        tongtien = tongtien + tmp;
                        Array.Resize(ref cthd, cthd.Length + 1);
                        cthd[cthd.Length - 1].mahd = "hdb" + (ds.Length + 1);
                        cthd[cthd.Length - 1].masach = K;
                        cthd[cthd.Length - 1].soluong = C;
                    }
                    Console.Clear();
                    Console.Write("Bán thêm sách khác( C / K ) : ");
                    KT = Console.ReadLine();
                }
                else
                {
                    tmp2 = true;
                    KT = "c";
                    Console.Write("BẠN NHẬP SAI MÃ SÁCH, ẤN BẤT KÌ ĐỂ  NHẬP LẠI");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (tmp2 && (KT == "c") || (KT == "C"));
            if (tongtien != 0)
            {
                Array.Resize(ref ds, ds.Length + 1);
                ds[ds.Length - 1].makh = kh1.LaymaKH();
                ds[ds.Length - 1].mahd = "hdb" + ds.Length;
                ds[ds.Length - 1].tongtien = tongtien;
                ds[ds.Length - 1].ngayban = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                ketxuat();
                ketxuatct();
                sp1.ketxuat();
                Console.Write("THÊM THÀNH CÔNG!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void xoa()
        {
            hienthihoadon();
            Console.Write("\n NHẬP MÃ HÓA ĐƠN BẠN MUỐN XÓA:");
            string mahd = Console.ReadLine();
            int d1 = 0, j = 0; int FORCT = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].mahd == mahd)
                {
                    j = i; d1++;
                    while (j < ds.Length - 1)
                    {
                        ds[j] = ds[j + 1];
                        j++;
                    }
                    Array.Resize(ref ds, ds.Length - 1);
                }
            }
            if (d1 == 0)
            {
                Console.WriteLine("Thông tin nhập vào không chính xác!");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                int k = cthd.Length;
                for (int i = 0; i < cthd.Length; i++)
                {
                    if (cthd[i].mahd == mahd)
                    {
                        FORCT++;
                    }
                }
                for (int i = 0; i < cthd.Length; i++)
                {
                    if (cthd[i].mahd == mahd)
                    {
                        k = i; break;
                    }
                }
                int k1 = k;
                while (k < cthd.Length - FORCT)
                {
                    cthd[k] = cthd[k + FORCT];
                    k++;
                }
                Array.Resize(ref cthd, cthd.Length - FORCT);
            }
            ketxuat();
            ketxuatct();
            Console.WriteLine("Thông tin đã được xóa!");
            Console.ReadKey();
            Console.Clear();
        }
        public void thongKeNgay()
        {
            double doanhthu = 0;
            Console.Write("Nhập ngày tháng năm cần thống kê(ngày/tháng/năm): ");
            string ntn = Console.ReadLine();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ntn == ds[i].ngayban)
                {
                    doanhthu = doanhthu + ds[i].tongtien;
                }
            }
            Console.Write("\n TỔNG DOANH THU NGÀY " + ntn + " LÀ: " + doanhthu + " VNĐ");
            Console.ReadKey();
            Console.Clear();
        }
        public void thongKeThang()
        {
            double doanhthu = 0;
            Console.Write("nhập tháng năm cần thống kê(tháng/năm): ");
            string ntn = Console.ReadLine();
            for (int i = 0; i < ds.Length; i++)
            {
                string[] tmp = ds[i].ngayban.Split('/');//tách ngày tháng năm ra riêng lẻ
                string tg = tmp[1] + "/" + tmp[2]; //gép tháng và năm vào theo dạng mm/yy
                if (ntn == tg)
                {
                    doanhthu = doanhthu + ds[i].tongtien;
                }
            }
            Console.Write("\n TỔNG DOANH THU THÁNG " + ntn + " LÀ: " + doanhthu + " VNĐ");
            Console.ReadKey();
            Console.Clear();
        }
        public void Menutk()
        {
            bool stop = false;
            while (!stop)
            {
                docTephd();
                docTepct();
                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                      ** QUẢN LÝ THỐNG KÊ **                         ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║ A │ THỐNG KÊ NGÀY                ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║ B │ THỐNG KÊ THÁNG               ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║ C │ QUAY VỀ MENU CHÍNH           ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║ D │ THOÁT                        ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n\t\t\t ║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(68, 15);
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                switch (kt.Key)
                {
                    case ConsoleKey.A:
                        thongKeNgay();
                        break;
                    case ConsoleKey.B:
                        thongKeThang();
                        break;
                    case ConsoleKey.C:
                        MENUCHINH BX = new MENUCHINH();
                        BX.Menu();
                        break;
                    case ConsoleKey.D:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void menubh()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                     << QUẢN LÝ BÁN SÁCH >>                          ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║A  │ BÁN HÀNG                     ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║B  │ XÓA HÓA ĐƠN                  ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║C  │ XEM CHI TIẾT HÓA ĐƠN         ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║D  │ QUAY VỀ MENU CHÍNH           ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║E  │ THOÁT                        ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n\t\t\t ║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(68, 17);
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                switch (kt.Key)
                {
                    case ConsoleKey.A:
                        Them();
                        break;
                    case ConsoleKey.B:
                        xoa();
                        break;
                    case ConsoleKey.C:
                        xemchichitiet();
                        break;
                    case ConsoleKey.D:
                        MENUCHINH TG = new MENUCHINH();
                        TG.Menu();
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
