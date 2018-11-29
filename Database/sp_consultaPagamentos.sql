create procedure sp_consultaPagamentos
(
	@dtInicio smalldatetime,
	@dtFim smalldatetime
)
as

Select 
 dsApelido as Nome,
 'Pago' as Status,
 lp.vlParcela as Valor,
 l.dtPagamento as Data,
 tl.dsTipoPagamento as Forma,
 month(lp.dtMesParcela) as Mes,
 year(lp.dtMesParcela) as Ano

 from tbParticipante p
 left join tbLancamento l on p.cdParticipante = l.cdParticipante
 left join tbTipoPagamento tl on tl.cdTipoPagamento = l.cdTipoPagamento
 left join tblancamentoparcelado lp on l.cdlancamento = lp.cdlancamento

