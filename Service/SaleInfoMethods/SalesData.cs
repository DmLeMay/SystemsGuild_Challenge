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

        public List<SalesAverageData> GetSalesAverages(string Zipcode, DateTime StartDate, DateTime EndDate)
        {
            List<SalesAverageData> SaleAverages = new List<SalesAverageData>();

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
                            SalesAverageData SaleData = new SalesAverageData();

                            SaleData.SalesAverage = Convert.ToDouble(reader["SalesAverage"]);
                            SaleData.PrevYearSameRange = Convert.ToDouble(reader["PrevYearSameRange"]);
                            SaleData.AllSalesAverage = Convert.ToDouble(reader["AllSalesAverage"]);
                            SaleData.AllSalesSameZip = Convert.ToDouble(reader["AllSalesSameZip"]);
                            
                            SaleAverages.Add(SaleData);
                        }
                    }
                }
            }

            return SaleAverages;
        }

    }
}
