

-- =============================================
-- Author:		Ligi
-- Create date: 2015/12/31
-- Description:	取得所有產品類型
-- =============================================
CREATE PROCEDURE [dbo].[GetCategories]
AS
BEGIN
SELECT [CategoryID]
      ,[CategoryName]
      ,[Description]
      ,[Picture]
  FROM [dbo].[Categories]
END