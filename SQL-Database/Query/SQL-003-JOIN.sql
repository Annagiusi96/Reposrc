--JOIN ((sempre definita su due tabelle)) metto sullo stesso piano le righe delle sue tabelle
use pinkacademy
go

select * from cjda;
select * from cjdb;

--se vogliamo emttere insieme qst due tabelle:
select ca.x, cb.x
from cjda ca, cjdb cb

--risultato 4 righe tabella cs, 5 righe tabella cb
--risultato 4*5=20 righe

--JOIN effettuata tramite una WHERE ((come si faceva prima dell'operatore join)
--((esempio di inner join)) basata sull uguaglianza, torna tutte le righe che fanno match 
--(che hanno una corrispondenza con le altre righe)
select r.nome, p.nome --combina insieme tutti i nomi delle regioni con tutti i nomi delle province (senza criterio)
from regioni r, province p
where p.id_regione = r.id; 
--con where-> combino quando id regione che trovo nelle province corrisponde all id che trova nelle regioni

--il sistema prima effettua ilprodotto cartesiano e poi con la where applica il filtro 
--e butta via le righe che non sono valide

--si usa operatoe join perchè è piu ottimizzato

--EQUI JOIN join per uguale (tentativo di accoppiare due tabelle su un criterio)=========== due grandi famiglie:
--INNER JOIN ((operatore di intertezione)) tengono conto solo delle righe accoppiate
---sono le piu frequenti
---quando riusciamo a mettere sulla medesima riga ciascuna delle righe dell'altra tabella

--OUTER JOIN ((tutte le righe di una tab piu tutte le righe della seconda tab che 
---uniscono alle inner join le righe della tab di sin e della dex
---outer join di sin tengono conto di tutte le righe accoppiate + tutte le righe della tab di sinistra
---outer join di dex tengono conto di tutte le righe accoppiate + tutte le righe della tab di destra

--CROSS JOIN (equivale al prodotto cartesiano)--> tutte le righe di una tab che si uniscono a tutte le righe da un'altra tabella


--INNER JOIN ESEMPI 
--bisogna chiedersi--> (qual è il criterio per legarli? quali sono i campi in comune?)
--possiamo accoppiare sempre due tabelle se abbiamo un criterio in comune
--se il criterio vale avremo una inner join, altrimenti avremo una delle outer join
select * 
from clienti;

select *
from ordini;

--id_cliente lega le due tabelle
--possiamo usare id_cliente come test di uguaglianza

--fornire elenco degli ordini per ogni cliente

select a.nome, a.cognome, b.data, b.valore
from clienti a --left table (và di fianco al from)
inner join ordini b --right table (di fianco a inner join)
on a.id_cliente = b.id_cliente;

--join per regioni e province

select * from regioni;
select * from province;
--legam tra regioni e province può essere effettuato tramite accoppiamento di:
--regiorni.id e province.id_regione

select r.id, r.nome, p.id, p.nome, p.sigla_automobilistica
from regioni r
inner join province p
on r.id = p.id_regione

--è arbitario decidere qual è la tab di sin e di dex
--normalmente si mette a sin la tab che 'governa' il nostro ragioname e a dex quella che 'traina'
--è uguale a dire:

select r.id, r.nome, p.id, p.nome, p.sigla_automobilistica
from province p
inner join regioni r
on p.id_regione = r.id;

--ES. inner join tra regioni e comuni
select * from regioni;
select * from comuni;

select r.id, r.nome, c.nome
from regioni r
inner join comuni c
on r.id = c.id_regione

--LEFT OUTER JOIN
---ci dà tutto quello che ci dava inner join + i clienti che falliscono la inner A DESTRA
---tiro fuori tutta la inner piu la tabella di sinistra (dove a dex non ci sono dati viene messo null)
select a.nome, a.cognome, b.data, b.valore
from clienti a
left join ordini b
on a.id_cliente = b.id_cliente;

--spesso succede che l'evoluzione naturale della left join è quella con esclusione della inner
--forniamo l'elenco che NON hanno effettuato gli ordini

--left join con esclusione della inner
--dal risultato butto via quello che non mi serve
select a.nome, a.cognome, b.data, b.valore
from clienti a
left join ordini b
on a.id_cliente = b.id_cliente
where data is null; --oppure where valore is null è la stessa cosa

--left join con inversione delle tabelle
--portiamo la clienti a al posto della ordini
--se inverto le tabelle ottengo la right join
--questo serve perche alcuni database non hanno la right join
select a.nome, a.cognome, b.data, b.valore
from ordini b
left join clienti a
on a.id_cliente = b.id_cliente;
--ottengo lo stesso risultato
select a.nome, a.cognome, b.data, b.valore
from clienti a
right join ordini b 
on a.id_cliente = b.id_cliente;

--right join tira fuori righe inner + il fallimento delle righe di sinistra

--focalizziamoci solo sui valori nulli
--right join con esclusione della inner
select a.nome, a.cognome, b.data, b.valore
from clienti a
right join ordini b 
on a.id_cliente = b.id_cliente
where nome is null;


--FULL OUTER JOIN unione della right e della left (by union)
--non tutti i database hanno istruzione full join, infatti viene usato il meccanisco UNION
select a.nome, a.cognome, b.data, b.valore
from clienti a
left join ordini b 
on a.id_cliente = b.id_cliente
union
select a.nome, a.cognome, b.data, b.valore
from clienti a
right join ordini b 
on a.id_cliente = b.id_cliente

--sql serve ci da l operatore full join:
select a.nome, a.cognome, b.data, b.valore
from clienti a
full join ordini b 
on a.id_cliente = b.id_cliente

--============================================es dal db-> join-db-per-es

--elencare padre, figlio, eta del figlio
select a.father, a.child, b.age
from fatherchild a
inner join person b
on a.child = b.name

--marito e moglie, figlio
select a.mother, a.child, b.father, b.child
from motherchild a
inner join fatherchild b
on a.child = b.child

select a.father, a.child, b.mother, b.child
from fatherchild a
left join motherchild b --mi dà anche padri che non hanno figli da parte di moglie
on a.child = b.child

select a.father, a.child, b.mother, b.child
from fatherchild a
right join motherchild b--mi dà anche mogli che non hanno figli da parte di padre
on a.child = b.child

select a.father, a.child, b.mother, b.child
from fatherchild a
full join motherchild b --mi dà tutto insieme, sia inner, left che right join
on a.child = b.child

--

select a.father, p4.age as 'father age', a.child, p2.age, b.mother, p3.age as 'mother age',b.child, p1.age
from fatherchild a
full join motherchild b
on a.child = b.child
left join person p1
on b.child = p1.name
left join person p2
on a.child = p2.name
left join person p3
on b.mother = p3.name
left join person p4
on a.father = p4.name

--esiste un'anomalia
--steve non ha età

--come verificare
--come sistemare se possibile

--steve è l'unico senza età:
--le 4 query servono per verificare l'integrità tra tabelle persone e altre tab
select father
from fatherchild
where father not in(
	select name
	from person
)

select mother
from motherchild
where mother not in(
	select name
	from person
)

select child
from motherchild
where child not in(
	select name
	from person
)

select child
from fatherchild
where child not in(
	select name
	from person
)

--siccome è l'unico senza età, la aggiungiamo:
insert into person (name, age, income) values
	('Steve', 98, 40000);

select * from person;

--trovare le relazioni di parentela padre, madre, figlio compresi orfani
--partendo da person

--versione base con NULL
select p.name, p.age, p.income, f.father, m.mother
from person p
full join fatherchild f
on p.name = f.child
full join motherchild m
on p.name = m.child

--sostituiamo NULL con '-'
select p.name, p.age, p.income, 
case when f.father is null then '.' else f.father end f_name, 
case when m.mother is null then '-' else m.mother end m_mother
from person p
full join fatherchild f
on p.name = f.child
full join motherchild m
on p.name = m.child

--con coalesce si testa sia il null che la stringa vuota e viene sostituita con '-'
select p.name, p.age, p.income, 
coalesce(f.father, '-') as 'father name', 
coalesce(m.mother, '-') as 'mother name'
from person p
full join fatherchild f
on p.name = f.child
full join motherchild m
on p.name = m.child

--se è null, sostituiamo con '-'
select p.name, p.age, p.income, 
isnull(f.father, '-'), 
isnull(m.mother, '-')
from person p
full join fatherchild f
on p.name = f.child
full join motherchild m
on p.name = m.child


select p.name, p.age, p.income, 
iif(f.father is null, '-', f.father) as 'father', 
iif(m.mother is null, '-', m.mother) as 'mother'
from person p
full join fatherchild f
on p.name = f.child
full join motherchild m
on p.name = m.child


