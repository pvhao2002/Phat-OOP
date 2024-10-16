using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Project.Model;

namespace Project.Helper
{
    public static class CsvHelper
    {
        public static List<Device> ReadCsv(string filePath)
        {
            var data = new List<Device>();
            try
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                    filePath).Replace(@"\bin\Debug", "");

                using (var reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("type")) continue;

                        var values = line.Split(',');
                        var type = values[0];
                        switch (type)
                        {
                            case "Ipad":
                                var ipad = new Ipad()
                                {
                                    ProductId = values[1],
                                    ProductName = values[2],
                                    ProductPrice = Convert.ToDecimal(values[3]),
                                    ProductStock = Convert.ToInt32(values[4]),
                                    IosVersion = values[5],
                                    ScreenSize = values[6]
                                };
                                data.Add(ipad);
                                break;
                            case "Iphone":
                                var iphone = new Iphone
                                {
                                    ProductId = values[1],
                                    ProductName = values[2],
                                    ProductPrice = Convert.ToDecimal(values[3]),
                                    ProductStock = Convert.ToInt32(values[4]),
                                    IosVersion = values[5],
                                    Ram = values[7],
                                    Storage = values[8]
                                };
                                data.Add(iphone);
                                break;
                            case "SamSung":
                                var samsung = new SamSung
                                {
                                    ProductId = values[1],
                                    ProductName = values[2],
                                    ProductPrice = Convert.ToDecimal(values[3]),
                                    ProductStock = Convert.ToInt32(values[4]),
                                    AndroidVersion = values[9],
                                    CameraZoom = values[10],
                                    YearOfManufacture = int.Parse(values[11])
                                };
                                data.Add(samsung);
                                break;

                            case "Tablet":
                                var tablet = new Tablet
                                {
                                    ProductId = values[1],
                                    ProductName = values[2],
                                    ProductPrice = Convert.ToDecimal(values[3]),
                                    ProductStock = Convert.ToInt32(values[4]),
                                    AndroidVersion = values[9],
                                    ScreenSize = values[6]
                                };
                                data.Add(tablet);
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"CsvHelper >> ReadCsv >> {e.Message} >> {e.StackTrace}");
            }

            return data;
        }

        public static bool WriteDataToCsv(string filePath, List<Device> data)
        {
            try
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                    filePath).Replace(@"\bin\Debug", "");
                using (var writer = new StreamWriter(path))
                {
                    // Ghi tiêu đề
                    writer.WriteLine(
                        "Type,ProductId,ProductName,ProductPrice,ProductStock,IosVersion,ScreenSize,Ram,Storage,AndroidVersion,CameraZoom,YearOfManufacture");

                    foreach (var device in data)
                    {
                        switch (device)
                        {
                            case Ipad ipad:
                                writer.WriteLine(
                                    $"{ipad.GetDeviceType()},{ipad.ProductId},{ipad.ProductName},{ipad.ProductPrice},{ipad.ProductStock},{ipad.IosVersion},{ipad.ScreenSize},,,,");
                                break;

                            case Iphone iphone:
                                writer.WriteLine(
                                    $"{iphone.GetDeviceType()},{iphone.ProductId},{iphone.ProductName},{iphone.ProductPrice},{iphone.ProductStock},{iphone.IosVersion},{iphone.Ram},{iphone.Storage},,");
                                break;

                            case SamSung samsung:
                                writer.WriteLine(
                                    $"{samsung.GetDeviceType()},{samsung.ProductId},{samsung.ProductName},{samsung.ProductPrice},{samsung.ProductStock},,,,,{samsung.AndroidVersion},{samsung.CameraZoom},{samsung.YearOfManufacture}");
                                break;

                            case Tablet tablet:
                                writer.WriteLine(
                                    $"{tablet.GetDeviceType()},{tablet.ProductId},{tablet.ProductName},{tablet.ProductPrice},{tablet.ProductStock},,{tablet.ScreenSize},,,{tablet.AndroidVersion},,");
                                break;
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"CsvHelper >> WriteDataToCsv >> {e.Message}");
                return false;
            }
        }
    }
}