using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSB
{
    public static class SqlLiteHelper
    {
        //public static string conStr = "Data Source=" + Environment.CurrentDirectory + "\\test.db;Initial Catalog=sqlite;";       
        public static DataTable ExecuteReader(string cmdText, string dataSource = ApplicationData.db)
        {
            SQLiteConnection con = null;
            try
            {
                string conStr = "Data Source=" + dataSource + ";Initial Catalog=sqlite;";
                con = new SQLiteConnection(conStr);
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = cmdText;
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(cmd);
                DataTable result = new DataTable();
                mAdapter.Fill(result);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static object ExecuteScalar(string cmdText, string dataSource = ApplicationData.db)
        {
            SQLiteConnection con = null;
            try
            {
                string conStr = "Data Source=" + dataSource + ";Initial Catalog=sqlite;";
                con = new SQLiteConnection(conStr);
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = cmdText;
                con.Open();
                object res = cmd.ExecuteScalar();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        public static int ExecuteNonQuery(string cmdText, string dataSource = ApplicationData.db)
        {
            SQLiteConnection con = null;
            try
            {
                string conStr = "Data Source=" + dataSource + ";Initial Catalog=sqlite;";
                con = new SQLiteConnection(conStr);
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = cmdText;
                con.Open();
                int res = cmd.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

    }
}
