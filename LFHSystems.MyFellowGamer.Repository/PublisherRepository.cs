using Dapper;
using LFHSystems.MyFellowGamer.Interface;
using LFHSystems.MyFellowGamer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class PublisherRepository : ICrud<PublisherModel>
    {
        private readonly MyDbContext ctx;
        private readonly IConnectionFactory _connection;
        public PublisherRepository(IConfiguration configuration, MyDbContext ctx)
        {
            this.ctx = ctx;
            _connection = new SqlConnectionFactory(configuration);
        }

        #region CRUD Dapper
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

        public IEnumerable<PublisherModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PublisherModel GetByParameter(PublisherModel pObj)
        {
            throw new NotImplementedException();
        }

        public int Delete(PublisherModel pObj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD EF_Core        
        public void Insert_EFCore(ref PublisherModel pObj)
        {
            try
            {
                ctx.Publisher.Add(pObj);
                ctx.SaveChanges();
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

        public void Update_EFCore(PublisherModel pObj)
        {
            ctx.Publisher.Update(pObj);
            ctx.SaveChanges();
        }

        public async void Delete_EFCore(PublisherModel pObj)
        {
           pObj = await ctx.Publisher.FirstOrDefaultAsync(a => a.ID == pObj.ID);

            ctx.Publisher.Remove(pObj);
            ctx.SaveChanges();
        }

        public IEnumerable<PublisherModel> GetAll_EFCore()
        {
            return ctx.Publisher;
        }
        #endregion
    }
}
