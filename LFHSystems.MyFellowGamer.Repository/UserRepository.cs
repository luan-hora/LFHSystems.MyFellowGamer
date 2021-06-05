using LFHSystems.MyFellowGamer.Interface;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class UserRepository : ICrud<UserModel>
    {
        private IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByParameter(UserModel pObj)
        {
            UserModel ret = null;
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("dbo.sp_select_tb_user");

                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MyFellowGamerConnString"));
                SqlCommand comm = new SqlCommand(str.ToString(), conn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add(pObj.Email.IsNullOrEmpty() ? new SqlParameter("@username", pObj.Username) : new SqlParameter("@email", pObj.Email));

                comm.Connection.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    ret = new UserModel()
                    {
                        ID = dr["ID"].ToInt(),
                        Username = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        PIN = dr["PIN"].ToString(),
                        CreationDate = dr["CreationDate"].ToDateTime(),
                        PrivacyPolicy = dr["PrivacyPolicy"].GetBoolFromBit(),
                        TermsOfUse = dr["TermsOfUse"].GetBoolFromBit()
                    };
                }

                comm.Connection.Close();

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
                StringBuilder str = new StringBuilder();
                str.Append("dbo.sp_insert_tb_user");

                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MyFellowGamerConnString"));
                SqlCommand comm = new SqlCommand(str.ToString(), conn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add(new SqlParameter("@username", pObj.Username));
                comm.Parameters.Add(new SqlParameter("@email", pObj.Email));
                comm.Parameters.Add(new SqlParameter("@pin", pObj.PIN));
                comm.Parameters.Add(new SqlParameter("@termsOfUse", pObj.TermsOfUse.GetBitFromBool()));
                comm.Parameters.Add(new SqlParameter("@privacyPolicy", pObj.PrivacyPolicy.GetBitFromBool()));
                comm.Parameters.Add(new SqlParameter("@creationDate", pObj.CreationDate));

                comm.Connection.Open();
                int id = comm.ExecuteScalar().ToInt();
                comm.Connection.Close();

                pObj.ID = id;
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
