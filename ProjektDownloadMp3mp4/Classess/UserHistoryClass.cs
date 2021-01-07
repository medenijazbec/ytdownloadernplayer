using SQLite;

namespace ProjektDownloadMp3mp4.Classess
{
    //[Table("Users")]
    public class UserHistoryClass
    {
        public UserHistoryClass()
        {
            Name = "Developers";
            Link = "https://www.youtube.com/watch?v=KMU0tzLwhbE&ab_channel=1doony4u";
        }

        public UserHistoryClass(string name, string link)
        {
            Name = name;
            Link = link;
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public bool CheckData()
        {
            return !Name.Equals("") || !Link.Equals("");
        }
    }
}
