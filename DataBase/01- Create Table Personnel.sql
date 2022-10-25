USE [Company]
GO

/****** Object:  Table [dbo].[Personnel]    Script Date: 25/10/2022 01:39:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personnel](
	[PersonnelId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Surname] [nvarchar](40) NULL,
	[Birthdate] [datetime] NULL,
	[Adress] [nvarchar](200) NULL,
	[ZipCode] [nvarchar](8) NULL,
	[JoinedDate] [datetime] NULL,
	[WorkingHours] [int] NULL,
	[GrossIncome] [float] NULL,
	[Department] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


