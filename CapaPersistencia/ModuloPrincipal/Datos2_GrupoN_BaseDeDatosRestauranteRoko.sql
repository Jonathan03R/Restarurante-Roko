---            Integrantes.

--	ROQUE GONZALES, Jonathan Jesús

--==========================================================================================
--									Base de Datos
--								Restaurante "ROKO"
--==========================================================================================

--Todo lo puse en el disco local C por que no tenngo disco D ni E 

xp_create_subdir 'C:\Base'
go
xp_create_subdir 'C:\Empresa'
go
xp_create_subdir 'C:\Reportes'
go

-- Crear BD
create database BDRestauranteRoko
	on primary
	(name = 'Restaurante01', filename ='C:\Base\Restaurante01.mdf',
		size = 50MB, maxsize = 30GB, filegrowth = 100MB),
	(name = 'Restaurante02', filename ='C:\Base\Restaurante02.ndf',
		size = 50MB, maxsize = 30GB, filegrowth = 100MB),
	filegroup administracion
	(name = 'EmpresaEmpleados01', filename ='C:\Empresa\EmpresaEmpleados01.ndf',
		size = 30MB, maxsize = 80GB, filegrowth = 100MB),
	(name = 'EmpresaEmpleados02', filename ='C:\Reportes\EmpresaEmpleados02.ndf',
		size = 80MB,  filegrowth = 100MB),
	filegroup comercial
	(name = 'EmpresaComercial01', filename ='C:\Empresa\EmpresaComercial01.ndf',
		size = 30MB, maxsize = 80GB, filegrowth = 100MB),
	(name = 'EmpresaComercial02', filename ='C:\Reportes\EmpresaComercial02.ndf',
		size = 80MB,  filegrowth = 100MB)
	log on
	(name = 'RestauranteLog01', filename ='C:\Reportes\RestauranteLog01.ldf',
		size = 80MB,  filegrowth = 100MB)
go

use BDRestauranteRoko
go


--==========================================================================================
--										Esquemas
--==========================================================================================

create schema Restaurante 
go

--==========================================================================================
--											TABLAS
--==========================================================================================
-- ==========================================================================================
-- Tabla Usuarios
-- Descripción: Almacena la información de los usuarios del sistema, incluyendo roles y estados.
-- ==========================================================================================
create table Restaurante.Usuarios
(
    UsuariosCodigo nchar(8), -- Código único del usuario, clave primaria.
    UsuariosNombre nvarchar(100) not null, -- Nombre del usuario.
    UsuariosCorreo nvarchar(100) not null unique, -- Correo único del usuario.
    UsuariosContrasena nvarchar(256) not null, -- Contraseña encriptada.
    UsuariosEstado nchar(1) constraint UsuariosEstadoDF default 'A', -- 'A' = Activo, 'I' = Inactivo.
    
    -- Restricciones
    constraint UsuariosPK primary key (UsuariosCodigo),
    constraint UsuariosEstadoCK check (UsuariosEstado in ('A', 'I')), -- Solo estados válidos.
) on administracion;
go


 -- Insertar: dos usuarios
--    administrador     Password = 4862
---    Encriptado: 3713bdda7149579475f3734e8bd0e14a
--  asistente   Password = 741
---    Encriptado:  2e65f2f2fdaf6c699b223c61b1b5ab89
INSERT INTO Restaurante.Usuarios 
    (UsuariosCodigo, UsuariosNombre, UsuariosCorreo, UsuariosContrasena, UsuariosEstado)
VALUES
    ('US000001', 'administrador', 'admin@gmail.com', '3713bdda7149579475f3734e8bd0e14a', 'A'),
    ('US000002', 'asistente', 'asistente@gmail.com', '2e65f2f2fdaf6c699b223c61b1b5ab89', 'A');
GO


--==========================================================================================
-- Tabla Mesas
-- Descripción: Define las mesas del restaurante y su estado (vacía, ocupada o reservada)
--==========================================================================================

create table Restaurante.Mesas
  (
  MesasCodigo		nchar(8),
  MesasCapacidad	nvarchar(10) not null,
  MesasEstado		nchar(1) constraint MesasEstadoDF default 'V', -- V significa que la mesa esta vacia y la "O" significa mesa ocupada y si es "R" Significa que la mesa esta reservada.

  constraint MesasPK primary key (MesasCodigo),
  constraint MesasEstadoCK Check 
		(MesasEstado = 'V' or MesasEstado = 'O' or MesasEstado =  'R')
  ) on administracion
go

--==========================================================================================
-- Tabla Clientes
-- Descripción: Almacena la información de los clientes registrados en el sistema.
--==========================================================================================
create table Restaurante.Clientes
  (
  ClientesCodigo nchar(8),
  ClientesNombre nvarchar(100) not null,
  ClientesApellidos nvarchar(100) not null,
  ClientesNombreCompleto As Upper(concat_ws(Space(1),ClientesApellidos, ClientesNombre)),
  ClientesTelefono nvarchar(12),
  ClientesDNI nchar(8) not null,
  ClientesCorreo nvarchar(50) unique,  --- este campo es unique por que los correo electronicos son unicos      
  ClientesFechaRegistro date constraint ClientesFechaRegistroDF default getdate(),
  ClientesEstado nvarchar(50) constraint ClientesEstadoDF default 'A',
  constraint ClientesPK primary key (ClientesCodigo),
  constraint ClientesEstadoCK check (ClientesEstado = 'A' or ClientesEstado = 'E' )
  ) on comercial
go




--==========================================================================================
-- Tabla RolesPermisos
-- Descripción: Define los roles y permisos de los usuarios en el sistema.
--==========================================================================================
create table Restaurante.RolesPermisos
(
    RolesPermisosCodigo nchar(8),
    RolesPermisosNombreRol nvarchar(100) not null,
    RolesPermisosDescripcion nvarchar(100) not null,
    RolesPermisosEstado nchar(1) constraint RolesPermisosEstadoDF default 'A', -- 'A' = Activo, 'E' = Eliminado
    constraint RolesPermisosCodigoPK primary key (RolesPermisosCodigo),
    constraint RolesPermisosEstadoCK check (RolesPermisosEstado = 'A' or RolesPermisosEstado = 'E')
) on administracion
go



-- Tabla Empleados

--esta tabla pusimos los campos calculados para poder obtener la fecha exacta de los dias que a trabajado un empleado.


create table Restaurante.Empleados
  (
  EmpleadosCodigo nchar(8),
  EmpleadosRolesPermisosCodigo nchar(8),
  EmpleadosPaterno nvarchar(80) not null,
  EmpleadosMaterno nvarchar(80) not null,
  EmpleadosNombres nvarchar(80) not null,
  EmpleadosNombreCompleto As Upper(concat_ws(Space(1),EmpleadosPaterno, EmpleadosMaterno,EmpleadosNombres)),
  EmpleadosTelefono nvarchar(12),
  EmpleadosEstado nchar(1)  constraint EmpleadosEstadoDF Default 'A',-- 'A' = Activo, 'E' = Eliminado
  EmpleadosSexo nchar(1),
  EmpleadosHoraEntreada nchar(5),
  EmpleadosSalario numeric(10,2) constraint EmpleadosSalarioDF default 0,
  EmpleadosFechaContratacion date constraint EmpleadoFechaContratacionDF default getdate(),

  -- Cálculo de años trabajados
  EmpleadosAniosAntiguedad As
  (
    iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
        Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
        Datediff(YEAR, EmpleadosFechaContratacion, GetDate()))
  ),
  
  -- Cálculo de meses trabajados
  EmpleadosMesesAntiguedad As
  (
    iif (
      DateAdd (
        MONTH, DateDiff(MONTH,
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion), 
        GetDate()), 
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion)) > GetDate(),
      DateDiff(MONTH,
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion),
        GetDate()) - 1,
      DateDiff(MONTH,
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion),
        GetDate()))
  ),

  -- Cálculo de días trabajados
  EmpleadosDiasAntiguedad As
  (
    DateDiff(DAY,
      DateAdd(MONTH, 
        iif(DateAdd(MONTH, DateDiff(MONTH, 
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion), 
        GetDate()), 
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion)) > GetDate(),
      DateDiff(MONTH, 
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion), GetDate()) - 1,
      DateDiff(MONTH, 
        Dateadd(YEAR, 
          iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
          Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion), GetDate())), 
      DateAdd(YEAR, 
        iif(Dateadd(YEAR, Datediff(YEAR, EmpleadosFechaContratacion, GetDate()), EmpleadosFechaContratacion) > GetDate(),
        Datediff(YEAR, EmpleadosFechaContratacion, GetDate()) - 1,
        Datediff(YEAR, EmpleadosFechaContratacion, GetDate())), EmpleadosFechaContratacion)), 
      GetDate())
  ),

  
  constraint EmpleadosPK primary key (EmpleadosCodigo),
  constraint EmpleadosRolesPermisosCodigoFK foreign key (EmpleadosRolesPermisosCodigo) references Restaurante.RolesPermisos (RolesPermisosCodigo),
  constraint EmpleadosEstadoCK check (EmpleadosEstado = 'A' or EmpleadosEstado = 'E'),
  constraint EmpleadosSexoCK check (EmpleadosSexo = 'F' or EmpleadosSexo = 'M')
  ) on administracion
