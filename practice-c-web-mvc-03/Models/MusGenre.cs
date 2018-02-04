using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace practice_c_web_mvc_03.Models
{
    public class MusGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual ObservableCollection<MusArtist> Artist { get; set; }
    }
}