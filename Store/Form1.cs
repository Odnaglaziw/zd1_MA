using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Form1 : Form
    {
        private Shop shop;
        public Form1()
        {
            InitializeComponent();
            InitializeFormControls();
            shop = new Shop();
        }
        private void InitializeFormControls()
        {
            Label lblProductName = new Label
            {
                Name = "lblProductName",
                Text = "Наименование товара",
                Location = new System.Drawing.Point(10, 20),
                AutoSize = true
            };
            Controls.Add(lblProductName);

            TextBox txtProductName = new TextBox
            {
                Name = "txtProductName",
                Location = new System.Drawing.Point(150, 20),
                Width = 150
            };
            Controls.Add(txtProductName);

            Label lblProductPrice = new Label
            {
                Name = "lblProductPrice",
                Text = "Цена товара",
                Location = new System.Drawing.Point(10, 60),
                AutoSize = true
            };
            Controls.Add(lblProductPrice);

            TextBox txtProductPrice = new TextBox
            {
                Name = "txtProductPrice",
                Location = new System.Drawing.Point(150, 60),
                Width = 150
            };
            Controls.Add(txtProductPrice);

            Label lblProductCount = new Label
            {
                Name = "lblProductCount",
                Text = "Количество товара",
                Location = new System.Drawing.Point(10, 100),
                AutoSize = true
            };
            Controls.Add(lblProductCount);

            TextBox txtProductCount = new TextBox
            {
                Name = "txtProductCount",
                Location = new System.Drawing.Point(150, 100),
                Width = 150
            };
            Controls.Add(txtProductCount);

            Button btnAddProduct = new Button
            {
                Name = "btnAddProduct",
                Text = "Добавить товар",
                Location = new System.Drawing.Point(10, 140),
                Width = 150
            };
            btnAddProduct.Click += BtnAddProduct_Click;
            Controls.Add(btnAddProduct);

            Button btnSellProduct = new Button
            {
                Name = "btnSellProduct",
                Text = "Продать товар",
                Location = new System.Drawing.Point(180, 140),
                Width = 150
            };
            btnSellProduct.Click += BtnSellProduct_Click;
            Controls.Add(btnSellProduct);

            ListBox lstProducts = new ListBox
            {
                Name = "lstProducts",
                Location = new System.Drawing.Point(10, 180),
                Size = new System.Drawing.Size(320, 150)
            };
            Controls.Add(lstProducts);

            Label lblProfit = new Label
            {
                Name = "lblProfit",
                Text = "Прибыль: 0 руб.",
                Location = new System.Drawing.Point(10, 340),
                Width = 320
            };
            Controls.Add(lblProfit);
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            string name = ((TextBox)Controls["txtProductName"]).Text;
            decimal price = decimal.TryParse(((TextBox)Controls["txtProductPrice"]).Text, out price) ? price : 0;
            int count = int.TryParse(((TextBox)Controls["txtProductCount"]).Text, out count) ? count : 0;

            if (string.IsNullOrEmpty(name) || price <= 0 || count <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            shop.CreateProduct(name, price, count);
            UpdateProductList();
            UpdateProfitLabel();
        }
        private void BtnSellProduct_Click(object sender, EventArgs e)
        {
            string name = ((TextBox)Controls["txtProductName"]).Text;
            decimal price = decimal.TryParse(((TextBox)Controls["txtProductPrice"]).Text, out price) ? price : -1;
            int count = int.TryParse(((TextBox)Controls["txtProductCount"]).Text, out count) ? count : 0;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, укажите наименование товара для продажи.");
                return;
            }
            Product productToSell;
            if (price < 0)
            {
                productToSell = shop.FindByName(name);
            }
            else
            {
                productToSell = new Product(name, price);
            }
            
            if (productToSell != null)
            {
                shop.Sell(productToSell,count);
                UpdateProductList();
                UpdateProfitLabel();
            }
            else
            {
                MessageBox.Show("Товар не найден.");
            }
        }
        private void UpdateProductList()
        {
            ListBox lstProducts = (ListBox)Controls["lstProducts"];
            lstProducts.Items.Clear();

            foreach (var product in shop.GetProducts())
            {
                lstProducts.Items.Add($"{product.Key.GetInfo()}; Количество: {product.Value}");
            }
        }

        private void UpdateProfitLabel()
        {
            Label lblProfit = (Label)Controls["lblProfit"];
            lblProfit.Text = $"Прибыль: {shop.Profit} руб.";
        }
    }
}
