--obiettivo allineamento tra tabelle
--comuni (ufficiale) e comuni italiani (da esterno)

--trovare delle vie per dei join
--esplorare colonne e dati
--aggiung colonne alla nuova table (alter table)
--effett inserimenti, update
--limiti: non toccare la comuni italiani
--documentare ogni passo per rendere la procedura replicabile
--documentare e spiegare eventuali anomalie

/*query conoscitive per esplorare la struttura e il contenuto delle tabelle
- corrispondono comuni.nome e comuni_italiani.comune
- corrispondono comuni.id e comuni_italiani.istat
- provincia in comuni è id_provincia
- provincia in comuni_italiani è provincia e prov (sigla)
- regione in comuni_italiani è regione 
- regione in comuni è id_regione 
*/
select top(10) * from comuni_italiani order by comune;

select top(10) * from comuni order by nome;

/*query conoscitiva verifica conteggio delle row di ciascuna tabella*/
select count(comune) from comuni_italiani; --7978
select count(nome) from comuni; --7999

--scoperta differenza tra numero record comuni e record comuni italiani (-21)
--****differenze: mancano 21 comuni da comuni_italiani

select 
	(select count(comune)
	from comuni_italiani) as 'comuni italiani',
	(select count(nome)
	from comuni) as 'comuni',
	(select count(comune)
	from comuni_italiani) - (select count(nome) from comuni) as 'differenza'

--notati diversi null sia in comuni che in comuni italiani
--full join conta 8156 righe --> ci sono comuni che non si allineano (diversi null)
select a.nome as 'comuni', b.comune as 'comuni italiani'
from comuni a
full join comuni_italiani b
on a.nome = b.comune

select count(*) --8156 righe
from comuni a
full join comuni_italiani b
on a.nome = b.comune

select count(*) --8013 righe
from comuni a
left join comuni_italiani b
on a.nome = b.comune

--8156-8013
--8156--> maggiore del massimo num di righe presenti nelle tab

--AA select count(*) --164 che falliscono a destra --> in comuni_it vi sono nomi diversi
select count(*)
from comuni a
left join comuni_italiani b
on a.nome = b.comune
where b.comune is null

--AB select count(*) --143 che falliscono a sinistra --> in comuni vi sono nomi diversi
select count(*)
from comuni a
right join comuni_italiani b
on a.nome = b.comune
where a.nome is null

--143 + 21 (righe mancanti) -> 164

/*
il risultato delle query ci indicano che l insieme di righe non coperto dalla join 
è il medesimo in entrambe le tabelle, quindi corente
non vi sono altre anomalie se non la differenza di nomi

*/

select count(a.nome) as 'comuni', count(b.comune) as 'comuni italiani' --comuni= 8013 - comuni italiani=7992
from comuni a
full join comuni_italiani b
on a.nome = b.comune

--comuni che sono in comuni e non sono in comuni italiani (164)
select count(nome)
from comuni 
where nome not in (
	select comune from comuni_italiani 
)

--comuni che sono in comuni italiani e non sono in comuni (143)
select count(comune)
from comuni_italiani
where comune not in (
	select nome from comuni
)

--per la regione trentino in comuni il separatore tra le lingue è ' / '
--mentre in comuni_italiani gli spazi sono omessi
-- altri comuni effettivamente hanno cambiato nome

select r.nome, c.nome
from comuni c
inner join regioni r
on r.id = c.id_regione
where c.nome not in (
	select comune from comuni_italiani 
)


select a.nome as 'comuni', a.id, b.comune as 'comuni italiani', b.istat
from comuni a
full join comuni_italiani b
on a.nome = b.comune

select * from comuni
where id_regione in (
	select id
	from regioni
	where nome = 'trentino-alto adige')

select * from regioni 
select * from province order by nome

select * from comuni
where id_provincia in (
	select id
	from province
	where nome = 'bolzano')

select * from comuni where id_provincia = 21;
select * from comuni_italiani where regione = 'trentino-alto adige';

select a.nome as 'comuni', a.id, b.comune as 'comuni italiani', b.istat
from comuni a
full join comuni_italiani b
on a.id = b.istat;

--comuni italiani è piu aggiornato xke alcuni nomi di comuni non corrispondono ai nomi comuni_italiani
select a.nome as 'comuni', a.id, b.comune as 'comuni italiani', b.istat
from comuni a
full join comuni_italiani b
on a.id = b.istat
where a.nome != b.comune;

select count(*)
from comuni c
inner join comuni_italiani ci
on c.id = ci.istat --7812 id uguale

select count(*)
from comuni c
inner join comuni_italiani ci
on c.nome = ci.comune --7849 nome uguale

select count(*) from comuni_italiani --7978

--======================================================================
--punto della situazione


