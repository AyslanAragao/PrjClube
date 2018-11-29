CREATE TABLE tbTipoPagamento(
cdTipoPagamento  int identity (1,1) not null,
dsTipoPagamento varchar(50),
);
CREATE TABLE tbLancamento(
	cdLancamento int identity (1,1) not null,
	cdParticipante int not null,
	cdTipoPagamento int ,
	vlLancamento numeric (10,2),
	dtLancamento smalldatetime default getDate(),
	dtPagamento smalldatetime
);


CREATE TABLE tbLancamentoParcelado(
	cdLancamentoParcelado int identity (1,1) not null,
	cdLancamento int not null,
	vlParcela numeric (10,2),
	dtMesParcela smalldatetime 
);



insert into tbTipoPagamento values ('Dinheiro');
insert into tbTipoPagamento values ('Conta');

insert into tbLancamento values (1,1, 30, getDate(), '20181001')

insert into tbLancamentoParcelado values (1, 10, '20181001')
insert into tbLancamentoParcelado values (1, 10, '20181101')
insert into tbLancamentoParcelado values (1, 10, '20181201')