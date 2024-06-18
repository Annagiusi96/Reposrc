--database italia ==> select
use pinkacademy;
go

--COUNT(*) ==> funzione SQL (parametro). è una funzione di AGGREGAZIONE 
--((trasforma il nostro set di righe in un'unica riga))

select count(*) from regioni;

--andiamo a denominare la colonna che viene fuori
select count(*) as conteggio from regioni;

--accanto alla select ci va l elenco delle colonne da proiettare
-- con * vuol dire che voglio proiettare tutte le colonne
select * from regioni;

/*questa scrittura in un programma ufficiale,doc ufficiali non va mai usato perche va contro la manutenzione
se la tabella è partita da un num di colonne ed è cambiato, così non tengo conto dell'evoluzione della tabella

usare * è leggittimo per il quick & dirty (ovvero per fare una cosa per noi) ad esempio per sapere tutte le colonne
*/

--va scritta così se vogliamo vedere tutte le colonne
--qst scrittura è molto piu chiara e il condice è piu manutenibile
select id, nome, latitudine, longitudine from regioni;

select count(codice_citta_metropolitana) as conteggio from province 
--mi conta tutte le occorrenze di una colonna che NON SONO NULL

select id, nome 
from regioni

select id, nome 
from regioni
where nome like 'a%'; --dove nome inizia per a

select id, nome 
from regioni
where nome like '%a'; --dove nome finisce per a

select id, nome 
from regioni
where nome like '%a%'; --dove nome contiene una a

--=================================================================
--se lavoriamo con numeri

select id, nome 
from regioni
where id = 10 or id = 11;

select id, nome 
from regioni
where id in (10,11); --lista di valori

--sono uguali

--AND devono ess entrambe vere
select id, nome 
from regioni
where id = 10 and id = 11; --non tira fuori nulla perche non c'è una regione che ha id sia = 10 che a 11

select id, nome
from regioni
where nome like 'l%' and nome like '%a'; --tira fuori nome che iniziano per l e finiscono per a

select id, nome 
from regioni
where id not in (10,11);--tita fuori tutte le regioni TRANNE quelle che hanno id=10 e 11

--contare province che contengono una b nel nome?
select count(*) as conteggio
from province 
where nome like '%b%';

select id, nome 
from province
where nome like '%b%'
order by nome; --< criterio di ordinamento

/*ES- elencare tutte le province lazio in ordine alfabetico*/

select *
from regioni; --per ogni regione c'è un id

select *
from province; --il lazio ha id = 12

select nome as Province_Lazio
from province
where id_regione = 12
order by nome;

--elencare tutti i comuni della provincia di roma

select *
from comuni

select *
from province
where nome = 'Roma' --id di roma è 58

select nome
from comuni
where id_provincia = 58
order by nome

--elencare tutte le province del veneto e della calabria

select *
from regioni 
where nome = 'Veneto' or nome = 'Calabria'; --id veneto 5, id calabria 18

select nome
from province
where id_regione = 5 or id_regione = 18
order by nome;

--la OR posso scriverlo con IN

select *
from regioni 
where nome in ('Veneto','Calabria'); --id veneto 5, id calabria 18

select nome
from province
where id_regione in (5, 18)
order by nome;


select id
from regioni
where nome in ('Veneto','Calabria');

--NESTED SELECT ((si parte sempre dall interno a pensare la condizione))

select nome
from province
where id_regione in (
	select id
	from regioni
	where nome in ('Veneto','Calabria') --qst tabella deve avere una sola colonna (entro quale elemento della lista devo controllare?)
)
order by nome;

--null
select id, nome, sigla_automobilistica
from province
where codice_citta_metropolitana is not null; --(non è null) mi da la tabella delle citta metropolitane

--elenco id citta metropolitane

select id
from province
where codice_citta_metropolitana is not null;

--elenco dei comuni appartenenti alle province delle città metropolitane
select id, id_provincia, nome
from comuni
where id_provincia in(
	select id
	from province
	where codice_citta_metropolitana is not null
)
order by nome;

--elenco dei nomi delle citta metropolitane
select nome
from province
where codice_citta_metropolitana is not null;

select id_regione
from comuni
where nome in (
	select nome
	from province
	where codice_citta_metropolitana is not null
);

select nome from regioni
where id in(
	select id_regione
	from comuni
	where nome in (
		select nome
		from province
		where codice_citta_metropolitana is not null
	)
)
order by nome

--elencare tutte le province che non sono dell'abruzzo e nella lombardia

select id,nome
from regioni
where nome in ('lombardia','abruzzo') --abbruzz 13 e lomb 3

select id, nome
from province
where id_regione in (
	select id
	from regioni
	where id not in(13,3)
)

--select interna
select id
from regioni
where nome not in('Abruzzo','Lombardia') --id regioni che non sono abb e lomb

--select esterna
select id,nome
from province
where id_regione in (
	select id
	from regioni
	where nome not in('Abruzzo','Lombardia')
)

--usiamo la and x lo stesso risultato
select id,nome
from province
where id_regione in(
	select id
	from regioni
	--where nome != 'Abruzzo' and ! = 'Lombardia'
)

select count(*) as 'Conteggio Regioni' from regioni ;

select count(*) as 'Conteggio Province' from province ;

select count(*) as 'Conteggio Comuni' from comuni ;

--come mettere insieme qst 3 select?
--unire i risultati
--il problema è che la colonna unica prende come nome solo la prima, ovvero conteggio regioni

select count(*) as 'Conteggio Regioni' from regioni 
union
select count(*) as 'Conteggio Province' from province 
union
select count(*) as 'Conteggio Comuni' from comuni 

--come risolvo?
--posso inventarmi dei campi dopo la select

select 'Regioni' as 'Tipo', count(*) as 'Conteggio' from regioni 
union
select 'Province', count(*) as 'Conteggio' from province 
UNION
select 'Province', count(*) as 'Conteggio' from province 
union
select 'Comuni', count(*) as 'Conteggio' from comuni 

--la UNION sopprime i doppioni
--quindi se duplico una riga uguale me la  sovrappone
--UNION --> OPERATORE INSIEMISTICO che sopprime i doppi
--se voglio vedere i doppi devo fare UNION ALL
--UNION ALL-> OPERATORE SQL che non sopprime i doppioni

select 'Regioni' as 'Tipo', count(*) as 'Conteggio' from regioni 
union all
select 'Province', count(*) as 'Conteggio' from province 
union all
select 'Province', count(*) as 'Conteggio' from province 
union all
select 'Comuni', count(*) as 'Conteggio' from comuni 

--se voglio una linea unica con tutti i risultati?
select 
	(select count(*)  from regioni) as 'Conteggio Regioni',
	(select count(*)  from province) as 'Conteggio Province',
	(select count(*)  from comuni) as 'Conteggio Comuni';


--esercizio : contare i comuni della provincia di roma, milano, napoli, torino
--elencarli in piu righe ((I output))

--elencarli in una singola riga ((II output))

--elenco multiriga
select 'Comuni Roma' as 'Comuni', count(*) as 'Conteggio' 
from comuni where id_provincia in (
	select id from province where nome = 'roma')
union
select 'Comuni Milano', count(*) as 'Conteggio' 
from comuni where id_provincia in (
	select id from province where nome = 'milano')
union
select 'Comuni Napoli', count(*) as 'Conteggio' 
from comuni where id_provincia in (
	select id from province where nome = 'napoli')
union
select 'Comuni Torino', count(*) as 'Conteggio' 
from comuni where id_provincia in (
	select id from province where nome = 'torino')

--elenco singola riga
select
	(select count(*) from comuni 
		where id_provincia in (
			select id from province 
			where nome = 'roma')) as 'Comuni Roma',

	(select count(*) from comuni 
		where id_provincia in (
			select id from province 
			where nome = 'milano')) as 'Comuni Milano',

		(select count(*) from comuni 
			where id_provincia in (
				select id from province 
				where nome = 'napoli')) as 'Comuni Napoli',

		(select count(*) from comuni 
			where id_provincia in (
				select id from province 
				where nome = 'torino')) as 'Comuni Torino';

--========================== prove mie ======================================

--conteggio comuni campania
select count(*) as 'TOT comuni campania'
from comuni
where id_regione in (
	select id
	from regioni
	where nome = 'campania'
)

--tutti i comuni della campania che iniziano per a
select nome as 'Comuni Campania'
from comuni
where id_provincia in( --in comuni id ->id_provincia che collega alla tab provincia
	select id
	from province
	where id_regione in(--in province id_regione che collega la tab alle regioni
			select id
			from regioni
			where nome = 'campania'
		) 
) and nome like 'a%'


--prendere query, metterci parentesi tonde, lui la vede come tab virtuale
--dò un nome (temp) e posso accedere ai campi,ovvero i titoli che dò

select sum(Conteggio) as 'conteggio comuni' from
(
	select 'Comuni Roma' as 'Comuni', count(*) as 'Conteggio' 
	from comuni where id_provincia in (
		select id from province where nome = 'roma')
union
	select 'Comuni Milano', count(*) as 'Conteggio' 
	from comuni where id_provincia in (
		select id from province where nome = 'milano')
union
	select 'Comuni Napoli', count(*) as 'Conteggio' 
	from comuni where id_provincia in (
		select id from province where nome = 'napoli')
union
	select 'Comuni Torino', count(*) as 'Conteggio' 
	from comuni where id_provincia in (
		select id from province where nome = 'torino')
)temp;

--per eliminare le righe doppie--> union all oppure DISTINCT
--è da usare solo in estremo alla fine qnd sono sicura che la query funziona
--fino alla fine non sopprimere mai le righe doppie

select top(100) * from comuni; --tirami fuori solo le prime 100 righe

select top(10) id_regione from comuni--mi dà tutti 1
where codice_catastale like 'a%'

select distinct top(10) id_regione from comuni --distinct solo alla fine perche potrebbe nascondere risultati sbagliati
where codice_catastale like 'a%'

--elenco capoluoghi di provincia del lazio
select id, nome
from comuni
where id_provincia in (
	select id
	from province
	where id_regione in (
			select id
			from regioni
			where nome = 'lazio' 
		)
)and capoluogo_provincia = 1
order by nome;

--group by
select capoluogo_provincia, count(capoluogo_provincia) 
from comuni 
group by capoluogo_provincia 
--group by calcola i sottototali tenendo conto dei campi che ci sono prima della funz di aggregazione

--contare quante province ci sono per regione
select * 
from province
order by nome;

select id_regione, count(nome)
from province
group by id_regione

--operazioni di conteggio, tante righe che vanno a finire in una e la distribuzione per criterio di raggrupp
--il criterio di raggruppamento va messo dopo la group by

--contare quanti comuni vi sono per regione
select id_regione, count(nome) as 'TOT comuni' 
from comuni
group by id_regione --sottototali x ogni regione
order by id_regione

--vogliamo suddividerli per provincia, qnt comuni ci sono nelle province di tutte le regioni

select id_provincia, count(nome) as 'TOT comuni' 
from comuni
group by id_provincia

select id_regione , id_provincia, count(nome) as 'TOT comuni' 
from comuni
group by id_regione, id_provincia
order by id_regione



select id_regione, id, nome, sigla_automobilistica
from province;

select id, nome
from regioni;