go

--==========================================================================================
-- Tabla Menu
-- Descripción: Contiene los productos del menú del restaurante.
--==========================================================================================
create table Restaurante.Menu
  (
  MenuCodigo nchar(8),
  MenuNombre varchar(50),
  MenuDescripcion nvarchar(100),
  MenuPrecio numeric(9,2) constraint MenuPrecioDF default 10,
  MenuEstado nchar(1) constraint MenuEstadoDF default 'A', -- 'A' = Activo, 'E' = Eliminado
  MenuFoto image,
  
  constraint MenuPK primary key (MenuCodigo),
  constraint MenuEstadoCK check (MenuEstado = 'A' or MenuEstado = 'E')
  ) on administracion
go

--==========================================================================================
-- Tabla MesaReservas
-- Descripción: Registra las reservas hechas para las mesas del restaurante.
--==========================================================================================

create table Restaurante.MesaReservas
  (
  ReservasCodigo nchar(8),
  ReservasClientesCodigo nchar(8), -- clave foranea que hace referencia a la tabla Clientes
  ReservasMesasCodigo nchar(8),    -- clave foranea que hace referencia a la tabla Mesas

  ReservasEstado nchar(1) constraint ReservasEstadoDF default 'A', -- Estados: 'A' (Activo), 'C' (Cancelado), 'P' (Pendiente), 'E' (Expirada), 'F' (Finalizada)
  
  ReservasFechaHoraReserva datetime constraint ReservaFechaHoraReservaDF default getdate(),
  constraint ReservasPK primary key (ReservasCodigo),
  constraint ReservasMesasFK foreign key (ReservasMesasCodigo) references Restaurante.Mesas(MesasCodigo),
  constraint ReservasClientesFK foreign key (ReservasClientesCodigo) references Restaurante.Clientes(ClientesCodigo),
  constraint ReservasEstadoCK check (ReservasEstado in ('A', 'C', 'P', 'E', 'F'))
  ) on comercial
go



--==========================================================================================
-- Tabla Pedidos
-- Descripción: Registra los pedidos de los clientes en el restaurante.
--==========================================================================================
create table Restaurante.Pedidos
  (
  PedidosCodigo nchar(8),
  PedidosMesasCodigo nchar(8),
  PedidosEmpleadosCodigo nchar(8),
  PedidoFecha date default getdate(),
  PedidosEstado nchar(1) constraint PedidosEstadoDF default 'P', -- 'P' = Pendiente, 'C' = Completado
  constraint PedidosCodigoPK primary key (PedidosCodigo),
  constraint PedidosMesasCodigoFK foreign key(PedidosMesasCodigo) references Restaurante.Mesas(MesasCodigo),
  constraint PedidosEmpleadosCodigoFK foreign key(PedidosEmpleadosCodigo) references Restaurante.Empleados(EmpleadosCodigo),
  constraint PedidosEstadoCK check (PedidosEstado = 'P' or PedidosEstado = 'C') 
  ) on comercial
go

--==========================================================================================
-- Tabla DetallesPedido
-- Descripción: Almacena los detalles de los productos pedidos por los clientes.
--==========================================================================================
create table Restaurante.DetallesPedido
   (
   DetallesPedidoCodigo nchar(8),
   DetallesPedidoPedidosCodigo nchar(8),
   DetallesPedidoMenuCodigo nchar(8),
   DetallesPedidoPrecio numeric(9,2),
   DetallesPedidoCantidad numeric(9,2),
   DetallesPedidoEstado nchar(1) not null constraint DetallesPedidoEstadoDF default 'P', -- 'P' = Pendiente, 'S' = Servido
   constraint DetallePedidoCodigoPK primary key (DetallesPedidoCodigo),
   constraint DetallesPedidoPedidosCodigoFK foreign key (DetallesPedidoPedidosCodigo) references Restaurante.Pedidos(PedidosCodigo),
   constraint DetallesPedidoMenuCodigoFK foreign key (DetallesPedidoMenuCodigo) references Restaurante.Menu(MenuCodigo),
   constraint DetallesPedidoEstadoCK check (DetallesPedidoEstado = 'P' or DetallesPedidoEstado = 'S')
   )on comercial
go


--==========================================================================================
-- Tabla Pagos
-- Descripción: Registra los pagos realizados por los clientes.
--==========================================================================================
create table Restaurante.Pago
  (
  PagoCodigo nchar(8),
  PagoPedidoCodigo nchar(8),
  PagoMonto numeric(10,2),
  PagoFechaPago date,
  PagoEstado nchar(1) constraint PagoEstadoDF default 'P', -- 'P' = Pendiente, 'C' = Completado
  constraint PagoCodigoPK primary key (PagoCodigo),
  constraint PagoPedidoCodigoFK foreign key (PagoPedidoCodigo) references Restaurante.Pedidos(PedidosCodigo),
  constraint PagoEstadoCK check (PagoEstado = 'P' or PagoEstado = 'C') 
  )on comercial
go



-- Tabla de Boletas
create table Restaurante.Boletas
(
    RestauranteBoletasCodigo nchar(8),
    RestauranteBoletasPedidosCodigo nchar(8) not null,
    RestauranteBoletasEmpleadosCodigo nchar(8) not null,
    RestauranteBoletasClientesCodigo nchar(8) not Null,
    RestauranteBoletasFechaHora date not null,
    RestauranteBoletasTotal numeric(10,2) not null,
	-- campo desnormalizado
	RestauranteBoletasClienteNombreCompleto nvarchar(200), 
    RestauranteBoletasEstado nchar(1) constraint RestauranteBoletasEstadoDF default 'E', -- 'E' = Emitida
    constraint RestauranteBoletasPK primary key (RestauranteBoletasCodigo),
    constraint BoletasPedidosFK foreign key(RestauranteBoletasPedidosCodigo) references Restaurante.Pedidos(PedidosCodigo),
    constraint BoletasEmpleadosFK foreign key(RestauranteBoletasEmpleadosCodigo) references Restaurante.Empleados(EmpleadosCodigo),
    constraint BoletasClientesCodigoFK foreign key(RestauranteBoletasClientesCodigo) references Restaurante.Clientes(ClientesCodigo),

	constraint RestauranteBoletasEstadoCK check (RestauranteBoletasEstado = 'E' or RestauranteBoletasEstado = 'C') 
) on comercial
go

-- Modificar la tabla Boletas para agregar campos calculados para el IGV y Total sin IGV
alter Table Restaurante.Boletas
	Add 
		RestauranteBoletasTotalSinIGV AS CAST(RestauranteBoletasTotal / 1.18 AS NUMERIC(10, 2)), -- Total sin IGV
		RestauranteBoletasIGV AS CAST(RestauranteBoletasTotal - (RestauranteBoletasTotal / 1.18) AS NUMERIC(10, 2)) -- IGV calculado
go





