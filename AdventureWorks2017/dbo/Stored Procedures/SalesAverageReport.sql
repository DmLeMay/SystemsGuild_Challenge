  CREATE Procedure [dbo].[SalesAverageReport]
  @Zipcode nvarchar(15),
  @StartDate DateTime,
  @EndDate DateTime

  AS
  /*
  -- Un-comment code below in order to test
  Declare @StartDate DateTime
  set @StartDate = '02/01/2013'

  Declare @EndDate DateTime
  set @EndDate = '02/02/2013'

  Declare @Zipcode nvarchar(15)
  set @Zipcode = '78400'
  */

  /* Created seperate variables for each additional statistic outside of basic in order to keep the final query more readable */

  --Get the Average Sale value for year prior from the end and start date with the same Zipcode 
  Declare @PrevYearSameRange money
  set @PrevYearSameRange = (Select AVG(h.TotalDue) 
						    from Sales.SalesOrderHeader h inner join Person.[Address] a 
							on h.BillToAddressID = a.AddressID
						    where (h.OrderDate >= DATEADD(year,-1 ,@StartDate) AND h.OrderDate <= DATEADD(year,-1 ,@EndDate))
							AND a.PostalCode = @Zipcode)
  
  --Get Average sale value for all data one year prior to selected range
  Declare @AllPrevYear money
  set @AllPrevYear = (Select AVG(h.TotalDue) 
						    from Sales.SalesOrderHeader h inner join Person.[Address] a 
							on h.BillToAddressID = a.AddressID
						    where (h.OrderDate >= DATEADD(year,-1 ,@StartDate) AND h.OrderDate <= DATEADD(year,-1 ,@EndDate)))

  --Get Average Sale value for all data
  Declare @AllSalesAverage money
  set @AllSalesAverage = (Select AVG(TotalDue) from Sales.SalesOrderHeader)

  --Get Average sale value for all data with same Zipcode that was passed in
  Declare @AllSalesSameZipcode money
  set @AllSalesSameZipcode = (Select AVG(TotalDue) 
							  from Sales.SalesOrderHeader h inner join Person.[Address] a 
							  on h.BillToAddressID = a.AddressID 
							  where a.PostalCode = @Zipcode)
  
  Select ISNULL(AVG(h.TotalDue), 0)  as SalesAverage, ISNULL(@PrevYearSameRange, 0) as PrevYearSameRange, 
		 ISNULL(@AllSalesAverage, 0) as AllSalesAverage, ISNULL(@AllSalesSameZipcode, 0) as AllSalesSameZip
  from Sales.SalesOrderHeader h inner join Person.[Address] a 
  on h.BillToAddressID = a.AddressID
  where (h.OrderDate >= @StartDate AND h.OrderDate <= @EndDate) AND a.PostalCode = @Zipcode