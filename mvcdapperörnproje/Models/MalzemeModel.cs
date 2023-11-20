using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdapperörnproje.Models
{
    public class MalzemeModel
    {
        public int malzemeNo {get; set;}
        public string malzemeAdi { get; set;}
        public string malzemeTutar {get; set;}
        
        public int hizmetNo { get; set;}    
    }
}