create table Restaurante.Facturas
(
  FacturasCodigo nchar(8),                    
  FacturasPedidosCodigo nchar(8) not null,    
  PedidoMesaCodigo nchar(8),                  

  FacturasNumeroFacura nvarchar(20) not null, 
  FacturasFechaCreacion date constraint FacturasFechaCreacionDF default getdate(), 
  FacturasTotal numeric(10,2) not null,       
  
  FacturaClienteNombreCompleto nvarchar(150),  
  FacturaRuc nvarchar(50),                     
  FacturasEstado nchar(1) not null constraint FacturasEstadoDF default 'E', -- Estado de la factura (Emitida, Completada)
  
  -- Constraints
  constraint FacturasPK primary key (FacturasCodigo),
  constraint FacturaPedidosFK foreign key (FacturasPedidosCodigo) references Restaurante.Pedidos(PedidosCodigo)
) on comercial;
go


-- Modificar la tabla Facturas para agregar campos calculados para el IGV y Total sin IGV
alter table Restaurante.Facturas
	add	
	FacturasTotalSinIGV AS CAST(FacturasTotal / 1.18 AS NUMERIC(10, 2)), -- Total sin IGV
    FacturaIGV AS CAST(FacturasTotal - (FacturasTotal / 1.18) AS NUMERIC(10, 2)) -- IGV calculado
go


create table Restaurante.Empresa 
	(
    EmpresaCodigo nchar(8),
    EmpresaNombre nvarchar(150) NOT NULL,
    EmpresaRUC nvarchar(11) NOT NULL,
    EmpresaDireccion nvarchar(200) NOT NULL,
    EmpresaTelefono nvarchar(15),
    EmpresaEmail nvarchar(100),
    EmpresaLogo image 

	constraint EmpresaCodigoPK primary key (EmpresaCodigo)
	) --por defecto en el grupo de archivos primarios
go


create table Restaurante.Documentos
	(
		DocumentoCodigo nchar(8),
		DocumentoReferencias nchar(8),
		DocumentoTipo nvarchar(20) ,
		DocumentoPDF image,
		DocumentoFecha datetime default getdate(),

		constraint DocumentoCodigoPK Primary key (DocumentoCodigo)
	)
go


--==========================================================================================
--										Fin - Base de Datos 
--==========================================================================================


--*********************************************************************************************
--										inices 
--*********************************************************************************************

create index DocumentoReferenciasOrigenIDX on Restaurante.Documentos(DocumentoReferencias, DocumentoTipo);


--==========================================================================================
--										Inicio - Inserts en las tablas  
--==========================================================================================
set dateformat dmy;
go

INSERT INTO Restaurante.Empresa 
    (EmpresaCodigo, EmpresaNombre, EmpresaRUC, EmpresaDireccion, EmpresaTelefono, EmpresaEmail, EmpresaLogo)
VALUES
    ('EPR00001', 'Restaurante Roko', '10737782943', 'chao-viru', '999999999', 'restauranteRoco@gmail.com', NULL);
go
INSERT INTO Restaurante.RolesPermisos (RolesPermisosCodigo, RolesPermisosNombreRol, RolesPermisosDescripcion)
VALUES
    (N'ROL00001', N'Administrator', N'Full access to all system functionalities'),
    (N'ROL00002', N'Waiter', N'Can take orders and handle payments'),
    (N'ROL00003', N'Chef', N'Can view and update order statuses');
GO


INSERT INTO Restaurante.Clientes (ClientesCodigo, ClientesNombre, ClientesApellidos, ClientesTelefono, ClientesDNI, ClientesCorreo)
VALUES
    (N'CLI00001', N'Carlos', N'Gomez', '1234567890', N'12345678', 'carlos.gomez@example.com'),
    (N'CLI00002', N'Maria', N'Lopez', '0987654321', N'23456789', 'maria.lopez@example.com'),
    (N'CLI00003', N'Luis', N'Fernandez', '1122334455', N'34567890', 'luis.fernandez@example.com'),
    (N'CLI00004', N'Ana', N'Martinez', '6677889900', N'45678901', 'ana.martinez@example.com'),
    (N'CLI00005', N'Jose', N'Rodriguez', '5566778899', N'56789012', 'jose.rodriguez@example.com'),
    (N'CLI00006', N'Lucia', N'Hernandez', '9988776655', N'67890123', 'lucia.hernandez@example.com'),
    (N'CLI00007', N'Pedro', N'Garcia', '4455667788', N'78901234', 'pedro.garcia@example.com'),
    (N'CLI00008', N'Laura', N'Perez', '3344556677', N'89012345', 'laura.perez@example.com'),
    (N'CLI00009', N'David', N'Sanchez', '2233445566', N'90123456', 'david.sanchez@example.com'),
    (N'CLI00010', N'Sofia', N'Ramirez', '1122334455', N'01234567', 'sofia.ramirez@example.com');
GO


INSERT INTO Restaurante.Empleados (
    EmpleadosCodigo,
    EmpleadosRolesPermisosCodigo,
    EmpleadosPaterno,
    EmpleadosMaterno,
    EmpleadosNombres,
    EmpleadosTelefono,
    EmpleadosSexo,
    EmpleadosHoraEntreada,
    EmpleadosSalario
)
VALUES
    (N'EMP00001', N'ROL00001', N'Perez', N'Lopez', N'Juan', '5551234567', N'M', N'08:00', 5000.00),
    (N'EMP00002', N'ROL00001', N'Gomez', N'Sanchez', N'Elena', '5552345678', N'F', N'08:30', 5000.00),
    (N'EMP00003', N'ROL00003', N'Fernandez', N'Garcia', N'Mario', '5553456789', N'M', N'09:00', 4000.00),
    (N'EMP00004', N'ROL00003', N'Lopez', N'Ramirez', N'Susana', '5554567890', N'F', N'09:00', 4000.00),
    (N'EMP00005', N'ROL00003', N'Martinez', N'Hernandez', N'Carlos', '5555678901', N'M', N'09:00', 4000.00),
    (N'EMP00006', N'ROL00002', N'Garcia', N'Lopez', N'Luis', '5556789012', N'M', N'10:00', 3000.00),
    (N'EMP00007', N'ROL00002', N'Hernandez', N'Martinez', N'Ana', '5557890123', N'F', N'10:00', 3000.00),
    (N'EMP00008', N'ROL00002', N'Sanchez', N'Gomez', N'Pedro', '5558901234', N'M', N'10:00', 3000.00),
    (N'EMP00009', N'ROL00002', N'Ramirez', N'Fernandez', N'Lucia', '5559012345', N'F', N'10:00', 3000.00),
    (N'EMP00010', N'ROL00002', N'Rodriguez', N'Perez', N'David', '5550123456', N'M', N'10:00', 3000.00);
GO

INSERT INTO Restaurante.Mesas (MesasCodigo, MesasCapacidad)
VALUES
    (N'MES00001', '2'),
    (N'MES00002', '4'),
    (N'MES00003', '2'),
    (N'MES00004', '6'),
    (N'MES00005', '4'),
    (N'MES00006', '2'),
    (N'MES00007', '8'),
    (N'MES00008', '4'),
    (N'MES00009', '10'),
    (N'MES00010', '6');
GO


