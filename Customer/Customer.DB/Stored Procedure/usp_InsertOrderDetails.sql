-- =============================================
-- Author:		Sachin Patil
-- Create date: 29-June-2023
-- Description:	To Insert order details
-- =============================================
CREATE PROCEDURE [dbo].[usp_InsertOrderDetails] 
@CustomerId UNIQUEIDENTIFIER,
@ProductName VARCHAR(100),
@PurchaseDate VARCHAR(1000)
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO [Order]
	SELECT
		NEWID()
	,	@CustomerId
	,	@ProductName
	,	CONVERT(DATETIME,@PurchaseDate,105) 

END