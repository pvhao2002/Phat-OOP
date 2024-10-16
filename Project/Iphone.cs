using System;

namespace Project
{
    public class Iphone : Mobile
    {
        public string IosVersion { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }

        public Iphone()
        {
            IosVersion = "";
            Ram = 0;
            Storage = 0;
        }

        public Iphone(string productId, string productName, decimal productPrice, int productStock, string network,
            string os, string iosVersion, int ram, int storage) : base(productId, productName, productPrice,
            productStock, network, os)
        {
            IosVersion = iosVersion;
            Ram = ram;
            Storage = storage;
        }

        public override string GetDeviceType()
        {
            return "Iphone";
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập phiên bản hệ điều hành: ");
            IosVersion = Console.ReadLine();
            Console.Write("Nhập dung lượng Ram: ");
            Ram = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Nhập dung lượng bộ nhớ: ");
            Storage = int.Parse(Console.ReadLine() ?? string.Empty);
        }

        public override object[] GetTitle()
        {
            return new object[]
            {
                "Mã sản phẩm", "Tên sản phẩm", "Giá", "Tồn kho", "Mạng", "Hệ điều hành", "Phiên bản IOS", "Ram",
                "Bộ nhớ"
            };
        }

        public override string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-10} {8,-10}";
        }

        public override object[] GetObjectArray()
        {
            return new object[]
                { ProductId, ProductName, ProductPrice, ProductStock, Network, Os, IosVersion, Ram, Storage };
        }
    }
}