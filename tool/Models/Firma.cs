using System;
using System.Collections.Generic;

namespace tool.Models
{
    public partial class Firma
    {
        public int FirmaId { get; set; }
        public int KurssiId { get; set; }
        public string Ostaja { get; set; }
        public string YhtHenkilö { get; set; }
        public int? OstetutPaikat { get; set; }
        public int? Sitoutuminen { get; set; }
    }
}
