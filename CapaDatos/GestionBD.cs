﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaDatos.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class GestionBD
    {
        string CadenaConexion;

        public GestionBD()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["CityTech"].ConnectionString;

        }

        //SELECT
        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            SqlDataReader Resultado;
            List<Producto> ListadoProductos;

            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                objConexion.ConnectionString = CadenaConexion;

                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "SELECT * FROM PRODUCTO"; 
                objConexion.Open();
                Resultado = await objComando.ExecuteReaderAsync();
                ListadoProductos = new List<Producto>();
                while (Resultado.Read())
                {
                    Producto objProducto = new Producto();
                    objProducto.IdProducto = Resultado.GetInt32(0);
                    objProducto.NomProducto = Resultado.GetString(1);
                    objProducto.MarcaProducto = Resultado.GetInt32(2);
                    objProducto.CostoProducto = Resultado.GetDecimal(3);
                    ListadoProductos.Add(objProducto);
                }
            }
            return ListadoProductos;
        }

        //INSERT
        public async Task<int> RegistrarProductoAsync(Producto oProducto)
        {
            int Resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Insert into Producto (NomProducto,MarcaProducto,CostoProducto)" +
                                         "Values (@NomProducto,@MarcaProducto,@CostoProducto)";

              

                SqlParameter oParametro = new SqlParameter();
                oParametro.ParameterName = "@NomProducto";
                oParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                oParametro.Size = 50;
                oParametro.Value = oProducto.NomProducto;

                objComando.Parameters.Add(oParametro);

                objComando.Parameters.Add(new SqlParameter("@MarcaProducto", oProducto.MarcaProducto));

                objComando.Parameters.Add(new SqlParameter("@CostoProducto", oProducto.CostoProducto));

                objConexion.Open();
                Resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();

            }

            return Resultado;
        }

        //UPDATE
        public async Task<int> ActualizarProductoAsync(Producto auxProducto, int id)
        {
            int Resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                
                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Update Producto set NomProducto = @NomProducto, MarcaProducto = @MarcaProducto, CostoProducto = @CostoProducto where IdProducto = @IdProducto";


                objComando.Parameters.Add(new SqlParameter("@IdProducto", id));

                SqlParameter oParametro = new SqlParameter();
                oParametro.ParameterName = "@NomProducto";
                oParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                oParametro.Size = 50;
                oParametro.Value = auxProducto.NomProducto;
                objComando.Parameters.Add(oParametro);

                objComando.Parameters.Add(new SqlParameter("@MarcaProducto", auxProducto.MarcaProducto));

                objComando.Parameters.Add(new SqlParameter("@CostoProducto", auxProducto.CostoProducto));
                objConexion.Open();
                Resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();
                
            }
           
           return Resultado;
        
        }


        public async Task<Producto> ObtenerProductoAsync(int? Id)
        {
            List<Producto> Listado = await ObtenerProductosAsync();
            Producto auxProducto = Listado.Where(x => x.IdProducto == Id).FirstOrDefault();
            return auxProducto;
        }

        public async Task<int> EliminarProductoAsyn(int Id)
        {
            int resultado = 0;
            using (SqlConnection objConexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand objComando = new SqlCommand();
                objComando.Connection = objConexion;
                objComando.CommandType = System.Data.CommandType.Text;
                objComando.CommandText = "Delete from Producto Where IdProducto = @IdProducto";            
                objComando.Parameters.Add(new SqlParameter("@IdProducto", Id));
                objConexion.Open();
                resultado = await objComando.ExecuteNonQueryAsync();
                objConexion.Close();
            }      

            return resultado;
        }

    }
}
