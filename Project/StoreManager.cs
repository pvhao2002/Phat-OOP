using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class StoreManager : IManager
    {
        private List<Device> List { get; set; } = new List<Device>();

        public void Add(Device device)
        {
            var isExist = List.Exists(x =>
                string.Compare(x.ProductId, device.ProductId, StringComparison.OrdinalIgnoreCase) == 0);
            if (isExist)
            {
                Console.WriteLine("Mã sản phẩm đã tồn tại");
                return;
            }

            List.Add(device);
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
            throw new System.NotImplementedException();
        }

        public void Delete(string deviceId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Device device)
        {
            throw new System.NotImplementedException();
        }
    }
}