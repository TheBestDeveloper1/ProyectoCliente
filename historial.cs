using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistema_de_Informacion;

namespace Logica
{
    public class historiales
    {
        Cadena cadcon = new Cadena();
        Conexion con = new Conexion();
        public string id_historial;
        public string id_lugar;
        private string nombre_usu;

        public string nombre_usua
        {
            get { return nombre_usu; }
            set { nombre_usu = value; }
        }
        public string id_lugares
        {
            get { return id_lugar; }
            set { id_lugar = value; }
        }

        public string id_historiales
        {
            get { return id_historial; }
            set { id_historial = value; }
        }

        public SqlDataAdapter conectar2;
        public SqlDataReader lectura;

        //CLASE PARA INGRESAR historial
        public bool ingresar()
        {
            if (con.conectar() == true)
            {

                string comando1 = " exec sp_registrar_historial @nombre_usu='"+nombre_usu+ "',@id_lugar='"+id_lugar+"'";
                con.ingresar(comando1);
                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA CONSULTAR usu
        public bool consultar()
        {
            if (con.conectar() == true)
            {
                SqlCommand sentencia = new SqlCommand("exec sp_consultar_historial @id_historial=" + id_historial, con.cone);
                con.cone.Open();
                sentencia.ExecuteNonQuery();
                lectura = sentencia.ExecuteReader();
                if (lectura.Read())
                {
                    nombre_usu = lectura.GetValue(1) + "";
                    id_lugar = lectura.GetValue(2) + "";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA ACTUALIZAR CARGO
        public bool actualizar()
        {
            if (con.conectar() == true)
            {

                string comando3 = "exec sp_actualizar_historial @nombre_usu='" + nombre_usu + "',@id_lugar='"+id_lugar+"',@id_historial='" + id_historial + "'";
                con.actualizar(comando3);

                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA LLAMAR DATOS DE SQL
        public bool combobox_historial()
        {
            if (con.conectar() == true)
            {

                conectar2 = new SqlDataAdapter("select * from historial", con.cone);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool combobox_lugar()
        {
            if (con.conectar() == true)
            {

                conectar2 = new SqlDataAdapter("select * from lugar", con.cone);
                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA CONSULTAR TODOS LAS historialES
        public bool consultartodo()
        {
            if (con.conectar() == true)
            {
                conectar2 = new SqlDataAdapter("exec sp_consultar_todahistorial ", con.cone);

                return true;
            }
            else
            {
                return false;
            }
        }

        //CLASE PARA INGRESAR historial
        public bool ingresar_detalle()
        {
            if (con.conectar() == true)
            {

                string comando1 = "exec sp_registrar_detalle_historial @rol_usu='"+Rol+"',@id_historial='"+id_historial+"'";
                con.ingresar(comando1);
                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA LLAMAR DATOS DE SQL
        public bool combobox_usu()
        {
            if (con.conectar() == true)
            {

                conectar2 = new SqlDataAdapter("select * from usu" + nombre_usu, con.cone);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
