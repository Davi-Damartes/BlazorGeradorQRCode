using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlazorGeradorQRCode.GeradorQRCodeService
{
    public static class GeradorDeQrCode
    {
        public static string GerarQrCodePelaUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url), "URL cannot be null or empty");
            }

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