INSERT INTO Restaurante.Menu (MenuCodigo, MenuNombre, MenuDescripcion, MenuPrecio)
VALUES
    (N'MEN00001', 'Margherita Pizza', N'Classic pizza with tomatoes and mozzarella', 12.50),
    (N'MEN00002', 'Spaghetti Bolognese', N'Pasta with meat sauce', 10.00),
    (N'MEN00003', 'Caesar Salad', N'Salad with romaine lettuce and Caesar dressing', 8.00),
    (N'MEN00004', 'Grilled Chicken', N'Grilled chicken breast with vegetables', 15.00),
    (N'MEN00005', 'Beef Steak', N'Grilled beef steak with fries', 18.00),
    (N'MEN00006', 'Fish and Chips', N'Fried fish with chips', 12.00),
    (N'MEN00007', 'Vegetable Soup', N'Hot soup with fresh vegetables', 7.00),
    (N'MEN00008', 'Cheeseburger', N'Burger with cheese, lettuce, and tomato', 9.00),
    (N'MEN00009', 'Chocolate Cake', N'Dessert with rich chocolate flavor', 6.00),
    (N'MEN00010', 'Ice Cream', N'Vanilla ice cream with toppings', 5.00),
    (N'MEN00011', 'Greek Salad', N'Salad with feta cheese and olives', 8.50),
    (N'MEN00012', 'Pancakes', N'Fluffy pancakes with syrup', 7.50),
    (N'MEN00013', 'Omelette', N'Egg omelette with ham and cheese', 6.50),
    (N'MEN00014', 'Sushi Platter', N'Assorted sushi rolls', 20.00),
    (N'MEN00015', 'Tacos', N'Tacos with beef and salsa', 9.50),
    (N'MEN00016', 'BBQ Ribs', N'Slow-cooked ribs with BBQ sauce', 16.00),
    (N'MEN00017', 'Seafood Paella', N'Spanish rice dish with seafood', 19.00),
    (N'MEN00018', 'Chicken Curry', N'Spicy chicken curry with rice', 13.00),
    (N'MEN00019', 'Fruit Salad', N'Mix of fresh seasonal fruits', 6.50),
    (N'MEN00020', 'Coffee', N'Freshly brewed coffee', 3.00);
GO

--==========================================================================================
--										Fin - Inserts en las tablas  
--==========================================================================================
--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CLIENTES
--==========================================================================================
-- ==========================================================================================
-- spListarClientesActivos
-- Descripción: Lista los clientes que están activos en el sistema.
-- ==========================================================================================
use BDRestauranteRoko
go
create or alter procedure spListarClientesActivos
as
    select [ClientesCodigo], [ClientesNombre], [ClientesApellidos], [ClientesTelefono], 
           [ClientesDNI], [ClientesCorreo], format([ClientesFechaRegistro], 'dd/MM/yy') as ClientesFechaRegistro, 
           [ClientesEstado]
    from Restaurante.Clientes
    where ClientesEstado = 'A'
go

-- ==========================================================================================
-- spListarClientesBorrados
-- Descripción: Lista los clientes que han sido eliminados o marcados como inactivos.
-- ==========================================================================================
create or alter procedure spListarClientesBorrados
as
    select [ClientesCodigo], [ClientesNombre], [ClientesApellidos], [ClientesNombreCompleto], 
           [ClientesTelefono], [ClientesDNI], [ClientesCorreo], 
           format([ClientesFechaRegistro], 'dd/MM/yy') as ClientesFechaRegistro, 
           [ClientesEstado]
    from Restaurante.Clientes
    where ClientesEstado = 'E'
go

-- ==========================================================================================
-- spBuscarClientesPorNombre
-- Descripción: Busca clientes activos por el nombre proporcionado.
-- ==========================================================================================
create or alter procedure spBuscarClientesPorNombre
    @nombre nvarchar(100)
as
    select ClientesCodigo, ClientesNombreCompleto, ClientesTelefono, ClientesDNI, 
           ClientesCorreo, ClientesFechaRegistro, ClientesEstado
    from Restaurante.Clientes
    where ClientesNombreCompleto collate Latin1_General_CI_AI like @nombre + '%'
      and ClientesEstado = 'A'
go


-- Prueba del procedimiento almacenado


-- ==========================================================================================
-- spEliminarCliente
-- Descripción: Marca a un cliente como eliminado.
-- ==========================================================================================
create or alter procedure spEliminarCliente
    @clienteCodigo nchar(8)
    with encryption
as
    update Restaurante.Clientes
    set ClientesEstado = 'E'
    where ClientesCodigo = @clienteCodigo
go

-- ==========================================================================================
-- spRecuperarClientes
-- Descripción: Restablece un cliente previamente eliminado como activo.
-- ==========================================================================================
create or alter procedure spRecuperarClientes
    @clienteCodigo nchar(8)
    with encryption
as
    update Restaurante.Clientes
    set ClientesEstado = 'A'
    where ClientesCodigo = @clienteCodigo
go

-- ==========================================================================================
-- spActualizarCliente
-- Descripción: Actualiza la información de un cliente en el sistema.
-- ==========================================================================================
create or alter procedure spActualizarCliente
    @ClientesCodigo nchar(8),
    @ClientesNombre nvarchar(100),
    @ClientesApellidos nvarchar(100),
    @ClientesTelefono nvarchar(12),
    @ClientesCorreo nvarchar(50)
    with encryption
as
    update Restaurante.Clientes
    set 
        ClientesNombre = @ClientesNombre,
        ClientesApellidos = @ClientesApellidos,
        ClientesTelefono = @ClientesTelefono,
        ClientesCorreo = @ClientesCorreo
    where ClientesCodigo = @ClientesCodigo
go


-- ==========================================================================================
-- spInsertarCliente
-- Descripción: Inserta un nuevo cliente en el sistema.
-- ==========================================================================================
create or alter procedure spInsertarCliente
    @ClientesCodigo nchar(8),
    @ClientesNombre nvarchar(100),
    @ClientesApellidos nvarchar(100),
    @ClientesTelefono nvarchar(12),
    @ClientesDNI nchar(8),
    @ClientesCorreo nvarchar(50)
    with encryption
as
    insert into Restaurante.Clientes 
    (ClientesCodigo, ClientesNombre, ClientesApellidos, ClientesTelefono, ClientesDNI, ClientesCorreo)
    values 
    (@ClientesCodigo, @ClientesNombre, @ClientesApellidos, @ClientesTelefono, @ClientesDNI, @ClientesCorreo)
go

--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA TABLA RESERVAS
--==========================================================================================

-- ==========================================================================================
-- spListarReservasPorCliente
-- Descripción: Lista las reservas asociadas a un cliente específico.
-- ==========================================================================================
create or alter procedure spListarReservasPorCliente
    @ClientesCodigo nchar(8)
as
    select 
        ReservasCodigo, ReservasMesasCodigo, 
        case 
            when ReservasEstado = 'A' then 'Activo'
            when ReservasEstado = 'C' then 'Cancelado'
            when ReservasEstado = 'P' then 'Pendiente'
            when ReservasEstado = 'E' then 'Expirada'
            when ReservasEstado = 'F' then 'Finalizada'
            else 'Error'
        end as ReservasEstado, 
        ReservasFechaHoraReserva
    from Restaurante.MesaReservas
    where ReservasClientesCodigo = @ClientesCodigo
go

use BDRestauranteRoko
go


-- ==========================================================================================
-- spInsertarReserva
-- Descripción: Inserta una nueva reserva en el sistema.
-- ==========================================================================================
create or alter procedure spInsertarReserva
    @ReservasCodigo nchar(8),
    @ReservasClientesCodigo nchar(8),
    @ReservasMesasCodigo nchar(8),
    @ReservasFechaHoraReserva datetime
as
    insert into Restaurante.MesaReservas 
    (ReservasCodigo, ReservasClientesCodigo, ReservasMesasCodigo, ReservasFechaHoraReserva)
    values 
    (@ReservasCodigo, @ReservasClientesCodigo, @ReservasMesasCodigo, @ReservasFechaHoraReserva)
go

-- ==========================================================================================
-- spListarReservas
-- Descripción: Muestra las reservas con opción de filtrar por estado.
-- ==========================================================================================
CREATE OR ALTER PROCEDURE spListarReservas
    @Estados NVARCHAR(100) = NULL
