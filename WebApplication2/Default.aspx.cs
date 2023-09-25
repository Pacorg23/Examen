using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hora en que fue cargada la página
            horaCarga.Text = "El sistema se corrio por primera vez a las: " + DateTime.Now.TimeOfDay.ToString();

            //Estilos agregados a la tabla
            tblClientes.BorderWidth = 2;

            //Lectura de datos desde el archivo Json
            string datosPuros = File.ReadAllText(Server.MapPath("~/Usersdata.json"));
            List<Usuario> usuarios = new List<Usuario>();
            dynamic  datos= JsonConvert.DeserializeObject(datosPuros);
            foreach (var item in datos)
            {
                Usuario usuario = new Usuario();
                usuario.id = item.idCliente;
                usuario.Nombre = item.nombres;
                usuario.PrimerApellido = item.primerApellido;
                usuario.SegundoApellido = item.segundoApellido;
                usuario.FechaHAcimiento = DateTime.Parse(item.fechaNacimiento.ToString());
                usuario.Sexo = item.sexo;
                usuarios.Add(usuario);
            }

            //Creacion de las filas

            //Fila de encabezados
            TableRow filaEncabezados = new TableRow(); 
            filaEncabezados.BackColor= System.Drawing.Color.Gray; 
            tblClientes.Rows.Add(filaEncabezados);
            string[] encabezados = { "Primer Apellido", "Segundo Apellido", "Nombre",  "Sexo" };
            foreach (string encabezado in encabezados)
            {
                TableCell celdaEncabezado = new TableCell();
                celdaEncabezado.Text = encabezado;
                filaEncabezados.Cells.Add(celdaEncabezado);
            }

            //Filas de datos
            foreach (Usuario usuario in usuarios)
            {
                TableRow fila = new TableRow();
                tblClientes.Rows.Add(fila);

                TableCell[] celdas = {
                new TableCell { Text = usuario.PrimerApellido },
                new TableCell { Text = usuario.SegundoApellido },
                new TableCell { Text = usuario.Nombre },
                new TableCell {  } //Esta la dejo en blanco para añadir el control despues
                 };

                DropDownList celdaSexo = new DropDownList();
                celdaSexo.Items.Add(new ListItem("Femenino"));
                celdaSexo.Items.Add(new ListItem("Masculino"));

                if (usuario.Sexo=='F')
                {
                    celdaSexo.SelectedValue = "Femenino";
                }
                else
                {
                    celdaSexo.SelectedValue = "Masculino";
                }
                //Añadir la referencia a la funcion javascript
                celdaSexo.Attributes.Add("onchange", "actualizarFooter(this, '" + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + "')");

                //Añadir el control a la celda
                celdas[3].Controls.Add(celdaSexo);
                //Añadir las celdas a la fila
                foreach (TableCell celda in celdas)
                {
                    fila.Cells.Add(celda);
                }
            }
            
            TableFooterRow footerRow = new TableFooterRow();
            footerRow.ID = "footerRow";
            footerRow.Height = 20;
            TableCell[] celdasDelFooter =
            {
                new TableCell { ID="footerCell1"},
                new TableCell { ID="footerCell2"},
                new TableCell { ID="footerCell3"}
            };
            foreach (TableCell item in celdasDelFooter)
            {
                footerRow.Cells.Add(item);
            }
            footerRow.BackColor = System.Drawing.Color.Gray;
            tblClientes.Rows.Add(footerRow);
        }
    }
}