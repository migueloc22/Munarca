using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.IO;

namespace Presentacion
{


    public partial class CrearNegocioPropietario : System.Web.UI.Page
    {
        List<csUbicacion> listarUbicacion;
        LogicaEstadoNegocio lgExtNegocio;
        csUbicacion Ubicacion;
        csUsuario Usuario;
        csPath path;
        LogicaPath lgPath;
        csUbicacion ubicacion;
        LogicaUbicacion lgUbicacion;
        csEstadoNegocio estNegocio;
        //#region metodos
        //private List<csUbicacion> ObtenerNuevaLista()
        //{
        //    List<csUbicacion> lista = new List<csUbicacion>();
        //    //csUbicacion csUbicacion = new csUbicacion(0, "ewqe", "sada", 0, "daadsw ");
        //    //lista.Add(csUbicacion);
        //    return lista;
        //}

        //private List<csUbicacion> ObtnerLista()
        //{
        //    if (Session["lista"] == null)
        //    {
        //        return this.ObtenerNuevaLista();

        //    }
        //    else
        //    {
        //        return (List<csUbicacion>)Session["Lista"];
        //    }
        //}
        //private List<csUbicacion> GuardarLista(csUbicacion Ubicacion)
        //{
        //    if (Session["lista"] == null)
        //    {
        //        List<csUbicacion> lista = this.ObtenerNuevaLista();
        //        lista.Add(Ubicacion);
        //        Session["Lista"] = lista;

        //    }
        //    else
        //    {
        //        List<csUbicacion> lista = (List<csUbicacion>)Session["Lista"];
        //        lista.Add(Ubicacion);
        //        Session["Lista"] = lista;
        //    }
        //    return (List<csUbicacion>)Session["Lista"];
        //}
       
        //#endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogicaCategoria lgCategoria;
                lgCategoria = new LogicaCategoria();
                chekListCategoria.DataSource = lgCategoria.Listar();
                chekListCategoria.DataTextField = "categoria";
                chekListCategoria.DataValueField = "id_categoria";
                chekListCategoria.DataBind();
            }

        }

       

        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {

            LogicaNegocio lgNegocio = new LogicaNegocio();
            lgPath = new LogicaPath();        
            csUsuario usuario = (csUsuario)Session["Usuario"];
             lgExtNegocio = new LogicaEstadoNegocio();

            if (IsValid)
            {
                if ((uploadFile1.PostedFile != null) && (uploadFile1.PostedFile.ContentLength > 0))
                {
                    try
                    {

                        string fn = System.IO.Path.GetFileName(uploadFile1.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("media\\img") + "\\" + fn;
                        csNegocio negocio = new csNegocio(0, txtNombre.Text, txtDescdrip.Text, txtTelefono.Text, usuario.id_usuario, uploadFile1.FileName, hdLonft.Value, txtUbicacion.Text, hdLatFt.Value);
                        int codNegoc = int.Parse(lgNegocio.CrearNegocio(negocio));
                        if (codNegoc > 0)
                        {
                            uploadFile1.PostedFile.SaveAs(SaveLocation);
                            foreach (ListItem item in chekListCategoria.Items)
                            {
                                estNegocio=new csEstadoNegocio(0,int.Parse(item.Value.ToString()),codNegoc);
                                lgExtNegocio.CrearEstadoNegocio(estNegocio);
                            }
                            
                            Button2_ModalPopupExtender.Show();
                        }
                        else
                        {
                            ltRepuesta.Text = @"<div class='alert alert-danger'>
                             <strong>Danger!</strong> no guardor el registro.
                             </div>";
                        }

                    }
                    catch (Exception ex)
                    {
                        ltRepuesta.Text = @"<div class='alert alert-danger'>
                    <strong>Advertencia</strong> " + ex.Message + "</div>";

                    }

                }
                else
                {
                    ltRepuesta.Text = @"<div class='alert alert-danger'>
                    <strong>Danger!</strong> No cargo la Foto.
                    </div>";
                } 
            }
                     
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (chekListCategoria.SelectedIndex == -1)
            {
                args.IsValid = false;
            }
            //for (int i = 0; i < (chekListCategoria.Items.Count-1); i++)
            //{
            //    chekListCategoria.Items(i).sel
            //}
        }

        //protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        //{
        //    lgCategoria = new LogicaCategoria();
        //    dpDownCategoria.DataSource = lgCategoria.Listar();
        //    dpDownCategoria.DataTextField = "categoria";
        //    dpDownCategoria.DataSourceID = "id_categoria";
        //    dpDownCategoria.DataBind();
        //}
    }
}