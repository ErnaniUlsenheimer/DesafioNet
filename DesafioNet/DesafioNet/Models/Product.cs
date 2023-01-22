using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioNet.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public double price { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public static List<Product> findProducts(int? p_id_procuct)
        {
            DataSet dsLocal = null;
            List<Product> retorno = null;
            SqlCommand sqlcomand = null;
            SqlConnection sqlconnect = null;
            SqlDataAdapter sqladapter = null;
            try
            {
                string conect = ConexaoDB.connectDB;
                sqlconnect = new SqlConnection(conect);
                sqlconnect.Open();
                sqlcomand = new SqlCommand();
                sqlcomand.CommandType = CommandType.StoredProcedure;
                sqlcomand.Connection = sqlconnect;
                sqlcomand.CommandText = "find_product";

                sqlcomand.Parameters.Add(new SqlParameter("@p_id_procuct", SqlDbType.Int));
                //int p_id_corretora,int p_id_algoritmo
                sqlcomand.Parameters["@p_id_procuct"].Value = p_id_procuct != null ? p_id_procuct.Value : sqlcomand.Parameters["@p_id_procuct"].Value = DBNull.Value;
                sqladapter = new SqlDataAdapter();
                sqladapter.SelectCommand = sqlcomand;
                dsLocal = new DataSet();
                sqladapter.Fill(dsLocal);
               
                if (dsLocal != null && dsLocal.Tables != null && dsLocal.Tables.Count > 0 && dsLocal.Tables[0].Rows != null && dsLocal.Tables[0].Rows.Count > 0)
                {
                    retorno = new List<Product>();
                    for (int i = 0; i < dsLocal.Tables[0].Rows.Count; i++)
                    {
                        Product aux = new Product();
                        aux.id = Convert.ToInt32(dsLocal.Tables[0].Rows[i]["id"].ToString());
                        aux.name = dsLocal.Tables[0].Rows[i]["name_product"].ToString();
                        aux.brand = dsLocal.Tables[0].Rows[i]["brand"].ToString();
                        aux.price = Convert.ToDouble(dsLocal.Tables[0].Rows[i]["price"].ToString());
                        aux.createdAt = Convert.ToDateTime(dsLocal.Tables[0].Rows[i]["createdAt"].ToString());
                        aux.updatedAt = dsLocal.Tables[0].Rows[i]["updatedAt"] != DBNull.Value ? Convert.ToDateTime(dsLocal.Tables[0].Rows[i]["updatedAt"].ToString()) : aux.updatedAt =null;
                        retorno.Add(aux);
                    }
                }
            }
            catch(Exception exc)
            {
                retorno = null;
            }

            if (sqladapter != null)
            {
                try
                {

                    sqladapter.Dispose();
                    sqladapter = null;
                }
                catch
                {
                }
            }
            if (sqlcomand != null)
            {
                try
                {
                    sqlcomand.Cancel();
                    sqlcomand.Dispose();
                    sqlcomand = null;
                }
                catch
                {
                }
            }
            if (sqlconnect != null)
            {
                try
                {
                    sqlconnect.Close();
                    sqlconnect.Dispose();
                    sqlconnect = null;
                }
                catch
                {
                }
            }

            return retorno;
        }

        public static Product insertProduct(string p_name, string p_brand, double p_price)
        {
            Product retorno = null;
            DataSet dsLocal = null;
            SqlCommand sqlcomand = null;
            SqlConnection sqlconnect = null;
            SqlDataAdapter sqladapter = null;
            try
            {
                string conect = ConexaoDB.connectDB;
                sqlconnect = new SqlConnection(conect);
                sqlconnect.Open();
                sqlcomand = new SqlCommand();
                sqlcomand.CommandType = CommandType.StoredProcedure;
                sqlcomand.Connection = sqlconnect;
                sqlcomand.CommandText = "insert_product";

                sqlcomand.Parameters.Add(new SqlParameter("@p_name_product", SqlDbType.VarChar));
                sqlcomand.Parameters.Add(new SqlParameter("@p_brand", SqlDbType.VarChar));
                sqlcomand.Parameters.Add(new SqlParameter("@p_price", SqlDbType.Real));

                sqlcomand.Parameters["@p_name_product"].Value = p_name;
                sqlcomand.Parameters["@p_brand"].Value = p_brand;
                sqlcomand.Parameters["@p_price"].Value = p_price;

                sqladapter = new SqlDataAdapter();
                sqladapter.SelectCommand = sqlcomand;
                dsLocal = new DataSet();
                sqladapter.Fill(dsLocal);

                if (dsLocal != null && dsLocal.Tables != null)// && dsLocal.Tables[1].Rows != null && dsLocal.Tables[1].Rows.Count > 0)
                {
                    if (dsLocal.Tables.Count > 0)
                    {
                        int index = dsLocal.Tables.Count - 1;
                        int retorno_id = Convert.ToInt32(dsLocal.Tables[index].Rows[0][0].ToString());
                        retorno = Product.findProducts(retorno_id)[0];

                    }
                }
                dsLocal = null;

            }
            catch
            { 
            }
            if (sqladapter != null)
            {
                try
                {

                    sqladapter.Dispose();
                    sqladapter = null;
                }
                catch
                {
                }
            }
            if (sqlcomand != null)
            {
                try
                {
                    sqlcomand.Cancel();
                    sqlcomand.Dispose();
                    sqlcomand = null;
                }
                catch
                {
                }
            }
            if (sqlconnect != null)
            {
                try
                {
                    sqlconnect.Close();
                    sqlconnect.Dispose();
                    sqlconnect = null;
                }
                catch
                {
                }
            }

            return retorno;
        }

        public static Product updateProduct(int p_id_product, string p_name, string p_brand, double p_price)
        {
            Product retorno = null;            
            SqlCommand sqlcomand = null;
            SqlConnection sqlconnect = null;
            try
            {
                string conect = ConexaoDB.connectDB;
                sqlconnect = new SqlConnection(conect);
                sqlconnect.Open();
                sqlcomand = new SqlCommand();
                sqlcomand.CommandType = CommandType.StoredProcedure;
                sqlcomand.Connection = sqlconnect;
                sqlcomand.CommandText = "update_product";

                sqlcomand.Parameters.Add(new SqlParameter("@p_id_product", SqlDbType.Int));
                sqlcomand.Parameters.Add(new SqlParameter("@p_name_product", SqlDbType.VarChar));
                sqlcomand.Parameters.Add(new SqlParameter("@p_brand", SqlDbType.VarChar));
                sqlcomand.Parameters.Add(new SqlParameter("@p_price", SqlDbType.Real));

                sqlcomand.Parameters["@p_id_product"].Value = p_id_product;
                sqlcomand.Parameters["@p_name_product"].Value = p_name;
                sqlcomand.Parameters["@p_brand"].Value = p_brand;
                sqlcomand.Parameters["@p_price"].Value = p_price;

                bool executed = Convert.ToBoolean(sqlcomand.ExecuteScalar());
                if(executed)
                {
                    retorno = Product.findProducts(p_id_product)[0];
                }
               

            }
            catch(Exception exc)
            {
            }
            
            if (sqlcomand != null)
            {
                try
                {
                    sqlcomand.Cancel();
                    sqlcomand.Dispose();
                    sqlcomand = null;
                }
                catch
                {
                }
            }
            if (sqlconnect != null)
            {
                try
                {
                    sqlconnect.Close();
                    sqlconnect.Dispose();
                    sqlconnect = null;
                }
                catch
                {
                }
            }

            return retorno;
        }
    }


}