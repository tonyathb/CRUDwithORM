using CRUDORM.Business;
using CRUDORM.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDORM.Presentation
{
    public partial class Form1 : Form
    {
        ProductBusiness productBusiness = new ProductBusiness();
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            label1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product
            {
                Name = textBox2.Text,
                Price = decimal.Parse(textBox3.Text),
                Stock = int.Parse(textBox4.Text)
            };
            productBusiness.Add(newProduct);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Product> allProducts = productBusiness.GetAll();
            foreach (var item in allProducts)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - {item.Price} ___ {item.Stock} kolichestvo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ne si izbral Id za iztrivane!");
                return;
            }

            int id = int.Parse(textBox1.Text);
            productBusiness.Delete(id);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == false)
            {
                label1.Visible = true;
                textBox1.Visible = true;
            }

            //btnFind_Click(sender, e);
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "")
            {
                MessageBox.Show("Ne si izbral Id za iztrivane!");
                return;
            }
            label2.Enabled = false;
            textBox2.Enabled = false;
            label3.Enabled = false;
            textBox3.Enabled = false;
            label4.Enabled = false;
            textBox4.Enabled = false;
            Product newProduct = productBusiness.Get(int.Parse(textBox1.Text));
            textBox1.Text = newProduct.Id.ToString();
            textBox2.Text = newProduct.Name;
            textBox3.Text = newProduct.Price.ToString();
            textBox4.Text = newProduct.Stock.ToString();
        }
    }
}
