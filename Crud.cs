using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistema_de_Informacion;

namespace Logica
{
    public class usuarios
    {
        Cadena cadcon = new Cadena();
        Conexion con = new Conexion();
        public string pass_usu;
        public string rol_usu;
        private string nombre_usu;

        public string nombre_usua
        {
            get { return nombre_usu; }
            set { nombre_usu = value; }
        }
        public string rol_usua
        {
            get { return rol_usu; }
            set { rol_usu = value; }
        }

        public string pass_usua
        {
            get { return pass_usu; }
            set { pass_usu = value; }
        }

        public SqlDataAdapter conectar2;
        public SqlDataReader lectura;

        //CLASE PARA INGRESAR usuario
        public bool ingresar()
        {
            if (con.conectar() == true)
            {

                string comando1 = " exec sp_registrar_usuario @nombre_usu='"+nombre_usu+ "',@rol_usu='"+rol_usu+"',@pass_usu='"+pass_usu+"'";
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
                SqlCommand sentencia = new SqlCommand("exec sp_consultar_usuario @nombre_usu=" + nombre_usu, con.cone);
                con.cone.Open();
                sentencia.ExecuteNonQuery();
                lectura = sentencia.ExecuteReader();
                if (lectura.Read())
                {
                    nombre_usu = lectura.GetValue(1) + "";
                    rol_usu = lectura.GetValue(2) + "";
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

                string comando3 = "exec sp_actualizar_usuario @nombre_usu='" + nombre_usu + "',@rol_usu='"+rol_usu+"',@pass_usu='" + pass_usu + "'";
                con.actualizar(comando3);

                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA LLAMAR DATOS DE SQL
        public bool combobox_usuario()
        {
            if (con.conectar() == true)
            {

                conectar2 = new SqlDataAdapter("select * from usuario", con.cone);
                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA CONSULTAR TODOS LAS usuarioES
        public bool consultartodo()
        {
            if (con.conectar() == true)
            {
                conectar2 = new SqlDataAdapter("exec sp_consultar_todausuario ", con.cone);

                return true;
            }
            else
            {
                return false;
            }
        }

        //CLASE PARA INGRESAR usuario
        public bool ingresar_detalle()
        {
            if (con.conectar() == true)
            {

                string comando1 = "exec sp_registrar_detalle_usuario @rol_usu='"+Rol+"',@pass_usu='"+pass_usu+"'";
                con.ingresar(comando1);
                return true;
            }
            else
            {
                return false;
            }
        }
        //CLASE PARA LLAMAR DATOS DE SQL
        public bool combobox_emple()
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