select 'Coperti da Nome e ID', count (c.nome) --7679
from Comuni c
join comuni_italiani ci
on c.id = ci.istat and c.nome = ci.comune
--
union
--
select 'Coperti da id', count (c.nome)--7812
from Comuni c
join comuni_italiani ci
on c.id = ci.istat
--
union
--
select 'Non Coperti da id', count (c.nome)--187
from Comuni c
left join comuni_italiani ci
on c.id = ci.istat
where ci.istat is null
--
union
--
select 'Coperti da Nome', count (c.nome)--7849
from Comuni c
join comuni_italiani ci
on c.nome = ci.comune
--
union
--
select 'Non Coperti da Nome', count (c.nome)--164
from Comuni c
left join comuni_italiani ci
on c.nome = ci.comune
where ci.comune is null
--
union
--
select 'row di comuni', count(c.nome)--7999
from comuni c
--
union
--
select 'row di comuni italiani', count(ci.comune)--7978
from comuni_italiani ci
;

--7978 (comuni it)- 7812 (coperti da id) =  166 righe
--7978 (comuni it)- 7849 = 129 (fuori dalla copertura con il nome)
--164 (nn coperti da nome) - 129 = 35

select 
(select count (distinct c.nome) from Comuni c) as 'numero comuni con nome diverso',
(select count(*) from comuni) - (select count (distinct c.nome) from Comuni c) as 'numero comuni con nome uguale e id diverso',
(select  count (distinct c.comune) from comuni_italiani c )  as 'numero comuni italiani con nome diverso',
(select count(*) from comuni_italiani) - (select  count (distinct c.comune) from comuni_italiani c )  as 'numero comuni_italiani con nome diverso'
;

--stessi nomi di comuni ma in province diverse
select c.nome, c.id_provincia, p.nome
from comuni c
inner join comuni c1
on c.nome = c1.nome
inner join province p
on c.id_provincia = p.id
where c.id_provincia != c1.id_provincia

--anche in comuni italiani si vede la stessa cosa
select c.comune, c.provincia
from comuni_italiani c
inner join comuni_italiani c1
on c.comune = c1.comune
where c.provincia != c1.provincia

--siccome ci sono --7978 (comuni it)- 7812 (coperti da id) =  166 righe senza a cui non corrispondono id
--bisogna:

--aggiungere colonna a comuni_italiani con denominazione id_comune
alter table comuni_italiani add id_comune int;

select distinct id_comune from comuni_italiani; --tutte le righe hanno il valore null

/*
intervento per tentare appaiamento delle tabelle

-1) aggiungere una colonna denominata id_comune alla tabella comuni_italiani che conterrà l'id
	del comune della tabella comuni
-2) aggiornamento della colonna id_comune con l'id della tabella comuni tramite join 
	tra comuni.id e comuni_italiani.istat. 
	in pratica per le righe che cadranno nella join avremo che istat = id_comune.
	Si attendono 7812 coperte 
-3) verifica relative alle righe non coperte
-4) copertura delle righe con id_comune = null tramite join tra comuni.nome e comuni_italiani.comune
-5) verifiche relative alle righe non coperte
*/
--UPDATE SU UNA JOIN
--aggiorna la tab destinazione
--imposta il compa destinazione = dato preso dalla join

--update di comune impostando sulla base della join id/istat

select count(*) --attese 7812 righe
from comuni c
inner join comuni_italiani ci
on c.id = ci.istat;

update comuni_italiani --aggiorno la tab comuni it
set comuni_italiani.id_comune = c.id --setto la colonna id_comune
from comuni c
inner join comuni_italiani ci
on c.id = ci.istat;

select count(*)
from comuni_italiani
where id_comune is null --166

select count(*)
from comuni_italiani
where ci.id_comune = ci.istat --attese 7812 righe

--contare qnt righe sistemerebba la join sui nomi
--166 righe e vedere se la join 

select a.comune, b.nome, b.id
from comuni_italiani a
inner join comuni b
on a.comune = b.nome
where id_comune is null --157 nomi uguali


select c.nome, ci.comune, p.sigla_automobilistica, ci.prov
from comuni c
inner join province p
on c.id_provincia = p.id
inner join comuni_italiani ci
on c.nome = ci.comune and p.sigla_automobilistica = ci.prov;


select c.nome, ci.comune, p.sigla_automobilistica, ci.prov
from comuni c
inner join province p
on c.id_provincia = p.id
inner join comuni_italiani ci
on c.nome = ci.comune and p.sigla_automobilistica = ci.prov
where ci.id_comune is null
;

--order by 1,2 (ordinami per la prima colonna e poi per la seconda)

--qnd facciamo una join di una tabella su stessa stiamo facendo una self join
--bisogna dare un alias diverso perche c'è la collisione di tutti i nomi