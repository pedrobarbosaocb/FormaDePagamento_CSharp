using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList formaPagto = new ArrayList();
            formaPagto.Add(new FormaDePagto(1, "-- Selecione a forma de pagamento --"));
            formaPagto.Add(new FormaDePagto(2, "Cartão"));
            formaPagto.Add(new FormaDePagto(3, "Pix"));
            formaPagto.Add(new FormaDePagto(4, "Boleto"));

            comboBox1.DataSource = formaPagto;
            comboBox1.DisplayMember = "Descricao";
            comboBox1.ValueMember = "ID";
        }

        public class FormaDePagto
        {
            public int ID { get; set; }
            public string Descricao { get; set; }
           
            public FormaDePagto (int ID, string Descricao)
            {
                this.ID = ID;
                this.Descricao = Descricao;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int escolha = comboBox1.SelectedIndex;
                double valor = 0;

                switch (escolha)
                {
                    case 0:
                        lblMetodo.Text = "";
                        lblValor.Text = "";
                        break;

                    case 1:
                        lblMetodo.Text = "Cartão";
                        valor = double.Parse(textBox1.Text);
                        lblValor.Text = $"1x R${valor.ToString("F2")}" +
                            $"\n2x R${valor / 2:F2}" +
                            $"\n3x R${valor / 3:F2}" +
                            $"\n5x R${valor / 5:F2}" +
                            $"\n10x R${valor / 10:F2}";
                        break;

                    case 2:
                        lblMetodo.Text = "Pix";
                        valor = double.Parse(textBox1.Text);
                        lblValor.Text = $"R${valor:F2}" +
                            $"\nChave Pix: emailexemplo@gmail.com";
                        break;

                    case 3:
                        lblMetodo.Text = "Boleto";
                        valor = double.Parse(textBox1.Text);
                        lblValor.Text = $"R${valor:F2}";
                        break;

                    default:
                        lblMetodo.Text = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMetodo.Text = "insira um valor válido";
            }
        }
    }
}
