drop table if exists productos, detalle_pago, direccion_usuario, usuarios, metodo_pago, carrito, compra, detalle_compra

--creación de tablas

create table productos
(
	id integer NOT NULL,
	nombre_producto character varying (50),
	precio integer,
	existencias integer,
	primary key (id)
);

insert into productos values (0001, 'Pokemon Esmeralda', 49990, 10);
insert into productos values (0002, 'Pokemon Amarillo', 64990, 10);
insert into productos values (0003, 'Pokemon Scarlet', 29990, 10);
insert into productos values (0004, 'Pokemon Violet', 29990, 10);
insert into productos values (0005, 'Pokemon Rojo', 34990, 10);
insert into productos values (0006, 'Pokemon Azul', 21990, 10);
select*from productos;

create table usuarios
(
	rut character varying (4),
	contraseña character varying (20),
	nombre_cliente character varying (50),
	apellido_cliente character varying (50),
	email character varying(50),
	primary key (rut)
);

insert into usuarios values ('11-1','passcarlos','carlos','perez','carlos.perez@gmail.com');
insert into usuarios values ('22-2','passmauricio','mauricio','martinez','mau.martinez@gmail.com');
insert into usuarios values ('33-3','passcarla','carla','mendez','carla.mendez@gmail.com');
insert into usuarios values ('44-4','passdante','dante','hutinel','dante.hutinel@gmail.com');
insert into usuarios values ('55-5','passmaximo','maximo','martinez','maximo.martinez@gmail.com');
select*from usuarios;



create table direccion_usuario
(
	id serial NOT NULL,
	direccion character varying(50),
	comuna character varying(50),
	ciudad character varying(50),
	region character varying(50),
	usuario_rut character varying(4),
	primary key (id),
	foreign key (usuario_rut) references usuarios(rut)
);

insert into direccion_usuario values (default,'pasaje aida 424','conchali','santiago','RM','11-1');
insert into direccion_usuario values (default,'pasaje san felipe 942','san carlos','san carlos','ñuble','22-2');
insert into direccion_usuario values (default,'pasaje san mateo 1541','san carlos','san carlos','ñuble','33-3');
insert into direccion_usuario values (default,'pasaje durango 3968','conchali','santiago','RM','44-4');
insert into direccion_usuario values (default,'av colon 1555','san miguel','santiago','RM','55-5');
select*from direccion_usuario;



create table carrito
(
	id serial NOT NULL,
	cantidad integer,
	producto_id integer,
	uruario_rut character varying (4),
	primary key (id),
	foreign key (producto_id) references productos(id)
);

insert into carrito values (default,10,0001,'11-1');
insert into carrito values (default,10,0002,'22-2');
insert into carrito values (default,10,0003,'33-3');
insert into carrito values (default,10,0004,'44-4');
insert into carrito values (default,10,0005,'55-5');
select*from carrito;



create table metodo_pago 
( 
	id serial NOT NULL,
	metodo character varying(20),
	usuario_rut character varying(4),
	primary key (id),
	foreign key (usuario_rut) references usuarios(rut)
);

insert into metodo_pago values (default,'debito','11-1');
insert into metodo_pago values (default,'debito','22-2');
insert into metodo_pago values (default,'credito','33-3');
insert into metodo_pago values (default,'debito','44-4');
insert into metodo_pago values (default,'credito','55-5');
select*from metodo_pago;


--CREACION DE TABLAS ASOCIADAs A LA COMPRA

create table detalle_pago
(
	id serial NOT NULL,
	estado character varying(12),
	metodo character varying(20),
	primary key (id)
);

insert into detalle_pago values (default,'finalizado','credito');
insert into detalle_pago values (default,'finalizado','debito');
insert into detalle_pago values (default,'finalizado','debito');
insert into detalle_pago values (default,'finalizado','debito');
insert into detalle_pago values (default,'finalizado','debito');
insert into detalle_pago values (default,'finalizado','credito');
insert into detalle_pago values (default,'finalizado','transferencia');
insert into detalle_pago values (default,'finalizado','debito');
insert into detalle_pago values (default,'finalizado','transferencia');
insert into detalle_pago values (default,'finalizado','debito');
select*from detalle_pago;



