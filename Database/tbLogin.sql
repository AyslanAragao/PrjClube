create table tbLogin(
	cdLogin int identity(1,1) primary key not null,
	nmLogin varchar(15) not null,
	dsSenha varchar(100) not null,
	dtUltimoLogin smalldatetime
);


insert into tbLogin values('79988451395', '13298200', null)
