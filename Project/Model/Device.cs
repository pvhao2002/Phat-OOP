using System;

namespace Project.Model
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

        public virtual void Input(bool isEdit = false)
        {
            if (!isEdit)
            {
                Console.Write("Nhập mã sản phẩm: ");
                ProductId = Console.ReadLine();
            }

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

        public string GetFormatString()
        {
            return "{0,-10} {1,-12} {2,-30} {3,-12} {4,-12} {5,-12} {6,-12} {7, -12} {8, -12} {9, -16} {10, -16}";
        }

        public object[] GetTitle()
        {
            return new object[]
            {
                "Loại", "Mã sản phẩm", "Tên sản phẩm", "Giá", "Số lượng",
                "OS", "Màn hình", "Ram", "Bộ nhớ", "Camera Zoom", "Năm sản xuất"
            };
        }

        public virtual object[] GetObjectArray()
        {
            return new object[] { ProductId, ProductName, ProductPrice, ProductStock };
        }
    }
}