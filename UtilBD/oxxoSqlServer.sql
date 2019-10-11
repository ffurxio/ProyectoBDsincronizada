create database oxxo;
use oxxo;
drop database oxxo;
create table empleados(
idempleado int identity primary key not null,
nss varchar(20),
rfc varchar(20),
nombre varchar(20),
apellidos varchar(40),
telefono varchar(40),
direccion varchar(50),
password varchar(50)
);

create table categorias(
idcategorias int identity primary key not null,
nombre varchar(20),
descripcion varchar(100));

CREATE TABLE productos (
idproducto int identity primary key,
  clave varchar(20) NOT NULL,
  nombre varchar(50) DEFAULT NULL,
  precio decimal(10,2)  NULL,
  foto varchar(100) DEFAULT NULL,
  idcategoria int,
  CONSTRAINT idcategoria_fk FOREIGN KEY (idcategoria) REFERENCES categorias(idcategorias)  ON DELETE CASCADE ON UPDATE CASCADE
) ;

create table ventas(
folio varchar(50),
fecha date,
total decimal(10,2),
iva decimal(10,2),
subtotal decimal(10,2),
caja varchar(50),
idempleado int,
primary key(folio),
CONSTRAINT idempleado_fk FOREIGN KEY (idempleado) REFERENCES empleados(idempleado) ON DELETE CASCADE ON UPDATE CASCADE
);


create table detalles_venta(
folio varchar(50),
idproducto int ,
cantidad int,
precio decimal(10,2),
importe decimal(10,2),
primary key(folio,idproducto),
CONSTRAINT folio_fk FOREIGN KEY (folio) REFERENCES ventas(folio) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT idproducto_fk FOREIGN KEY (idproducto) REFERENCES productos (idproducto) ON DELETE CASCADE ON UPDATE CASCADE
);


