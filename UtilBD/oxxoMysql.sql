create database oxxo;
use oxxo;
#drop database oxxo;
create table empleados(
idempleado int primary key not null,
nss varchar(20),
rfc varchar(20),
nombre varchar(20),
apellidos varchar(40),
telefono varchar(40),
direccion 	varchar(50),
password varchar(50)
);


create table categorias(
idcategoria int primary key not null,
nombre varchar(20),
descripcion varchar(100));


CREATE TABLE `productos` (
idproducto int primary key,
  clave varchar(20) NOT NULL,
  nombre varchar(50) DEFAULT NULL,
  precio double DEFAULT NULL,
  foto varchar(100) DEFAULT NULL,
  idcategoria int,
  CONSTRAINT `idcategoria_fk` FOREIGN KEY (`idcategoria`) REFERENCES `categorias` (`idcategoria`) ON DELETE CASCADE ON UPDATE CASCADE
);

create table ventas(
folio int not null auto_increment primary key,
fecha date,
total double,
iva double,
subtotal double,
caja varchar(50),
idempleado int,
CONSTRAINT `idempleado_fk` FOREIGN KEY (`idempleado`) REFERENCES `empleados` (`idempleado`) ON DELETE CASCADE ON UPDATE CASCADE
);

create table detalles_venta(
folio int,
idproducto int ,
cantidad int,
precio double,
importe double,
primary key(folio,idproducto),
CONSTRAINT `folio_fk` FOREIGN KEY (`folio`) REFERENCES `ventas` (`folio`) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT `idproducto_fk` FOREIGN KEY (`idproducto`) REFERENCES `productos` (`idproducto`) ON DELETE CASCADE ON UPDATE CASCADE
);