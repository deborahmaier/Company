USE [Company]
GO

/****** Object:  Table [dbo].[Salary]    Script Date: 26/10/2022 22:00:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Salary](
	[SalaryId] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[GrossIncome] [decimal](18, 2) NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Personnel_Salary] PRIMARY KEY CLUSTERED 
(
	[SalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Personnel_Salary_Table_2] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO

ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Personnel_Salary_Table_2]
GO


