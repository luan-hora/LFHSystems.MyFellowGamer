using LFHSystems.MyFellowGamer.Interface;
using LFHSystems.MyFellowGamer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class PublisherRepository : ICrud<PublisherModel>
    {
        private readonly MyDbContext ctx;
        public PublisherRepository(MyDbContext ctx)
        {
            this.ctx = ctx;
        }

        public int Delete(PublisherModel pObj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            return ctx.Publisher;
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
                ctx.Publisher.Add(pObj);
                ctx.SaveChanges();

                //using (var dbConnection = _connection.ConnString())
                //{
                //    dbConnection.Open();

                //    int id = dbConnection.Execute("dbo.sp_insert_tb_publishers", new
                //    {
                //        publisherName = pObj.PublisherName,
                //        creationDate = pObj.CreationDate
                //    }, commandType: CommandType.StoredProcedure);

                //    pObj.ID = id;

                //    dbConnection.Close();
                //}

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
