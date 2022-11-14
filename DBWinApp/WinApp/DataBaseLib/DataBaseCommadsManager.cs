using DataBaseLib.Access;
using DataBaseLib.Commands;
using System.Data;

namespace DataBaseLib;

/// <summary>
/// Выполнение команд пользователя
/// </summary>
public class DataBaseCommadsManager
{


    public DataTable GetDataTable(string tableName)
    {
        BaseCommands command = new BaseCommands();        
        return command.GetDataTable(tableName);
    }

    public void Insert(string[] args, string tableName)
    {
        ITableEditorCommand command;
        switch(tableName)
        {
            case "Информация о клиенте": command = new Table1Commands();
                break;
            
            case "Приемы":
                command = new Table1Commands();
                break;
            default: throw new Exception("Ошибка!");
        }        
        command.Insert(args);
    }
    public void Delete(string[] args, string tableName)
    {
        ITableEditorCommand command;
        switch (tableName)
        {
            case "Информация о клиенте":
                command = new Table1Commands();
                break;
            case "Приемы":
                command = new Table1Commands();
                break;
            default: throw new Exception("Ошибка!");
        }
        command.Delete(args);

    }
    public void Update(string[] args, string tableName)
    {
        ITableEditorCommand command;
        switch (tableName)
        {
            case "Информация о клиенте":
                command = new Table1Commands();
                break;
            case "Приемы":
                command = new Table1Commands();
                break;
            default: throw new Exception("Ошибка!");
        }
        command.Update(args);

    }

    // Домашнее задание
    // 1. Дописать логику методов Update, Delete
    // 2. Продумать структуру БД по вариантам
    // 3. Использовать Access или SQLite

}
