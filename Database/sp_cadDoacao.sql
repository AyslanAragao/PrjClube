create procedure sp_cadDoacao
(
	@cdParticipante int,
	@vlDoacao numeric(10,2),
	@metodoPagamento int,
	@dtDoaca smalldatetime
)
as
insert into tbLancamento values (@cdParticipante, @metodoPagamento, @vlDoacao, getDate(), @dtDoaca);

