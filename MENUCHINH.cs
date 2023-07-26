using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL_QL_CUAHANGSACH
{
    class MENUCHINH
    {
        public void giaodienchinh()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\t\t\t║_______________Trường Đại Học Sư Phạm Kỹ Thuật Hưng Yên_________________║");
            Console.WriteLine("\t\t\t║                                                                        ║");
            Console.WriteLine("\t\t\t║                       --KHOA CÔNG NGHỆ THÔNG TIN--                     ║");
            Console.WriteLine("\t\t\t║                                                                        ║");
            Console.WriteLine("\t\t\t║                                                                        ║");
            Console.WriteLine("\t\t\t║                   CHƯƠNG TRÌNH QUẢN LÝ CỬA HÀNG SÁCH                   ║");
            Console.WriteLine("\t\t\t║                                                                        ║");
            Console.WriteLine("\t\t\t║           Giáo viên giảng dạy:         Nguyễn Thị Thanh Huệ            ║");
            Console.WriteLine("\t\t\t║           Sinh viên thực hiện:         Lê Quang Huy                    ║");
            Console.WriteLine("\t\t\t╚════════════════════════════════════════════════════════════════════════╝");
            Console.Write("\t\t\t\tẤn phím bất kì để tiếp tục!: ");
            Console.SetCursorPosition(60, 21);
            Console.ReadKey();
            Console.Clear();
        }
        public void Menu()
        {
            bool stop = false;
            while (!stop)
            {

                Console.OutputEncoding = Encoding.UTF8;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n\t\t\t ╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t ║                  CHƯƠNG TRÌNH QUẢN LÝ CỬA HÀNG SÁCH                 ║");
                Console.Write("\n\t\t\t ║                         ** MENU CHÍNH **                            ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║A  │     QUẢN LÝ SÁCH             ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║B  │     QUẢN LÝ KHÁCH HÀNG       ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║C  │     QUẢN LÝ NHẬP SÁCH        ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║D  │     QUẢN LÝ BÁN SÁCH         ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║E  │     THỐNG KÊ DOANH THU       ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║F  │     THOÁT                    ║                 ║");
                Console.Write("\n\t\t\t ║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n\t\t\t ║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n\t\t\t ║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ║                                                                     ║");
                Console.Write("\n\t\t\t ╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(68, 19);
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                switch (kt.Key)
                {
                    case ConsoleKey.A:
                        Sanpham ql = new Sanpham();
                        ql.menu();
                        break;
                    case ConsoleKey.B:
                        Khachhang kh = new Khachhang();
                        kh.Menu();
                        break;
                    case ConsoleKey.C:
                        Nhaphang nh = new Nhaphang();
                        nh.Menu();
                        break;
                    case ConsoleKey.D:
                        Banhang bh = new Banhang();
                        bh.menubh();
                        break;
                    case ConsoleKey.E:
                        Banhang tk = new Banhang();
                        tk.Menutk();
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
