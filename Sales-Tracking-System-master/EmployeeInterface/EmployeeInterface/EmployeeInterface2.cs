using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInterface
{
    public partial class EmployeeInterface2 : Form
    {
        // Data Members

        private List<Quote> quoteList = new List<Quote>();
        private List<string> quoteNames = new List<string>();

        private QuoteSanctioner qs = new QuoteSanctioner();
        private QuoteConverter qc = new QuoteConverter();

        // Methods

        public EmployeeInterface2()
        {
            InitializeComponent();

            submitGroupBox.Visible = false;
            Width = 420;
            Height = 440;
        }

        private void customerSearchButton_Click(object sender, EventArgs e)
        {
            // clear out the quote selection box

            quoteNames.Clear();
            selectQuoteBox.DataSource = null;

            // pass the value in the customer search box to QuoteSanctioner

            if (customerSearchBox.Text != "")
            {
                quoteList = qc.searchCustomer(customerSearchBox.Text);

                for (int i = 0; i < quoteList.Count; i++)
                {
                    if (quoteList[i].getSanctioned())
                    {
                        quoteNames.Add("" + quoteList[i].getCustName() + " : " + quoteList[i].getName());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a name into the search box.");
            }

            selectQuoteBox.DataSource = quoteNames;
        }

        private void quoteSearchButton_Click(object sender, EventArgs e)
        {
            // clear out the quote selection box

            quoteNames.Clear();
            selectQuoteBox.DataSource = null;

            // pass the value in the quote search box to QuoteSanctioner

            if (quoteSearchBox.Text != "")
            {
                quoteList = qc.searchQuote(quoteSearchBox.Text);

                for (int i = 0; i < quoteList.Count; i++)
                {
                    if (quoteList[i].getSanctioned())
                    {
                        quoteNames.Add("" + quoteList[i].getCustName() + " : " + quoteList[i].getName());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a name into the search box.");
            }

            selectQuoteBox.DataSource = quoteNames;
        }

        private void selectQuoteButton_Click(object sender, EventArgs e)
        {
            // if a quote has been selected

            if (selectQuoteBox.SelectedIndex > -1)
            {
                // call quote sanctioner to select the quote

                qc.selectQuote(quoteList[selectQuoteBox.SelectedIndex]);
            }

            totalPriceBox.Text = qc.getActiveQuote().getTotalPrice() + "";

            submitGroupBox.Visible = true;
            Width = 800;
            Height = 440;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            float disc;

            float.TryParse(discountBox.Text, out disc);
            
            if(disc >= qc.getActiveQuote().getTotalPrice())
            {
                MessageBox.Show("Discount must be lower than the total price.");
            }
            else
            {
                qc.getActiveQuote().setTotalPrice(float.Parse(totalPriceBox.Text));

                string msg = qc.convertQuote(disc);
                MessageBox.Show(msg);

                qc.submitQuote(msg);
            }
        }

        private void discountBox_TextChanged(object sender, EventArgs e)
        {
            float discount;
            float.TryParse(discountBox.Text, out discount);

            if (discount < qc.getActiveQuote().getTotalPrice())
            {
                qc.getActiveQuote().setDiscount(discount);
            }
            else
            {
                MessageBox.Show("Discount must be lower than the total price.");
            }

            totalPriceBox.Text = qc.getActiveQuote().getTotalPrice() - qc.getActiveQuote().getDiscount() + "";
        }
    }
}
