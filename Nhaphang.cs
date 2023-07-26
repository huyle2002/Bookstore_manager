using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL_QL_CUAHANGSACH
{
    class Nhaphang
    {
        Sanpham x = new Sanpham();
        private StreamReader sr;
        string fileName = "Hoadonnhap.txt";
        string fileNamect = "ctHoadonnhap.txt";
        public Nhaphang()
        {
            docTep();
            docTepct();
        }
        private struct Hoadonnhap
        {
            public string ngaythangnam, nguoinhap, mahdn;
        }
        private Hoadonnhap[] ds;
        private struct ctnhap
        {
            public int soluong;
            public string mahdn, masp;
        }
        private ctnhap[] dsct;

        private void docTepct()
        {
            sr = new StreamReader(fileNamect);
            dsct = new ctnhap[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref dsct, dsct.Length + 1);
                dsct[k].mahdn = tmp[0];
                dsct[k].masp = tmp[1];
                dsct[k].soluong = int.Parse(tmp[2]);
                k++;
            }
            sr.Close();
        }
        private void docTep()
        {
            sr = new StreamReader(fileName);
            ds = new Hoadonnhap[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref ds, ds.Length + 1);
                ds[k].mahdn = tmp[0];
                ds[k].nguoinhap = tmp[1];
                ds[k].ngaythangnam = tmp[2];
                k++;
            }
            sr.Close();
        }
        private void hienthihoadon()
        {
            Console.WriteLine("╔════════╦══════════════════════════╦════════════════════════╗");
            Console.WriteLine("║ MÃ HD  ║      TÊN NGƯỜI NHẬP      ║    NGÀY NHẬP HÀNG      ║");
            Console.WriteLine("╠════════╬══════════════════════════╬════════════════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("║{0,-8}║ {1,-25}║   {2,-21}║", ds[i].mahdn, ds[i].nguoinhap, ds[i].ngaythangnam);
            }
            Console.WriteLine("╚════════╩══════════════════════════╩════════════════════════╝");
        }
        private void xemchichitiet()
        {
            ConsoleKeyInfo KT;
            hienthihoadon();
            Console.Write("NHẬP MÃ HÓA ĐƠN: ");
            string TMP = Console.ReadLine();
            Console.Clear();
            int dem = 0;// đếm để xem có mã  hóa đơn đã thập thật hay k
            Console.WriteLine("THÔNG TIN VỀ HÓA ĐƠN CÓ MÃ: " + TMP);
            Console.WriteLine("╔═══════════════╦═══════════════════╗");
            Console.WriteLine("║  MÃ SẢN PHẨM  ║      SỐ LƯỢNG     ║");
            Console.WriteLine("╠═══════════════╬═══════════════════╣");
            for (int i = 0; i < dsct.Length; i++)
            {
                if (TMP == dsct[i].mahdn)
                { Console.WriteLine("║ {0,-14}║     {1,-14}║ ", dsct[i].masp, dsct[i].soluong); dem++; }
            }
            Console.WriteLine("╚═══════════════╩═══════════════════╝");
            if (dem == 0)
            {
                Console.Clear();
                Console.WriteLine("KHÔNG TỒN TẠI HÓA ĐƠN MUỐN TÌM ! ẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Write("ẤN BẤT KÌ ĐỂ TIẾP TỤC!!");
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
                    case ConsoleKey.B: Menu(); break;
                    default: break;
                }
            }
        }
        private void ketxuat()
        {
            StreamWriter f = File.CreateText(fileName);
            for (int i = 0; i < ds.Length; i++)
                f.WriteLine(ds[i].mahdn + "#" + ds[i].nguoinhap + "#" + ds[i].ngaythangnam);
            f.Close();
        }
        private void ketxuatct()
        {
            StreamWriter f = File.CreateText(fileNamect);
            for (int i = 0; i < dsct.Length; i++)
                f.WriteLine(dsct[i].mahdn + "#" + dsct[i].masp + "#" + dsct[i].soluong);
            f.Close();
        }
        private void them()
        {
            Console.Write("------------------>THÊM HÓA ĐƠN NHẬP SỐ: " + (ds.Length + 1));
            Console.Write("\n TÊN NGƯỜI NHẬP KHO: ");
            string ten = Console.ReadLine();
            Console.Clear();
            string K;
            string KT;
            do
            {
                x.HienThi();
                Console.Write("\n NHẬP MÃ SƠN: ");
                K = Console.ReadLine();
                Console.Clear();
                if (x.kiemTraTonTai(K))
                {
                    Console.Write("\n NHẬP SỐ LƯỢNG: ");
                    int C = int.Parse(Console.ReadLine());
                    x.nhaphang(K, C);// nhập hàng chuyền vào K: mã sơn, C: số lượng. để tăng số lượng trong danh sách sơn. đồng thời kết xuất để lưu luôn.
                    Array.Resize(ref dsct, dsct.Length + 1);
                    string[] tach;
                    tach = ds[ds.Length - 1].mahdn.Split('n');
                    dsct[dsct.Length - 1].mahdn = "hdn" + (int.Parse(tach[1]) + 1);
                    dsct[dsct.Length - 1].masp = K;
                    dsct[dsct.Length - 1].soluong = C;
                    Console.Clear();
                    Console.Write("nhập thêm sách khác( C / K ) : ");
                    KT = Console.ReadLine();
                }
                else
                {
                    KT = "c";
                    Console.Write("MÃ SAI- ẤN BẤT KÌ ĐỂ NHẬP LẠI!");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while ((KT == "c") || (KT == "C"));
            Console.Clear();
            string[] s;
            s = ds[ds.Length - 1].mahdn.Split('n');
            Array.Resize(ref ds, ds.Length + 1);
            ds[ds.Length - 1].mahdn = "hdn" + (int.Parse(s[1]) + 1);
            //string[] tach;
            //tach = ds[ds.Length - 1].makh.Split('h');
            //Array.Resize(ref ds, ds.Length + 1);
            //ds[ds.Length - 1].makh = "kh" + (int.Parse(tach[1]) + 1);
            ds[ds.Length - 1].nguoinhap = ten;
            ds[ds.Length - 1].ngaythangnam = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            ketxuat();
            ketxuatct();
            Console.Write("THÊM THÀNH CÔNG!");
            Console.ReadKey();
            Console.Clear();
        }
        private void xoa()
        {
            hienthihoadon();
            Console.Write("\n NHẬP MÃ HÓA ĐƠN BẠN MUỐN XÓA:");
            string mahd = Console.ReadLine();
            int d1 = 0, j = 0; int FORCT = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].mahdn == mahd)
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
                int k = dsct.Length;
                for (int i = 0; i < dsct.Length; i++)
                {
                    if (dsct[i].mahdn == mahd)
                    {
                        FORCT++;
                    }
                }
                for (int i = 0; i < dsct.Length; i++)
                {
                    if (dsct[i].mahdn == mahd)
                    {
                        k = i; break;
                    }
                }
                while (k < dsct.Length - FORCT)
                {
                    dsct[k] = dsct[k + FORCT];
                    k++;
                }
            }
            ketxuat();
            ketxuatct();
            Console.WriteLine("Thông tin đã được xóa!");
            Console.ReadKey();
            Console.Clear();
        }
        public void Menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                    <<   QUẢN LÝ NHẬP SÁCH     >>                    ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║A  │ XEM HÓA ĐƠN NHẬP             ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║B  │ NHẬP SÁCH                    ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║C  │ XÓA                          ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║D  │ QUAY LẠI MENU CHÍNH          ║                 ║");
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
                        xemchichitiet();
                        Console.Clear();
                        break;
                    case ConsoleKey.B:
                        them();
                        break;
                    case ConsoleKey.C:
                        xoa();
                        break;
                    case ConsoleKey.D:
                        MENUCHINH MN = new MENUCHINH();
                        MN.Menu();
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
