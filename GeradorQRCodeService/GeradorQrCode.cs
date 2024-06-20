using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlazorGeradorQRCode.GeradorQRCodeService
{
    public static class GeradorQrCode
    {
        public static string GerarQrCodePelaUrl(string url)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var qrGerador = new QRCodeGenerator();
                var qrCodeData = qrGerador.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                var qRCode = new QRCode(qrCodeData);

                using (Bitmap qrCodeBitMap = qRCode.GetGraphic(20))
                {
                    qrCodeBitMap.Save(ms, ImageFormat.Png);
                    var byteImage = ms.ToArray();
                    return $"data:image/png;base64,{Convert.ToBase64String(byteImage)}";
                }
            }

        }
    }
}
