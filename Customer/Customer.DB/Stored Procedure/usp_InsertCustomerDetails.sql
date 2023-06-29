-- =============================================
-- Author:		Sachin Patil
-- Create date: 29-June-2023
-- Description:	To Insert customer details
-- =============================================
CREATE PROCEDURE [dbo].[usp_InsertCustomerDetails] 
@Name VARCHAR(100),
@City VARCHAR(50),
@Address VARCHAR(1000),
@PhoneNumber VARCHAR(100)
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO Customer
	SELECT
		NEWID()
	,	@Name
	,	@City
	,	@Address
	,	@PhoneNumber

END