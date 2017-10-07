using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayCottageManager.Shared
{
    public class Locomotive
    {
        [Key]
        public int id { get; set; }
        public int PartNumber { get; set; }
        public int Adress { get; set; }
        public string Name { get; set; }
        public string ProductLink { get; set; }
        public string Notes { get; set; }
    }
}