AS
BEGIN
    DECLARE @EstadosTabla TABLE (Estado NCHAR(1));
    
    IF @Estados IS NOT NULL
    BEGIN
        INSERT INTO @EstadosTabla
        SELECT value
        FROM string_split(@Estados, ',');
    END
    
    SELECT TOP 20
        r.ReservasCodigo,
        r.ReservasClientesCodigo, 
        (SELECT c.ClientesNombreCompleto 
         FROM Restaurante.Clientes c 
         WHERE c.ClientesCodigo = r.ReservasClientesCodigo) AS NombreCliente,
        r.ReservasMesasCodigo,
        (SELECT m.MesasCapacidad 
         FROM Restaurante.Mesas m 
         WHERE m.MesasCodigo = r.ReservasMesasCodigo) AS CapacidadMesa,
        CASE 
            WHEN r.ReservasEstado = 'A' THEN 'Activo'
            WHEN r.ReservasEstado = 'C' THEN 'Cancelado'
            WHEN r.ReservasEstado = 'P' THEN 'Pendiente'
            WHEN r.ReservasEstado = 'E' THEN 'Expirada'
            WHEN r.ReservasEstado = 'F' THEN 'Finalizada'
            ELSE 'Estado Desconocido'
        END AS EstadoReserva,
        CAST(r.ReservasFechaHoraReserva AS DATE) AS FechaReserva,        -- Solo la fecha
        CONVERT(VARCHAR(8), r.ReservasFechaHoraReserva, 108) AS HoraReserva -- Solo la hora en formato HH:MM:SS
    FROM Restaurante.MesaReservas r
    WHERE (@Estados IS NULL OR r.ReservasEstado IN (SELECT Estado FROM @EstadosTabla))
    ORDER BY 
        CASE 
            WHEN r.ReservasFechaHoraReserva >= GETDATE() THEN 1  
            ELSE 2  
        END,
        ABS(DATEDIFF(MINUTE, r.ReservasFechaHoraReserva, GETDATE()));  
END;
GO

-- ==========================================================================================
-- spActualizarReserva
-- Descripción: Actualiza la información de una reserva, incluyendo su estado y fecha.
-- Comparación de costos:
--- Subconsulta: 0.0134956
--- JOIN: 0.0140954
--- FDU: 0.0141276
-- ==========================================================================================
create or alter procedure spActualizarReserva
    @ReservasCodigo nchar(8),
    @ReservasMesasCodigo nchar(8) = null, 
    @NuevaFecha date = null, 
    @NuevaHora time = null, 
    @NuevoEstado nvarchar(20) = null
    with encryption
as
    set @NuevoEstado = lower(@NuevoEstado)

    declare @EstadoChar nchar(1)

    set @EstadoChar = case 
        when @NuevoEstado = 'activo' then 'A'
        when @NuevoEstado = 'cancelado' then 'C'
        when @NuevoEstado = 'pendiente' then 'P'
        when @NuevoEstado = 'expirada' then 'E'
        when @NuevoEstado = 'finalizada' then 'F'
        else null
    end

    declare @FechaHoraActual datetime
    select @FechaHoraActual = ReservasFechaHoraReserva from Restaurante.MesaReservas where ReservasCodigo = @ReservasCodigo

    declare @NuevaFechaHora datetime
    set @NuevaFechaHora = case 
        when @NuevaFecha is not null and @NuevaHora is not null then cast(@NuevaFecha as datetime) + cast(@NuevaHora as datetime)
        when @NuevaFecha is not null and @NuevaHora is null then cast(@NuevaFecha as datetime) + cast(cast(@FechaHoraActual as time) as datetime)
        when @NuevaFecha is null and @NuevaHora is not null then cast(cast(@FechaHoraActual as date) as datetime) + cast(@NuevaHora as datetime)
        else @FechaHoraActual
    end

    update Restaurante.MesaReservas
    set 
        ReservasMesasCodigo = isnull(@ReservasMesasCodigo, ReservasMesasCodigo),
        ReservasFechaHoraReserva = @NuevaFechaHora,
        ReservasEstado = isnull(@EstadoChar, ReservasEstado)
    where ReservasCodigo = @ReservasCodigo
go


--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA TABLA EMPLEADOS
--==========================================================================================

-- ==========================================================================================
-- spListarEmpleadosActivos
-- Descripción: Lista los empleados activos en el sistema.

--Comparación de costos:
--- Subconsulta: 0.0078473
--- JOIN: 0.0080596
--- FDU: 0.0080486
--costo 0.0078473
-- ==========================================================================================
create or alter procedure spListarEmpleadosActivos
as
    select 
        e.EmpleadosCodigo, 
        e.EmpleadosRolesPermisosCodigo, 
        (select rp.RolesPermisosNombreRol from Restaurante.RolesPermisos rp where rp.RolesPermisosCodigo = e.EmpleadosRolesPermisosCodigo) as RolesPermisosNombreRol, 
        e.EmpleadosPaterno, e.EmpleadosMaterno, e.EmpleadosNombres, e.EmpleadosNombreCompleto, 
        e.EmpleadosTelefono, e.EmpleadosEstado, e.EmpleadosSexo, e.EmpleadosHoraEntreada, e.EmpleadosSalario, 
        format(e.EmpleadosFechaContratacion, 'dd/MM/yy') as EmpleadosFechaContratacion, 
        e.EmpleadosAniosAntiguedad, e.EmpleadosMesesAntiguedad, e.EmpleadosDiasAntiguedad
    from Restaurante.Empleados e
    where e.EmpleadosEstado = 'A'
go

-- ==========================================================================================
-- spListarEmpleadosBorrados
-- Descripción: Lista los empleados marcados como inactivos o eliminados.
-- ==========================================================================================
create or alter procedure spListarEmpleadosBorrados
as
    select 
        e.EmpleadosCodigo, 
        e.EmpleadosRolesPermisosCodigo, 
        (select rp.RolesPermisosNombreRol from Restaurante.RolesPermisos rp where rp.RolesPermisosCodigo = e.EmpleadosRolesPermisosCodigo) as RolesPermisosNombreRol, 
        e.EmpleadosPaterno, e.EmpleadosMaterno, e.EmpleadosNombres, e.EmpleadosNombreCompleto, 
        e.EmpleadosTelefono, e.EmpleadosEstado, e.EmpleadosSexo, e.EmpleadosHoraEntreada, e.EmpleadosSalario, 
        format(e.EmpleadosFechaContratacion, 'dd/MM/yy') as EmpleadosFechaContratacion, 
        e.EmpleadosAniosAntiguedad, e.EmpleadosMesesAntiguedad, e.EmpleadosDiasAntiguedad
    from Restaurante.Empleados e
    where e.EmpleadosEstado = 'E'
go

-- ==========================================================================================
-- spEliminarEmpleado
-- Descripción: Marca a un empleado como eliminado en el sistema.
-- ==========================================================================================
create or alter procedure spEliminarEmpleado
    @EmpleadoCodigo nchar(8)
    with encryption
as
    update Restaurante.Empleados
    set EmpleadosEstado = 'E'
    where EmpleadosCodigo = @EmpleadoCodigo
go

-- ==========================================================================================
-- spRecuperarEmpleado
-- Descripción: Restablece a un empleado previamente eliminado como activo.
-- ==========================================================================================
create or alter procedure spRecuperarEmpleado
    @EmpleadoCodigo nchar(8)
    with encryption
as
    update Restaurante.Empleados
    set EmpleadosEstado = 'A'
    where EmpleadosCodigo = @EmpleadoCodigo
go

-- ==========================================================================================
-- spActualizarEmpleado
-- Descripción: Actualiza la información de un empleado en el sistema.
-- ==========================================================================================
create or alter procedure spActualizarEmpleado
    @EmpleadosCodigo nchar(8),
    @EmpleadosPaterno nvarchar(80),
    @EmpleadosMaterno nvarchar(80),
    @EmpleadosNombres nvarchar(80),
    @EmpleadosTelefono nvarchar(12),
    @EmpleadosSexo nchar(1),
    @EmpleadosHoraEntreada nchar(5),
    @EmpleadosSalario numeric(10,2),
    @EmpleadosRolesPermisosCodigo nchar(8)
    with encryption
as
    if exists (select 1 from Restaurante.RolesPermisos where RolesPermisosCodigo = @EmpleadosRolesPermisosCodigo)
    begin
        update Restaurante.Empleados
        set 
            EmpleadosPaterno = @EmpleadosPaterno,
            EmpleadosMaterno = @EmpleadosMaterno,
            EmpleadosNombres = @EmpleadosNombres,
            EmpleadosTelefono = @EmpleadosTelefono,
            EmpleadosSexo = @EmpleadosSexo,
            EmpleadosHoraEntreada = @EmpleadosHoraEntreada,
            EmpleadosSalario = @EmpleadosSalario,
            EmpleadosRolesPermisosCodigo = @EmpleadosRolesPermisosCodigo 
        where EmpleadosCodigo = @EmpleadosCodigo
    end
    else
    begin
        raiserror('El código del rol no existe en la tabla RolesPermisos', 16, 1)
    end
