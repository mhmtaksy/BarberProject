using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdapperörnproje.Models
{
    public class HizmetlerModel
    {
        public int hizmetNo { get; set; }

        public string hizmetAdi { get; set; }

        public string hizmetAmaci { get; set; }

        public string odemeTuru { get; set; }

        public int görevliNo { get; set; }
    }
}