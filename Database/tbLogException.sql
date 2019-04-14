USE [dbClube]
GO

/****** Object:  Table [dbo].[tbLogException]    Script Date: 14/04/2019 10:19:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbLogException](
	[idExcecao] [int] IDENTITY(1,1) NOT NULL,
	[idLogin] [varchar](50) NOT NULL,
	[dsErro] [varchar](50) NOT NULL,
	[dsDetalhe] [varchar](5000) NOT NULL,
	[dtErro] [date] NOT NULL,
 CONSTRAINT [PK_tbLogException] PRIMARY KEY CLUSTERED 
(
	[idExcecao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbLogException] ADD  CONSTRAINT [DF_tbLogException_dtErro]  DEFAULT (getdate()) FOR [dtErro]
GO


