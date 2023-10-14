create procedure uspClienteAlterar

@IdCliente int,
@Nome varchar(100),
@DataNascimento datetime,
@Sexo bit,
@LimiteCompra decimal(18,2)

as
begin
update tblCliente 
set 

Nome=@Nome,
DataNascimento=@DataNascimento,
Sexo=@Sexo,
LimiteCompra=@LimiteCompra

where IdCliente=@IdCliente

select @IdCliente as  Retorno

end