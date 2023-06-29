-- =============================================
-- Author:		Sachin Patil
-- Create date: 29-June-2023
-- Description:	To get customer details
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCustomerDetails]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		Id
	,	Name
	,	City
	,	Address
	,	PhoneNumber
	FROM
		Customer
END
GO