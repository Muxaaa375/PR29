using System;
using Microsoft.EntityFrameworkCore;


namespace PR29_Паксюаткин.Classes.Common
{
    public class Config
    {
        public static string ConnectionConfig = "server=127.0.0.1;port=3308;uid=root;pwd=;database=pr29;SslMode=None;";

        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
