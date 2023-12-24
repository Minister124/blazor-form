namespace Forms.Data.Utils
{
    public static class Utils
    { 
        public static string ApplicationDirectoryPath()
        {
            string directoryPath = @"D:\IIC\Application Development\Self\Database";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                return directoryPath;
            }
            else
            {
                return directoryPath;
            }
        }
        public static string ApplicationFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "FormData.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return filePath;
                }
                else
                {
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public static string HobbiesFilePath(){
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Hobbies.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return filePath;
                }
                else
                {
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }
    }
}
