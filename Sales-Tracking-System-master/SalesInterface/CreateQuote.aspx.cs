using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class CreateQuote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // on first page load

        if(!Page.IsPostBack)
        {
            // display customer information at top of screen

            string custName = (string)(Session["custName"]);
            string custStreet = (string)(Session["custStreet"]);
            string custCity = (string)(Session["custCity"]);
            string custContact = (string)(Session["custContact"]);

            custNameLabel.Text = custName;
            custStreetLabel.Text = custStreet;
            custCityLabel.Text = custCity;
            custContactLabel.Text = custContact;
        }
    }

    // On clicking the back button, redirect to customer select screen
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    // On clicking the logout button, redirect to the logout page
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // redirect to the logout page

        Response.Redirect("Logout.aspx");
    }

    // Submits the quote to the quote database upon clicking the submit button
    protected void submitButton_Click(object sender, EventArgs e)
    {
        if(Page.IsValid)
        {
            // set up arrays for list items, prices, and notes

            string[] items = new string[8] { itemBox1.Text, itemBox2.Text, itemBox3.Text, itemBox4.Text, itemBox5.Text, itemBox6.Text, itemBox7.Text, itemBox8.Text };
            TextBox[] priceBoxes = new TextBox[] { priceBox1, priceBox2, priceBox3, priceBox4, priceBox5, priceBox6, priceBox7, priceBox8 };
            float[] prices = new float[8];
            string[] notes = new string[] { noteBox1.Text, noteBox2.Text, noteBox3.Text };

            // ensure the discount field's text is an int

            float discount;
            float.TryParse(discountBox.Text, out discount);

            // calculate the total price before discount

            float total = calcTotal();

            // error check the discount amount

            if(discount >= total)
            {
                discount = 0;
            }
            else if(discount < 0)
            {
                discount = 0;
            }

            // get the connection string for the quote database

            string connString = ConfigurationManager.ConnectionStrings["myDBConn"].ConnectionString;

            // connect to the database

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                // open the connection

                conn.Open();

                // create the command to insert the quote into the database

                MySqlCommand insertQuote = new MySqlCommand("INSERT INTO quote (name, custName, email, sid, discount, total, sanctioned) " +
                    "VALUES ( '" + quoteNameBox.Text + "', '" + Session["custName"] + "', '" + emailBox.Text + "', " + Session["sid"] + ", " +
                        discount + ", " + total + ", 0 );", conn);

                // execute the command

                insertQuote.ExecuteNonQuery();

                // create a new query to get the id of the quote that was just created

                MySqlCommand getQuoteID = new MySqlCommand("SELECT id FROM quote WHERE name = '" + quoteNameBox.Text + "' AND custName = '" + 
                    Session["custName"] + "';", conn);

                // read the results of the query

                MySqlDataReader reader = getQuoteID.ExecuteReader();

                // if the read was successful, insert the quote items and notes

                if(reader.Read())
                {
                    // store the quote id in a string and close the reader

                    Session["qid"] = reader["id"];
                    reader.Close();

                    // loop through the line items to insert any that are not null

                    for (int i = 0; i < 8; i++)
                    {
                        // if the item is not null, check the validity of the price and insert

                        if (items[i] != "")
                        {
                            float.TryParse(priceBoxes[i].Text, out prices[i]);

                            // create command to insert items with prices

                            MySqlCommand insertItem = new MySqlCommand("INSERT INTO item (description, price, qid) VALUES ('" + items[i] +
                                "', " + prices[i] + ", " + Session["qid"] + ");", conn);

                            // execute command

                            insertItem.ExecuteNonQuery();
                        }
                    }

                    // loop through the notes to insert any that are not null

                    for (int i = 0; i < 3; i++)
                    {
                        // if a note is not null, insert into secretnotes table

                        if(notes[i] != "")
                        {
                            // create command to insert note

                            MySqlCommand insertNote = new MySqlCommand("INSERT INTO secretnotes (note, qid) VALUES ('" + notes[i] +
                                "', " + Session["qid"] + ");", conn);

                            // execute command

                            insertNote.ExecuteNonQuery();
                        }
                    }

                    // Redirect to form submit

                    Response.Redirect("QuoteSubmit.aspx");
                }
                else
                {
                    errorLabel.Text = "The quote could not be submitted.";
                }

                conn.Close();
            }
        }
        else
        {
            errorLabel.Text = "Missing required information";
        }
    }

    // Calculates the total price of the quote based on each item's price
    protected float calcTotal()
    {
        string[] items = new string[8] { itemBox1.Text, itemBox2.Text, itemBox3.Text, itemBox4.Text, itemBox5.Text, itemBox6.Text, itemBox7.Text, itemBox8.Text };
        TextBox[] priceBoxes = new TextBox[] { priceBox1, priceBox2, priceBox3, priceBox4, priceBox5, priceBox6, priceBox7, priceBox8 };
        
        float total = 0;
        float temp;

        // loop through the items array and add each valid item's price to the total

        for (int i = 0; i < 7; i++)
        {
            if (items[i] != "")
            {
                float.TryParse(priceBoxes[i].Text, out temp);
                total += temp;
            }
        }

        return total;
    }
 }