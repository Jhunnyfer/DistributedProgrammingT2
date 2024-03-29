﻿using System.IO;

namespace DistributedProgrammingT2.Common.Herpers
{
    public class FilesHelper
    {
        public static bool UploadPhoto(MemoryStream stream, string folder, string name)
        {
            try
            {
                stream.Position = 0;
                var path = Path.Combine(Directory.GetCurrentDirectory(), folder, name);
                File.WriteAllBytes(path, stream.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}