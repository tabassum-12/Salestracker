using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace EmployeeInterface
{
	public partial class EmployeeInterface : Form
	{
		// Data Members

		private TextBox[] itemBoxList;
		private TextBox[] priceBoxList;

		private List<Item> itemList = new List<Item>();
		private int itemCount = 0;
		private float[] priceList;
		private List<Quote> quoteList = new List<Quote>();
		private List<string> quoteNames = new List<string>();

		private QuoteSanctioner qs = new QuoteSanctioner();

		// Methods

		public EmployeeInterface()
		{
			InitializeComponent();

            // fill the textbox lists with their respective textboxes

			itemBoxList = new TextBox[8] {itemBox1, itemBox2, itemBox3, itemBox4, 
                itemBox5, itemBox6, itemBox7, itemBox8};
			priceBoxList = new TextBox[8] {priceBox1, priceBox2, priceBox3, priceBox4, 
                priceBox5, priceBox6, priceBox7, priceBox8};

            // Initialize itemList and priceList
			//itemList = new List<Item>();
			priceList = new float[8];

            this.Width = 420;
            this.Height = 440;
		}

		private void EmployeeInterface_Load(object sender, EventArgs e)
		{

		}

        // Searches for a quote by customer name
		private void customerSearchButton_Click(object sender, EventArgs e)
		{
			quoteNames.Clear();
			selectQuoteBox.DataSource = null;

			if (customerSearchBox.Text != "")
			{
				quoteList = qs.searchCustomer(customerSearchBox.Text);
				for (int i = 0; i < quoteList.Count; i++)
				{
					if (!quoteList[i].getSanctioned())
						quoteNames.Add("" + quoteList[i].getCustName() + " : " + quoteList[i].getName());
				}
			}
			else
				MessageBox.Show("Please enter a name into the search box.");

			selectQuoteBox.DataSource = quoteNames;
		}

        // Searches for a quote by quote name
		private void quoteSearchButton_Click(object sender, EventArgs e)
		{
			quoteNames.Clear();
			selectQuoteBox.DataSource = null;

			if (quoteSearchBox.Text != "")
			{
				quoteList = qs.searchQuote(quoteSearchBox.Text);
				for (int i = 0; i < quoteList.Count; i++)
				{
					if (!quoteList[i].getSanctioned())
						quoteNames.Add("" + quoteList[i].getCustName() + " : " + quoteList[i].getName());
				}
			}
			else
				MessageBox.Show("Please enter a name into the search box.");

			selectQuoteBox.DataSource = quoteNames;
		}

        // Displays the quote information for the selected quote
		private void selectQuoteButton_Click(object sender, EventArgs e)
		{
            // if a quote has been selected

            if(selectQuoteBox.SelectedIndex > -1)
            {
                // call quote sanctioner to select the quote

                qs.selectQuote(quoteList[selectQuoteBox.SelectedIndex]);

                // make the rest of the form visible

                quoteGroupBox.Visible = true;
				quoteNameBox.Text = qs.getActiveQuote().getName();
				discountBox.Text = qs.getActiveQuote().getDiscount() + "";
				emailBox.Text = qs.getActiveQuote().getEmail();
				totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() + "";

				//copy over the quote's item list into this item list

				itemList = qs.getActiveQuote().getItemList();
				fillItemBoxText();
				itemCount = itemList.Count;
				fillSecretNotes();

                // resize window

                this.Width = 1130;
                this.Height = 670;
            }
		}

		// Creates a quote object filled with values from the form
		// when the 'submit quote' button is pressed.
		private void submitQuoteButton_Click(object sender, EventArgs e)
		{
			fillItemList();
			fillPriceList();

            // put each box's value into variables to pass to QuoteSanctioner

			string quoteName = quoteNameBox.Text;

			string email = emailBox.Text;

			float discount = float.Parse(discountBox.Text);
			bool sanctioned = SanctionBox.Checked;
			
			//clear itemList to start it fresh for submitting
			//itemList.Clear();
			//add items to the item list
			for (int i = itemList.Count; i < itemCount; i++)
				itemList.Add(new Item(itemBoxList[i].Text, float.Parse(priceBoxList[i].Text)));

			//make a note list and add the text from the text boxes to it
			List<string> notes = new List<string>();
			notes.Add(noteBox1.Text);
			if (noteBox2.Text != "")
				notes.Add(noteBox2.Text);
			if (noteBox3.Text != "")
				notes.Add(noteBox3.Text);

			qs.submitQuote(itemList, quoteName, email, discount, sanctioned, notes);

			if (sanctioned)
			{
				MailMessage mail = new MailMessage();
				SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress("salestracking467@gmail.com");
				mail.To.Add(email);
				mail.Subject = "Order Confirmation";
				mail.Body = "Your sales quote with id: " + qs.getActiveQuote().getId() + " has been sanctioned and is ready to be made into a purchase order. Your total for the order is: $" 
							+ (qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount());

				smtpServer.Port = 587;
				smtpServer.Credentials = new System.Net.NetworkCredential("salestracking467", "salestracking123");
				smtpServer.EnableSsl = true;

				smtpServer.Send(mail);
			}

			MessageBox.Show("Quote submitted successfully.");
		}

		//fills the item text boxes with info about the items from the db
		private void fillItemBoxText()
		{
			for (int i = 0; i < qs.getActiveQuote().getItemList().Count; i++)
			{
				//not sure of a more efficient way to do this besides manually editing the visible/not visible things
				switch (i)
				{
					case 0:
						itemBox1.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox1.Visible = true;
						priceBox1.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox1.Visible = true;
						break;
					case 1:
						itemBox2.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox2.Visible = true;
						priceBox2.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox2.Visible = true;
						itemButton2.Visible = true;
						itemButtonR2.Visible = true;
						itemButton1.Visible = false;
						label4.Visible = true;
						break;
					case 2:
						itemBox3.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox3.Visible = true;
						priceBox3.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox3.Visible = true;
						itemButton3.Visible = true;
						itemButtonR3.Visible = true;
						itemButton2.Visible = false;
						itemButtonR2.Visible = false;
						label5.Visible = true;
						break;
					case 3:
						itemBox4.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox4.Visible = true;
						priceBox4.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox4.Visible = true;
						itemButton4.Visible = true;
						itemButtonR4.Visible = true;
						itemButton3.Visible = false;
						itemButtonR3.Visible = false;
						label6.Visible = true;
						break;
					case 4:
						itemBox5.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox5.Visible = true;
						priceBox5.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox5.Visible = true;
						itemButton5.Visible = true;
						itemButtonR5.Visible = true;
						itemButton4.Visible = false;
						itemButtonR4.Visible = false;
						label7.Visible = true;
						break;
					case 5:
						itemBox6.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox6.Visible = true;
						priceBox6.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox6.Visible = true;
						itemButton6.Visible = true;
						itemButtonR6.Visible = true;
						itemButton5.Visible = false;
						itemButtonR5.Visible = false;
						label8.Visible = true;
						break;
					case 6:
						itemBox7.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox7.Visible = true;
						priceBox7.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox7.Visible = true;
						itemButton7.Visible = true;
						itemButtonR7.Visible = true;
						itemButton6.Visible = false;
						itemButtonR6.Visible = false;
						label9.Visible = true;
						break;
					case 7:
						itemBox8.Text = qs.getActiveQuote().getItemList()[i].getDescription();
						itemBox8.Visible = true;
						priceBox8.Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
						priceBox8.Visible = true;
						itemButtonR8.Visible = true;
						itemButton7.Visible = false;
						itemButtonR7.Visible = false;
						label10.Visible = true;
						break;
					default:
						break;
				}
				itemBoxList[i].Visible = true;
				itemBoxList[i].Text = qs.getActiveQuote().getItemList()[i].getDescription();
				priceBoxList[i].Text = qs.getActiveQuote().getItemList()[i].getPrice().ToString();
			}
		}

        // fills them item list with the text of any item boxes that are currently visible
		private void fillItemList()
		{
			for (int i = 0; i < 8; i++)
			{
				if (itemBoxList[i].Visible)
				{
					itemList[i].setDescription(itemBoxList[i].Text);
				}
			}
		}


        // Fills the price list with the values of any price boxes that are currently visible
		private void fillPriceList()
		{
			for (int i = 0; i < 8; i++)
			{
				if (priceBoxList[i].Visible)
				{
                    float price;
                    float.TryParse(priceBoxList[i].Text, out price);
					itemList[i].setPrice(price);
				}
			}
		}

		//fills the secret note boxes with notes from the db
		private void fillSecretNotes()
		{
			qs.getSecretNotes();
			for (int i = 0; i < qs.getActiveQuote().getNotes().Count; i++)
			{
				switch (i)
				{
					case 0:
						noteBox1.Text = qs.getActiveQuote().getNotes()[0];
						noteBox2.Visible = true;
						noteButton2.Visible = true;
						noteButtonR2.Visible = true;
						noteButton1.Visible = false;
						break;
					case 1:
						noteBox2.Text = qs.getActiveQuote().getNotes()[1];
						noteBox3.Visible = true;
						noteButtonR3.Visible = true;
						noteButton2.Visible = false;
						noteButtonR2.Visible = false;
						break;
					case 2:
						noteBox3.Text = qs.getActiveQuote().getNotes()[2];
						noteButton2.Visible = false;
						noteButtonR2.Visible = false;
						noteButtonR3.Visible = false;
						break;
					default:
						break;
				}
			}
		}

        // These methods are for each + / - button to change visibility on the required fields

        private void itemButton1_Click(object sender, EventArgs e)
        {
            itemBox2.Visible = true;
            priceBox2.Visible = true;
            itemButton2.Visible = true;
            itemButtonR2.Visible = true;

			itemButton1.Visible = false;
			label4.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton2_Click(object sender, EventArgs e)
        {
            itemBox3.Visible = true;
            priceBox3.Visible = true;
            itemButton3.Visible = true;
            itemButtonR3.Visible = true;

            itemButton2.Visible = false;
			itemButtonR2.Visible = false;
			label5.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton3_Click(object sender, EventArgs e)
        {
            itemBox4.Visible = true;
            priceBox4.Visible = true;
            itemButton4.Visible = true;
            itemButtonR4.Visible = true;

            itemButton3.Visible = false;
			itemButtonR3.Visible = false;
			label6.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton4_Click(object sender, EventArgs e)
        {
            itemBox5.Visible = true;
            priceBox5.Visible = true;
            itemButton5.Visible = true;
            itemButtonR5.Visible = true;

            itemButton4.Visible = false;
			itemButtonR4.Visible = false;
			label7.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton5_Click(object sender, EventArgs e)
        {
            itemBox6.Visible = true;
            priceBox6.Visible = true;
            itemButton6.Visible = true;
            itemButtonR6.Visible = true;

            itemButton5.Visible = false;
			itemButtonR5.Visible = false;
			label8.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton6_Click(object sender, EventArgs e)
        {
            itemBox7.Visible = true;
            priceBox7.Visible = true;
            itemButton7.Visible = true;
            itemButtonR7.Visible = true;

            itemButton6.Visible = false;
			itemButtonR6.Visible = false;
			label9.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButton7_Click(object sender, EventArgs e)
        {
            itemBox8.Visible = true;
            priceBox8.Visible = true;
            itemButtonR8.Visible = true;

            itemButton7.Visible = false;
			itemButtonR7.Visible = false;
			label10.Visible = true;
			itemCount++;
			itemList.Add(new Item());
        }

        private void itemButtonR2_Click(object sender, EventArgs e)
        {
            itemBox2.Visible = false;
            itemBox2.Text = "";
            priceBox2.Visible = false;
            priceBox2.Text = "";
            itemButton2.Visible = false;
			itemButtonR2.Visible = false;

			itemButton1.Visible = true;
			label4.Visible = false;

			//remove item from list and db

			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR3_Click(object sender, EventArgs e)
        {
            itemBox3.Visible = false;
            itemBox3.Text = "";
            priceBox3.Visible = false;
            priceBox3.Text = "";
            itemButton3.Visible = false;
            itemButtonR3.Visible = false;

            itemButton2.Visible = true;
			itemButtonR2.Visible = true;
			label5.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR4_Click(object sender, EventArgs e)
        {
            itemBox4.Visible = false;
            itemBox4.Text = "";
            priceBox4.Visible = false;
            priceBox4.Text = "";
            itemButton4.Visible = false;
            itemButtonR4.Visible = false;

            itemButton3.Visible = true;
			itemButtonR3.Visible = true;
			label6.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR5_Click(object sender, EventArgs e)
        {
            itemBox5.Visible = false;
            itemBox5.Text = "";
            priceBox5.Visible = false;
            priceBox5.Text = "";
            itemButton5.Visible = false;
            itemButtonR5.Visible = false;

            itemButton4.Visible = true;
			itemButtonR4.Visible = true;
			label7.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR6_Click(object sender, EventArgs e)
        {
            itemBox6.Visible = false;
            itemBox6.Text = "";
            priceBox6.Visible = false;
            priceBox6.Text = "";
            itemButton6.Visible = false;
            itemButtonR6.Visible = false;

            itemButton5.Visible = true;
			itemButtonR5.Visible = true;
			label8.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR7_Click(object sender, EventArgs e)
        {
            itemBox7.Visible = false;
            itemBox7.Text = "";
            priceBox7.Visible = false;
            priceBox7.Text = "";
            itemButton7.Visible = false;
            itemButtonR7.Visible = false;

            itemButton6.Visible = true;
			itemButtonR6.Visible = true;
			label9.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void itemButtonR8_Click(object sender, EventArgs e)
        {
            itemBox8.Visible = false;
            itemBox8.Text = "";
            priceBox8.Visible = false;
            priceBox8.Text = "";
            itemButtonR8.Visible = false;

            itemButton7.Visible = true;
			itemButtonR7.Visible = true;
			label10.Visible = false;
			itemCount--;
			qs.deleteItem(itemList[itemCount]);
			itemList.RemoveAt(itemCount);
        }

        private void noteButton1_Click(object sender, EventArgs e)
        {
            noteBox2.Visible = true;
            noteButton2.Visible = true;
            noteButtonR2.Visible = true;

			noteButton1.Visible = false;
        }

        private void noteButton2_Click(object sender, EventArgs e)
        {
            noteBox3.Visible = true;
            noteButtonR3.Visible = true;

            noteButton2.Visible = false;
			noteButtonR2.Visible = false;
        }

        private void noteButtonR2_Click(object sender, EventArgs e)
        {
            noteBox2.Visible = false;
            noteButton2.Visible = false;
            noteButtonR2.Visible = false;

			noteButton1.Visible = true;
        }

        private void noteButtonR3_Click(object sender, EventArgs e)
        {
            noteBox3.Visible = false;
            noteButtonR3.Visible = false;

            noteButton2.Visible = true;
			noteButtonR2.Visible = true;
        }

		//this section is for copying the text from the UI text boxes into the text box list arrays

		private void itemBox1_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[0].Text = itemBox1.Text;
		}

		private void itemBox2_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[1].Text = itemBox2.Text;
		}

		private void itemBox3_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[2].Text = itemBox3.Text;
		}

		private void itemBox4_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[3].Text = itemBox4.Text;
		}

		private void itemBox5_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[4].Text = itemBox5.Text;
		}

		private void itemBox6_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[5].Text = itemBox6.Text;
		}

		private void itemBox7_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[6].Text = itemBox7.Text;
		}

		private void itemBox8_TextChanged(object sender, EventArgs e)
		{
			itemBoxList[7].Text = itemBox8.Text;
		}

		private void priceBox1_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[0].Text = priceBox1.Text;

            float price;
            float.TryParse(priceBox1.Text, out price);

			if (price < float.MaxValue)
                itemList[0].setPrice(price);
			else
			{
				priceBox1.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox2_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[1].Text = priceBox2.Text;

            float price;
            float.TryParse(priceBox2.Text, out price);

			if (price < float.MaxValue)
                itemList[1].setPrice(price);
			else
			{
				priceBox2.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox3_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[2].Text = priceBox3.Text;

            float price;
            float.TryParse(priceBox3.Text, out price);

			if (price < float.MaxValue)
                itemList[2].setPrice(price);
			else
			{
				priceBox3.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox4_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[3].Text = priceBox4.Text;

            float price;
            float.TryParse(priceBox4.Text, out price);

			if (price < float.MaxValue)
                itemList[3].setPrice(price);
			else
			{
				priceBox4.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox5_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[4].Text = priceBox5.Text;

            float price;
            float.TryParse(priceBox5.Text, out price);

			if (price < float.MaxValue)
                itemList[4].setPrice(price);
			else
			{
				priceBox5.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox6_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[5].Text = priceBox6.Text;

            float price;
            float.TryParse(priceBox6.Text, out price);

			if (price < float.MaxValue)
                itemList[5].setPrice(price);
			else
			{
				priceBox6.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox7_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[6].Text = priceBox7.Text;

            float price;
            float.TryParse(priceBox7.Text, out price);

			if (price < float.MaxValue)
				itemList[6].setPrice(price);
			else
			{
				priceBox7.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void priceBox8_TextChanged(object sender, EventArgs e)
		{
			priceBoxList[7].Text = priceBox8.Text;

            float price;
            float.TryParse(priceBox8.Text, out price);

			if (price < float.MaxValue)
				itemList[7].setPrice(price);
			else
			{
				priceBox8.Text = float.MaxValue + "";
				MessageBox.Show("Value exceeds max.");
			}
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}

		private void discountBox_TextChanged(object sender, EventArgs e)
		{
            float discount;
            float.TryParse(discountBox.Text, out discount);

			if (discount < qs.getActiveQuote().getCurrentTotalPrice())
				qs.getActiveQuote().setDiscount(discount);
			else
				MessageBox.Show("Discount must be lower than the total price.");
			totalPriceBox.Text = qs.getActiveQuote().getCurrentTotalPrice() - qs.getActiveQuote().getDiscount() + "";
		}
	}
}
