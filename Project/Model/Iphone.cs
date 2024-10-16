using System;

namespace Project.Model
{
    public class Iphone : Device, IClone
    {
        public string IosVersion { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }

        public Iphone()
        {
            IosVersion = "";
            Ram = "";
            Storage = "";
        }

        private Iphone(string productId, string productName, decimal productPrice, int productStock, string iosVersion,
            string ram, string storage) : base(productId, productName, productPrice,
            productStock)
        {
            IosVersion = iosVersion;
            Ram = ram;
            Storage = storage;
        }

        public override string GetDeviceType()
        {
            return "Iphone";
        }

        public override void Input(bool isEdit = false)
        {
            base.Input(isEdit);
            Console.Write("Nhập phiên bản hệ điều hành: ");
            IosVersion = Console.ReadLine();
            Console.Write("Nhập dung lượng Ram: ");
            Ram = Console.ReadLine();
            Console.Write("Nhập dung lượng bộ nhớ: ");
            Storage = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Phiên bản hệ điều hành: {IosVersion}");
            Console.WriteLine($"Dung lượng Ram: {Ram}");
            Console.WriteLine($"Dung lượng bộ nhớ: {Storage}");
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
                "",
                Ram,
                Storage,
                "", ""
            };
        }

        public Device Clone()
        {
            return new Iphone(
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                IosVersion,
                Ram,
                Storage
            );
        }
    }
}