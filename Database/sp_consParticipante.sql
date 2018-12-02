

alter procedure sp_consParticipante
@Codigo int = 0,
@Nome varchar(100) = '',
@Apelido varchar(50) = '',
@DDD int = 0,
@Telefone int = 0,
@DtCadastro smalldatetime = '',
@DtEntrada smalldatetime = '',
@Indicador int = 0
as
Select p1.cdParticipante, p1.nmParticipante, p1.dsApelido, p1.nrDDD, p1.nrTelefone,p1.cdPartIndicador, p2.nmParticipante, p1.dtEntrada, p1.dtCadastro, p1.flGeraLogin

from tbParticipante p1
left join tbParticipante p2 on p1.cdPartIndicador = p2.cdParticipante

where
( 0 = @Codigo OR @Codigo = p1.cdParticipante) 
and ('' = @Nome OR p1.nmParticipante like '%'+@Nome+ '%') 
and ('' = @Apelido OR p1.dsApelido like '%'+@Apelido+ '%')
and (0 = @DDD OR @DDD = p1.nrDDD) 
and (0 = @Telefone OR @Telefone = p1.nrTelefone) 
and ('' = @DtCadastro OR @DtCadastro = p1.dtCadastro) 
and ('' = @DtEntrada OR @DtEntrada = p1.dtEntrada) 
and (0 = @Indicador OR @Indicador = p1.cdPartIndicador)

