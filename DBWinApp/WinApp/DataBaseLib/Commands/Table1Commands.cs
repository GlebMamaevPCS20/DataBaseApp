using DataBaseLib.Access;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib.Commands
{
    internal class Table1Commands : ITableEditorCommand
    {
        // ЕСЛИ нужна другая БД, просто меняем AccessDataBaseController
        // на нужную, например SQLiteDataBaseController
        // в следующей строке
        private AccessDataBaseController controller = new AccessDataBaseController();

        public void Select(string[] args)
        {

        }
        

        public void Insert(string[] args)
        {            
            string query = $"INSERT INTO [Информация о клиенте] " +
                    $"([ФИО], [Адресс], [Телефон], [Заказ]) " +
                    $"VALUES ('{args[0]}', '{args[1]}', '{args[2]}', '{args[3]}')";
            controller.ExecuteCommand(query);

        }

        public void Update(string[] args)
        {
            string query = @$"UPDATE [Информация о клиенте] 
                    SET [ФИО] = {args [1]}, [Адресс] = {args[2]},  [Телефон] = '{args[3]}', [Заказ] = '{args[4]}'  
                    WHERE [Код клиента] = {args[0]}";
            controller.ExecuteCommand(query);

            // дома

            /*
             string query = $"UPDATE [Категории] SET [Категория товара] = '{type}', " +
                    $"[Скидка %] = {discount} " +
                    $"WHERE [ID] = {id}"; 
             */
        }

        public void Delete(string[] args)
        {
            
            
            string query = $"DELETE FROM [Информация о клиенте] " +
                    $"WHERE [Код клиента] = {args[0]}";
            controller.ExecuteCommand(query);
           
            
        }


    }
}
