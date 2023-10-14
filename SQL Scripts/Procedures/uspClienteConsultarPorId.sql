create procedure uspClienteConsultarPorId
@IdCliente int
as
begin
Select IdCliente, Nome, DataNascimento, Sexo,LimiteCompra

from tblCliente

where IdCliente = @IdCliente

end