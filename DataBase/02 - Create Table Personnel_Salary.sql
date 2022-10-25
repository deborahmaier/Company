USE [Company]
GO

/****** Object:  Table [dbo].[Personnel_Salary]    Script Date: 25/10/2022 01:39:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personnel_Salary](
	[SalaryId] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelId] [int] NULL,
	[GrossIncome] [float] NULL,
	[Month] [int] NULL,
	[Year] [int] NULL,
	[WorkHours] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Personnel_Salary] PRIMARY KEY CLUSTERED 
(
	[SalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Personnel_Salary]  WITH CHECK ADD  CONSTRAINT [FK_Personnel_Salary_Table_2] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO

ALTER TABLE [dbo].[Personnel_Salary] CHECK CONSTRAINT [FK_Personnel_Salary_Table_2]
GO


