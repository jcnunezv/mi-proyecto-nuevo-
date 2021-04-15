using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimerFormulario.Modelos;

namespace PrimerFormulario
{
    public partial class Form1 : Form
    {
        private Estudiante estudiante;

        internal Estudiante Estudiante { get => estudiante; set => estudiante = value; }

        public Form1()
        {
            InitializeComponent();
        }
        public void Llenarcontroles()
        {
            txtCedula.Text = estudiante.Cedula;
            txtCedula.Text = estudiante.Nombre;
            txtCedula.Text = estudiante.Edad;


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "" && txtNombre.Text == "" && txtNombre.Text == "") {
                MessageBox.Show("Todos los campos son obligatorios");
            }
            else
            {
                if (this.estudiante == null)
                {
                    Estudiante estudiante = new Estudiante();
                    if (estudiante.Error == "")
                    {
                        estudiante.Cedula = txtCedula.Text;
                        estudiante.Nombre = txtNombre.Text;
                        estudiante.Edad = txtEdad.Text;
                        estudiante.Agregar();
                        if (estudiante.Error == "")
                        {
                            MessageBox.Show("Estudiante guardado con exito");
                            txtCedula.Text = "";
                            txtNombre.Text = "";
                            txtEdad.Text = "";
                        }

                        else
                        {
                            MessageBox.Show("1 " + estudiante.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("2 " + estudiante.Error);
                    }
                }
                else
                {
                    this.estudiante.Cedula = txtCedula.Text;
                    this.estudiante.Nombre = txtNombre.Text;
                    this.estudiante.Edad = txtEdad.Text;
                    this.estudiante.editar();
                    if (this.estudiante.Error == "")
                    {
                        MessageBox.Show("estudiante gurdado con exito");
                        txtCedula.Text = "";
                        txtNombre.Text = "";
                        txtEdad.Text = "";
       

                    }

                    else
                    {
                        MessageBox.Show("1" + this.estudiante.Error);
                    }
                }
                    }

                }
            }
        }
    






