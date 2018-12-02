create procedure sp_delParticipante
(
	@cdParticipante int
)
as
delete from tbParticipante where cdParticipante = @cdParticipante;
