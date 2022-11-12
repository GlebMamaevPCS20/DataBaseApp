using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib.Access
{
    public class AccessDataBaseController
    {
        private string _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Delivery.accdb";

        /// <summary>
        /// Возвращает виртуальную таблицу по SQL-запросу из БД Access
        /// </summary>
        /// <param name="query">SQL-запрос</param>
        /// <returns></returns>
        public DataTable GetDataTable(string query)
        {
            DataTable table = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(table);
            }
            return table;
        }

        /// <summary>
        /// Для команд Delete, Insert, Update
        /// </summary>
        /// <param name="query"></param>
        public void ExecuteCommand(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Соединение не было установлено!");
                }
            }
        }
    }

}
