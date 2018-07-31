using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ISLApp
{
    public static class Connect 
    {
        private static string connectionstring = Properties.Settings.Default.Database;
        private static string SK = Properties.Settings.Default.Secret;
        private static string SALT = Properties.Settings.Default.Salt;

        public static bool AuthUser(RequestLogin request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spGetUser", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    // HASH PASSWORD
                    request.Password = Security.SHA1(Security.SHA1(request.Password + Properties.Settings.Default.Secret));

                    proc.Parameters.Add("@username", SqlDbType.NVarChar).Value = request.Username;
                    proc.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = request.Password;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        SqlDataReader dr = proc.ExecuteReader();
                        
                        while(dr.Read()) {
                            int dbUserId = Convert.ToInt32(dr["Id"]);
                            string dbUser = Convert.ToString(dr["Username"]);
                            string dbPassword = Convert.ToString(dr["Password"]);

                            User.Id = dbUserId;
                            User.Username = dbUser;
                            User.Password = dbPassword;

                            Console.WriteLine("Id : {0}", dbUserId);
                            Console.WriteLine("Username : {0}", dbUser);
                            Console.WriteLine("Password : {0}", dbPassword);

                            if(dbPassword == request.Password) {
                                return true;
                            }
                        
                        }

                        return false;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }
           
        }

        public static List<RequestCompany> ListCompany(RequestCompany request)
        {
            List<RequestCompany> response = new List<RequestCompany>();

            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spListCompany", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@user_id", SqlDbType.Int).Value = request.UserId;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        SqlDataReader dr = proc.ExecuteReader();

                        while(dr.Read()) {
                            int dbCompanyId = Convert.ToInt32(dr["Id"]);
                            string dbCompanyName = Convert.ToString(dr["Name"]);

                            Console.WriteLine("Company Id : {0}", dbCompanyId);
                            Console.WriteLine("Company Name : {0}", dbCompanyName);

                            RequestCompany company = new RequestCompany(dbCompanyId, User.Id, dbCompanyName);
                            response.Add(company);
                        }

                        return response;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return response;
                    }
                }
            }
        }

        public static bool AddCompany(RequestCompany request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spAddCompany", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@user_id", SqlDbType.Int).Value = request.UserId;
                    proc.Parameters.Add("@name", SqlDbType.NVarChar).Value = request.Name;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        try {
                            proc.ExecuteNonQuery(); // this is where I run my stored procedure
                        } catch(Exception e) {

                            Console.WriteLine("-------------");
                            Console.WriteLine("Procedure Error on spAddCompany : {0}", e.ToString());
                            Console.WriteLine("-------------");

                            return false;
                        }

                        Console.WriteLine("-------------");
                        Console.WriteLine("Procedure Success on spAddCompany!");
                        Console.WriteLine("-------------");

                        return true;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }


        }

        public static bool DeleteCompany(RequestCompany request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spDeleteCompany", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@id", SqlDbType.Int).Value = request.Id;
                    proc.Parameters.Add("@user_id", SqlDbType.Int).Value = request.UserId;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        try {
                            proc.ExecuteNonQuery(); // this is where I run my stored procedure
                        } catch(Exception e) {

                            Console.WriteLine("-------------");
                            Console.WriteLine("Procedure Error on spDeleteCompany : {0}", e.ToString());
                            Console.WriteLine("-------------");

                            return false;
                        }

                        Console.WriteLine("-------------");
                        Console.WriteLine("Procedure Success on spAddCompany!");
                        Console.WriteLine("-------------");

                        return true;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }


        }

        public static bool DeleteCompanyAccounts(RequestCompany request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spDeleteCompanyAccounts", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@company_id", SqlDbType.Int).Value = request.Id;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        try {
                            proc.ExecuteNonQuery(); // this is where I run my stored procedure
                        } catch(Exception e) {

                            Console.WriteLine("-------------");
                            Console.WriteLine("Procedure Error on spDeleteCompanyAccounts : {0}", e.ToString());
                            Console.WriteLine("-------------");

                            return false;
                        }

                        Console.WriteLine("-------------");
                        Console.WriteLine("Procedure Success on spDeleteCompanyAccounts!");
                        Console.WriteLine("-------------");

                        return true;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }


        }

        public static List<RequestAccounts> ListAccounts(RequestAccounts request)
        {
            List<RequestAccounts> response = new List<RequestAccounts>();

            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spListAccount", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@company_id", SqlDbType.Int).Value = request.CompanyId;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        SqlDataReader dr = proc.ExecuteReader();

                        while(dr.Read()) {
                            int dbAccountId = Convert.ToInt32(dr["Id"]);
                            int dbAccountCompanyId = Convert.ToInt32(dr["CompanyId"]);
                            string dbAccountUsername = Convert.ToString(dr["Username"]);
                            string dbAccountPassword = Security.Decrypt(Convert.ToString(dr["Password"]), SALT);

                            Console.WriteLine("----------------");
                            Console.WriteLine("Account Id : {0}", dbAccountId);
                            Console.WriteLine("Account Company Id : {0}", dbAccountCompanyId);
                            Console.WriteLine("Account username : {0}", dbAccountUsername);
                            Console.WriteLine("Account password decrypted : {0}", dbAccountPassword);
                            Console.WriteLine("Account password encrypted : {0}", Convert.ToString(dr["Password"]));
                            Console.WriteLine("----------------");

                            RequestAccounts account = new RequestAccounts(dbAccountId, dbAccountCompanyId, dbAccountUsername, dbAccountPassword);
                            response.Add(account);
                        }

                        return response;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return response;
                    }
                }
            }
        }

        public static bool AddAccount(RequestAccounts request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spAddAccount", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@company_id", SqlDbType.Int).Value = request.CompanyId;
                    proc.Parameters.Add("@username", SqlDbType.NVarChar).Value = request.Username;
                    proc.Parameters.Add("@password", SqlDbType.NVarChar).Value = Security.Encrypt(request.Password, SALT);

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        try {
                            proc.ExecuteNonQuery(); // this is where I run my stored procedure
                        } catch(Exception e) {

                            Console.WriteLine("-------------");
                            Console.WriteLine("Procedure Error on spAddAccount : {0}", e.ToString());
                            Console.WriteLine("-------------");

                            return false;
                        }

                        return true;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }


        }

        public static bool DeleteAccount(RequestAccounts request)
        {
            using(SqlConnection con = new SqlConnection(connectionstring)) {
                using(SqlCommand proc = new SqlCommand("spDeleteAccount", con) {
                    CommandType = CommandType.StoredProcedure
                }) {

                    proc.Parameters.Add("@id", SqlDbType.Int).Value = request.Id;

                    try {
                        con.Open();
                        Console.WriteLine("Connection Success!");

                        try {
                            proc.ExecuteNonQuery(); // this is where I run my stored procedure
                        } catch(Exception e) {

                            Console.WriteLine("-------------");
                            Console.WriteLine("Procedure Error on spAddAccount : {0}", e.ToString());
                            Console.WriteLine("-------------");

                            return false;
                        }

                        return true;
                    } catch(SqlException) {
                        Console.WriteLine("Connection Failure!");
                        return false;
                    }
                }
            }


        }
    }
}
