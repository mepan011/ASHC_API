using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class Exception
    {
        public int Id { get; set; }
        public string ExDesc { get; set; }
        public string ExSource { get; set; }
        public DateTime? ExDate { get; set; }
        public string FromStatement { get; set; }
        public string Status { get; set; }
    }
}
