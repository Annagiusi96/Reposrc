-- questo è un commento
/* questo è un commento */

--sql usa lo statement e il punto e virgola alla fine. è un simbolo che il client usa per capire quando 
-- termina uno statement e ne inizia un altro 

/* SQL server può raggruppare i vari statement in gruppi utilizzando la parola GO 




*/
use master;--ci posizioniamo sul database maste principale
go

drop database if exists pinkacademy --se già esiste lo cancello e ne creo un altro
--step creazione del database di lavoro del corso
go
create database pinkacademy;
go

use pinkacademy;
go

--creazione login
drop login allieva -- lo elimino (se esiste uno uguale lo elimina)
go

create login allieva with password = '@@C202405', default_database = pinkacademy;
go

--creare lo user
drop user allieva -- lo elimino (se esiste uno uguale lo elimina)
go

create user allieva for login allieva;--agganciare utente al login
go

grant control to allieva; --dai il controllo di allieva sul database