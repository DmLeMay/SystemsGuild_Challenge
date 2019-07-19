using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.SalesInfo
{
    public class SalesAverageData
    {
        public double SalesAverage { get; set; }
        public double AllSalesAverage { get; set; }
        public double AllSalesSameZip { get; set; }
        public double PrevYearSameRange { get; set; }        

        public SalesAverageData()
        {
            SalesAverage = 0;
            AllSalesAverage = 0;
            AllSalesSameZip = 0;
            PrevYearSameRange = 0;
        }
    }
}
