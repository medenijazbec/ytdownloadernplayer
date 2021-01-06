using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektDownloadMp3mp4
{
    //[Table("Users")]
   public class UserHistoryClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }


        public UserHistoryClass() 
        {
            Name = "Developers";
            Link = "https://www.youtube.com/watch?v=KMU0tzLwhbE&ab_channel=1doony4u";


        }

        public UserHistoryClass(string _name, string _link)
        {

            this.Name = _name;
            this.Link = _link;
        }

        public bool CheckData()
        {
            if (!this.Name.Equals("") || !this.Link.Equals(""))
                return true;
            else
                return false;
        
        }

    }
}
