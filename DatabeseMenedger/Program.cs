using DatabeseMenedger.Database;

namespace DatabeseMenedger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Db db = new Db();
            db.CrateDb("log; DROP  DATABASE IF  EXISTS Test;");
            db.CrateDb("log2");
            // db.CrateTable("users");
            // db.CrateTable("users2");
            // db.CrateTable("users3");
        }
    }
}