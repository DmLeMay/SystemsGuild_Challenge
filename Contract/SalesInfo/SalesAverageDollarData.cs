using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.SalesInfo
{
    public class SalesAverageDollarData
    {
        public double SubTotalAverage { get; set; }
        public double TotalAverage { get; set; }
        public double AllAverageSameYear { get; set; }
        public double AllAveragePrevYear { get; set; }
        public double SalesAveragePrevMonthSameRange { get; set; }        

        public SalesAverageDollarData()
        {
            TotalAverage = 0;
            SubTotalAverage = 0;
            AllAverageSameYear = 0;
            AllAveragePrevYear = 0;
            SalesAveragePrevMonthSameRange = 0;
        }
    }
}
