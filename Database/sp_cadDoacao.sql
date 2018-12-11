alter procedure sp_cadDoacao
(
	@cdParticipante int,
	@vlDoacao numeric(10,2),
	@metodoPagamento int,
	@dtDoaca smalldatetime
)
as
declare 
@cont int = 1,
@parcela int,
@maxdata smalldatetime,
@cdlancamento int


insert into tbLancamento values (@cdParticipante, @metodoPagamento, @vlDoacao, getDate(), @dtDoaca);

set @cdlancamento = @@identity

set @parcela = @vlDoacao/10

select @maxdata = max(dtmesparcela)
		from  tblancamentoParcelado lp 
		join tblancamento l on lp.cdlancamento = l.cdlancamento
		where l.cdparticipante = @cdParticipante



WHILE @cont < @parcela
BEGIN
if (@maxdata > getDate())
   insert into tblancamentoParcelado values (@cdlancamento, 10, DATEADD(month, @cont, @maxdata))
   else
    insert into tblancamentoParcelado values (@cdlancamento, 10, DATEADD(month, @cont, getDate()))

   SET @cont = @cont + 1;
END;


