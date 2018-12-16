ALTER procedure sp_consDoacao
@nmParticipante varchar(100) = '',
@modoPagamento int = 0,
@dtDoacaoDE smalldatetime = null,
@dtDoacaoATE smalldatetime = null
as
	select 
	l.cdLancamento,
	l.cdParticipante,
	nmParticipante,
	vlLancamento,
	dtPagamento,
	l.cdTipoPagamento,
	dstipopagamento,
	convert(int, vlLancamento / 10) as Parcelas
	--lp.cdLancamentoParcelado,
	--lp.vlParcela,
	--lp.dtMesParcela

	from tblancamento l 
				  join tbParticipante p on l.cdparticipante = p.cdParticipante
				  join tbTipoPagamento tl on l.cdTipoPagamento = tl.cdTipoPagamento
				  --left join tbLancamentoParcelado lp on l.cdLancamento = lp.cdLancamento
WHERE
('' = @nmParticipante or nmParticipante like '%' + @nmParticipante + '%')
and(0 = @modoPagamento or tl.cdTipoPagamento = @modoPagamento)
and (
	
	(@dtDoacaoDE is null or @dtDoacaoATE is null) or (dtPagamento BETWEEN @dtDoacaoDE and @dtDoacaoATE)
	
	)