go


/******************************************************************************************
Descripción: Insertar un nuevo empleado.
**************************************************************************************/
create or alter procedure spInsertarEmpleado
    @EmpleadosCodigo nchar(8),
    @EmpleadosRolesPermisosCodigo nchar(8),
    @EmpleadosPaterno nvarchar(80),
    @EmpleadosMaterno nvarchar(80),
    @EmpleadosNombres nvarchar(80),
    @EmpleadosTelefono nvarchar(12),
    @EmpleadosSexo nchar(1),
    @EmpleadosHoraEntreada nchar(5),
    @EmpleadosSalario numeric(10,2)
with encryption
as
    begin try
        insert into Restaurante.Empleados
        (EmpleadosCodigo, EmpleadosRolesPermisosCodigo, EmpleadosPaterno, 
         EmpleadosMaterno, EmpleadosNombres, EmpleadosTelefono, EmpleadosSexo, 
         EmpleadosHoraEntreada, EmpleadosSalario)
        values
        (@EmpleadosCodigo, @EmpleadosRolesPermisosCodigo, @EmpleadosPaterno, 
         @EmpleadosMaterno, @EmpleadosNombres, @EmpleadosTelefono, @EmpleadosSexo, 
         @EmpleadosHoraEntreada, @EmpleadosSalario);
    end try
    begin catch
        declare @ErrorMessage nvarchar(4000) = ERROR_MESSAGE();
        declare @ErrorSeverity int = ERROR_SEVERITY();
        declare @ErrorState int = ERROR_STATE();
        raiserror(@ErrorMessage, @ErrorSeverity, @ErrorState);
    end catch;
go

--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA TABLA MESAS
--==========================================================================================

/******************************************************************************************
Descripción: Listar todas las mesas, con opción de filtrar por estado.
**************************************************************************************/
create or alter procedure spListarMesas
    @MesasEstado nchar(1) = null -- Parámetro opcional para el estado de la mesa ('V', 'O', 'R')
with encryption
as
    select MesasCodigo, MesasCapacidad, MesasEstado
    from Restaurante.Mesas
    where (@MesasEstado is null or MesasEstado = @MesasEstado);
go

create or alter procedure spOcuparMesa
    @MesasCodigo nchar(8)
as
begin
    update Restaurante.Mesas
    set MesasEstado = 'O'
    where MesasCodigo = @MesasCodigo;
end;
go


create or alter procedure spLiberarMesa
    @MesasCodigo nchar(8)
as
begin
    update Restaurante.Mesas
    set MesasEstado = 'V'
    where MesasCodigo = @MesasCodigo;
end;
go

--actualizar las mesas a reservadas si en caso hay una reserva para ese dia
create or alter procedure spActualizarEstadoMesasReservadas
as
	begin
		update Restaurante.Mesas
		set MesasEstado = 'R'
		where MesasCodigo in 
			(
				Select ReservasMesasCodigo
				from Restaurante.MesaReservas
				where CAST(ReservasFechaHoraReserva as date) = cast(GETDATE() AS date )
					and ReservasEstado = 'A'
			);
	end;
go

create OR alter procedure spVerificarDisponibilidadMesa
    @MesasCodigo nchar(8),
    @FechaReserva datetime
as
	begin
    -- Verificar si existe una reserva activa para la mesa en la fecha y hora especificada
		IF NOT EXISTS (
			SELECT 1
			FROM Restaurante.MesaReservas
			WHERE ReservasMesasCodigo = @MesasCodigo
			  AND CAST(ReservasFechaHoraReserva AS DATE) = CAST(@FechaReserva AS DATE) -- misma fecha
			  AND ReservasEstado = 'A' -- reserva activa
		)
		BEGIN
			SELECT 1 AS Disponible -- Mesa disponible para la fecha solicitada
		END
		ELSE
		BEGIN
			SELECT 0 AS Disponible -- Mesa no disponible para la fecha solicitada
		END
	END;
go


--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA PEDIDOS
--==========================================================================================
create or alter procedure spCrearPedido
    @PedidosCodigo nchar(8),  
    @MesasCodigo nchar(8),   
    @EmpleadosCodigo nchar(8) 
as
begin
    insert into Restaurante.Pedidos (PedidosCodigo, PedidosMesasCodigo, PedidosEmpleadosCodigo, PedidoFecha, PedidosEstado)
    values (@PedidosCodigo, @MesasCodigo, @EmpleadosCodigo, getdate(), 'P'); -- Estado inicial 'P' = Pendiente

    select @PedidosCodigo as NuevoPedidoCodigo;
end;
go

create or alter procedure spFinalizarPedido
    @PedidosCodigo nchar(8)
as
begin
    update Restaurante.Pedidos
    set PedidosEstado = 'C'
    where PedidosCodigo = @PedidosCodigo;
end;
go

create or alter procedure spObtenerPedidoPorMesa
    @MesasCodigo nchar(8)
with encryption
as
select top 1
    PedidosCodigo, 
    PedidosMesasCodigo, 
    PedidosEmpleadosCodigo, 
    PedidoFecha,
    PedidosEstado
from Restaurante.Pedidos
where PedidosMesasCodigo = @MesasCodigo
  ORDER BY CAST(SUBSTRING(PedidosCodigo, 4, LEN(PedidosCodigo)) AS INT) DESC;
go



--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA DETALLE PEDIDO
--==========================================================================================

create or alter procedure spAgregarDetallesPedido
    @DetallesPedidoCodigo nchar(8),
    @PedidosCodigo nchar(8),       
    @MenuCodigo nchar(8),          
    @Precio numeric(9,2),          
    @Cantidad numeric(9,2)          
as
begin
    insert into Restaurante.DetallesPedido 
    (
        DetallesPedidoCodigo, 
        DetallesPedidoPedidosCodigo, 
        DetallesPedidoMenuCodigo, 
        DetallesPedidoPrecio, 
        DetallesPedidoCantidad, 
        DetallesPedidoEstado
    )
    values 
    (
        @DetallesPedidoCodigo, 
        @PedidosCodigo, 
        @MenuCodigo, 
        @Precio, 
        @Cantidad, 
        'P' -- Estado inicial 'P' = Pendiente
    );
end;
go

create or alter procedure spObtenerDetallesPedido
    @PedidosCodigo nchar(8)

as
select 
    DetallesPedidoCodigo,
    DetallesPedidoMenuCodigo,
    (select MenuNombre from Restaurante.Menu where MenuCodigo = DetallesPedidoMenuCodigo) as MenuNombre,
    DetallesPedidoPrecio,
    DetallesPedidoCantidad,
    DetallesPedidoEstado
from Restaurante.DetallesPedido
where DetallesPedidoPedidosCodigo = @PedidosCodigo;
go

/*
** Nota: Esta implementación de DELETE se ha considerado como una excepción, después de reflexionar sobre la situación. 
* Comprendo la indicación de evitar el uso de DELETE, pero en este caso particular he tomado esta decisión para evitar la acumulación innecesaria de registros incorrectos.
* En un escenario donde el comensal se equivoca o decide cambiar su pedido después de haber agregado un plato al detalle, trabajar con estados resultaría ineficiente.
* Mantener estos platos en la base de datos, aunque marcados como inactivos o eliminados, no aportaría valor ni al historial ni a la gestión del pedido.
* Además, estos registros innecesarios aumentarían el tamaño de la base de datos y complicarían el análisis de los datos.
* Por tanto, considero más eficiente eliminar permanentemente aquellos detalles de pedido que el cliente ya no desea.
*/
create or alter procedure spEliminarDetallePedido
    @DetallesPedidoCodigo nchar(8)
as
    delete from Restaurante.DetallesPedido
    where DetallesPedidoCodigo = @DetallesPedidoCodigo;
go


/******************************************************************************************
Descripción: Lista de todos los pedidos, incluyendo el código del pedido, código de la mesa, 
código del empleado, nombre completo del empleado, cargo del empleado y estado del pedido 
(Pendiente o Completado).

Implementación con:
-- Subconsultas:
---- Costo estimado: 0.0568704

-- Joins:
---- Costo estimado: 0.0265323

-- Función Definida por el Usuario (FDU):
---- Costo estimado: 0.0033948

**************************************************************************************/

