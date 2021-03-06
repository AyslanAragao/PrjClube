USE [dbClube]
GO
/****** Object:  StoredProcedure [dbo].[sp_consDoacao]    Script Date: 16/12/2018 15:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_consDoacaoParcelada]
@cdLancamentoParcelado int = 0,
@cdLancamento int = 0,
@vlParcela int = 0,
@dtMesParcelaDE smalldatetime = '',
@dtMesParcelaATE smalldatetime = ''
as
	select 
	cdLancamentoParcelado
	,cdLancamento
	,vlParcela
	,dtMesParcela
	from tbLancamentoParcelado l 
				  
WHERE
(0 = @cdLancamentoParcelado or cdLancamentoParcelado = @cdLancamentoParcelado)
and(0 = @cdLancamento or cdLancamento = @cdLancamento)
and (('' = @dtMesParcelaDE or '' = @dtMesParcelaATE)
	 or
	 dtMesParcela BETWEEN @dtMesParcelaDE and @dtMesParcelaATE)