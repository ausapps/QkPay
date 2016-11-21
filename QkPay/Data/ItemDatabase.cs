using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;
using QkPay.Models;

namespace QkPay.Data
{
    public class ItemDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public ItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            string query = "SELECT * FROM [User]";

            lock (locker)
            {
                return database.Query<Models.User>(query);
            }
        }

        public Models.User GetUser(string id)
        {
            lock (locker)
            {
                return database.Table<Models.User>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveUser(Models.User user)
        {
            lock (locker)
            {
                if (GetUser(user.Id) == null)
                {
                    return database.Insert(user);
                }
                else
                {
                    return database.Update(user);
                }
            }
        }

        public int DeleteUser(string id)
        {
            lock (locker)
            {
                return database.Delete<Models.User>(id);
            }
        }
    }
}

