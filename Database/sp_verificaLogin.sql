alter procedure sp_verificaLogin
(
	@login varchar(15),
	@senha varchar(100),
	@codigo int out
)
as
select @codigo = cdlogin from tblogin where nmlogin = @login and dssenha = @senha 