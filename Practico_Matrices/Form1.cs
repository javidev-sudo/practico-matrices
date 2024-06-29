using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practico_Matrices
{
    public partial class Form1 : Form
    {

        Matriz x1,x2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = new Matriz();
            x2 = new Matriz();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.Cargar(int.Parse(textBox1.Text),int.Parse(textBox2.Text),int.Parse(textBox3.Text),int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = x1.Descargar();
            
        }

        private void acumlarNumerosPrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(x1.AcumEle());
        }

        private void frecuenciaDeUnElementoeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(x1.Frecuele(int.Parse(textBox7.Text)));
        }

        private void frecuenciaDeElemntosNoRepetidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(x1.EleNoRep());
        }

        private void cargarFiboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.Cargarfibo(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

        private void verifTodasLasFilasOrdenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(x1.VerifTofiOr());
        }

        private void elementosDeMayorFrecuenciaDeLaFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ElemenMayorFre();
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            x2.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox8.Text = x2.Descargar();
        }

        private void verifSiLaMatrizExisteEnOtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
           textBox6.Text = string.Concat(x1.VerifMaEleOtra(x2));
        }

        private void segmentarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.SegmenfILMatr();
            textBox8.Text = x1.Descargar();
        }

        private void primosUltimaFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.AddPrim();
            textBox5.Text = x1.Descargar();
        }

        private void ordenarPrimosDeUltimaFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.OrdCoprim();
            textBox8.Text = x1.Descargar();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            x1.OrdenarElePorFre(int.Parse(textBox9.Text),int.Parse(textBox10.Text),int.Parse(textBox11.Text),int.Parse(textBox12.Text));
            textBox8.Text = x1.Descargar();
        }

        private void ordenamientoSenoizoidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ordZeno();
            textBox8.Text = x1.Descargar();
        }

        private void intercalFiboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.IntercalarFibo();
            textBox8.Text = x1.Descargar();

        }

        private void ordenaminetoTriangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.OrdTrian1();
            textBox8.Text = x1.Descargar();
        }

        private void ordenaminetoTriangularInfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.OrdTri();
            textBox8.Text = x1.Descargar();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            x1.ordeDIa();
            textBox8.Text = x1.Descargar();
        }

        private void insertarElementoMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.InserEleMa();
            textBox8.Text = x1.Descargar();
        }

        private void verificarMatrizConRigorDe1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(x1.OrdenRig1());
        }
    }
}
