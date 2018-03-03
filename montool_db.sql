/*
Mon Tool v1.
Marzo, 2018.
Base de datos de prueba.
*/

create database if not exists montool;
use montool;

# Tabla "estructura".
create table estructura (
	id int not null auto_increment,
    nombre varchar(100),
    tipo varchar(100),
    descripcion text,
    ubicacion varchar(100),
    activa bool,
    primary key (id)
);

# Datos de prueba para la tabla "estructura".
insert into estructura (nombre, tipo, descripcion, ubicacion, activa) values 
("Sdtr 12Z8 XB789", "Regular", "Estructura regular, ubicada en Cd. de México. Está activa.", "Centro, Cd. México", 1), 
("Lgdv UCdfy er", "Iregular", "Estructura irregular, ubicada en Cd. de México. Está activa.", "Coy., Cd. México", 1),
("Nnts 97885r", "Especial", "Estructura especial, ubicada en Cd. de México. Está activa.", "Centro, Cd. México", 1)



