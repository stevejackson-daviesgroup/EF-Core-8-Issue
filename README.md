# Test project to replicate an issue with EF Core 8

<details>
  <summary>Create a SQL Server database called EF8_Issue_Testing, then run this SQL script to build the required tables and relationships:</summary>

```
USE [EF8_Issue_Testing]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 13/11/2024 15:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleId] [int] NULL,
	[FirstName] [nvarchar](32) NULL,
	[LastName] [nvarchar](32) NULL,
	[DefaultHomePageId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePage]    Script Date: 13/11/2024 15:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[RedirectPage] [int] NOT NULL,
	[OrganisationAdminOnly] [bit] NOT NULL,
 CONSTRAINT [PK_HomePage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 13/11/2024 15:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_HomePage] FOREIGN KEY([DefaultHomePageId])
REFERENCES [dbo].[HomePage] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_HomePage]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Title] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Title]
GO
```
</details>

<details>
  <summary>Run the code</summary>

  A console window will show the count of each data that is going to be written, and then read all the data back (of that entity type) and state how many were loaded from SQL server.  When all three entity types have been saved to the database the console will show the Long Debug view of the Entity Framework Change Tracker.

  At this point you should look at your SQL database and see that there are:

  - 3 Homepage rows
  - 2 Title rows
  - 4 Employee rows

  However, you will find that there are:

  - 3 Homepage rows
  - 2 Title rows
  - 3 Employee rows
    - One of these rows will also have a NULL TitleId!
</details>
