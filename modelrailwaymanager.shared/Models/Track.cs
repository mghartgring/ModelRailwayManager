using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HolidayCottageManager.Shared
{
    public class Track
    {
        [Key]
        public int PartNumber { get; set; }
        public int Count { get; set; }
    }
}
