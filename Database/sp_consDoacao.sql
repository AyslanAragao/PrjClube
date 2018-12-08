ALTER procedure sp_consDoacao
@nmParticipante varchar(100) = '',
@modoPagamento int = 0,
@dtDoacaoDE smalldatetime = '',
@dtDoacaoATE smalldatetime = ''
as
	select 
	nmParticipante as Nome,
	vlLancamento as Valor,
	dstipopagamento as Forma,
	dtPagamento as Data,
	convert(int, vlLancamento / 10) as Parcelas

	from tblancamento l 
				  join tbParticipante p on l.cdparticipante = p.cdParticipante
				  join tbTipoPagamento tl on l.cdTipoPagamento = tl.cdTipoPagamento
WHERE
('' = @nmParticipante or nmParticipante = @nmParticipante)
and(0 = @modoPagamento or tl.cdTipoPagamento = @modoPagamento)
and (('' = @dtDoacaoDE or '' = @dtDoacaoATE)
	 or
	 dtPagamento BETWEEN @dtDoacaoDE and @dtDoacaoATE)