create or alter function Restaurante.fduEmpleadoNombreCompleto(@EmpleadoCodigo nchar(8))
returns nvarchar(200)
as
begin
    declare @NombreCompleto nvarchar(200);
    
    select 
        @NombreCompleto = Empleados.EmpleadosNombreCompleto
    from 
        Restaurante.Empleados
    where 
        Empleados.EmpleadosCodigo = @EmpleadoCodigo;

    return @NombreCompleto;
end;
go
create or alter function Restaurante.fduEmpleadoRol(@EmpleadoCodigo nchar(8))
returns nvarchar(100)
as
begin
    declare @Rol nvarchar(100);
    
    select 
        @Rol = RolesPermisos.RolesPermisosNombreRol
    from 
        Restaurante.Empleados
    inner join 
        Restaurante.RolesPermisos on Empleados.EmpleadosRolesPermisosCodigo = RolesPermisos.RolesPermisosCodigo
    where 
        Empleados.EmpleadosCodigo = @EmpleadoCodigo;

    return @Rol;
end;
go
select * from Restaurante.Boletas
go

create or alter procedure Restaurante.spObtenerPedidosConDetalle
	as
	select 
		Pedidos.PedidosCodigo as CodigoPedido,
		Pedidos.PedidosMesasCodigo as CodigoMesa,
		Pedidos.PedidosEmpleadosCodigo as CodigoEmpleado,
		Restaurante.fduEmpleadoNombreCompleto(Pedidos.PedidosEmpleadosCodigo) as NombreEmpleado,
		Restaurante.fduEmpleadoRol(Pedidos.PedidosEmpleadosCodigo) as CargoEmpleado,
		case 
			when Pedidos.PedidosEstado = 'P' then 'Pendiente'
			when Pedidos.PedidosEstado = 'C' then 'Completado'
			else Pedidos.PedidosEstado
		end as EstadoPedido
	from 
		Restaurante.Pedidos
	order by 
		pedidos.PedidoFecha desc
go
--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA PAGO
--==========================================================================================
CREATE or alter PROCEDURE spRegistrarPago
    @PagoCodigo nchar(8),
    @PagoPedidoCodigo nchar(8),
    @PagoMonto numeric(10,2)
AS

    -- Insertar el pago en la tabla Restaurante.Pago con fecha actual y estado 'C'
    INSERT INTO Restaurante.Pago
    (
        PagoCodigo, 
        PagoPedidoCodigo, 
        PagoMonto, 
        PagoFechaPago, 
        PagoEstado
    )
    VALUES
    (
        @PagoCodigo, 
        @PagoPedidoCodigo, 
        @PagoMonto, 
        GETDATE(),         -- Fecha actual por defecto
        'C'                -- Estado por defecto 'C' (Completado)
    );
GO


--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA FACTURA
--==========================================================================================
--devolverá el nombre completo del cliente, que podemos usar en la boleta o factura.
CREATE FUNCTION Restaurante.ObtenerNombreCliente(@ClienteCodigo NCHAR(8))
RETURNS NVARCHAR(200)
AS
BEGIN
    DECLARE @NombreCliente NVARCHAR(200)
    SELECT @NombreCliente = ClientesNombreCompleto
    FROM Restaurante.Clientes
    WHERE ClientesCodigo = @ClienteCodigo
    RETURN @NombreCliente
END
GO


create or alter procedure spCrearFactura
	@facturaCodigo nchar(8),
	@facturaPedidoCodigo nchar(8),
	@facturaPedidoMesaCodigo nchar(8),
	@facturaTotal numeric(10,2),
	@facturaEmpresaCliente nvarchar(150),
	@facturaRUC nvarchar(50)
	with encryption
	as
	begin 
		insert into Restaurante.Facturas
		(
			[FacturasCodigo], 
			[FacturasPedidosCodigo], 
			[PedidoMesaCodigo],
			[FacturasNumeroFacura],
			[FacturasFechaCreacion], [FacturasTotal], 
			[FacturaClienteNombreCompleto], [FacturaRuc]
		)
		values 
		(
			@facturaCodigo,
			@facturaPedidoCodigo,
			@facturaPedidoMesaCodigo,
			@facturaCodigo, -- eliminar
			GETDATE(),
			@facturaTotal,
			@facturaEmpresaCliente,
			@facturaRUC	
		);
	end
go




--[FacturasCodigo], [FacturasPedidosCodigo], 
--[PedidoMesaCodigo], [FacturasNumeroFacura], 
--[FacturasFechaCreacion], [FacturasTotal], 
--[FacturaClienteNombreCompleto], [FacturaRuc], 
--[FacturasEstado], [FacturasTotalSinIGV], 
--[FacturaIGV]
--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA BOLETA
--==========================================================================================
create or alter procedure spCrearBoleta
    @BoletaCodigo nchar(8),
    @BoletaPedidosCodigo nchar(8),
    @BoletaEmpleadosCodigo nchar(8),
	@BoletaClientesCodigo nchar(8),
    @BoletaTotal numeric(10,2),
	@BoletaClienteNombreCompleto nvarchar(200)
	with encryption
	as
	begin
		-- Insertar en la tabla Boletas
		insert into Restaurante.Boletas
		(
			[RestauranteBoletasCodigo] ,
			[RestauranteBoletasPedidosCodigo], 
			[RestauranteBoletasEmpleadosCodigo], 
			[RestauranteBoletasClientesCodigo], 
			[RestauranteBoletasFechaHora], 
			[RestauranteBoletasTotal], 
			[RestauranteBoletasClienteNombreCompleto]
		)
		values
		(
			@BoletaCodigo,
			@BoletaPedidosCodigo, 
			@BoletaEmpleadosCodigo, 
			@BoletaClientesCodigo, 
			getdate(),            
			@BoletaTotal,
			@BoletaClienteNombreCompleto      
		);
	end
go




--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA EL MENU
--==========================================================================================

create or alter procedure spListarMenuActivo
as
    select 
        MenuCodigo, 
        MenuNombre, 
        MenuDescripcion, 
        MenuPrecio, 
        MenuEstado, 
        MenuFoto
    from Restaurante.Menu
    where MenuEstado = 'A'; -- Solo productos activos
go


create or alter procedure spObtenerMenuPorCodigo
	@MenuCodigo nchar(8)
as
	SELECT MenuCodigo, MenuNombre, MenuDescripcion, MenuPrecio, MenuEstado, MenuFoto
    FROM Restaurante.Menu
    WHERE RTRIM(MenuCodigo) = RTRIM(@MenuCodigo);
go

create or alter procedure spListarMenu
as
    select 
        MenuCodigo, 
        MenuNombre, 
        MenuDescripcion, 
        MenuPrecio, 
        MenuEstado, 
        MenuFoto
    from Restaurante.Menu
go

CREATE OR ALTER PROCEDURE spInsertarMenu
    @MenuCodigo nchar(8),
    @MenuNombre varchar(50),
    @MenuDescripcion nvarchar(100),
    @MenuPrecio numeric(9,2),
    @MenuFoto image = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Restaurante.Menu
    (
        MenuCodigo,
        MenuNombre,
        MenuDescripcion,
        MenuPrecio,
        MenuEstado,
        MenuFoto
    )
    VALUES
    (
        @MenuCodigo,
        @MenuNombre,
        @MenuDescripcion,
        @MenuPrecio,
        'A', -- Estado por defecto es 'A' (Activo)
        @MenuFoto
    );
END
GO


CREATE or alter PROCEDURE spActualizarMenu
    @MenuCodigo nchar(8),
    @MenuNombre varchar(50),
    @MenuDescripcion nvarchar(100),
    @MenuPrecio numeric(9,2),
    @MenuEstado nchar(1),
    @MenuFoto image
