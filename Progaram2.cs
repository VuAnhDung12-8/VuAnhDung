using System;
using System.Collections.Generic;

class Todo
{
    public string Ten { get; set; }
    public int DoUuTien { get; set; } 
    public string MoTa { get; set; }
    public int TrangThai { get; set; } 

    public void HienThiThongTin()
    {
        Console.WriteLine($"Tên: {Ten}, Ưu tiên: {DoUuTien}, Trạng thái: {TrangThaiToString()}, Mô tả: {MoTa}");
    }

    private string TrangThaiToString()
    {
        return TrangThai switch
        {
            0 => "Hủy",
            1 => "Hoàn thành",
            2 => "Chờ",
            _ => "Không xác định"
        };
    }
}

class Program
{
    static List<Todo> danhSachTodo = new List<Todo>();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nQuản lý danh sách việc cần làm:");
            Console.WriteLine("1. Thêm việc cần làm");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("Nhấn 'q' hoặc ESC để thoát");
            Console.Write("Chọn một tùy chọn: ");

            
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            
            if (keyInfo.Key == ConsoleKey.Q || keyInfo.Key == ConsoleKey.Escape)
            {
                running = false;
                break;
            }

            
            string luaChon = Console.ReadLine();
            switch (luaChon)
            {
                case "1":
                    ThemCongViec();
                    break;
                case "2":
                    HienThiDanhSach();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ!");
                    break;
            }
        }
    }

    static void ThemCongViec()
    {
        Console.Write("Nhập tên công việc: ");
        string ten = Console.ReadLine();
        
        Console.Write("Nhập độ ưu tiên (1-5): ");
        int doUuTien = int.Parse(Console.ReadLine());
        
        Console.Write("Nhập mô tả: ");
        string moTa = Console.ReadLine();
        
        Console.Write("Nhập trạng thái (0: Hủy, 1: Hoàn thành, 2: Chờ): ");
        int trangThai = int.Parse(Console.ReadLine());
        
        danhSachTodo.Add(new Todo { Ten = ten, DoUuTien = doUuTien, MoTa = moTa, TrangThai = trangThai });
        Console.WriteLine("\nCông việc đã được thêm!");
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\nDanh sách công việc:");
        foreach (var todo in danhSachTodo)
        {
            todo.HienThiThongTin();
        }
    }
static void CapNhatCongViec()
    {
        HienThiDanhSach();
        Console.Write("Nhập số thứ tự công việc cần cập nhật: ");
        int stt = int.Parse(Console.ReadLine()) - 1;
        if (stt < 0 || stt >= danhSachTodo.Count)
        {
            Console.Write("Nhập tên công việc mới: ");
            danhSachTodo[stt].Ten = Console.ReadLine();
            Console.Write("Nhập độ ưu tiên mới (1-5): ");
            danhSachTodo[stt].DoUuTien = int.Parse(Console.ReadLine());
            Console.Write("Nhập mô tả mới: ");
            danhSachTodo[stt].MoTa = Console.ReadLine();
            Console.Write("Nhập trạng thái mới (0: Hủy, 1: Hoàn thành, 2: Chờ): ");
            danhSachTodo[stt].TrangThai = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCông việc đã được cập nhật!");
        }
    }
    else
    {
        Console.WriteLine("Số thứ tự không hợp lệ!");
    }
}

    static void XoaCongViec()
    {
        HienThiDanhSach();
        Console.Write("Nhập số thứ tự công việc cần xóa: ");
        int stt = int.Parse(Console.ReadLine()) - 1;
        if (stt < 0 || stt >= danhSachTodo.Count)
        {
            danhSachTodo.RemoveAt(stt);
            Console.WriteLine("\nCông việc đã được xóa!");
        }

        static void TimKiemTheoDoUuTien()
        { 
            Console.Write("Nhập độ ưu tiên cần tìm (1-5): ");
        int doUuTien = int.Parse(Console.ReadLine());
        var ketQua = danhSachTodo.Where(t => t.DoUuTien == doUuTien).ToList();
        Console.WriteLine("\nKết quả tìm kiếm:");
        ketQua.ForEach(t => t.HienThiThongTin());
    }

    static void SapXepDanhSach()
    {
        danhSachTodo = danhSachTodo.OrderByDescending(t => t.DoUuTien).ToList();
        Console.WriteLine("\nDanh sách đã được sắp xếp!");
    }
}
