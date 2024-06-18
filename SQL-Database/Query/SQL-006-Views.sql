
select 
	person.name as name,
	person.age as age,
	person.income as income,
	motherchild.mother as mother,
	p1.age as mother_age,
	p1.income as mother_income,
	fatherchild.father as father,
	p2.age as father_age,
	p2.income as father_income
from person
full join motherchild
on person.name = motherchild.child
full join fatherchild
on person.name = fatherchild.child
left join person p1
on p1.name = motherchild.mother
left join person p2
on p2.name = fatherchild.father;


--se voglio estrapolare elenco madri da qull query
select distinct mother from --così non ho duplicati
(
select 
	person.name as name,
	person.age as age,
	person.income as income,
	motherchild.mother as mother,
	p1.age as mother_age,
	p1.income as mother_income,
	fatherchild.father as father,
	p2.age as father_age,
	p2.income as father_income
from person
full join motherchild
on person.name = motherchild.child
full join fatherchild
on person.name = fatherchild.child
left join person p1
on p1.name = motherchild.mother
left join person p2
on p2.name = fatherchild.father
) xxx
where mother is not null;


--se voglio estrapolare elenco padri da qull query
select distinct father from 
(
select 
	person.name as name,
	person.age as age,
	person.income as income,
	motherchild.mother as mother,
	p1.age as mother_age,
	p1.income as mother_income,
	fatherchild.father as father,
	p2.age as father_age,
	p2.income as father_income
from person
full join motherchild
on person.name = motherchild.child
full join fatherchild
on person.name = fatherchild.child
left join person p1
on p1.name = motherchild.mother
left join person p2
on p2.name = fatherchild.father
) xxx
where father is not null;

--in qst modo devo duplicare il codice piu volte
--per minimizzare le duplicazioni di codice dovute all'utilizzo ricorrente di nested select, sql ci consente di creare le VIEW
--sql ci consente però di fare LE VIEW

create view /*nome della vista*/ person_full as
select 
	person.name as name,
	person.age as age,
	person.income as income,
	motherchild.mother as mother,
	p1.age as mother_age,
	p1.income as mother_income,
	fatherchild.father as father,
	p2.age as father_age,
	p2.income as father_income
from person
full join motherchild
on person.name = motherchild.child
full join fatherchild
on person.name = fatherchild.child
left join person p1
on p1.name = motherchild.mother
left join person p2
on p2.name = fatherchild.father;

--sql ci ha consentito di dare un nome a qst query e metterla nel catalogo delle viste
--a qst punto posso->

select distinct mother from person_full; 
select distinct father from person_full; 

--sql server prende la query, la compila, crea un execution plan e lo memorizza gia compilato sotto il nome di view
--tutte le volte che noi andiamoa riutilizzare la view, lui tira fuori dalle view qll select congelata
--la esegue e da il risultato

--congela la select in una libreria e poi se la riprende in maniera precompilata per essere piu veloci

--inoltre la VIEW è una select già compilata e con già fattol'execution plan 
--che viene ripresa dal catalogo tutte l volte che la si invochi

--la view si usa nelle select come una normale table

----es:

-- per le righe abbinate di comuni italiani
--creare una view che unisca 
--regione, provincia, targa, comune, area geografica, densità demografica
--da comuni ==> codice catastale, capoluogo_provincia
drop view if exists comuni_full;
go
create view comuni_full as
select 
	ci.regione as regione,
	ci.provincia as provincia,
	ci.prov as targa,
	ci.comune as comune,
	c.codice_catastale as codice_catastale,
	c.capoluogo_provincia as capoluogo_provincia,
	ci.area_geo as area_georgrafica,
	ci.densita_demogr as densità_demografica
from comuni_italiani ci
inner join comuni c
on ci.id_comune = c.id;
go

select * from comuni_full;
select comune,targa from comuni_full;

select count(*) from clienti;
select count(*) from ordini;


--query base tra clienti ed ordini
select 
	cli.nome, 
	cli.cognome,
	cli.id_cliente,
	ord.id_ordine,
	ci.regione,
	ci.prov,
	ord.data,
	ord.valore
from clienti cli
inner join ordini ord
on cli.id_cliente = ord.id_cliente
inner join comuni_full ci
on cli.provincia = ci.prov;

--somma degli ordini per cliente
select
	cli.id_cliente,
	cli.nome,
	cli.cognome,
	sum(valore) as 'tot ordinato per cliente'
from clienti cli
inner join ordini ord
on cli.id_cliente = ord.id_cliente
group by cli.id_cliente, cli.nome, cli.cognome;

--somma degli ordini per cliente/provincia
select
	cli.id_cliente,
	cli.nome,
	cli.cognome,
	cli.provincia,
	sum(valore) as 'tot ordinato per cliente'
from clienti cli
inner join ordini ord
on cli.id_cliente = ord.id_cliente
group by cli.id_cliente, cli.nome, cli.cognome, cli.provincia;

-- fare l'ordinato per provincia (senza il cliente)

select
	cli.provincia,
	p.nome,
	sum(valore) as 'tot ordinato per provincia'
from clienti cli
inner join ordini ord
on cli.id_cliente = ord.id_cliente
inner join province p
on sigla_automobilistica = cli.provincia
group by cli.provincia, p.nome
order by p.nome;

--ord--clienti-comuni-regioni

select
	r.nome,
	sum(valore) as 'tot ordinato per regione'
from ordini ord
inner join clienti cli
on ord.id_cliente = cli.id_cliente
inner join comuni c
on cli.citta = c.nome
inner join regioni r
on r.id = c.id_regione
group by r.nome;





--ord--clienti-comuni_full-regioni 

select 
	r.nome,
	sum(valore) as 'tot ordinato per regione'
from ordini ord
inner join clienti cli
on ord.id_cliente = cli.id_cliente
inner join comuni_full c
on c.targa = cli.provincia and cli.citta = c.comune
inner join regioni r
on r.nome = c.regione
group by r.nome;

select distinct regione from comuni_full;

create view province_integrata as
select distinct regione, provincia, targa
from comuni_full;

select 
 r.nome
 sum(valore)
from ordini ord
inner join clienti cli
on ord.id_cliente = cli.id_cliente
inner join province_integrata pi
on pi.targa = cli.provincia
inner join regioni r
on r.nome = pi.regione
group by r.nome;

SELECT 
    r.nome AS 'Regione',
	count(*),
    SUM(ord.valore) AS 'Totale ordinato per Regione'
FROM 
    ordini ord
INNER JOIN 
    clienti cli	 ON cli.id_cliente = ord.id_cliente
INNER JOIN 
	province_integrata pi ON pi.prov = cli.provincia
INNER JOIN 
    regioni r ON r.nome = pi.regione
GROUP BY 
    r.nome
	ORDER BY 'Totale ordinato per Regione';