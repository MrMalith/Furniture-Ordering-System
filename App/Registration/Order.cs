using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class Main_UI : Form
    {
        const double Price_Sofa = 75000.00;
        const double Price_TvStands = 15000.00;
        const double Price_WallUnits = 10000.00;
        const double Price_Coffee = 22000.00;
        const double Price_Iron = 17000.00;
        const double Price_BlossomSofa = 17000.00;
        const double Price_WallShelves = 35000.00;
        const double Price_Rugs = 11000.00;
        const double Price_Beds = 33000.00;
        const double Price_Matresses = 18000.00;
        const double Price_ClothRacks = 9000.00;
        const double Price_Wardrobes = 75000.00;
        const double Price_WoodenDS = 55000.00;
        const double Price_MetalDS = 85000.00;
        const double Price_ResDS = 45000.00;
        const double Price_Pantry = 13000.00;
        const double Price_BlossomDS = 50000.00;
        const double Price_ResDCH = 3500.00;
        const double Price_MetalDCH = 4500.00;
        const double Price_WoodenDCH = 4750.00;

        public Main_UI()
        {
            InitializeComponent();
        }

        //fn for uncheck the combo boxes
        //==================================EnableTextBoxes()===================================
        private void EnableTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = true;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        //========================================================================================

        //combo box items
        private void Main_UI_Load(object sender, EventArgs e)
        {
            cmbPaymentMethod.Items.Add("");
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("Master Card");
            cmbPaymentMethod.Items.Add("Debit Card");
            cmbPaymentMethod.Items.Add("Visa Card");

            EnableTextBoxes();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Confirm u want to Exit the system", "Covanro Furniture", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text == "Cash")
            {
                txtPaymentMethod.Enabled = true;
                txtPaymentMethod.Text = "";
                txtPaymentMethod.Focus();
            }
            else
            {
                txtPaymentMethod.Enabled = true;
                txtPaymentMethod.Text = "0";
                txtPaymentMethod.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //===================creating an array to store pricing details==================================
            double[] itemcost = new double[20];
            itemcost[0] = (Double)NumericUDSofa.Value * Price_Sofa;
            itemcost[1] = (Double)NumericUDTv.Value * Price_TvStands;
            itemcost[2] = (Double)NumericUDwall.Value * Price_WallUnits;
            itemcost[3] = (Double)NumericUDCoffee.Value * Price_Coffee;
            itemcost[4] = (Double)NumericUDIron.Value * Price_Iron;
            itemcost[5] = (Double)NumericUDBlossomSofa.Value * Price_BlossomSofa;
            itemcost[6] = (Double)NumericUDwall.Value * Price_WallShelves;//
            itemcost[7] = (Double)NumericUDRugs.Value * Price_Rugs;//
            itemcost[8] = (Double)NumericUDBeds.Value * Price_Beds;//
            itemcost[9] = (Double)NumericUDMattresses.Value * Price_Matresses;//
            itemcost[10] = (Double)NumericUDClothes.Value * Price_ClothRacks;//
            itemcost[11] = (Double)NumericUDWardrobes.Value * Price_Wardrobes;//
            itemcost[12] = (Double)NumericUDWoodenDS.Value * Price_WoodenDS;//
            itemcost[13] = (Double)NumericUDMetalDS.Value * Price_MetalDS;//
            itemcost[14] = (Double)NumericUDResDS.Value * Price_ResDS;//
            itemcost[15] = (Double)NumericUDPantry.Value * Price_Pantry;//
            itemcost[16] = (Double)NumericUDBlossomDS.Value * Price_BlossomDS;//
            itemcost[17] = (Double)NumericUDResDCH.Value * Price_ResDCH;//
            itemcost[18] = (Double)NumericUDMetalDCH.Value * Price_MetalDCH;//
            itemcost[19] = (Double)NumericUDWoodenDCH.Value * Price_WoodenDCH;//

            double Tax_Rate = 0.1;

            if (cmbPaymentMethod.Text == "Cash")
            {
                double iSubtotal = 0;

                foreach (double item in itemcost)
                {
                    iSubtotal += item;
                }

                txtSubTotal.Text = Convert.ToString(iSubtotal);

                double iTax = iSubtotal * Tax_Rate;
                txtTax.Text = Convert.ToString(iTax);

                double iTotal = (iSubtotal + iTax);
                txtTotal.Text = Convert.ToString(iTotal);

                double ichange = Convert.ToDouble(txtPaymentMethod.Text);
                double cost = ichange - (iTax + iTotal);
                txtChange.Text = Convert.ToString(cost);

                txtChange.Text = String.Format("{0:C}", cost);
                txtTax.Text = String.Format("{0:C}", iTax);
                txtSubTotal.Text = String.Format("{0:C}", iSubtotal);
                txtTotal.Text = String.Format("{0:C}", iTotal);
            }
            else
            {
                //
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtChange.Text = "0";
            txtTax.Text = "0";
            txtSubTotal.Text = "0";
            txtTotal.Text = "0";
        }
    }
}
