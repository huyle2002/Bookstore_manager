using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL_QL_CUAHANGSACH
{
    class Sanpham
    {
        private StreamReader sr;
        private string fileName = "sanphamsach.txt";
        private struct Sach
        {
            public string maS, tenS, loaiS, tacgia, nxb;
            public int sL;
            public double giaNhap, giaBan;
        }
        public Sanpham() { docTep(); }
        private Sach[] ds;
        private void docTep()
        {
            sr = new StreamReader(fileName);
            ds = new Sach[0];
            string r;
            int k = 0;
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('#');
                Array.Resize(ref ds, ds.Length + 1);
                ds[k].maS = tmp[0];
                ds[k].tenS = tmp[1];
                ds[k].loaiS = tmp[2];
                ds[k].tacgia = tmp[3];
                ds[k].nxb = tmp[4];
                ds[k].sL = int.Parse(tmp[5]);
                ds[k].giaNhap = double.Parse(tmp[6]);
                ds[k].giaBan = double.Parse(tmp[7]);
                k++;
            }
            sr.Close();
        }
        public void HienThi()
        {
            Console.WriteLine("╔═══════╦══════════════════════╦═══════════════╦═══════════╦═══════════╦════════╦══════════════╦═════════════╗");
            Console.WriteLine("║MÃ SÁCH║       TÊN SÁCH       ║   LOẠI SÁCH   ║  TÁC GIẢ  ║    NXB    ║SỐ LƯỢNG║   GIÁ NHẬP   ║   GIÁ BÁN   ║");
            Console.WriteLine("╠═══════╬══════════════════════╬═══════════════╬═══════════╬═══════════╬════════╬══════════════╬═════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("║ {0,-6}║ {1,-21}║ {2,-14}║ {3,-10}║ {4,-10}║ {5,-7}║ {6,-13}║ {7,-12}║", ds[i].maS, ds[i].tenS, ds[i].loaiS, ds[i].tacgia, ds[i].nxb, ds[i].sL, ds[i].giaNhap, ds[i].giaBan);
            }
            Console.WriteLine("╚═══════╩══════════════════════╩═══════════════╩═══════════╩═══════════╩════════╩══════════════╩═════════════╝");
        }
        public void ketxuat()
        {
            StreamWriter f = File.CreateText(fileName);
            for (int i = 0; i < ds.Length; i++)
                f.WriteLine(ds[i].maS + "#" + ds[i].tenS + "#" + ds[i].loaiS + "#" + ds[i].tacgia + "#" + ds[i].nxb + "#" + ds[i].sL + "#" + ds[i].giaNhap + "#" + ds[i].giaBan);
            f.Close();
        }
        private void sua()
        {
            string tmp;
            ConsoleKeyInfo KT;
            bool ktT;
            do
            {
                HienThi();
                Console.Write("Nhập mã sách cần sửa: ");
                tmp = Console.ReadLine();
                ktT = true;
                Console.Clear();
                for (int k = 0; k < ds.Length; k++)
                {
                    if (tmp == ds[k].maS)
                    {
                        ktT = false;
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
                if (tmp == ds[i].maS)
                {
                    Console.WriteLine("_________mời bạn nhập thông tin sách có mã {0}_________", tmp);
                    Console.Write("Nhập tên Sách: ");
                    ds[i].tenS = Console.ReadLine();
                    Console.Write("Nhập loại Sách: ");
                    ds[i].loaiS = Console.ReadLine();
                    Console.Write("Nhập tác giả: ");
                    ds[i].loaiS = Console.ReadLine();
                    Console.Write("Nhập nhà xuất bản: ");
                    ds[i].nxb = Console.ReadLine();
                    Console.Write("Nhập giá nhập: ");
                    ds[i].giaNhap = double.Parse(Console.ReadLine());
                    Console.Write("Nhập giá bán: ");
                    ds[i].giaBan = double.Parse(Console.ReadLine());
                    Console.Clear();
                }
            }
            ketxuat();
            Console.Write(" \nsửa thành công rồi!!");
            Console.WriteLine("\t\tẤN 1 PHÍM BẤT KÌ ĐỂ QUAY LẠI!");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\t\t\t┌──────────────┐");
                Console.WriteLine("\t\t\t│ SỬA SÁCH TIẾP│");
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
                    case ConsoleKey.A: sua(); break;
                    case ConsoleKey.B: menu(); break;
                    default: break;
                }
            }
        }

        internal void Menu()
        {
            throw new NotImplementedException();
        }

        private void them()
        {

            ConsoleKeyInfo KT;
            string[] s;
            s = ds[ds.Length - 1].maS.Split('p');
            Array.Resize(ref ds, ds.Length + 1);
            Console.WriteLine("_________MỜI BẠN NHẬP THÔNG TIN SÁCH THỨ {0}_________", ds.Length);
            ds[ds.Length - 1].maS = "sp" + (int.Parse(s[1]) + 1);
            Console.Write("Nhập tên sách: ");
            ds[ds.Length - 1].tenS = Console.ReadLine();
            Console.Write("Nhập loại sách: ");
            ds[ds.Length - 1].loaiS = Console.ReadLine();
            Console.Write("Nhập tác giả: ");
            ds[ds.Length - 1].tacgia = Console.ReadLine();
            Console.Write("Nhập nhà xuất bản: ");
            ds[ds.Length - 1].nxb = Console.ReadLine();
            ds[ds.Length - 1].sL = 0;
            Console.Write("Nhập giá nhập: ");
            ds[ds.Length - 1].giaNhap = double.Parse(Console.ReadLine());
            Console.Write("Nhập giá bán: ");
            ds[ds.Length - 1].giaBan = double.Parse(Console.ReadLine());
            Console.Clear();
            ketxuat();
            Console.WriteLine("\t\tThêm thành công !!!!");
            while (true)
            {
                Console.WriteLine("\t\t\t┌──────────────┐");
                Console.WriteLine("\t\t\t│THÊM SÁCH TIẾP│");
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
                    case ConsoleKey.A: them(); break;
                    case ConsoleKey.B: menu(); break;
                    default: break;

                }
            }
        }
        private void xoa()
        {

            ConsoleKeyInfo KT;
            HienThi();
            string s;
            Console.Write("NHẬP MÃ SÁCH CẦN XÓA ");
            s = Console.ReadLine();
            Console.Clear();
            int d1 = 0, j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maS == s) { j = i; d1++; }
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
            ketxuat();
            Console.WriteLine("\t\tẤN 1 PHÍM BẤT KÌ ĐỂ TIẾP TỤC!");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\t\t\t┌──────────────┐");
                Console.WriteLine("\t\t\t│XÓA THÊM      │");
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
                    case ConsoleKey.A: xoa(); break;
                    case ConsoleKey.B: menu(); break;
                    default: break;
                }
            }

        }
        private void timkiem()
        {

            ConsoleKeyInfo KT;
            string x;
            Console.Write("NHẬP THÔNG TIN BẠN MUỐN TÌM: ");
            x = Console.ReadLine();
            Console.Clear();
            int k = 0;
            Console.WriteLine("╔═════╦═══════╦══════════════════════════╦════════════════════╦═══════════════╦═══════════╦════════╦══════════════════╗");
            Console.WriteLine("║ STT ║MÃ SÁCH║        TÊN SÁCH          ║     LOẠI SÁCH      ║    TÁC GIẢ    ║    NXB    ║SỐ LƯỢNG║     GIÁ TIỀN     ║");
            Console.WriteLine("╠═════╬═══════╬══════════════════════════╬════════════════════╬═══════════════╬═══════════╬════════╬══════════════════╣");
            for (int i = 0; i < ds.Length; i++)
            {
                if (x == ds[i].maS || x == ds[i].tenS || x == ds[i].loaiS)
                {
                    k++;
                    Console.WriteLine("║{0,-5}║ {1,-6}║ {2,-25}║ {3,-19}║ {4,-14}║ {5,-10}║ {6,-7}║ {7,-17}║", i + 1, ds[i].maS, ds[i].tenS, ds[i].loaiS, ds[i].tacgia, ds[i].nxb, ds[i].sL, ds[i].giaBan);
                }
            }
            Console.WriteLine("╚═════╩═══════╩══════════════════════════╩════════════════════╩═══════════════╩═══════════╩════════╩══════════════════╝");
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
                    case ConsoleKey.A: timkiem(); break;
                    case ConsoleKey.B: menu(); break;
                    default: break;
                }
            }
        }
        public double Bansp(string masp, int sl)
        {
            double thanhtien = 0;
            int dem = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (masp == ds[i].maS)
                {
                    if (ds[i].sL > sl && sl > 0)
                    {
                        dem++;
                        ds[i].sL = ds[i].sL - sl;
                        thanhtien = thanhtien + sl * ds[i].giaBan;
                    }
                    else Console.WriteLine("số lượng quá lớn, sản phẩm chỉ còn: {0}", ds[i].sL);
                }
            }
            if (dem == 0)
            {
                Console.WriteLine("Thông tin nhập vào chưa hợp lý! ấn phím bất kì để nhập lại");
                Console.ReadKey();
            }
            return thanhtien;
        }
        public bool kiemTraTonTai(string maHH)
        {
            bool ok = false;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maS == maHH) ok = true;
            }
            return ok;
        }// KIỂM TRA MÃ XEM CÓ TỒN TẠI KHÔNG- PHỤC VỤ BÁN HÀNG
        public void nhaphang(string ma, int sl)// khi nhập hàng, số lượng hàng tăng lên.
        {
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maS == ma) ds[i].sL = ds[i].sL + sl;
            }
            ketxuat();
        }
        public void menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                        <<  QUẢN LÝ SÁCH  >>                         ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║A  │ XEM THÔNG TIN CÁC LOẠI SÁCH  ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║B  │ THÊM SÁCH MỚI                ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║C  │ SỬA THÔNG TIN SÁCH           ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║D  │ XÓA SÁCH                     ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║E  │ TÌM KIẾM SÁCH                ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║F  │ QUAY LẠI MENU CHÍNH          ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║G  │ THOÁT                        ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n\t\t\t ║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ╚═════════════════════════════════════════════════════════════════════╝");

                Console.SetCursorPosition(67, 21);
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
                        them();
                        break;
                    case ConsoleKey.C:
                        sua();
                        break;
                    case ConsoleKey.D:
                        xoa();
                        break;
                    case ConsoleKey.E:
                        timkiem();
                        break;
                    case ConsoleKey.F:
                        MENUCHINH MENUC = new MENUCHINH();
                        MENUC.Menu();
                        break;
                    case ConsoleKey.G:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
