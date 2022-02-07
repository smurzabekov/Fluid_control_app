using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WaterTracker.Models;

namespace WaterTracker.Services
{
    class Repository<T> where T : IEntity, new()
    {
        private readonly SQLiteConnection _dataBase;
        public Repository(SQLiteConnection connection)
        {
            _dataBase = connection;
            _dataBase.CreateTable<T>();
        }
        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate) 
            => predicate is null 
            ? _dataBase.Table<T>() 
            : _dataBase.Table<T>().Where(predicate);
        public T GetItem(int id) => _dataBase.Get<T>(id);
        public int Add(T item) => _dataBase.Insert(item);
        public int Update(T item) => _dataBase.Update(item);
    }
}
