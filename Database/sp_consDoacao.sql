ALTER procedure sp_consDoacao
@nmParticipante varchar(100) = '',
@modoPagamento int = 0,
@dtDoacaoDE smalldatetime = '',
@dtDoacaoATE smalldatetime = ''
as
	select 
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
('' = @nmParticipante or nmParticipante = @nmParticipante)
and(0 = @modoPagamento or tl.cdTipoPagamento = @modoPagamento)
and (('' = @dtDoacaoDE or '' = @dtDoacaoATE)
	 or
	 dtPagamento BETWEEN @dtDoacaoDE and @dtDoacaoATE)