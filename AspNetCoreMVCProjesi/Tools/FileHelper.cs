namespace AspNetCoreMVCProjesi.Tools
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string klasorYolu = "/wwwroot/Img/")
        {
            string dosyaAdi = "";

            if (formFile != null && formFile.Length > 0) // gönderilen formfile(Resim dosyası) eğer boş değilse ve gönderilen dosyanın içi boş değilse
            {
                dosyaAdi = formFile.FileName; // dosyaAdi değişkenine gönderilen dosyanın adını aktardık
                string dizin = Directory.GetCurrentDirectory() + klasorYolu + dosyaAdi; // uygulamanın çalıştığı bilgisayardaki gerçek klasör yolunu bulduk
                using var stream = new FileStream(dizin, FileMode.Create); // stream isminde bir değişken oluşturduk .net core un FileStream sınıfını kullanarak dosyanın yükleneceği klasöre FileMode.Create ile yeni dosya oluşturacağımızı belirttik
                await formFile.CopyToAsync(stream); // Gönderilen formFile(resim) dosyasını CopyToAsync metoduyla sunucuya kopyaladık
            }

            return dosyaAdi; // Geriye yüklenen resmin adını döndürdük. Eğer resim yüklenemezse boş string gidecek.
        }

        public static bool FileRemover(string fileName, string klasorYolu = "/wwwroot/Img/")
        {
            string dizin = Directory.GetCurrentDirectory() + klasorYolu + fileName;

            if (File.Exists(dizin)) // File.Exists metodu kendisine verilen dizindeki dosya gerçekten var mı yok mu bunu kontrol eder
            {
                File.Delete(dizin); // File.Delete metodu dosyayı sunucudan siler
                return true; // Eğer silme başarılıysa geriye true dön
            }

            return false; // buraya düşmüşsek dosya silinememiştir geriye 
        }

    }
}
