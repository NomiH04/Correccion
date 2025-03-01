use master;
go

use HotelValle;

drop

create table Huespedes(
idHuespedes int  not null IDENTITY(1,1) primary key ,
nombreCompleto varchar (250) not null,
fechaNacimiento DateTime not null,
genero varchar (50) not null,
telefono varchar (50) not null,
correoElectronico varchar (150) not null,
direccion varchar (500),
fotoHuesped varchar(200))


create table Habitaciones(
idHabitacion int  not null identity(1,1) primary key,
habitacion int not null,
tipoHabitacion varchar (100) not null,
precio int not null,
capacidadMaxima int not null,
duracionEstancia int not null,
estado varchar (100) not null,
servicios varchar (500),
fotoHabitacion varchar(200));

create table Reservas(
idReserva int  not null identity (1,1) primary key,
idHuesped int  not null,
idHabitacion int not null,
fechaCheckIn DateTime not null,
fechaCheckOut DateTime not null,
estadoReserva varchar (100) not null,
montoTotal int not null,
observaciones varchar (500));

alter table Reservas add foreign key (idHuesped) references Huespedes(idHuespedes);
alter table Reservas add foreign key (idHabitacion) references Habitaciones(idHabitacion);


--Huespedes
CREATE OR ALTER PROCEDURE Ins_Huesped
@nombreCompleto VARCHAR(250),
@fechaNacimiento DATE,
@genero VARCHAR(50),
@telefono VARCHAR(50),
@correoElectronico VARCHAR(150),
@direccion VARCHAR(500),
@fotoHuesped VARCHAR(200)
AS
BEGIN
    INSERT INTO Huespedes (nombreCompleto, fechaNacimiento, genero, telefono, correoElectronico, direccion, fotoHuesped)
    VALUES (@nombreCompleto, @fechaNacimiento, @genero, @telefono, @correoElectronico, @direccion, @fotoHuesped);

    PRINT 'Guardado correctamente';
END;


create or alter procedure [Upd_Huesped]
@idHuespedes int,
@nombreCompleto varchar(250),
@fechaNacimiento datetime,
@genero varchar (50),
@telefono varchar (50),
@correoElectronico varchar (150),
@direccion varchar (500),
@fotoHuesped varchar(200)
as begin 
update Huespedes 
set nombreCompleto = @nombreCompleto,
fechaNacimiento = @fechaNacimiento,
genero = @genero,
telefono = @telefono,
direccion = @direccion,
fotoHuesped = @fotoHuesped
where correoElectronico = @correoElectronico
print 'Modificado correctamente'
end

create or alter procedure [del_Huesped]
@correoElectronico varchar (150)
as begin 
delete from huespedes 
where correoElectronico = @correoElectronico
print 'Eliminado correctamente'
end

create or alter procedure [read_Huesped]
@correoElectronico varchar (150)
as begin 
select * from huespedes 
where correoElectronico like '%'+@correoElectronico+'%' 
order by correoElectronico
print 'Encontrado'
end



--HABITACIONES
create or alter procedure Ins_Habitacion
@habitacion int,
@tipoHabitacion varchar(100),
@precio decimal,
@capacidadMax int,
@duracionEstancia int ,
@estado varchar(100),
@servicios varchar(500),
@imagenHabitacion varchar(200)
as begin 
insert into Habitaciones (habitacion,tipoHabitacion,precio,capacidadMaxima,duracionEstancia,estado,servicios, fotoHabitacion)
values (@habitacion,@tipoHabitacion,@precio,@capacidadMax,@duracionEstancia,@estado,@servicios,@imagenHabitacion)
print 'Guardado correctamente'
end

create or alter procedure [Upd_Habitacion]
@idHabitacion int,
@habitacion int,
@tipoHabitacion varchar(100),
@precio decimal,
@capacidadMaxima int,
@duracionEstancia int ,
@estado varchar(100),
@servicios varchar(500),
@fotoHabitacion varchar(200)
as begin 
update Habitaciones
set tipoHabitacion = @tipoHabitacion,
precio = @precio,
capacidadMaxima = @capacidadMaxima,
duracionEstancia = @duracionEstancia,
estado = @estado,
servicios = @servicios,
fotoHabitacion = @fotoHabitacion
where habitacion = @habitacion
print 'Modificado correctamente'
end

create or alter procedure [del_Habitacion]
@habitacion int
as begin 
delete from Habitaciones 
where habitacion = @habitacion
print 'Eliminado correctamente'
end

create or alter procedure [read_Habitacion]
@habitacion int
as begin 
select * from Habitaciones 
where habitacion like '%'+@habitacion+'%' 
order by habitacion
print 'Encontrado'
end




--Reservaciones
create or alter procedure [Ins_Reserva]
@idHuesped int,
@idHabitacion int,
@fechaCheckIn datetime,
@fechaCheckOut datetime,
@estadoReserva varchar(100),
@montoTotal int,
@observaciones varchar (500)
as begin 
insert into Reservas (idHuesped,idHabitacion,fechaCheckIn,fechaCheckOut,estadoReserva,montoTotal,observaciones)
values (@idHuesped,@idHabitacion,@fechaCheckIn,@fechaCheckOut,@estadoReserva,@montoTotal,@observaciones)
print 'Guardado correctamente'
end

create or alter procedure [Upd_Reserva]
@idReserva int,
@idHuesped int,
@idHabitacion int,
@fechaCheckIn datetime,
@fechaCheckOut datetime,
@estadoReserva varchar(100),
@montoTotal int,
@observaciones varchar (500)
as begin 
update Reservas
set idReserva = @idReserva,
idHuesped = @idHuesped,
idHabitacion = @idHabitacion,
fechaCheckIn = @fechaCheckIn,
fechaCheckOut = @fechaCheckOut,
estadoReserva = @estadoReserva,
montoTotal = @montoTotal,
observaciones = @observaciones
where idHuesped = @idHabitacion
print 'Modificado correctamente'
end

create or alter procedure [del_Reserva]
@idReserva int
as begin 
delete from Reservas 
where idReserva = @idReserva
print 'Eliminado correctamente'
end

create or alter procedure [read_Reserva]
@idReserva int
as begin 
select * from Reservas 
where idReserva like '%'+@idReserva+'%' 
order by idReserva
print 'Encontrado'
end

select * from huespedes
select * from habitaciones
select * from reservas