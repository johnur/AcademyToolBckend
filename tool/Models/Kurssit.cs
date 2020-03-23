using System;
using System.Collections.Generic;

namespace tool.Models
{
    public partial class Kurssit
    {
        public int KurssiId { get; set; }
        public string Nimi { get; set; }
        public int? PaikkojaVapaana { get; set; }
        public int? MinPaikat { get; set; }
        public DateTime? DlIlmoittautuminen { get; set; }
        public DateTime? DlValmistuminen { get; set; }
        public bool? Statuksen { get; set; }
        public string OpintoSuunnitelma { get; set; }
    }
}
