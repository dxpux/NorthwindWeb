

-- =============================================
-- Author:		Ligi
-- Create date: 2017/1/1
-- Description:	更新產品資料
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProducts]
	@ProductID int, @ProductName nvarchar(40), @SupplierID int, @CategoryID int, @QuantityPerUnit nvarchar(20),
	@UnitPrice money, @UnitsInStock smallint, @UnitsOnOrder smallint, @ReorderLevel smallint, @Discontinued bit
AS
BEGIN
UPDATE	[dbo].[Products]
SET		[ProductName] = @ProductName
		,[SupplierID] = @SupplierID
		,[CategoryID] = @CategoryID
		,[QuantityPerUnit] = @QuantityPerUnit
		,[UnitPrice] = @UnitPrice
		,[UnitsInStock] = @UnitsInStock
		,[UnitsOnOrder] = @UnitsOnOrder
		,[ReorderLevel] = @ReorderLevel
		,[Discontinued] = @Discontinued
WHERE	[ProductID] = @ProductID
END