using ApiClientPackage;
using ExamenAppMovilesPozoCarlos.Clases;
using System;

namespace ExamenAppMovilesPozoCarlos;

public partial class TiendaArticulos : ContentPage
{
    private string ApiUrlArticulos = "https://utnpozocarlosapi20240516115336.azurewebsites.net/api/Articulos";
    private string ApiUrlOrganizaciones = "https://utnpozocarlosapi20240516115336.azurewebsites.net/api/Organizaciones";

    public TiendaArticulos()
    {
        InitializeComponent();
    }

    // Métodos para Artículos
    private async void btnGuardarArticulo_Clicked(object sender, EventArgs e)
    {
        var articulo = new Articulo
        {
            Nombre = txtNombre.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            OrganizacionId = string.IsNullOrWhiteSpace(txtOrganizacionId.Text) ? (int?)null : int.Parse(txtOrganizacionId.Text)
        };

        var resultado =   ApiConsumer<Articulo>.Create(ApiUrlArticulos, articulo);
        if (resultado != null)
        {
            txtIdArticulo.Text = resultado.Id.ToString(); // Asumiendo que hay un txtIdArticulo para mostrar el ID
        }
    }

    private async void btnLeerArticulo_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdArticulo.Text);
        var resultado =   ApiConsumer<Articulo>.Read(ApiUrlArticulos, id);
        if (resultado != null)
        {
            txtNombre.Text = resultado.Nombre;
            txtExistencia.Text = resultado.Existencia.ToString();
            txtPrecioUnitario.Text = resultado.PrecioUnitario.ToString();
            txtIVA.Text = resultado.IVA.ToString();
            txtOrganizacionId.Text = resultado.OrganizacionId?.ToString() ?? "";
        }
    }

    private async void btnActualizarArticulo_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdArticulo.Text);
        var articulo = new Articulo
        {
            Id = id,
            Nombre = txtNombre.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            OrganizacionId = string.IsNullOrWhiteSpace(txtOrganizacionId.Text) ? (int?)null : int.Parse(txtOrganizacionId.Text)
        };

        var resultado =   ApiConsumer<Articulo>.Update(ApiUrlArticulos, id, articulo);
        if (resultado != null)
        {
            txtNombre.Text = resultado.Nombre; // Asumiendo que deseas actualizar la vista con la información actualizada
        }
    }

    private async void btnEliminarArticulo_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdArticulo.Text);
          ApiConsumer<Articulo>.Delete(ApiUrlArticulos, id);
        txtIdArticulo.Text = "";
        txtNombre.Text = "";
        txtExistencia.Text = "";
        txtPrecioUnitario.Text = "";
        txtIVA.Text = "";
        txtOrganizacionId.Text = "";
    }

    // Métodos para Organizaciones
    private async void btnGuardarOrganizacion_Clicked(object sender, EventArgs e)
    {
        var organizacion = new Organizacion
        {
            Descripcion = txtDescripcion.Text
        };

        var resultado =   ApiConsumer<Organizacion>.Create(ApiUrlOrganizaciones, organizacion);
        if (resultado != null)
        {
            txtIdOrganizacion.Text = resultado.Id.ToString();
            txtDescripcion.Text = resultado.Descripcion;
        }
    }

    private async void btnLeerOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
        var resultado =   ApiConsumer<Organizacion>.Read(ApiUrlOrganizaciones, id);
        if (resultado != null)
        {
            txtIdOrganizacion.Text = resultado.Id.ToString();
            txtDescripcion.Text = resultado.Descripcion;
        }
    }

    private async void btnActualizarOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
        var organizacion = new Organizacion
        {
            Id = id,
            Descripcion = txtDescripcion.Text
        };

        var resultado =   ApiConsumer<Organizacion>.Update(ApiUrlOrganizaciones, id, organizacion);
        if (resultado != null)
        {
            txtDescripcion.Text = resultado.Descripcion;
        }
    }

    private async void btnEliminarOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
          ApiConsumer<Organizacion>.Delete(ApiUrlOrganizaciones, id);
        txtIdOrganizacion.Text = "";
        txtDescripcion.Text = "";
    }
}
