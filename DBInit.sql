

/****** Object:  Table [dbo].[Customers]    Script Date: 18/12/2022 09:11:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[customerId] [nvarchar](9) NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](150) NULL,
	[phone] [nvarchar](50) NULL
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Groups](
	[groupCode] [int] NULL,
	[groupName] [nvarchar](150) NULL
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factories](
	[groupCode] [int] NULL,
	[factoryCode] [int] NULL,
	[factoryName] [nvarchar](50) NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FactoriesToCustomer](
	[groupCode] [int] NULL,
	[factoryCode] [int] NULL,
	[customerId] [nvarchar](9) NULL
) ON [PRIMARY]
GO







