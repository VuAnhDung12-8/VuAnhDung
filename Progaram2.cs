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
            Console.WriteLine("3. Thoát");
            Console.Write("Chọn một tùy chọn: ");
            
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
}