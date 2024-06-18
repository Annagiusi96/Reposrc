--query 001

--per ogni query che facciamo è sempre bene mettere in testa lo script:
use pinkacademy;
go


--uccidere tabella:
drop table if exists prova;
go 
--creare tabelle:
create table prova (
	codice int,
	descrizione varchar(100), --string di al massimo 100 caratteri
	prezzo decimal(10, 2),
	);
	go

--^^ciasciuna ringa: 
-- la I è di tipo int
-- la II (caratteri)
-- la III decimal (10 numeri e due decimali)
-- per uccidere la taballa: drop table if extists prova

--inseririmento dati forma completa:
--per inserimenti SINGOLI
insert into prova (codice, descrizione, prezzo) values (01, 'Primo articolo', 100.33);
insert into prova (codice, descrizione, prezzo) values (02, 'Secondo articolo', 24.20);
insert into prova (codice, descrizione, prezzo) values (03, 'Terzo articolo', 2.99);

--inseririmento dati forma breve:
--va fatto con operazioni che non vengono ripetute, è un po criptico
insert into prova  values (04, 'Quarto articolo', 1200);
insert into prova  values (05, 'Quinto articolo', 18.44);
insert into prova  values (06, 'Sesto articolo', 2.99);

--inserimento forma veloce per molte righe
--(ti dò prima elenco dei campi da inserire e poi i valori di ogni riga separati da virgola
--rende piu veloce la trasmissione dei dati al server, e il server esegue una sola volta lo statement
insert into prova (codice, descrizione, prezzo) values 
(07, 'Settimo articolo', 70.21),
(08, 'Articolo 9', 1.34);
go

--Aggiornamenti tuple o UPDATE
--se vogliamo prendere un articolo e cambiargli il valore:
--insert into prova  values (04, 'Quarto articolo', 1200); ==> ('Articolo IV)'

update prova 
set descrizione = 'Articolo IV' --set => riga
where codice = 04; --quale riga? dove il codice è = a 4;

update prova
set prezzo = 150; -- se non specifico qual è la riga da aggiornate aggiorno tutta la colonna prezzo = 150

-- cancellazioni di tuple
delete from prova
where codice = 3; --elimino la riga dove il codice = 3

delete from prova
where codice in (1,2,3,33,78,-123); 
--se il codice cade in uno di questi range allora viene eliminato, sennò non succedere nulla

--se scrivo solamente
delete from prova; --elimino tutta la tabella

--le righe sono insieme di dati
--se lavoro su una determinata riga la centro tramite la clausola WHERE (è come se fosse la IF)

--visualizzazione
select codice, descrizione, prezzo --mi tira fuori una tabella risultato della mia interrogazione
from prova;

--se si rinchiudono i campi in parentesi quadre: (rende sql in maniera case sensitive)
--mi da la stessa cosa perchè la tabella è case insensitive
select [codice], [descrizione], [prezzo]
from prova;

insert into prova (codice, descrizione, prezzo) values (100, 'nuovo articolo', null);

--alter table (disolito fanno i database administrator) -> inserire ad es una colonna 'classificazione'
alter table prova add classificazione char(4)

select * from prova;
--dalla tabella completa proietto un'altra tabella:

select codice, descrizione from prova --qst operazione si chiama PROIEZIONE (sottoinsieme di dati)
-- in questa tabela che ottengo posso cambiare i nomi di quello che voglio vedere

select codice, descrizione as 'Descrizione prodotto' from prova --RIDENOMINAZIONE

select codice, descrizione as 'Descrizione prodotto' from prova as p --RIDENOMINAZ TABELLA

select codice, descrizione as Prodotto from prova --se ho una sola parola non metto apici (prodotto)

select prova.codice, prova.descrizione as Prodotto from prova --posso anche scriverla così (sintassi completa)
--per ambiguità è obbligatorio

select codice from prova where codice = 100; --ottengo sempre una tabella, di una riga e una colonna

--ES=> creare tabella studenti:

create table studenti (
	nome varchar(100),
	cognome varchar(100),
	matricola char(8),
	età int
);
go

--inserire 5 righe
insert into studenti (nome, cognome, matricola, età) values
	('Annagiusi', 'Volpe', '88990077', 28),
	('Angela', 'Lupo', '99776655', 30),
	('Andrea', 'Rossi','00443322', 22),
	('Luca', 'Gialli', '22115588', 28),
	('Monica', 'Verdi', '55446622', 32);
go

--modificare 2 tuple
update studenti 
set matricola = 11556644
where nome = 'Annagiusi';

update studenti 
set cognome = 'Marroni'
where nome = 'Luca';

--cancellare una row 
delete from studenti
where nome = 'Monica';

select nome, cognome, matricola, età from studenti