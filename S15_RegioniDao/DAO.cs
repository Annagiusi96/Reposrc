using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S15_RegioniDao;
/*
 C# (DAO):
    Count (qnt righe ci sono)→ int
    findById(key) (dammi un’unica riga)→ Entity
    findAll (dammi tutte le righe)→ List<Entity>
    delete(id)
    update(Entity)
    create(Entity)

 */

//per poter gestire in maniera standard le operazioni di db per ogni entità
//per ogni entità dobbiamo c
public interface DAO<ENTITY, KEY> //parametrica perche gestisce vari tipi di dati
{
    //RETRIEVE
    int Count();
    //entity findById(key)
    ENTITY FindById(KEY id);

    //findAll
    List<ENTITY> FindAll();

    //DELETE
    void Delete(KEY id);
  //  bool Delete(ENTITY id);

    //UPDATE
    void Update(ENTITY entity); //bool

    //CREATE
    void Create(ENTITY entity);
}
