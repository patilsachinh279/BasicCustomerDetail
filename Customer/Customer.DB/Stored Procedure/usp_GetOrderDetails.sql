-- =============================================
-- Author:		Sachin Patil
-- Create date: 29-June-2023
-- Description:	To get order details
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetOrderDetails]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		Id
	,	CustomerId
	,	ProductName
	,	PurchaseDate
	FROM
		[Order]
END
GO