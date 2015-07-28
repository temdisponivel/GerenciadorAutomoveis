using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace GerenciadorAutomoveis.Models
{
    /// <summary>
    /// Implementação do repositorio de automóveis.
    /// </summary>
    public class AutomoveisRepositorio : IAutomoveisRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["GerenciadorAutomoveis"].ConnectionString;

        public List<Automovel> GetTodos()
        {
            List<Automovel> automoveis = null;
            StringBuilder sb = null;
            Automovel automovel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select aut.id, aut.modelo, aut.preco, marc.id as id_marca, marc.nome as marca, aut.ano ");
                    sb.Append(" from Automoveis aut, Marcas marc ");
                    sb.Append(" where aut.marca = marc.id ");

                    try
                    {

                        conn.Open();
                        cmd.CommandText = sb.ToString();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            automoveis = new List<Automovel>();

                            while (reader.Read())
                            {
                                automovel = new Automovel();
                                automovel.id = reader.GetInt32(reader.GetOrdinal("id"));
                                automovel.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                                automovel.ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                automovel.preco = (float)reader.GetDecimal(reader.GetOrdinal("preco"));
                                automovel.marca = new Marca { id = reader.GetInt32(reader.GetOrdinal("id_marca")), nome = reader.GetString(reader.GetOrdinal("marca")), };
                                automovel.opcionais = this.GetOpcionais(automovel.id);
                                automoveis.Add(automovel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }

            return automoveis;
        }

        public Automovel GetId(int id)
        {
            StringBuilder sb = null;
            Automovel automovel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select aut.id, aut.modelo, aut.preco, marc.id as id_marca, marc.nome as marca, aut.ano ");
                    sb.Append(" from Automoveis aut, Marcas marc ");
                    sb.Append(" where aut.id = @id and aut.marca = marc.id ");

                    try
                    {
                        conn.Open();
                        cmd.CommandText = sb.ToString();
                        cmd.Parameters.Add("id", SqlDbType.Int);
                        cmd.Parameters["id"].Value = id;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                automovel = new Automovel();
                                automovel.id = reader.GetInt32(reader.GetOrdinal("id"));
                                automovel.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                                automovel.ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                automovel.preco = (float)reader.GetDecimal(reader.GetOrdinal("preco"));
                                automovel.marca = new Marca { id = reader.GetInt32(reader.GetOrdinal("id_marca")), nome = reader.GetString(reader.GetOrdinal("marca")), };
                                automovel.opcionais = this.GetOpcionais(automovel.id);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        automovel = null;
                    }

                    return automovel;
                }
            }
        }

        public List<Automovel> GetModelo(string modelo)
        {
            List<Automovel> automoveis = null;
            StringBuilder sb = null;
            Automovel automovel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select aut.id, aut.modelo, aut.preco, marc.id as id_marca, marc.nome as marca, aut.ano ");
                    sb.Append(" from Automoveis aut, Marcas marc ");
                    sb.Append(" where aut.marca = marc.id and aut.modelo like @modelo" );

                    try
                    {
                        conn.Open();
                        cmd.CommandText = sb.ToString();
                        cmd.Parameters.Add("modelo", SqlDbType.VarChar);
                        cmd.Parameters["modelo"].Value = "%" + modelo + "%";
                         
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            automoveis = new List<Automovel>();

                            while (reader.Read())
                            {
                                automovel = new Automovel();
                                automovel.id = reader.GetInt32(reader.GetOrdinal("id"));
                                automovel.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                                automovel.ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                automovel.preco = (float)reader.GetDecimal(reader.GetOrdinal("preco"));
                                automovel.marca = new Marca { id = reader.GetInt32(reader.GetOrdinal("id_marca")), nome = reader.GetString(reader.GetOrdinal("marca")), };
                                automovel.opcionais = this.GetOpcionais(automovel.id);
                                automoveis.Add(automovel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }

            return automoveis;
        }

        public List<Automovel> GetAno(int ano)
        {
            List<Automovel> automoveis = null;
            StringBuilder sb = null;
            Automovel automovel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select aut.id, aut.modelo, aut.preco, marc.id as id_marca, marc.nome as marca, aut.ano ");
                    sb.Append(" from Automoveis aut, Marcas marc ");
                    sb.Append(" where aut.marca = marc.id and aut.ano = @ano");

                    try
                    {

                        conn.Open();
                        cmd.CommandText = sb.ToString();

                        cmd.Parameters.Add("ano", SqlDbType.Int);
                        cmd.Parameters["ano"].Value = ano;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            automoveis = new List<Automovel>();

                            while (reader.Read())
                            {
                                automovel = new Automovel();
                                automovel.id = reader.GetInt32(reader.GetOrdinal("id"));
                                automovel.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                                automovel.ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                automovel.preco = (float)reader.GetDecimal(reader.GetOrdinal("preco"));
                                automovel.marca = new Marca { id = reader.GetInt32(reader.GetOrdinal("id_marca")), nome = reader.GetString(reader.GetOrdinal("marca")), };
                                automovel.opcionais = this.GetOpcionais(automovel.id);
                                automoveis.Add(automovel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }

            return automoveis;
        }

        public List<Automovel> GetMarca(string marca)
        {
            List<Automovel> automoveis = null;
            StringBuilder sb = null;
            Automovel automovel = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select aut.id, aut.modelo, aut.preco, marc.id as id_marca, marc.nome as marca, aut.ano ");
                    sb.Append(" from Automoveis aut, Marcas marc ");
                    sb.Append(" where aut.marca = marc.id and marc.nome like @marca");

                    try
                    {
                        conn.Open();
                        cmd.CommandText = sb.ToString();
                        cmd.Parameters.Add("marca", SqlDbType.VarChar);
                        cmd.Parameters["marca"].Value = "%" + marca + "%";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            automoveis = new List<Automovel>();

                            while (reader.Read())
                            {
                                automovel = new Automovel();
                                automovel.id = reader.GetInt32(reader.GetOrdinal("id"));
                                automovel.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                                automovel.ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                automovel.preco = (float)reader.GetDecimal(reader.GetOrdinal("preco"));
                                automovel.marca = new Marca { id = reader.GetInt32(reader.GetOrdinal("id_marca")), nome = reader.GetString(reader.GetOrdinal("marca")), };
                                automovel.opcionais = this.GetOpcionais(automovel.id);
                                automoveis.Add(automovel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }

            return automoveis;
        }

        public bool Update(Automovel auto)
        {
            StringBuilder sb = null;
            bool retorno = true;
            SqlTransaction transaction = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" update Automoveis ");
                    sb.Append(" set modelo = @modelo, marca = @marca, ano = @ano, preco = @preco ");
                    sb.Append(" where id = @id ");

                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();
                        cmd.Transaction = transaction;

                        /* UPDATE AUTOMOVEIS */
                        cmd.CommandText = sb.ToString();

                        cmd.Parameters.Add("id", SqlDbType.Int);
                        cmd.Parameters["id"].Value = auto.id;

                        cmd.Parameters.Add("modelo", SqlDbType.VarChar);
                        cmd.Parameters["modelo"].Value = auto.modelo;

                        cmd.Parameters.Add("marca", SqlDbType.Int);
                        cmd.Parameters["marca"].Value = auto.marca.id;

                        cmd.Parameters.Add("ano", SqlDbType.Int);
                        cmd.Parameters["ano"].Value = auto.ano;

                        cmd.Parameters.Add("preco", SqlDbType.Float);
                        cmd.Parameters["preco"].Value = auto.preco;

                        retorno = cmd.ExecuteNonQuery() > 0;

                        cmd.Parameters.Clear();

                        /* UPDATE OPCIONAIS */
                        cmd.CommandText = " delete from OpcionaisRelacao where automovel_id = @id ";
                        cmd.Parameters.Add("id", SqlDbType.Int);
                        cmd.Parameters["id"].Value = auto.id;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        if (auto.opcionais != null)
                        {
                            foreach (Opcional opcional in auto.opcionais)
                            {
                                cmd.CommandText = " insert into OpcionaisRelacao values (@id, @opcId) ";
                                cmd.Parameters.Add("id", SqlDbType.Int);
                                cmd.Parameters["id"].Value = auto.id;
                                cmd.Parameters.Add("opcId", SqlDbType.Int);
                                cmd.Parameters["opcId"].Value = opcional.id;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        retorno = false;
                    }

                    return retorno;
                }
            }
        }

        public bool Delete(int id)
        {
            bool retorno = true;
            SqlTransaction transaction = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();

                        transaction = conn.BeginTransaction();
                        cmd.Transaction = transaction;

                        cmd.CommandText = "delete from OpcionaisRelacao where automovel_id = @id";
                        cmd.Parameters.Add("id", SqlDbType.Int);
                        cmd.Parameters["id"].Value = id;

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "delete from Automoveis where id = @id";
                                                
                        retorno = cmd.ExecuteNonQuery() > 0;
                        
                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        retorno = false;
                    }

                    return retorno;
                }
            }
        }

        
        /// <summary>
        /// Retorna uma lista com os opcionais do automóvel que corresponde ao id parametrizado.
        /// </summary>
        /// <param name="id">Id do automóvel para pegar os opcionais.</param>
        /// <returns>Lista com os opcionais do automóvel.</returns>
        private List<Opcional> GetOpcionais(int id)
        {
            List<Opcional> opcionais = null;
            StringBuilder sb = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select opc.id, opc.descricao ");
                    sb.Append(" from Opcionais opc, OpcionaisRelacao opcr ");
                    sb.Append(" where opc.id = opcr.opcional_id and opcr.automovel_id = @id ");

                    conn.Open();
                    cmd.CommandText = sb.ToString();
                    cmd.Parameters.Add("id", SqlDbType.Int);
                    cmd.Parameters["id"].Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        opcionais = new List<Opcional>();

                        while (reader.Read())
                        {
                            opcionais.Add(new Opcional { id = reader.GetInt32(reader.GetOrdinal("id")), descricao = reader.GetString(reader.GetOrdinal("descricao")), });
                        }
                    }
                }
            }

            return opcionais;
        }

        public List<Opcional> GetOpcionais()
        {
            List<Opcional> opcionais = null;
            StringBuilder sb = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select * ");
                    sb.Append(" from Opcionais ");

                    conn.Open();
                    cmd.CommandText = sb.ToString();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        opcionais = new List<Opcional>();

                        while (reader.Read())
                        {
                            opcionais.Add(new Opcional { id = reader.GetInt32(reader.GetOrdinal("id")), descricao = reader.GetString(reader.GetOrdinal("descricao")), });
                        }
                    }
                }
            }

            return opcionais;
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> opcionais = null;
            StringBuilder sb = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sb = new StringBuilder();
                    sb.Append(" select * ");
                    sb.Append(" from Marcas ");

                    conn.Open();
                    cmd.CommandText = sb.ToString();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        opcionais = new List<Marca>();

                        while (reader.Read())
                        {
                            opcionais.Add(new Marca { id = reader.GetInt32(reader.GetOrdinal("id")), nome = reader.GetString(reader.GetOrdinal("nome")), });
                        }
                    }
                }
            }

            return opcionais;
        }
    }



}