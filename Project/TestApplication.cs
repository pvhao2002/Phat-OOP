using System;
using System.Collections.Generic;
using System.Text;
using Project.Helper;
using Project.Model;
using Project.Service;

namespace Project
{
    public static class TestApplication
    {
        private static readonly Dictionary<string, Device> Devices = new Dictionary<string, Device>()
        {
            { "1", new Ipad() },
            { "2", new Iphone() },
            { "3", new SamSung() },
            { "4", new Tablet() }
        };

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            IManager store = new StoreManager();
            var list = CsvHelper.ReadCsv("data.csv");
            list.ForEach(x => store.Add(x));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị sản phẩm");
                Console.WriteLine("3. Tìm kiếm sản phẩm theo tên");
                Console.WriteLine("4. Xóa sản phẩm");
                Console.WriteLine("5. Sửa sản phẩm");
                Console.WriteLine("6. Lưu vào file");
                Console.WriteLine("7. Tìm kiếm theo mã sản phẩm");
                Console.WriteLine("8. Sắp xếp theo giá");
                Console.WriteLine("9. Sắp xếp theo tên");
                Console.WriteLine("10. Sắp xếp theo số lượng");
                Console.WriteLine("11. Thống kê số lượng sản phẩm theo loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("1. Ipad");
                        Console.WriteLine("2. Iphone");
                        Console.WriteLine("3. SamSung");
                        Console.WriteLine("4. Tablet");
                        Console.Write("Chọn loại sản phẩm: ");
                        var type = Console.ReadLine();
                        if (string.IsNullOrEmpty(type) || !Devices.TryGetValue(type, out var device1))
                        {
                            Console.WriteLine("Loại sản phẩm không tồn tại");
                            break;
                        }

                        device1.Input();
                        Console.WriteLine(
                            $"\n[+] Kết quả: {(store.Add(device1) ? "Thêm sản phẩm thành công" : "Mã sản phẩm đã tồn tại")}");
                        break;
                    case "2":
                        store.Display();
                        break;
                    case "3":
                        Console.Write("Nhập tên sản phẩm cần tìm: ");
                        var name = Console.ReadLine();
                        store.Search(name);

                        break;
                    case "4":
                        Console.Write("Nhập mã sản phẩm cần xóa: ");
                        var id = Console.ReadLine();
                        Console.Write("\n[+] Kết quả: ");
                        Console.WriteLine(store.Delete(id) ? "Xóa sản phẩm thành công" : "Mã sản phẩm không tồn tại");
                        break;
                    case "5":
                        Console.Write("Nhập mã sản phẩm cần sửa: ");
                        var updateDeviceId = Console.ReadLine();
                        Console.Write("\n[+] Kết quả: ");
                        Console.WriteLine(store.Update(updateDeviceId)
                            ? "Sửa sản phẩm thành công"
                            : "Mã sản phẩm không tồn tại");
                        break;
                    case "6":
                        CsvHelper.WriteDataToCsv("file.csv", store.GetList());
                        break;
                    case "7":
                        Console.Write("Nhập mã sản phẩm cần tìm: ");
                        var deviceId = Console.ReadLine();
                        var device = store.Get(deviceId);
                        if (device == null)
                        {
                            Console.WriteLine("Không tìm thấy sản phẩm");
                            break;
                        }

                        device.Output();
                        break;
                    case "8":
                        store.SortByPrice();
                        store.Display();
                        break;
                    case "9":
                        store.SortByName();
                        store.Display();
                        break;
                    case "10":
                        store.SortByStock();
                        store.Display();
                        break;
                    case "11":
                        store.StatisticByType();
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại");
                        break;
                }

                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            }
        }
    }
}