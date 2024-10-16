using System;

namespace Project.Model
{
    public class Tablet : Device, IClone
    {
        public string AndroidVersion { get; set; }
        public string ScreenSize { get; set; }

        public Tablet()
        {
            AndroidVersion = "";
            ScreenSize = "";
        }

        private Tablet(string productId, string productName, decimal productPrice, int productStock,
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

        public override void Input(bool isEdit = false)
        {
            base.Input(isEdit);
            Console.Write("Nhập phiên bản hệ điều hành: ");
            AndroidVersion = Console.ReadLine();
            Console.Write("Nhập kích thước màn hình: ");
            ScreenSize = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Phiên bản hệ điều hành: {AndroidVersion}");
            Console.WriteLine($"Kích thước màn hình: {ScreenSize}");
        }

        // get format string and array of object
        public override object[] GetObjectArray()
        {
            return new object[]
            {
                GetDeviceType(),
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                AndroidVersion,
                ScreenSize,
                "", "", "", ""
            };
        }

        public Device Clone()
        {
            return new Tablet(
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                AndroidVersion,
                ScreenSize
            );
        }
    }
}