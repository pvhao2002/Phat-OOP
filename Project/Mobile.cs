using System;

namespace Project
{
    public class Mobile : Device
    {
        protected string Network { get; set; }
        protected string Os { get; set; }

        public Mobile()
        {
            Network = "";
            Os = "";
        }

        public Mobile(string productId, string productName, decimal productPrice, int productStock, string network,
            string os) : base(productId, productName, productPrice, productStock)
        {
            Network = network;
            Os = os;
        }

        public override string GetDeviceType()
        {
            return "Mobile";
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập mạng di động: ");
            Network = Console.ReadLine();
            Console.Write("Nhập hệ điều hành: ");
            Os = Console.ReadLine();
        }

        public override object[] GetTitle()
        {
            return new object[] { "Mã sản phẩm", "Tên sản phẩm", "Giá", "Tồn kho", "Mạng", "Hệ điều hành" };
        }

        public override string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10}";
        }

        public override object[] GetObjectArray()
        {
            return new object[] { ProductId, ProductName, ProductPrice, ProductStock, Network, Os };
        }
    }
}