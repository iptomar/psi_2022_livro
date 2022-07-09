using System;
using IronBarCode;

namespace QRCode_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode("https://www.youtube.com/watch?v=d-tx9D4a8dc&ab_channel=JovemDionisio", BarcodeEncoding.QRCode);
            barcode.AddAnnotationTextAboveBarcode("Abre");
            barcode.SaveAsPng("barcode.png");
        }
    }
}