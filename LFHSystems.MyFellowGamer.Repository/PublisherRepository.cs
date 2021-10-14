using LFHSystems.MyFellowGamer.Interface;
using LFHSystems.MyFellowGamer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class PublisherRepository : ICrud<PublisherModel>
    {
        private IConfiguration _configuration;
        private IConnectionFactory _connection;
        public PublisherRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnectionFactory(configuration);
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PublisherModel GetByParameter(PublisherModel pObj)
        {
            throw new NotImplementedException();
        }

        //public void Insert(ref PublisherModel pObj)
        //{
        //    throw new NotImplementedException();
        //}

        public void Insert(ref PublisherModel pObj)
        {
            try
            {
                using (var dbConnection = _connection.ConnString())
                {
                    dbConnection.Open();

                    int id = dbConnection.Execute("dbo.sp_insert_tb_publishers", new
                    {
                        publisherName = pObj.PublisherName,
                        creationDate = pObj.CreationDate
                    }, commandType: CommandType.StoredProcedure);

                    pObj.ID = id;

                    dbConnection.Close();
                }

                //return new Task(pObj>;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(PublisherModel pObj)
        {
            throw new NotImplementedException();
        }
    }
}
