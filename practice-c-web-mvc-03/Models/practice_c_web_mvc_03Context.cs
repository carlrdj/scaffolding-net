using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace practice_c_web_mvc_03.Models
{
    public class practice_c_web_mvc_03Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public practice_c_web_mvc_03Context() : base("name=practice_c_web_mvc_03Context")
        {
        }

        public System.Data.Entity.DbSet<practice_c_web_mvc_03.Models.MusGenre> MusGenres { get; set; }

        public System.Data.Entity.DbSet<practice_c_web_mvc_03.Models.MusArtist> MusArtists { get; set; }

        public System.Data.Entity.DbSet<practice_c_web_mvc_03.Models.MusSong> MusSongs { get; set; }
    }
}
