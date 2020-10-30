using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bgs.Bll
{
    public class FileSystemMultimediaService : IMultimediaService
    {       
        public string AddImage(IFormFile file)
        {
            var fileName = RandomString(10);
            var fileExtension = Path.GetExtension(file.FileName);
            var filePath = Path.Combine("c:\\UploadedFiles", $"{fileName}.{fileExtension}");
            using( var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return $"api/product/getImage?fileName={fileName}.{fileExtension}";
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
