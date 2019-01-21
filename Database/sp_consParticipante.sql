

alter procedure sp_consParticipante
@cdParticipante int = 0,
@nmParticipante varchar(100) = '',
@dsApelido varchar(50) = '',
@nrDDD int = 0,
@nrTelefone int = 0,
@DtCadastroDE smalldatetime = '',
@DtCadastroATE smalldatetime = '',
@DtEntradaDE smalldatetime = '',
@DtEntradaATE smalldatetime = '',
@cdPartIndicador int = 0
as
Select p1.cdParticipante, p1.nmParticipante, p1.dsApelido, p1.nrDDD, p1.nrTelefone,p1.cdPartIndicador, p2.nmParticipante as nmIndicador, p1.dtEntrada, p1.dtCadastro, p1.flGeraLogin

from tbParticipante p1
left join tbParticipante p2 on p1.cdPartIndicador = p2.cdParticipante

where
( 0 = @cdParticipante OR @cdParticipante = p1.cdParticipante) 
and ('' = @nmParticipante OR p1.nmParticipante like '%'+@nmParticipante+ '%') 
and ('' = @dsApelido OR p1.dsApelido like '%'+@dsApelido+ '%')
and (0 = @nrDDD OR @nrDDD = p1.nrDDD) 
and (0 = @nrTelefone OR @nrTelefone = p1.nrTelefone) 

and (('' = @DtCadastroDE OR '' = @DtCadastroATE) or 
		p1.dtCadastro between @DtCadastroDE and @DtCadastroATE) 

and (('' = @DtEntradaDE OR '' = @DtEntradaATE) 
or p1.dtEntrada between @DtEntradaDE and @DtEntradaATE) 

and (0 = @cdPartIndicador OR @cdPartIndicador = p1.cdPartIndicador)

