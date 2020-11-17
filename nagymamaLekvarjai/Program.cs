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
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    meret INTEGER,
    tipus VACHAR(1000) NOT NULL
)
";
                createComm.ExecuteNonQuery();

                Console.WriteLine("adjon megy egy üvegmétetet.");
                var uvegMeret = Console.ReadLine();
                Console.WriteLine("adjon megy egy lekvártipust.");
                var lekvarTipus = Console.ReadLine();

                var insertComm = conn.CreateCommand();
                insertComm.CommandText = @"
INSERT INTO uvegek (meret, tipus)
VALUES ('@uvegMeret', '@lekvarTipus')
";
                insertComm.Parameters.AddWithValue("@uvegMeret", uvegMeret);
                insertComm.Parameters.AddWithValue("@lekvarTipus", lekvarTipus);
                insertComm.ExecuteNonQuery();

                var selectComm = conn.CreateCommand();

                createComm.CommandText = @"
SELECT meret, tipus 
FROM uvegek
WHERE 1
";
                using (var reader = createComm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int emeret = reader.GetInt32(0);
                        string etipus = reader.GetString(1);
                        Console.WriteLine("{1}-{2}",emeret,etipus);
                    }
                }

                createComm.CommandText = @"
SELECT SUM(meret)
FROM uvegek
WHERE 1
";
                using (var reader = createComm.ExecuteReader())
                {
                    var eszam = reader.GetInt32(0);
                }

                createComm.CommandText = @"
SELECT tipus, 
FROM uvegek
WHERE 1
";
                using (var reader = createComm.ExecuteReader())
                {
                    var eszam = reader.GetInt32(0);
                }

                createComm.CommandText = @"
SELECT AVG(SUM(meret))
FROM uvegek
WHERE 1
";
                using (var reader = createComm.ExecuteReader())
                {
                    var eszam = reader.GetInt32(0);
                }


                Console.ReadLine();
            }
        }
    }
}
