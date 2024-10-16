using System;

namespace Project
{
    public class Tablet : Device
    {
        public string AndroidVersion { get; set; }
        public string ScreenSize { get; set; }

        public Tablet()
        {
            AndroidVersion = "";
            ScreenSize = "";
        }

        public Tablet(string productId, string productName, decimal productPrice, int productStock,
            string androidVersion,
            string screenSize) : base(productId, productName, productPrice, productStock)
        {
            AndroidVersion = androidVersion;
            ScreenSize = screenSize;
        }

        public override string GetDeviceType()
        {
            return "Tablet";
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập phiên bản hệ điều hành: ");
            AndroidVersion = Console.ReadLine();
            Console.Write("Nhập kích thước màn hình: ");
            ScreenSize = Console.ReadLine();
        }

        // get format string and array of object

        public override object[] GetTitle()
        {
            return new object[] { "Mã sản phẩm", "Tên sản phẩm", "Giá", "Tồn kho", "Phiên bản Android" };
        }

        public override string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10}";
        }

        public override object[] GetObjectArray()
        {
            return new object[] { ProductId, ProductName, ProductPrice, ProductStock, AndroidVersion, ScreenSize };
        }
    }
}