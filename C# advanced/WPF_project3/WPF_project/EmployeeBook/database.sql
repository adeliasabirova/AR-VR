USE [EmployeeBook]
GO

/****** Object:  Table [dbo].[DepartamentCategory]    Script Date: 25.04.2021 12:02:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DepartamentCategory](
	[DepartamentID] [int] NOT NULL,
	[Description] [nchar](50) NULL,
 CONSTRAINT [PK_DepartamentCategory] PRIMARY KEY CLUSTERED 
(
	[DepartamentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [EmployeeBook]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 25.04.2021 12:02:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Job] [nvarchar](250) NULL,
	[DepartamentID] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_DepartamentCategory] FOREIGN KEY([DepartamentID])
REFERENCES [dbo].[DepartamentCategory] ([DepartamentID])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_DepartamentCategory]
GO

