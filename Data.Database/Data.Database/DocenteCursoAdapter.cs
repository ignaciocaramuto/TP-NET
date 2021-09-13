using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter: Adapter
    {
        private static List<DocenteCurso> DocenteCurso
        {
            get;
            set;
        }

        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read())
                {
                    DocenteCurso doc = new DocenteCurso();
                    doc.ID = (int)drDocenteCurso["id_dictado"];
                    doc.IdDocente = (int)drDocenteCurso["id_docente"];
                    doc.IdCurso = (int)drDocenteCurso["id_curso"];
                    doc.Cargo = (int)drDocenteCurso["cargo"];
                    docentes.Add(doc);
                }

                drDocenteCurso.Close();
                this.CloseConnection();
                return docentes;
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de dictados", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    doc.ID = (int)drDocenteCurso["id_dictado"];
                    doc.IdDocente = (int)drDocenteCurso["id_docente"];
                    doc.IdCurso = (int)drDocenteCurso["id_curso"];
                    doc.Cargo = (int)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docente)
        {
            if (docente.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docente.ID);
            }
            else if (docente.State == BusinessEntity.States.New)
            {
                this.Insert(docente);
            }
            else if (docente.State == BusinessEntity.States.Modified)
            {
                this.Update(docente);
            }
            docente.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(DocenteCurso docente)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_docente = @id_docente, id_curso = @id_curso, cargo = @cargo WHERE id_dictado=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docente.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docente.IdDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docente.IdCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docente.Cargo;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docente)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos (id_docente, id_curso, cargo) values (@id_docente, @id_curso, @cargo) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docente.IdDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docente.IdCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docente.Cargo;
                docente.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
    }
}
