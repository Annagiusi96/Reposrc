
drop table if exists prova_id;
go

CREATE TABLE prova_id 
   (	
    identificativo int IDENTITY(1,1), --sql genera in autonomia il valore del campo
									  --a partire dal valore 1, incrementando di 1
	descrizione VARCHAR(100), 
	primary key(identificativo)
   );
go

insert into prova_id(descrizione) values('descrizione 001');
insert into prova_id(descrizione) values('descrizione 002');
insert into prova_id(descrizione) values('descrizione 003');
   
select * from prova_id; --vediamo che l'identificativo viene generato in automatico dal db

delete from prova_id where identificativo = 3;

insert into prova_id(descrizione) values
('descrizione 004'),
('descrizione 005'),
('descrizione 006');

-- la riga 3 è stata cancellata quindi l'identificativo parte sempre dall'ultimo num

--attraverso IDENTITY(1,1) ci consente di avere sempre un id UNIVOCO, 
--non sequenziale

--posso inserire a mano la primary key
SET IDENTITY_INSERT prova_id ON; --se dò questo comando nn mi dà piu errore
insert into prova_id(identificativo, descrizione) values
(200, 'descrizione 100') -- ci dà errore IDENTITIY_INSERT is set to off
SET IDENTITY_INSERT prova_id OFF;

insert into prova_id(descrizione) values
('descrizione 010'),
('descrizione 011'),
('descrizione 012');

--mi dà errore se metto null 
insert into prova_id(descrizione) values
(null, 'descrizione 999');


--questo mi dà errore perche può esserci solo 1 IDENTITY in una tabella
CREATE TABLE prova_id_2
   (	
    identificativo int IDENTITY(1,1),
	descrizione VARCHAR(100), 
	id3 int IDENTITY(1,1),
	primary key(identificativo)
   );
go
