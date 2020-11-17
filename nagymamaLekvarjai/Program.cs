using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagymamaLekvarjai
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SQLiteConnection("Data Source=mydb.db"))
            {
                conn.Open();

                var createComm = conn.CreateCommand();

                createComm.CommandText = @"
CREATE TABLE IF NOT EXISTS uvegek(
    id INT AUTO_INCREMENT PRIMARY KEY,
    meret INT,
    tipus VACHAR(1000) NOT NULL
)

";
                createComm.ExecuteNonQuery();

                var insertComm = conn.CreateCommand();
                insertComm.CommandText = @"
INSERT INTO uvegek (meret, tipus)
VALUES (500, 'szilva')
";
                insertComm.ExecuteNonQuery();

                

                Console.ReadLine();
            }
        }
    }
}
