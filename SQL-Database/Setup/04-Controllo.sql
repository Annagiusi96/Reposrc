
select tipo, conteggio
from (
        select 'Regioni' as 'Tipo', count(*)  as 'Conteggio'
        from regioni
    union
        select 'Province', count(*)
        from province
    union
        select 'Comuni', count(*)
        from comuni ) xyz

order by conteggio desc;
/* order by 2 */


-- Risultato da ottenere
-- Conteggio | Regioni | Province | Comuni
--           |      20 |      110 |   7999
select  sum(R) as 'Regioni', sum(P) as 'Province', sum(C) as 'Comuni'
from
    (
            select count(*)  as 'R', 0 as 'P', 0 as 'C'
        from regioni
    union
        select 0, count(*), 0
        from province
    union
        select 0, 0, count(*)
        from comuni
) contatori
;

select
    (select count(*) from regioni) as 'Regioni', 
    (select count(*) from province) as 'Province', 
    (select count(*) from comuni) as 'Comuni';


drop view if exists conteggio_regioni_province_comuni_view
go

create view conteggio_regioni_province_comuni_view as
select tipo, conteggio
from (
        select 'Regioni' as 'Tipo', count(*)  as 'Conteggio'
        from regioni
    union
        select 'Province', count(*)
        from province
    union
        select 'Comuni', count(*)
        from comuni ) xyz
go


select * from conteggio_regioni_province_comuni_view
go


select conteggio from conteggio_regioni_province_comuni_view
where tipo = 'Regioni'
go
