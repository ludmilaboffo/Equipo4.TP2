using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Grupo4TPWinform
{
    public partial class Form1 : Form
    {
        private List<Articulo>listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvArticulos.DataSource = listaArticulos;
            pbArticulos.Load(listaArticulos[0].ImagenUrl);

        }

        private void pbArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado=(Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagenArticulo(seleccionado.ImagenUrl);
        }

        private void cargarImagenArticulo(string imagen)
        {
            try
            {
                pbArticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pbArticulos.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
