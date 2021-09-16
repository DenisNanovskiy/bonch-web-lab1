using System;
using System.ComponentModel.DataAnnotations;


namespace laba1.Models
{
    public class WebPage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }


        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
    }
}
