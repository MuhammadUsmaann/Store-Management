using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.IO;

namespace storeManager.BusinessLayer.Interfaces
{
    public class DBModel
    {
        public static SqlConnection Get_DB_SQL_Connection()
        {
            string connetionString = @"Data Source=" + RepositoryConfiguration.SERVERNAME + ";Initial Catalog=" + RepositoryConfiguration.DBNAME + ";User ID=" + RepositoryConfiguration.USERNAME + ";Password=" + RepositoryConfiguration.PASSWORD;
            SqlConnection connection = new SqlConnection(connetionString);
            return connection;
        }
        public static SQLiteConnection Get_DB_SQLite_Connection()
        {
            var DbFile  =  Environment.CurrentDirectory + "\\DB\\test.sqlite";
            if (!File.Exists(DbFile))
            {
                // Run Scripts here for tables

             //   var d = new SQLiteConnection("Data Source=" + DbFile) ;
            }
            SQLiteConnection connection = new SQLiteConnection(DbFile);
            return connection;
       }

        public void RunScript(string script)
        {
            string connetionString = @"Data Source=" + RepositoryConfiguration.SERVERNAME + ";Initial Catalog=" + RepositoryConfiguration.DBNAME + ";User ID=" + RepositoryConfiguration.USERNAME + ";Password=" + RepositoryConfiguration.PASSWORD;
            SQLiteConnection connection = new SQLiteConnection(connetionString);
            
        }
    }
}
