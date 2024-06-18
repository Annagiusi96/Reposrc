use pinkacademy
go

drop table if exists clienti;

create table
		clienti ( id_cliente int primary key,
		nome varchar(50),
		cognome varchar(50),
		email varchar(50),
		indirizzo varchar(100),
		citta varchar(50),
		provincia varchar(4),
		cap char(5) );
	
insert into clienti VALUES (1,'Giuseppe','Verdi','gverdi@aol.com','Roncole Verdi','Busseto','PR','43011');
insert into clienti VALUES (2,'Gioacchino','Rossini','gioacchino@libero.it','Via del Duomo','Pesaro','PU','61122');
insert into clienti VALUES (3,'Giacomo','Puccini','gpuccini@gmail.com','Corte San Lorenzo, 9 ','Lucca','LU','55100');
insert into clienti VALUES (4,'Gaetano','Donizetti','gaetano@walla.com','Via Don Luigi Palazzolo, 88','Bergamo','BG','24122');
insert into clienti VALUES (5,'Vincenzo','Bellini','bellini@bellini.org','Piazza San Francesco d’Assisi, 3','Catania','CT','95100');
		
drop table if exists ordini;
create table ordini (id_ordine int primary key, data date,valore decimal(10,2),id_cliente int);
insert into ordini values (1, convert(datetime,'10/10/2018', 105) ,345.67,   1);
insert into ordini values (2, convert(datetime,'31/12/2017', 105) ,176.00,   3);
insert into ordini values (3, convert(datetime,'01/01/2019', 105) ,33.88,    2);
insert into ordini values (4, convert(datetime,'24/11/2018', 105) ,4589.00,  3);
insert into ordini values (5, convert(datetime,'13/07/2018', 105) ,230.00,  10);
insert into ordini values (6, convert(datetime,'01/06/2018', 105) ,144.00,   9);
	
drop table if exists cjdA;
drop table if exists cjdB;

create table cjdA (x char);
insert into cjdA values('A');
insert into cjdA values('B');
insert into cjdA values('C');
insert into cjdA values('D');

create table cjdB (x char);
insert into cjdB values('1');
insert into cjdB values('2');
insert into cjdB values('3');
insert into cjdB values('4');
insert into cjdB values('5');

