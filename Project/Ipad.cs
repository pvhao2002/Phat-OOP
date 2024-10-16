using System;

namespace Project
{
    public class Ipad : Device
    {
        public string IosVersion { get; set; }
        public string ScreenSize { get; set; }

        public Ipad()
        {
            IosVersion = "";
            ScreenSize = "";
        }

        public Ipad(string productId, string productName, decimal productPrice, int productStock, string iosVersion,
            string screenSize) : base(productId, productName, productPrice, productStock)
        {
            IosVersion = iosVersion;
            ScreenSize = screenSize;
        }

        public override string GetDeviceType()
        {
            return "Ipad";
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập phiên bản hệ điều hành: ");
            IosVersion = Console.ReadLine();
            Console.Write("Nhập kích thước màn hình: ");
            ScreenSize = Console.ReadLine();
        }

        public override object[] GetTitle()
        {
            return new object[] { "Mã sản phẩm", "Tên sản phẩm", "Giá", "Tồn kho", "Phiên bản IOS", "Màn hình" };
        }

        public override string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10}";
        }

        public override object[] GetObjectArray()
        {
            return new object[] { ProductId, ProductName, ProductPrice, ProductStock, IosVersion, ScreenSize };
        }
    }
}