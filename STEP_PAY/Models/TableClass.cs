using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Models
{
    public class TableClass
    {
        public int Id { get; set; } = new Random().Next(0,1000);
        public string Title { get; set; }
        public double Money { get; set; }
        public double Percent { get; set; }

    }
}
