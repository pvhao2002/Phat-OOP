using System;
using System.Collections.Generic;
using System.Linq;
using Project.Model;

namespace Project.Service
{
    public class StoreManager : IManager
    {
        private List<Device> List { get; } = new List<Device>();

        public bool Add(Device device)
        {
            var isExist = Get(device.ProductId);
            if (isExist != null) return false;
            List.Add(device);
            return true;
        }

        public void Display()
        {
            if (List.Count == 0)
            {
                Console.WriteLine("Danh sách sản phẩm rỗng");
                return;
            }

            Console.WriteLine("Danh sách sản phẩm");
            var first = List.First();
            Console.WriteLine(first.GetFormatString(), first.GetTitle());
            List.ForEach(x => Console.WriteLine(x.GetFormatString(), x.GetObjectArray()));
        }

        public void Search(string name)
        {
            var listSearch = List.Where(item => item.ProductName.ToLower().Contains(name.ToLower())).ToList();
            if (listSearch.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sản phẩm");
                return;
            }

            Console.WriteLine("Danh sách sản phẩm");
            var first = listSearch.First();
            Console.WriteLine(first.GetFormatString(), first.GetTitle());
            listSearch.ForEach(x => Console.WriteLine(x.GetFormatString(), x.GetObjectArray()));
        }

        public bool Delete(string deviceId)
        {
            var device = Get(deviceId);
            if (device == null) return false;
            List.Remove(device);
            return true;
        }

        public bool Update(string id)
        {
            var item = Get(id);
            if (item == null) return false;
            item.Input(true); // param isEdit = true co nghia la dang chinh sua thong tin
            return true;
        }

        public Device Get(string deviceId)
        {
            return List.FirstOrDefault(item =>
                string.Compare(item.ProductId, deviceId, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public List<Device> GetList()
        {
            return List;
        }

        public void SortByName()
        {
            List.Sort((x, y) => string.Compare(x.ProductName, y.ProductName, StringComparison.OrdinalIgnoreCase));
        }

        public void SortByPrice()
        {
            List.Sort((x, y) => decimal.Compare(x.ProductPrice, y.ProductPrice));
        }

        public void SortByStock()
        {
            List.Sort((x, y) => x.ProductStock.CompareTo(y.ProductStock));
        }

        public void StatisticByType()
        {
            var listType = List.GroupBy(x => x.GetDeviceType()).Select(x => new
            {
                Type = x.Key,
                Count = x.Count(),
                TotalPrice = x.Sum(y => y.ProductPrice),
                TotalStock = x.Sum(y => y.ProductStock)
            }).ToList();

            Console.WriteLine("Thống kê theo loại sản phẩm");
            listType.ForEach(x =>
            {
                Console.WriteLine($"============== Thông tin - {x.Type} ==============");
                Console.WriteLine($"Số lượng sản phẩm: {x.Count}");
                Console.WriteLine($"Tổng giá sản phẩm: {x.TotalPrice}");
                Console.WriteLine($"Tổng số lượng sản phẩm: {x.TotalStock}");
            });
        }
    }
}