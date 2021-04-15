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
    public partial class Form2 : Form
    {
        List<Estudiante> estudiantes;

        public Form2()
        {
           
            InitializeComponent();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Cedula";
            dataGridView1.Columns[2].Name = "Nombre";
            dataGridView1.Columns[3].Name = "Edad";
            //Estudiante e = new Estudiante();
            //estudiantes = e.ObtenerRegistros();
            estudiantes = (new Estudiante()).ObtenerRegistros();

            foreach (Estudiante e in estudiantes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = e.Id;
                row.Cells[1].Value = e.Cedula;
                row.Cells[2].Value = e.Nombre;
                row.Cells[3].Value = e.Edad;
                dataGridView1.Rows.Add(row);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            //form.ShowDialog();
            //this.Hide();
            form.Show();
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(Convert.ToString(e.RowIndex));

            if (e.RowIndex>=0)
            {
                Form1 form1 = new Form1();
                form1.Estudiante = estudiantes[e.RowIndex];
                form1.Llenarcontroles();
                form1.Show();
            }

        }
    }
}
