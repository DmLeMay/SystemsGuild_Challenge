using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Contract.SalesInfo;
using System.Data;


namespace Service.SaleInfoMethods
{    
    public class SalesData : ISalesData
    {
        private readonly string ConnectionString = "Server=SAPPHIRE-PC;Database=AdventureWorks2017;Trusted_Connection=True;";

        public List<SalesAverageDollarData> GetSalesAverages(string Zipcode, DateTime StartDate, DateTime EndDate)
        {
            List<SalesAverageDollarData> SaleAverages = new List<SalesAverageDollarData>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SalesAverageReport", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Zipcode", Zipcode);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesAverageDollarData SaleAverageData = new SalesAverageDollarData();

                            SaleAverageData.SubTotalAverage = Convert.ToDouble(reader["SubTotalAverage"]);
                            SaleAverageData.TotalAverage = Convert.ToDouble(reader["TotalAverage"]);
                            //SaleAverageData.SalesAveragePrevMonthSameRange = Convert.ToDouble(reader["AveragePrevMonthRange"]);
                            //SaleAverageData.AllSalesAverageSameYear = Convert.ToDouble(reader["AveragePrevMonthRange"]);
                            //SaleAverageData.AllSalesAveragePrevYear = Convert.ToDouble(reader["AllSalesAveragePrevYear"]);
                            SaleAverages.Add(SaleAverageData);
                        }
                    }
                }
            }

            return SaleAverages;
        }

    }
}
