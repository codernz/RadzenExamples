 
 
/****** Object:  Table [dbo].[Customers]    Script Date: 6/09/2021 7:27:34 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[GivenName] [nvarchar](50) NOT NULL,
	[MiddleInitial] [nvarchar](50) NULL,
	[Surname] [nvarchar](60) NOT NULL,
	[StreetAddress] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Age] [int] NOT NULL,
	[Company] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers_Staging]    Script Date: 6/09/2021 7:27:34 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers_Staging](
	[Customer_StagingID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[GivenName] [nvarchar](50) NULL,
	[MiddleInitial] [nvarchar](50) NULL,
	[Surname] [nvarchar](60) NULL,
	[StreetAddress] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Company] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers_Staging] PRIMARY KEY CLUSTERED 
(
	[Customer_StagingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerUpdate]    Script Date: 6/09/2021 7:27:34 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[usp_CustomerUpdate]
AS
BEGIN
	 
	SET NOCOUNT ON;
	 
INSERT INTO Customers
             ( Title, GivenName, MiddleInitial, Surname, StreetAddress, City, ZipCode, Country,Gender, EmailAddress, Age, Company)
SELECT   Title, isnull(GivenName,'n/a'), MiddleInitial, isnull(Surname,'n/a'), StreetAddress, isnull(City,'????'), ZipCode, Country, Gender, EmailAddress, isnull(Age,0), Company
FROM   Customers_Staging 

 
 delete from  [dbo].[Customers_Staging]

END
GO
