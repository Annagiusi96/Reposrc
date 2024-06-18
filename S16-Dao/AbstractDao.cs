using Microsoft.Data.SqlClient;
using S15_RegioniDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S16_Dao;

public abstract class AbstractDao<ENTITY, KEY> : DAO<ENTITY, KEY>
{
    public virtual int Count()
    {
        throw new NotImplementedException();
    }

    public virtual void Create(ENTITY entity)
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(KEY id)
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(ENTITY entity)
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(List<ENTITY> entities)
    {
        throw new NotImplementedException();
    }

    public virtual List<ENTITY> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual ENTITY FindById(KEY id)
    {
        throw new NotImplementedException();
    }

    public virtual bool Update(ENTITY entity)
    {
        throw new NotImplementedException();
    }

    public virtual bool Update(List<ENTITY> entities)
    {
        throw new NotImplementedException();
    }

    // metodo che incapsula la creazione della connessione
    protected virtual SqlConnection getConnection()
    {
        string serverName = "LAPTOP-V77R6E37\\SQLEXPRESS"; // "pc_name\SQLEXPRESS"
       
        string database = "pinkacademy";

        string connectionString = $"Server={serverName}; Database={database}; TrustServerCertificate=True";

        // TrustedConnection=True corrisponde a "Windows Authentication" 
        string windowsConnectionString = $"{connectionString}; Integrated Security=True";

        string userName = "allieva";
        string password = "@@C202403";
        string dockerConnectionString = $"{connectionString}; User id={userName}; Password={password}";

        return new(windowsConnectionString);
    }
}
