using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registerForm
{
    internal class ReportDetails
    {
        public int No {  get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double Amount { get { return Price * Qty; } }
        public ReportDetails() 
        {

        }
      


    }
}