create table compra
(
	id serial NOT NULL,
	usuario_rut character varying(4),
	fecha date,
	detallepago_id integer,
	primary key (id),
	foreign key (detallepago_id) references detalle_pago(id),
	foreign key (usuario_rut) references usuarios(rut)
);

insert into compra values (default,'11-1','22-09-2022',1);
insert into compra values (default,'22-2','15-12-2022',2);
insert into compra values (default,'33-3','22-05-2021',3);
insert into compra values (default,'44-4','13-06-2022',4);
insert into compra values (default,'55-5','02-02-2022',5);
insert into compra values (default,'11-1','02-08-2021',6);
insert into compra values (default,'22-2','08-05-2021',7);
insert into compra values (default,'33-3','14-04-2022',8);
insert into compra values (default,'44-4','06-11-2021',9);
insert into compra values (default,'55-5','12-12-2022',10);
select*from compra;



create table detalle_compra
(
	id serial NOT NULL,
	producto_id integer,
	cantidad_compra integer,
	compra_id integer,
	primary key(id),
	foreign key (producto_id) references productos(id),
	foreign key (compra_id) references compra(id)
	
);

insert into detalle_compra values (default,0005,1,1);
insert into detalle_compra values (default,0001,2,1);
insert into detalle_compra values (default,0005,1,2);
insert into detalle_compra values (default,0002,1,2);
insert into detalle_compra values (default,0003,1,3);
insert into detalle_compra values (default,0001,2,4);
insert into detalle_compra values (default,0003,4,4);
insert into detalle_compra values (default,0003,2,5);
insert into detalle_compra values (default,0001,1,5);
insert into detalle_compra values (default,0005,1,5);
insert into detalle_compra values (default,0002,1,5);
insert into detalle_compra values (default,0002,3,6);
insert into detalle_compra values (default,0005,3,6);
insert into detalle_compra values (default,0002,3,7);
insert into detalle_compra values (default,0001,2,8);
insert into detalle_compra values (default,0001,3,8);
insert into detalle_compra values (default,0003,2,8);
insert into detalle_compra values (default,0004,3,9);
insert into detalle_compra values (default,0004,8,10);
insert into detalle_compra values (default,0002,8,10);
select*from detalle_compra;

/***Preguntas****/

/**Rebaja del 20%**/
/*Se utiliza update para actualizar y round para redondear*/
update productos set precio=round(precio*0.8,0);

/* se crea una tabla para almacenar los precios antiguos*/
CREATE TABLE precios_pasados
(
    id integer NOT NULL,
    nombre_producto character varying(50),
    precio integer,
	existencias integer,
    PRIMARY KEY (id)
);

Create function guardar_datos() returns Trigger
as 
$$
begin

Insert into precios_pasados values (old.id, old.nombre_producto , old.precio, old.existencias);

return new;
End
$$
Language plpgsql;

Create Trigger TR_Update before update on productos
for each row
execute procedure guardar_datos();


/**Listar productos con stock critico <=5**/

/*Se selecciona el nombre y las existencias de los productos, fijando la cantidad y ordenando ascendentemente*/
select nombre_producto, existencias 
from productos
where existencias<=5
order by existencias asc;

/**Simular la compra de al menos 3 productos, calcular sub total, iva y total**/

/*1.Insertamos las compras (el id sera=11 ya tenemos 10 anteriores)*/
insert into detalle_pago values (default,'finalizado','debito');
insert into compra values (default,'11-1','14-12-2022',(SELECT MAX(id) from detalle_pago));
insert into detalle_compra values (default,1,2,(SELECT MAX(id) from detalle_pago));
insert into detalle_compra values (default,5,3,(SELECT MAX(id) from detalle_pago));
insert into detalle_compra values (default,4,1,(SELECT MAX(id) from detalle_pago));

SELECT setval(pg_get_serial_sequence('compra', 'id'), coalesce(MAX(id), 1))
from compra;

