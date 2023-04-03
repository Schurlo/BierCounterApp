using _23._03._10_MAUI_BierApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._03._10_MAUI_BierApp.Service
{
    public static class BierService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "BierData");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Bier>();
        }

        public static async Task AddBier(Bier bier)
        {
            await Init();

            await db.InsertAsync(bier);
        }

        public static async Task UpdateBier(Bier bier)
        {
            await Init();

            await db.UpdateAsync(bier);
        }

        public static async Task RemoveBier(int id)
        {
            await Init();
            await db.DeleteAsync<Bier>(id);
        }

        public static async Task<IEnumerable<Bier>> GetBier()
        {
            await Init();

            var bier = await db.Table<Bier>().ToListAsync();
            return bier;
        }


    }
}
