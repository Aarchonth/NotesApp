using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class DataPaths
    {
        public static readonly string BaseDir = AppContext.BaseDirectory;
        public static readonly string DataDir = Path.Combine(BaseDir, "data");
        public static readonly string UsersDir = Path.Combine(DataDir, "users");
        public static readonly string UsersFile = Path.Combine(UsersDir, "users.json");
        

        public DataPaths()
        {
            Directory.CreateDirectory(DataDir);
            Directory.CreateDirectory(UsersDir);

        }
    }
}
