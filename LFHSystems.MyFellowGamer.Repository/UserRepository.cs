using LFHSystems.MyFellowGamer.Interface;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class UserRepository : ICrud<UserModel>
    {
        MyDbContext _ctx;
        private readonly IConnectionFactory _connection;
        public UserRepository(IConfiguration configuration, MyDbContext ctx)
        {
            this._ctx = ctx;
            _connection = new SqlConnectionFactory(configuration);
        }

        public int Delete(UserModel pObj)
        {
            int rowsAffected = 0;
            try
            {
                using (var dbConnection = _connection.ConnString())
                {
                    dbConnection.Open();

                    rowsAffected = dbConnection.Execute("dbo.sp_delete_tb_user", new
                    {
                        idUser = pObj.ID
                    }, commandType: CommandType.StoredProcedure);

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

            return rowsAffected;
        }

        public IEnumerable<UserModel> GetAll()
        {
            List<UserModel> ret = null;
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT ID, Username, Email, PIN, TermsOfUse, PrivacyPolicy, CreationDate FROM Tb_User");

            try
            {
                using (var dbConnection = _connection.ConnString())
                {
                    dbConnection.Open();
                    ret = dbConnection.Query<UserModel>(sqlQuery.ToString(), commandType: CommandType.Text).ToList();
                    dbConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

            return ret;
        }

        public IEnumerable<UserModel> GetAll_EFCore()
        {
            return _ctx.User;
        }

        public UserModel GetByParameter(UserModel pObj)
        {
            UserModel ret = null;
            try
            {
                using (var dbConnection = _connection.ConnString())
                {
                    dbConnection.Open();

                    object email = new { email = pObj.Email };
                    object username = new { username = pObj.Username };


                    var result = dbConnection.QueryFirstOrDefault<UserModel>("dbo.sp_select_tb_user",
                        pObj.Email.IsNullOrEmpty() ? username : email, commandType: CommandType.StoredProcedure);
                    ret = result;

                    dbConnection.Close();
                }

                return ret;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Insert(ref UserModel pObj)
        {
            try
            {
                using (var dbConnection = _connection.ConnString())
                {
                    dbConnection.Open();

                    int id = dbConnection.Execute("dbo.sp_insert_tb_user", new
                    {
                        username = pObj.Username,
                        email = pObj.Email,
                        pin = pObj.PIN,
                        termsOfUse = pObj.TermsOfUse.GetBitFromBool(),
                        privacyPolicy = pObj.PrivacyPolicy.GetBitFromBool(),
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



        public void Update(UserModel pObj)
        {
            throw new NotImplementedException();
        }
    }
}
