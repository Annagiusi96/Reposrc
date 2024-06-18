--ALTER examples

alter table prova add class2 varchar(20); --aggiunge una colonna alla tab prova

alter table prova drop column class2; --elimina la colonna class2

alter table prova add class3 varchar(20)
not null constraint const_prova_class3 default 'xxxx'--non può contenere valori null (con not null)

--sintassi abbreviata
alter table prova add class4 varchar(20)
not null --la colonna non può contenere valori null
default 'yyyy';

select * from prova;

insert into prova values(22, 'chiave doppia', 99, 'err', 'gg', 'pp');
--aggiunta di una primary key a una tabella che non ce l'ha

--la primary key può essere già presente nella creazione
--qnd metto il db in forma normale--> aggiungo una primary key

alter table prova alter column codice int not null;--impostiamo codice a not null
delete prova where classificazione = 'err';

alter table prova add primary key (codice); --errore xke c'era la possibilità di creare null nel codice

--se volevvi suggerire dei percorsi piu veloci al motore sql potrei costruire degli indici

--create index su nome comune

create index index_comune on comuni_italiani (comune) --creami un indice in comuni it per ogni comune
--abbiamo costruito un percorso preferenziale che il db puo usare quando deve fare una scansione dei comuni
--attraverso il campo comune
--tutte le join che usano il comune useranno l'index e saranno piu veloci