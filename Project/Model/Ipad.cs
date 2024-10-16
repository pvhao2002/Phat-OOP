using System;

namespace Project.Model
{
    public class Ipad : Device, IClone
    {
        public string IosVersion { get; set; }
        public string ScreenSize { get; set; }

        public Ipad()
        {
            IosVersion = "";
            ScreenSize = "";
        }

        private Ipad(string productId, string productName, decimal productPrice, int productStock, string iosVersion,
            string screenSize) : base(productId, productName, productPrice, productStock)
        {
            IosVersion = iosVersion;
            ScreenSize = screenSize;
        }

        public override string GetDeviceType()
        {
            return "Ipad";
        }

        public override void Input(bool isEdit = false)
        {
            base.Input(isEdit);
            Console.Write("Nhập phiên bản hệ điều hành: ");
            IosVersion = Console.ReadLine();
            Console.Write("Nhập kích thước màn hình: ");
            ScreenSize = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Phiên bản hệ điều hành: {IosVersion}");
            Console.WriteLine($"Kích thước màn hình: {ScreenSize}");
        }

        public override object[] GetObjectArray()
        {
            return new object[]
            {
                GetDeviceType(),
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                IosVersion,
                ScreenSize,
                "", "", "", ""
            };
        }

        public Device Clone()
        {
            return new Ipad(
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                IosVersion,
                ScreenSize
            );
        }
    }
}