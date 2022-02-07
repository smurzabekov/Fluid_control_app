using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WaterTracker.Models;

namespace WaterTracker.Services
{
    interface IMangaer
    {
        List<T> GetItems<T>(Expression<Func<T, bool>> predicate = null) where T : IEntity, new();
        T GetItem<T>(int id) where T : IEntity, new();
        int Add<T>(T item) where T : IEntity, new();
        int Edit<T>(T item) where T : IEntity, new();
    }
}
