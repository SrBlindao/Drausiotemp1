create procedure uspClienteConsultarPorNome
@Nome varchar(100)
as
begin
Select IdCliente, Nome, DataNascimento, Sexo,LimiteCompra

from tblCliente

where Nome like '%' + @Nome + '%'

end