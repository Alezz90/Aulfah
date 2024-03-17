namespace Aulfah.PL.Helper
{
    public class DucomentConfi
    {
        public static string DocumentUplod(IFormFile formFile, string FileName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", FileName);
            string fileName = $"{Guid.NewGuid()}{formFile.FileName}";
            string path = Path.Combine(folderPath, fileName);
            var fs = new FileStream(path, FileMode.Create);
            formFile.CopyTo(fs);
            return fileName;
        }
        public static void DocumentDelete(string filename, string Foldername)
        {
            //  string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", FileName);
            if (filename != null)
            {

            }
        }
    }
}
