USE [dbClube]
GO
/****** Object:  StoredProcedure [dbo].[sp_cadParticipante]    Script Date: 14/04/2019 10:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_cadException]
(
	@Usuario varchar(15),
	@Mensagem varchar(50),
	@Detalhe varchar(5000)
)
as
insert into tbLogException (idLogin, dsErro, dsDetalhe) values (@Usuario, @Mensagem, @Detalhe);