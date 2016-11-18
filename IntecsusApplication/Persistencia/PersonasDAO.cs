using IntecsusApplication.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecsusApplication.Persistencia
{
    public class PersonasDAO
    {
        private List<Persona> personas;

        public PersonasDAO()
        {
            personas = new List<Persona>();  
        }

        private void guardarPersonas()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("personas");
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "datos.xml";
            if (File.Exists(ruta))
            {
                ds.ReadXml(ruta);
                dt = ds.Tables[0].Copy();
            }
            else
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "nombre";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "apellido";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "numIdentificacion";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "email";
                dt.Columns.Add(dc);
            }
            foreach (Persona p in personas)
            {
                DataRow dr = dt.NewRow();
                dr["nombre"] = p.Nombre;
                dr["apellido"] = p.Apellido;
                dr["numIdentificacion"] = p.NumIdentificacion;
                dr["email"] = p.Email;
                dt.Rows.Add(dr);
                dt.WriteXml(ruta);
            }
        }

        public bool creaPersona(string nombres, string apellidos, string numId, string email)
        {
            try
            {
                Persona p = new Persona(nombres, apellidos, numId, email);
                personas.Add(p);
                guardarPersonas();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Persona> consultaPersonas()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("personas");
            List<Persona> personasConsultadas = new List<Persona>();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "datos.xml";
            if (File.Exists(ruta))
            {
                ds.ReadXml(ruta);
                dt = ds.Tables[0].Copy();
            }
            else
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = "nombre";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "apellido";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "numIdentificacion";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "email";
                dt.Columns.Add(dc);
            }
            foreach (DataRow row in dt.Rows)
            {
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                string numid = row["numIdentificacion"].ToString();
                string email = row["email"].ToString();
                personasConsultadas.Add(new Persona(nombre, apellido, numid, email));
            }
            return personasConsultadas;
        }
    }
}
