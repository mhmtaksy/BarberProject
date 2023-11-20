using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdapperörnproje.Models
{
    public class GörevliModel
    {
        public int görevliNo { get; set; }

        public string adSoyad {get; set; }
        public string Yas { get; set; }
        public string Tel { get; set; } 
        public string mesaiDurum { get; set; }  
        public decimal Maas { get; set; }
        public string Prim { get; set; }    
        public int salonNo { get; set; }
    }
}