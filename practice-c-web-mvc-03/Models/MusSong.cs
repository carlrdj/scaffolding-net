using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practice_c_web_mvc_03.Models
{
    public class MusSong
    {
        public int Id { get; set; }
        public int MusArtistId { get; set; }
        public string Name { get; set; }
        //[Required]
        //[MaxLenght(10)]
        public float Time { get; set; }
        public int Status { get; set; }
        public virtual MusArtist Artist { get; set; }
    }
}