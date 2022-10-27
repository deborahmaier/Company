USE [Company]
GO

/****** Object:  Table [dbo].[Salary_Item]    Script Date: 26/10/2022 22:00:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Salary_Item](
	[SalaryId] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Salary_Item] PRIMARY KEY CLUSTERED 
(
	[SalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Salary_Item]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Item_Personnel_Salary1] FOREIGN KEY([SalaryId])
REFERENCES [dbo].[Salary] ([SalaryId])
GO

ALTER TABLE [dbo].[Salary_Item] CHECK CONSTRAINT [FK_Salary_Item_Personnel_Salary1]
GO

ALTER TABLE [dbo].[Salary_Item]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Item_Tax] FOREIGN KEY([TaxId])
REFERENCES [dbo].[Tax] ([TaxId])
GO

ALTER TABLE [dbo].[Salary_Item] CHECK CONSTRAINT [FK_Salary_Item_Tax]
GO


