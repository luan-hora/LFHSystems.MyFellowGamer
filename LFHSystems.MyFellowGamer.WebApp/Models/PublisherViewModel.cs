using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Models
{
    public class PublisherViewModel
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, set the publisher name")]
        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