AS
BEGIN
    -- Validar que MenuEstado sea 'A' o 'E'
    IF @MenuEstado NOT IN ('A', 'E')
    BEGIN
        RAISERROR('El estado del menú debe ser ''A'' (Activo) o ''E'' (Eliminado).', 16, 1)
        RETURN
    END

    UPDATE Restaurante.Menu
    SET
        MenuNombre = @MenuNombre,
        MenuDescripcion = @MenuDescripcion,
        MenuPrecio = @MenuPrecio,
        MenuEstado = @MenuEstado,
        MenuFoto = @MenuFoto
    WHERE
        MenuCodigo = @MenuCodigo;
END
GO

--ejemplo de poner imagenes manualmente
--update Restaurante.Menu set
--	MenuFoto = 
--		(
--		select * from OpenRowset(Bulk 'C:\url', Single_Blob) As MenuFoto
--		)
--go

--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA LA ROLES 
--==========================================================================================

-- ==========================================================================================
-- spListarRolesActivos
-- Descripción: Lista los roles activos en el sistema.
-- ==========================================================================================
create or alter procedure spListarRolesActivos
as
    select 
        RolesPermisosCodigo, 
        RolesPermisosNombreRol 
    from Restaurante.RolesPermisos
    where RolesPermisosEstado = 'A'
go

--==========================================================================================
-- PROCEDIMIENTOS ADICIONALES
--==========================================================================================
-- ==========================================================================================
-- spGenerarCodigoUnico
-- Descripción: Genera un código único para una tabla específica, según un prefijo dado.
-- ==========================================================================================

create or alter procedure spGenerarCodigoUnico
		@prefijo nvarchar(3),         
		@tabla nvarchar(128),         
		@columnaCodigo nvarchar(128)
	as
		declare @nuevoCodigo int
		declare @codigoGenerado nchar(8)
		declare @sql nvarchar(max)

		set @sql = '
			select @nuevoCodigo = isnull(max(cast(substring(' + @columnaCodigo + ', 4, len(' + @columnaCodigo + ')) as int)), 0) + 1
			from ' + @tabla + '
			where ' + @columnaCodigo + ' like @prefijo + ''%''
		'
		exec sp_executesql @sql, N'@nuevoCodigo int output, @prefijo nvarchar(3)', @nuevoCodigo output, @prefijo

		set @codigoGenerado = @prefijo + right('00000' + cast(@nuevoCodigo as varchar(5)), 5)
		select @codigoGenerado as CodigoUnico
go





CREATE or alter PROCEDURE spHistorialFacturas
AS
BEGIN
    SELECT 
        FacturasCodigo,
        FacturasPedidosCodigo,
        FacturasNumeroFacura,
        FacturasFechaCreacion,
        FacturasTotal,
        FacturaClienteNombreCompleto,
        FacturaRuc,
        FacturasEstado
    FROM Restaurante.Facturas
    WHERE FacturasEstado = 'E'  -- 'E' = Emitida
    ORDER BY FacturasFechaCreacion DESC;
END;
GO



CREATE or alter PROCEDURE spHistorialBoletas
AS
    SELECT 
        RestauranteBoletasCodigo,
        RestauranteBoletasPedidosCodigo,
        RestauranteBoletasEmpleadosCodigo,
        RestauranteBoletasClientesCodigo,
        RestauranteBoletasFechaHora,
        RestauranteBoletasTotal,
        RestauranteBoletasClienteNombreCompleto,
        RestauranteBoletasEstado
    FROM Restaurante.Boletas
    WHERE RestauranteBoletasEstado = 'E'  -- 'E' = Emitida
    ORDER BY RestauranteBoletasFechaHora DESC;
GO


--COMPROBANTE DE PAGO


CREATE OR ALTER PROCEDURE Restaurante.spObtenerComprobantePorPedido
    @PedidoCodigo NCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si existe una boleta asociada al pedido
    IF EXISTS (SELECT 1 FROM Restaurante.Boletas WHERE RestauranteBoletasPedidosCodigo = @PedidoCodigo)
    BEGIN
        -- Obtener detalles de la boleta si existe
        SELECT 
            'Boleta' AS TipoComprobante,
            B.RestauranteBoletasCodigo AS CodigoComprobante,
            B.RestauranteBoletasFechaHora AS Fecha,
            B.RestauranteBoletasTotal AS TotalConIGV,
            B.RestauranteBoletasTotalSinIGV AS TotalSinIGV,
            B.RestauranteBoletasIGV AS IGV,
            B.RestauranteBoletasClienteNombreCompleto AS NombreCliente,
            (SELECT EmpresaNombre FROM Restaurante.Empresa) AS NombreEmpresa,
            (SELECT EmpresaRUC FROM Restaurante.Empresa) AS RUCEmpresa,
            (SELECT EmpresaDireccion FROM Restaurante.Empresa) AS DireccionEmpresa
        FROM Restaurante.Boletas B
        WHERE B.RestauranteBoletasPedidosCodigo = @PedidoCodigo;
    END
    ELSE IF EXISTS (SELECT 1 FROM Restaurante.Facturas WHERE FacturasPedidosCodigo = @PedidoCodigo)
    BEGIN
        -- Obtener detalles de la factura si no existe boleta pero sí factura
        SELECT 
            'Factura' AS TipoComprobante,
            F.FacturasCodigo AS CodigoComprobante,
            F.FacturasFechaCreacion AS Fecha,
            F.FacturasTotal AS TotalConIGV,
            F.FacturasTotalSinIGV AS TotalSinIGV,
            F.FacturaIGV AS IGV,
            F.FacturaClienteNombreCompleto AS NombreCliente,
            F.FacturaRuc AS RUCCliente,
            (SELECT EmpresaNombre FROM Restaurante.Empresa) AS NombreEmpresa,
            (SELECT EmpresaRUC FROM Restaurante.Empresa) AS RUCEmpresa,
            (SELECT EmpresaDireccion FROM Restaurante.Empresa) AS DireccionEmpresa
        FROM Restaurante.Facturas F
        WHERE F.FacturasPedidosCodigo = @PedidoCodigo;
    END
    ELSE
    BEGIN
        -- Si no se encuentra ni boleta ni factura
        PRINT 'No se encontró un comprobante asociado al código de pedido especificado.'
    END
END;
GO


--==========================================================================================
-- PROCEDIMIENTOS ALMACENADOS PARA DOCUMENTOS 
--==========================================================================================

create or alter procedure spDocumentoInsertar
    @DocumentoCodigo nchar(8),
    @DocumentoReferencias nchar(8),
    @DocumentoTipo nvarchar(20),
    @DocumentoPDF image
as
begin
    set nocount on;

    insert into Restaurante.Documentos
    (
        DocumentoCodigo,
        DocumentoReferencias,
        DocumentoTipo,
        DocumentoPDF
    )
    values
    (
        @DocumentoCodigo,
        @DocumentoReferencias,
        @DocumentoTipo,
        @DocumentoPDF
    );

    set nocount off;
end;
go


create or alter procedure spObtenerDocumentoPDF
    @DocumentoCodigo nchar(8)
as
begin
    set nocount on;

    select DocumentoPDF
    from Restaurante.Documentos
    where DocumentoCodigo = @DocumentoCodigo;
end
go

create or alter procedure spListarDocumentos
as
begin
    set nocount on;

    select 
        DocumentoCodigo,
        DocumentoReferencias,
        DocumentoTipo,
        DocumentoFecha
    from Restaurante.Documentos
	where year(DocumentoFecha) = year(getdate())  -- Filtra por el año actual
    order by DocumentoFecha desc;
end
go


CREATE OR ALTER PROCEDURE spAutenticacionUsuarios
(
    @Nombre nvarchar(100), -- Nombre del usuario
    @Clave nvarchar(256)   -- Contraseña encriptada
)
AS
BEGIN
    -- Validar si existe el usuario con la contraseña y estado activo
    IF EXISTS 
    (
        SELECT 1 
        FROM Restaurante.Usuarios 
        WHERE UsuariosNombre = @Nombre 
          AND UsuariosContrasena = @Clave 
          AND UsuariosEstado = 'A' -- Asegura que solo usuarios activos puedan iniciar sesión
    )
    BEGIN
        RETURN 1 -- Usuario autenticado correctamente
    END
    ELSE
    BEGIN
        RETURN 0 -- Usuario no autenticado
    END
END;
GO






