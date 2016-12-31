-- =============================================
-- Author:		Ligi
-- Create date: 2016/12/31
-- Description:	取得所有產品
-- =============================================
CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
	SELECT [ProductID]
      ,[ProductName]
      ,[SupplierID]
      ,[CategoryID]
      ,[QuantityPerUnit]
      ,[UnitPrice]
      ,[UnitsInStock]
      ,[UnitsOnOrder]
      ,[ReorderLevel]
      ,[Discontinued]
	FROM [dbo].[Products]
END