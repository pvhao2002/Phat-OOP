using System;

namespace Project
{
    public abstract class Device
    {
        protected string _productId;
        protected string _productName;
        protected decimal _productPrice;
        protected int _productStock; // tồn kho

        public string ProductId
        {
            get => _productId;
            set => _productId = value;
        }

        public string ProductName
        {
            get => _productName;
            set => _productName = value;
        }

        public decimal ProductPrice
        {
            get => _productPrice;
            set => _productPrice = value;
        }

        public int ProductStock
        {
            get => _productStock;
            set => _productStock = value;
        }

        protected Device()
        {
            ProductId = "";
            ProductName = "";
            ProductPrice = 0;
            ProductStock = 0;
        }

        public abstract string GetDeviceType();

        protected Device(string productId, string productName, decimal productPrice, int productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductStock = productStock;
        }

        public virtual void Input()
        {
            Console.Write("Nhập mã sản phẩm: ");
            ProductId = Console.ReadLine();
            Console.Write("Nhập tên sản phẩm: ");
            ProductName = Console.ReadLine();
            Console.Write("Nhập giá sản phẩm: ");
            ProductPrice = decimal.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Nhập số lượng sản phẩm: ");
            ProductStock = int.Parse(Console.ReadLine() ?? string.Empty);
        }

        public virtual void Output()
        {
            Console.WriteLine("===== Thông tin sản phẩm =====");
            Console.WriteLine("Mã sản phẩm: " + ProductId);
            Console.WriteLine("Tên sản phẩm: " + ProductName);
            Console.WriteLine("Giá sản phẩm: " + ProductPrice);
            Console.WriteLine("Số lượng sản phẩm: " + ProductStock);
        }

        // get format string and array of object

        public virtual object[] GetTitle()
        {
            return new object[] { "Mã SP", "Tên SP", "Giá", "Số lượng" };
        }

        public virtual string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10}";
        }

        public virtual object[] GetObjectArray()
        {
            return new object[] { ProductId, ProductName, ProductPrice, ProductStock };
        }

        public abstract Device Clone();
    }
}