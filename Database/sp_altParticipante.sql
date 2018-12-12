USE [dbClube]
GO
/****** Object:  StoredProcedure [dbo].[sp_altParticipante]    Script Date: 11/12/2018 22:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_altParticipante]
@cdParticipante int = 0,
@nmParticipante varchar(100) = '',
@dsApelido varchar(50) = '',
@nrDDD int = 0,
@nrTelefone int = 0,
@cdPartIndicador int = 0
as
update tbParticipante set nmParticipante = @nmParticipante, dsApelido = @dsApelido, nrDDD = @nrDDD, nrTelefone = @nrTelefone, cdPartIndicador = @cdPartIndicador
where
cdParticipante = @cdParticipante