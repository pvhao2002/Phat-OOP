namespace Project.Model
{
    public class SamSung : Device, IClone
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

        private SamSung(string productId, string productName, decimal productPrice, int productStock,
            string androidVersion, string cameraZoom, int yearOfManufacture) : base(productId, productName,
            productPrice, productStock)
        {
            AndroidVersion = androidVersion;
            CameraZoom = cameraZoom;
            YearOfManufacture = yearOfManufacture;
        }

        public override string GetDeviceType()
        {
            return "SamSung";
        }

        public override void Input(bool isEdit = false)
        {
            base.Input(isEdit);
            System.Console.Write("Nhập phiên bản hệ điều hành: ");
            AndroidVersion = System.Console.ReadLine();
            System.Console.Write("Nhập zoom camera: ");
            CameraZoom = System.Console.ReadLine();
            System.Console.Write("Nhập năm sản xuất: ");
            YearOfManufacture = int.Parse(System.Console.ReadLine() ?? string.Empty);
        }

        public override void Output()
        {
            base.Output();
            
            System.Console.WriteLine($"Phiên bản hệ điều hành: {AndroidVersion}");
            System.Console.WriteLine($"Zoom camera: {CameraZoom}");
            System.Console.WriteLine($"Năm sản xuất: {YearOfManufacture}");
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
                AndroidVersion,
                "",
                "",
                "",
                CameraZoom,
                YearOfManufacture
            };
        }

        public Device Clone()
        {
            return new SamSung(
                ProductId,
                ProductName,
                ProductPrice,
                ProductStock,
                AndroidVersion,
                CameraZoom,
                YearOfManufacture
            );
        }
    }
}