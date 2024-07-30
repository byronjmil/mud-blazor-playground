// QRCodeService.cs
using QRCoder;
using System;
using System.IO;

public class QRCodeService
{
    public string GenerateQRCodeAsBase64(string text)
    {
        using (var qrGenerator = new QRCodeGenerator())
        {
            using (var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
            {
                using (var qrCode = new Base64QRCode(qrCodeData))
                {
                    string base64Image = qrCode.GetGraphic(20);
                    return base64Image;
                }
            }
        }
    }
}
