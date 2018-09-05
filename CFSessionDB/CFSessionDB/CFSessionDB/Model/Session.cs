using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CFSessionDB.Model
{
    class Session
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SessionTitle { get; set; }
        public string SessionDescription { get; set; }

        public Session()
        {

        }
        public Session(String SessionTitle, string SessionDescription)
        {
            this.SessionTitle = SessionTitle;
            this.SessionDescription = SessionDescription;
        }
    }
}
}
