create table tbParticipante(
	cdParticipante int identity(1,1) primary key not null,
	nmParticipante varchar(100) not null,
	dsApelido varchar(50) not null,
	nrDDD varchar(3) not null,
	nrTelefone varchar(9) not null,
	cdPartIndicador int,
	dtEntrada smalldatetime,
	dtCadastro smalldatetime default getDate(),
	flGeraLogin bit
);

