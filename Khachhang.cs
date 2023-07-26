using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL_QL_CUAHANGSACH
{
    class Khachhang
    {
        private StreamReader sr;
        string fileName = "Khachhang.txt";
        private struct kh
        {
            public string tenkh, dc, makh;
            public int sdt;
        }
        public Khachhang()
        {
            DocTep();
        }
        private kh[] ds;
        private void DocTep()
        {
            sr = new StreamReader(fileName);
            ds = new kh[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref ds, ds.Length + 1);
                ds[k].makh = tmp[0];
                ds[k].tenkh = tmp[1];
                ds[k].dc = tmp[2];
                ds[k].sdt = int.Parse(tmp[3]);
                k++;
            }
            sr.Close();
        }
        private void HienThi()
        {
            Console.WriteLine("╔══════╦═══════════════╦════════════════════════╦═════════════════╦════════════════════════════════════════════╗");
            Console.WriteLine("║ STT  ║ MÃ KHÁCH HÀNG ║  TÊN KHÁCH HÀNG        ║  SỐ ĐIỆN THOẠI  ║                  ĐỊA CHỈ                   ║");
            Console.WriteLine("╠══════╬═══════════════╬════════════════════════╬═════════════════╬════════════════════════════════════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("║{0,-6}║ {1,-14}║ {2,-23}║ 0{3,-15}║ {4,-43}║", i + 1, ds[i].makh, ds[i].tenkh, ds[i].sdt, ds[i].dc);
            }
            Console.WriteLine("╚══════╩═══════════════╩════════════════════════╩═════════════════╩════════════════════════════════════════════╝");
        }
        private void TimKiem()
        {
            ConsoleKeyInfo KT;
            string x;
            Console.Write("NHẬP THÔNG TIN BẠN MUỐN TÌM: ");
            x = Console.ReadLine();
            Console.Clear();
            int k = 0;
            Console.WriteLine("╔══════╦═════════════════╦════════════════════╦═══════════════════════╦═════════════════════════════╗");
            Console.WriteLine("║ STT  ║  MÃ KHÁCH HÀNG  ║  TÊN KHÁCH HÀNG    ║  SỐ ĐIỆN THOẠI        ║         ĐỊA CHỈ             ║");
            Console.WriteLine("╠══════╬═════════════════╬════════════════════╬═══════════════════════╬═════════════════════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                if (x == ds[i].makh || x == ds[i].tenkh)
                {
                    k++;
                    Console.WriteLine("║{0,-6}║ {1,-16}║ {2,-19}║ 0{3,-21}║ {4,-28}║", i + 1, ds[i].makh, ds[i].tenkh, ds[i].sdt, ds[i].dc);
                }
            }
            Console.WriteLine("╚══════╩═════════════════╩════════════════════╩═══════════════════════╩═════════════════════════════╝");
            if (k == 0) { Console.Clear(); Console.WriteLine(" ---KHÔNG CÓ MÃ(TÊN) BẠN MUỐN TÌM!!"); }
            Console.WriteLine("\t\tẤN 1 PHÍM BẤT KÌ ĐỂ TIẾP TỤC!");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\t\t\t┌──────────────┐");
                Console.WriteLine("\t\t\t│TÌM LẠI       │");
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
                    case ConsoleKey.F1: TimKiem(); break;
                    case ConsoleKey.F2: Menu(); break;
                    default: break;
                }
            }
        }
        private void Ketxuat()
        {
            StreamWriter f = File.CreateText("khachhang.txt");
            for (int i = 0; i < ds.Length; i++)
                f.WriteLine(ds[i].makh + "#" + ds[i].tenkh + "#" + ds[i].dc + "#" + ds[i].sdt);
            f.Close();
        }
        public void Them()
        {
            DocTep();
            string ten, diachi;
            int sdt;
            Console.WriteLine("_________mời bạn nhập thông tin của khách hàng thứ {0}_________", ds.Length + 1);
            Console.Write("Nhập tên khách hàng: ");
            ten = Console.ReadLine();
            Console.Write("Nhập địa chỉ khách hàng: ");
            diachi = Console.ReadLine();
            Console.Write("Nhập số điện thoại khách hàng: ");
            sdt = int.Parse(Console.ReadLine());
            string[] tach;
            tach = ds[ds.Length - 1].makh.Split('h');
            Array.Resize(ref ds, ds.Length + 1);
            ds[ds.Length - 1].makh = "kh" + (int.Parse(tach[1]) + 1);
            ds[ds.Length - 1].tenkh = ten;
            ds[ds.Length - 1].dc = diachi;
            ds[ds.Length - 1].sdt = sdt;
            Console.WriteLine("ẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC!");
            Console.ReadKey();
            Console.Clear();
            Ketxuat();

        }
        public string LaymaKH()
        {
            return ds[ds.Length - 1].makh;
        }
        private void Sua()
        {


            string tmp;// mã khách hàng giả.
            bool ktT;// nếu mã kh đã đúng thì thoát vòng lập do while.
            do
            {
                HienThi();
                Console.WriteLine("nhập mã khách hàng : ");
                tmp = Console.ReadLine();
                ktT = true;// tạm đặt là true
                Console.Clear();
                for (int k = 0; k < ds.Length; k++)
                {
                    if (tmp == ds[k].makh)
                    {
                        ktT = false;// nếu tìm thấy đặt là false
                    }
                }
                if (ktT == true)
                {
                    Console.WriteLine("HÃY NHẬP LẠI MÃ !!");
                    Console.WriteLine("ẤN PHÍM BẤT KÌ ĐỂ NHẬP LẠI!!");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (ktT);
            for (int i = 0; i < ds.Length; i++)
            {
                if (tmp == ds[i].makh)
                {
                    Console.WriteLine("_________mời bạn nhập thông tin sửa_________");
                    Console.Write("Nhập tên KH: ");
                    ds[i].tenkh = Console.ReadLine();
                    Console.Write("Nhập ĐC: ");
                    ds[i].dc = Console.ReadLine();
                    Console.Write("Nhập SĐT: ");
                    ds[i].sdt = int.Parse(Console.ReadLine());
                }
            }
            Ketxuat();
            Console.Write(" \nSửa thành công rồi!");
            Console.ReadKey();
            Console.Clear();
        }

        internal string laymaKH => throw new NotImplementedException();

        private void xoa(ref kh[] ds)
        {
            HienThi();
            string s;
            Console.Write("nhập mã KH cần xóa: ");
            s = Console.ReadLine();
            int d1 = 0, j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].makh == s) { j = i; d1++; }
            }
            if (d1 == 0)
                Console.WriteLine("Thông tin nhập vào không chính xác!");
            else
            {
                while (j < ds.Length - 1)
                {
                    ds[j] = ds[j + 1];
                    j++;
                }
                Array.Resize(ref ds, ds.Length - 1);
                Console.WriteLine("Thông tin đã được xóa!");

            }
            Console.ReadKey();
            Console.Clear();
            Ketxuat();

        }
        public void Menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                      << QUẢN LÝ KHÁCH HÀNG >>                       ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║A  │ XEM THÔNG TIN CÁC KHÁCH HÀNG ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║B  │ THÊM KHÁCH HÀNG MỚI          ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║C  │ SỬA THÔNG TIN KHÁCH HÀNG     ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║D  │ XÓA KHÁCH HÀNG               ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║E  │ QUAY LẠI MENU CHÍNH          ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║F  │ THOÁT                        ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n\t\t\t ║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(67, 19);
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                switch (kt.Key)
                {
                    case ConsoleKey.A:
                        HienThi();
                        Console.Write("\n\n\t\t\tẤN 1 PHÍM BẤT KÌ ĐỂ QUAY LẠI");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.B:
                        Them();
                        break;
                    case ConsoleKey.C:
                        Sua();
                        break;
                    case ConsoleKey.D:
                        xoa(ref ds);
                        break;
                    case ConsoleKey.E:
                        MENUCHINH MN = new MENUCHINH();
                        MN.Menu();
                        break;
                    case ConsoleKey.F:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
