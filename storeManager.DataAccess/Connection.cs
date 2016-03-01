using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using System.Configuration;
using storeManager.DataAccess;


namespace DataAccess
{
    public class Connection
    {
        public StoreManagerDBEntities GetContext()
        {
            StoreManagerDBEntities ctx = new StoreManagerDBEntities();

            return ctx;
        }
    }

    public sealed class StoreManagerDbContextSingleton
    {
        private static readonly StoreManagerDBEntities instance = new StoreManagerDBEntities();

        static StoreManagerDbContextSingleton() { }

        private StoreManagerDbContextSingleton() { }

        public static StoreManagerDBEntities Instance
        {
            get
            {
                if (instance == null)
                    return new StoreManagerDBEntities();
                return instance;
            }
        }
    }
}
