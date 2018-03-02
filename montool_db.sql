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
("Gtr 12Z8 FB789", "Irregular", "Estructura irregular, ubicada en Cd. Guerrero. Está activa.", "Vall, Cd. Guerrero", 1), 
("Frdg WGFss er", "Iregular", "Estructura irregular, ubicada en Sn. LP. Está inactiva.", "VCarr, Sn. LP.", 0),
("Bfts Bac545r", "Especial", "Estructura especial, ubicada en Cd. de México. Está activa.", "Cuh, Cd. México", 1)



