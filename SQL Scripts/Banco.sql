USE [master]
GO
/****** Object:  Database [Drausio]    Script Date: 23/11/2023 09:19:03 ******/
CREATE DATABASE [Drausio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Drausio', FILENAME = N'E:\Programas\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Drausio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Drausio_log', FILENAME = N'E:\Programas\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Drausio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Drausio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Drausio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Drausio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Drausio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Drausio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Drausio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Drausio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Drausio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Drausio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Drausio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Drausio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Drausio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Drausio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Drausio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Drausio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Drausio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Drausio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Drausio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Drausio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Drausio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Drausio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Drausio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Drausio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Drausio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Drausio] SET RECOVERY FULL 
GO
ALTER DATABASE [Drausio] SET  MULTI_USER 
GO
ALTER DATABASE [Drausio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Drausio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Drausio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Drausio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Drausio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Drausio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Drausio', N'ON'
GO
ALTER DATABASE [Drausio] SET QUERY_STORE = OFF
GO
USE [Drausio]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [bit] NOT NULL,
	[LimiteCompra] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspClienteAlterar]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspClienteAlterar]

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
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorId]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspClienteConsultarPorId]
@IdCliente int
as
begin
Select IdCliente, Nome, DataNascimento, Sexo,LimiteCompra

from tblCliente

where IdCliente = @IdCliente

end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorNome]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspClienteConsultarPorNome]
@Nome varchar(100)
as
begin
Select IdCliente, Nome, DataNascimento, Sexo,LimiteCompra

from tblCliente

where Nome like '%' + @Nome + '%'

end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteExcluir]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspClienteExcluir]
@IdCliente int
as
begin
delete from tblCliente
where IdCliente = @IdCliente

select @IdCliente as Retorno
end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteInserir]    Script Date: 23/11/2023 09:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[uspClienteInserir]
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
GO
USE [master]
GO
ALTER DATABASE [Drausio] SET  READ_WRITE 
GO
