using NETSWAGApp.models;
using NuGet.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETSWAGApp.data
{
    public class OrderingItemDatabase
    {
            static SQLite.SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<OrderingItemDatabase> instance = new AsyncLazy<OrderingItemDatabase>(async () =>
             {
                 var instance = new OrderingItemDatabase();
                 CreateTableResult result = await Database.CreateTableAsync<OrderingItem>();
                 return instance;
             });

        public static AsyncLazy<OrderingItemDatabase> Instance => instance;

        public OrderingItemDatabase()
            {
                Database = new SQLiteAsyncConnection(Constant.DatabasePath, Constant.Flags);
            }

        public Task<List<OrderingItem>> GetItemsAsync()
            {
                return Database.Table<OrderingItem>().ToListAsync();
            }

            public Task<List<OrderingItem>> GetItemsNotDoneAsync()
            {
                return Database.QueryAsync<OrderingItem>("SELECT * FROM [OrderingItem] WHERE [Done] = 0");
            }

            public Task<OrderingItem> GetItemAsync(int id)
            {
                return Database.Table<OrderingItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
            }

            public Task<int> SaveItemAsync(OrderingItem item)
            {
                if (item.ID != 0)
                {
                    return Database.UpdateAsync(item);
                }
                else
                {
                    return Database.InsertAsync(item);
                }
            }

            public Task<int> DeleteItemAsync(OrderingItem item)
            {
                return Database.DeleteAsync(item);
            }
        
    }
}
