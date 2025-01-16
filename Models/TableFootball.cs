using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCups.Models
{
    public class TableFootball
    {
        [Key]
        public int Id { get; set; }
        public int Stadiums_id { get; set; }
        public string Ateam1 { get; set; }
        public string Ateam2 { get; set; }
        public DateTime MatchTime { get; set; }

    }
}
