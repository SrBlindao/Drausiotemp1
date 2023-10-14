create procedure uspClienteExcluir
@IdCliente int
as
begin
delete from tblCliente
where IdCliente = @IdCliente

select @IdCliente as Retorno
end