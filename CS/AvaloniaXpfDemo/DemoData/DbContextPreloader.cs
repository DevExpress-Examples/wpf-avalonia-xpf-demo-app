#nullable disable
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace DevExpress.AvaloniaXpfDemo.DemoData;

static class DbContextPreloader<T> where T : DbContext, new() {
    static Task task;
    static DbContextPreloader() {
        Action action = null;
        if(ViewModelBase.IsInDesignMode) {
            action = () => { };
        }
        else {
            action = () => {
                var context = new T();
                var prop = typeof(T).GetProperties()
                    .Where(p => p.PropertyType.IsGenericType &&
                                p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                    .FirstOrDefault();
                if(prop == null)
                    return;
                var query = (IQueryable<object>)prop.GetValue(context, null);
                query.Count();
            };
        }
        task = new TaskFactory().StartNew(action);
    }
    public static Task Preload() {
        return task;
    }
}