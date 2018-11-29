create procedure sp_consDoacao
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