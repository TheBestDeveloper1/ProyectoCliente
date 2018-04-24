using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class Usuario
    {
        ConexionDataContext objcn = new ConexionDataContext();
        usuario objs = new usuario();

        private string usu_nombre;
        private string usu_rol;
        private string usu_pass;

        public string Usu_nombre;
        {
            get { return usu_nombre}
            set { usu_nombre= value; }
        }

        public string Usu_rol;
        {
            get { return usu_rol}
            set { usu_rol= value; }
        }

        public string Usu_pass;
        {
            get { return usu_pass}
            set { usu_pass= value; }
        }

        public DataTable buscar()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("usu_nombre");
            dt.Columns.Add("usu_rol");
            dt.Columns.Add("usu_pass");

            var busqueda = from dato in objcn.sp_consultar_usuario(usu_nombre) select dato;
            foreach (var item in busqueda)
            {
                DataRow fila = dt.NewRow();
                fila[0] = item.usu_nombre;
                fila[1] = item.usu_rol;
                fila[2] = item.usu_pass;
                dt.Rows.Add(fila);
            }
            return dt;
        }
        public DataTable actualizar()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("usu_nombre");
            dt.Columns.Add("usu_rol");
            dt.Columns.Add("usu_pass");

            var consulta = from datos in objcn.usuario
                           where datos.Usu_nombre.ToString().Equals(usu_nombre)
                           select datos;
            foreach (usuario item in consulta)
            {
                DataRow fila = dt.NewRow();
                fila[0] = item.usu_nombre;
                fila[1] = item.usu_rol;
                fila[2] = item.usu_pass;
                dt.Rows.Add(fila);
            }
            objcn.SubmitChanges();
            return dt;
        }
    }
}
