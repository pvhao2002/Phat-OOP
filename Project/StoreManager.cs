using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class StoreManager : IManager
    {
        private List<Device> List { get; set; } = new List<Device>();

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
            if (device != null)
            {
                List.Remove(device);
                return true;
            }
            return false;
        }

        public bool Update(Device device)
        {
            var obj = Get(device.ProductId);
            if (obj != null)
            {
                if (device is Ipad)
                {
                    obj = (Ipad)device;
                }
                else if (device is Mobile)
                {
                    obj = (Mobile)device;
                }
                else if (device is Tablet)
                {
                    obj = (Tablet)device;
                }
                else if (device is SamSung)
                {
                    obj = (SamSung)device;
                }
                else if (device is Iphone)
                {
                    obj = (Iphone)device;
                }
                return true;
            }
            return false;
        }

        public Device Get(string deviceId)
        {
            return List.FirstOrDefault(item => string.Compare(item.ProductId, deviceId, StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}