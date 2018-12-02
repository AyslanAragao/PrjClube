create procedure sp_cadParticipante
(
	@nmParticipante varchar(15),
	@dsApelido varchar(100),
	@nrDDD int,
	@nrTelefone int,
	@cdPartindicador int
)
as
insert into tbParticipante (nmParticipante, dsApelido, nrDDD, nrTelefone, cdPartIndicador) values (@nmParticipante, @dsApelido, @nrDDD, @nrTelefone, @cdPartindicador);