namespace API.Services
{
    public static class ImageFileService
    {

        public static async Task AddImageAsync(IFormFile formfile,string filepath, string filename)
        {
           // string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
            string path = Path.Combine(Directory.GetCurrentDirectory(), filepath, filename);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await formfile.CopyToAsync(stream);
            }
        }


        public static void RemoveImage(string fileName)
        {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
