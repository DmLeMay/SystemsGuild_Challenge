using System;
using System.Collections.Generic;
using Contract.SalesInfo;

namespace Service
{
    public interface ISalesData
    {
        List<SalesAverageDollarData> GetSalesAverages(string Zipcode, DateTime StartDate, DateTime EndDate);
    }
}