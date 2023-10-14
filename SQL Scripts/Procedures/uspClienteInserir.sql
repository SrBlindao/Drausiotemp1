create  procedure uspClienteInserir
@Nome varchar(100),
@DataNascimento datetime,
@Sexo bit,
@LimiteCompra decimal(18,2)
as
begin
insert into tblCliente
(	
		Nome, 
		DataNascimento,	
		Sexo,
		LimiteCompra
)
values
(
	@Nome,
	@DataNascimento,
	@Sexo,
	@LimiteCompra
)

select @@IDENTITY as Retorno
end