/*

CREATE OR REPLACE FUNCTION insertar_compra(estado varchar, modo varchar, rut varchar, fecha date, detalle_id integer, cantidad integer) RETURNS VOID AS
$$
 	SELECT setval(pg_get_serial_sequence('detalle_pago', 'id'), coalesce(MAX(id), 1))
	from detalle_pago;
	SELECT setval(pg_get_serial_sequence('compra', 'id'), coalesce(MAX(id), 1))
	from compra;
	SELECT setval(pg_get_serial_sequence('detalle_compra', 'id'), coalesce(MAX(id), 1))
	from detalle_compra;
    insert into detalle_pago values (default,estado,modo);
	insert into compra values (default,rut,fecha,(SELECT MAX(id) from detalle_pago));
	insert into detalle_compra values (default,detalle_id,cantidad,(SELECT MAX(id) from detalle_pago));

$$
LANGUAGE SQL

Select insertar_compra('finalizado','debito','14-4','14-12-2022',1,2)

drop function insertar_compra
*/



/*2. Generamos una Tabla de calculos como una pseudo boleta, incluye nombre,cantidad, valor id=11
para ello unimos la tabla de detalles, compra y producto
*/

/*esto se puede anidar al interior de la funcion para generar la pseudo boleta*/

select nombre_producto, cantidad_compra, precio, (precio*cantidad_compra) as valor_cantidadxprecio
from detalle_compra 
inner join compra 
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
where compra.id=(SELECT MAX(id) from compra);

/*2. Generamos un Subtotal
con el mismo conjunto de tablas anteriores generamos el calculo de subtotal -> precio*cantidad*/
select sum(precio*cantidad_compra) as subtotal
from detalle_compra 
inner join compra 
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
where compra.id=11

/*3. Calculamos el iva
De lamisma forma que el sub total pero multiplicando el 19% y redondeando*/
select round((sum(precio*cantidad_compra))*0.19,0) as iva,
from detalle_compra 
inner join compra 
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
where compra.id=11;

/*4. Calculamos el total
Similar a la forma anterior pero hora sumando la compra con el 0.19 es decir, x1,19*/
select  round(sum((precio*cantidad_compra*1.19)),0) as Total
from detalle_compra 
inner join compra 
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
where compra.id=11; 

/**Mostrar el total de ventas del mes de diciembre 2022**/
/*Similar al total anterior pero en vez de filtrar la id de la compra filtramos la fecha en mes y año extrayendo la informacion de la vaariable data*/
select  count(distinct compra_id) as numero_compras, round(sum((precio*cantidad_compra*1.19)),0) as Total
from detalle_compra 
inner join compra 
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
where (extract(month from fecha)=12) and (extract(year from fecha)=2022);

/**Listar el comportamiento del usuario que mas compras realizo en 2022**/

/**El problema de esta tabla es que si hay más de una persona que realizaron más compras entonces arroja solo una**/
/*Primero veremos como seleccionar al con mas compras,anidando una consulta donde ordenamos la cuenta de las compras y seleccionamos el primero*/
select usuario_rut as max_comprador
from( select usuario_rut,count(usuario_rut) as n_compras
	from compra
	group by usuario_rut
	order by n_compras desc
	limit 1) as tabla_calculada 

/*select usuario_rut as max_comprador
from( select usuario_rut,count(usuario_rut) as n_compras
	from compra
	group by usuario_rut) as tabla_calculada 
	where n_compras=(SELECT MAX(n_compras) 
					 FROM (select usuario_rut,count(usuario_rut) as n_compras
					 from compra
					 group by usuario_rut) as tabla_calculada);*/
	
/*Ahora vemos el comportamiento de los compradores para este caso consideraremos su comportamiento como cuales compras realiza, cuando y de que monto,
ademas para completar la informacion mostraremos su rut y nombre completo, para ellos unimos las tablas de usuarios,compra,detalles_compray productos
, y filtramos por el rut anidando la consulta anterior y agrupamos*/

select rut, concat(nombre_cliente,' ',apellido_cliente) as nombre_completo,fecha,compra_id, round(sum((precio*cantidad_compra*1.19)),0) as Total_compra
from usuarios
inner join compra 
on usuarios.rut=compra.usuario_rut
inner join detalle_compra
on compra.id=detalle_compra.compra_id
inner join productos
on productos.id=detalle_compra.producto_id
group by compra_id,rut,fecha
having (extract(year from fecha)=2022) 
and rut=(select usuario_rut as max_comprador
		from( select usuario_rut,count(usuario_rut) as n_compras
			from compra
			group by usuario_rut
			order by n_compras desc
			limit 1) as tabla_calculada) 




