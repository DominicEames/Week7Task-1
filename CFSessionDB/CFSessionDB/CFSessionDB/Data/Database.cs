using CFSessionDB.Model;
using CFSessionDB.Data;
using MarcTron.Plugin.MTSql;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CFSessionDB.Data
{
    
    public class Database
    {
        public SQLiteAsyncConnection CF_database { get; private set; }

        public Database()
        {
            CF_database = MTSql.Current.GetConnectionAsync("w7lab.db");
            CF_database = MTSql.Current.GetConnectionAsync("w7lab.bd");
            CF_database.CreateTableAsync<Session>().Wait();
            CF_database.InsertAsync(new Session { SessionTitle = "Microsoft", SessionDescription = "Azure" });
            CF_database.InsertAsync(new Session { SessionTitle = "Google", SessionDescription = "Android!" });
            CF_database.InsertAsync(new Session { SessionTitle = "Facebook", SessionDescription = "What's App" });
        }
        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return await CF_database.Table<Session>().ToListAsync();
        
        }
        public async Task AddSessionsAsync(Session newSession)
        {
            await CF_database.InsertAsync(newSession);

        }

    }
}
