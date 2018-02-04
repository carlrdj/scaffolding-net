using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace practice_c_web_mvc_03.Models
{
    public class MusArtist
    {
        public int Id { get; set; }
        public int MusGenreId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual MusGenre Genre { get; set; }
        public virtual ObservableCollection<MusSong> Song { get; set; }
    }
}