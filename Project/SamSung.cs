namespace Project
{
    public class SamSung : Mobile
    {
        public string AndroidVersion { get; set; }
        public string CameraZoom { get; set; }
        public int YearOfManufacture { get; set; }

        public SamSung()
        {
            AndroidVersion = "";
            CameraZoom = "";
            YearOfManufacture = 0;
        }

        public SamSung(string productId, string productName, decimal productPrice, int productStock, string network,
            string os, string androidVersion, string cameraZoom, int yearOfManufacture) : base(productId, productName,
            productPrice, productStock, network, os)
        {
            AndroidVersion = androidVersion;
            CameraZoom = cameraZoom;
            YearOfManufacture = yearOfManufacture;
        }

        public override string GetDeviceType()
        {
            return "SamSung";
        }

        public override object[] GetTitle()
        {
            return new object[]
            {
                "Mã sản phẩm", "Tên sản phẩm", "Giá", "Tồn kho", "Mạng", "Hệ điều hành", "Phiên bản Android",
                "Zoom camera", "Năm sản xuất"
            };
        }

        public override void Input()
        {
            base.Input();
            System.Console.Write("Nhập phiên bản hệ điều hành: ");
            AndroidVersion = System.Console.ReadLine();
            System.Console.Write("Nhập zoom camera: ");
            CameraZoom = System.Console.ReadLine();
            System.Console.Write("Nhập năm sản xuất: ");
            YearOfManufacture = int.Parse(System.Console.ReadLine() ?? string.Empty);
        }

        public override string GetFormatString()
        {
            return "{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-10} {8,-10}";
        }

        public override object[] GetObjectArray()
        {
            return new object[]
            {
                ProductId, ProductName, ProductPrice, ProductStock, Network, Os, AndroidVersion, CameraZoom,
                YearOfManufacture
            };
        }
    }
}