create procedure sp_cadParticipante
(
	@nmParticipante varchar(15),
	@dsApelido varchar(100),
	@nrDDD int,
	@nrTelefone int
)
as
insert into tbParticipante (nmParticipante, dsApelido, nrDDD, nrTelefone) values (@nmParticipante, @dsApelido, @nrDDD, @nrTelefone);