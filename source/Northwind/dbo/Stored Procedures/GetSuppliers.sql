
-- =============================================
-- Author:		Ligi
-- Create date: 2016/12/31
-- Description:	取得所有供應商
-- =============================================
CREATE PROCEDURE [dbo].[GetSuppliers]
AS
BEGIN
SELECT [SupplierID]
      ,[CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax]
      ,[HomePage]
  FROM [dbo].[Suppliers]
END