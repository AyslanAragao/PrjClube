USE [dbClube]
GO
/****** Object:  StoredProcedure [dbo].[sp_consDoacaoParcelada]    Script Date: 19/01/2019 06:56:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[sp_ConsultarTodasParcelasPorID]
@idUsuario int = 0
as
	select 
	 lp.cdLancamentoParcelado
	,lp.cdLancamento
	,lp.vlParcela
	,lp.dtMesParcela
	from tbLancamentoParcelado lp 
	join tbLancamento l on l.cdLancamento = lp.cdLancamento
	join tbParticipante p on p.cdParticipante = l.cdLancamento
				  
WHERE
(0 = @idUsuario or l.cdLancamento = @idUsuario)