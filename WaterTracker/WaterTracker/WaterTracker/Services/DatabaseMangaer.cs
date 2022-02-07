using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using WaterTracker.Models;

namespace WaterTracker.Services
{
    internal class DatabaseMangaer : IMangaer
    {
        private readonly SQLiteConnection _dataBase;
        public static readonly string connectionString = Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InternalDb");
        public DatabaseMangaer()
        {
            _dataBase = new SQLiteConnection(connectionString);
        }

        public List<T> GetItems<T>(Expression<Func<T, bool>> predicate = null) where T : IEntity, new()
        {
            return (new Repository<T>(_dataBase)).GetItems(predicate).ToList();
        }
        public T GetItem<T>(int id) where T : IEntity, new()
        {
            return  (new Repository<T>(_dataBase)).GetItem(id);
        }
        public int Add<T>(T item) where T : IEntity, new()
        {
            return (new Repository<T>(_dataBase)).Add(item);
        }

        public int Edit<T>(T item) where T : IEntity, new()
        {
            return (new Repository<T>(_dataBase)).Update(item);
        }
    }
}
