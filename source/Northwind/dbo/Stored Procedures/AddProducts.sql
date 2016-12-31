
-- =============================================
-- Author:		Ligi
-- Create date: 2015/12/31
-- Description:	新增產品
-- =============================================
CREATE PROCEDURE [dbo].[AddProducts]
	@ProductName nvarchar(40), @SupplierID int, @CategoryID int, @QuantityPerUnit nvarchar(20), @UnitPrice money,
	@UnitsInStock smallint, @UnitsOnOrder smallint, @ReorderLevel smallint, @Discontinued bit
AS
BEGIN
INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[SupplierID]
           ,[CategoryID]
           ,[QuantityPerUnit]
           ,[UnitPrice]
           ,[UnitsInStock]
           ,[UnitsOnOrder]
           ,[ReorderLevel]
           ,[Discontinued])
     VALUES
           (@ProductName
           ,@SupplierID
           ,@CategoryID
           ,@QuantityPerUnit
           ,@UnitPrice
           ,@UnitsInStock
           ,@UnitsOnOrder
           ,@ReorderLevel
           ,@Discontinued)
END