using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S16_Dao;

public interface DAO<ENTITY, KEY>
{
    // R) Retrieve
    int Count();

    ENTITY FindById(KEY id);

    List<ENTITY> FindAll();

    // D) Delete
    bool Delete(KEY id);
    bool Delete(ENTITY entity);
    bool Delete(List<ENTITY> entities);

    // U) Update
    bool Update(ENTITY entity);
    bool Update(List<ENTITY> entities);

    // C) Cretae

    void Create(ENTITY entity);
}
