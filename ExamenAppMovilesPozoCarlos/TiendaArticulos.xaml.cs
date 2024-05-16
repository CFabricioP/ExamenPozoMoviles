using ApiClientPackage;
using ExamenAppMovilesPozoCarlos.Clases;

namespace ExamenAppMovilesPozoCarlos;

public partial class TiendaArticulos : ContentPage
{

    private string ApiUrlArticulos = "https://utnpozocarlosapi20240516115336.azurewebsites.net/api/Articulos";
    private string ApiUrlOrganizaciones = "https://utnpozocarlosapi20240516115336.azurewebsites.net/api/Organizaciones";

    public TiendaArticulos()
    {
        InitializeComponent();
    }

    // M�todos para Art�culos
    private async void btnGuardarArticulo_Clicked(object sender, EventArgs e)
    {
        var articulo = new Articulo
        {
            // Presumiendo que los campos est�n disponibles como Entries
            Nombre = txtNombre.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            OrganizacionId = string.IsNullOrWhiteSpace(txtOrganizacionId.Text) ? null : int.Parse(txtOrganizacionId.Text)
        };

        var resultado =  ApiConsumer<Articulo>.Create(ApiUrlArticulos, articulo);
        if (resultado != null)
        {
            // Actualizar la interfaz de usuario con los datos del art�culo guardado
        }
    }

    private async void btnLeerArticulo_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdArticulo.Text);
        var resultado =  ApiConsumer<Articulo>.Read(ApiUrlArticulos, id);
        if (resultado != null)
        {
            // Actualizar la interfaz de usuario con los datos del art�culo le�do
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
            OrganizacionId = string.IsNullOrWhiteSpace(txtOrganizacionId.Text) ? null : int.Parse(txtOrganizacionId.Text)
        };

        var resultado =  ApiConsumer<Articulo>.Update(ApiUrlArticulos, id, articulo);
        if (resultado != null)
        {
            // Actualizar la interfaz de usuario
        }
    }

    private async void btnEliminarArticulo_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdArticulo.Text);
         ApiConsumer<Articulo>.Delete(ApiUrlArticulos, id);
        // Limpiar la interfaz de usuario despu�s de eliminar el art�culo
    }
    // M�todo para crear una nueva Organizacion
    private async void btnGuardarOrganizacion_Clicked(object sender, EventArgs e)
    {
        var organizacion = new Organizacion
        {
            // Asumiendo que tienes Entry para la descripci�n
            Descripcion = txtDescripcion.Text
        };

        var resultado =  ApiConsumer<Organizacion>.Create(ApiUrlOrganizaciones, organizacion);
        if (resultado != null)
        {
            txtIdOrganizacion.Text = resultado.Id.ToString(); // Actualizar la interfaz de usuario con el ID de la organizaci�n creada
            txtDescripcion.Text = resultado.Descripcion;
        }
    }

    // M�todo para leer una Organizacion por ID
    private async void btnLeerOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
        var resultado =  ApiConsumer<Organizacion>.Read(ApiUrlOrganizaciones, id);
        if (resultado != null)
        {
            txtIdOrganizacion.Text = resultado.Id.ToString();
            txtDescripcion.Text = resultado.Descripcion;
        }
    }

    // M�todo para actualizar una Organizacion
    private async void btnActualizarOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
        var organizacion = new Organizacion
        {
            Id = id,
            Descripcion = txtDescripcion.Text
        };

        var resultado =  ApiConsumer<Organizacion>.Update(ApiUrlOrganizaciones, id, organizacion);
        if (resultado != null)
        {
            txtDescripcion.Text = resultado.Descripcion; // Actualizar la interfaz de usuario con la nueva descripci�n
        }
    }

    // M�todo para eliminar una Organizacion
    private async void btnEliminarOrganizacion_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtIdOrganizacion.Text);
        ApiConsumer<Organizacion>.Delete(ApiUrlOrganizaciones, id);
        txtIdOrganizacion.Text = ""; // Limpiar los campos despu�s de la eliminaci�n
        txtDescripcion.Text = "";
    }


}

