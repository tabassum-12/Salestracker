using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    private string connString;
    private MySqlConnection conn;
    private MySqlCommand getCustomers;
    private MySqlDataReader reader;

    // On initial page load, connect to legacy database and populate customer drop down list
    protected void Page_Load(object sender, EventArgs e)
    {
        // if this is the first time the page has loaded, connect to the server
        if (!Page.IsPostBack)
        {
            // set connection string to legacyConn

            connString = ConfigurationManager.ConnectionStrings["legacyConn"].ConnectionString;

            // open the connection

            using (conn = new MySqlConnection(connString))
            {
                conn.Open();

                // create the query to pull customer names from database

                getCustomers = new MySqlCommand("SELECT * FROM customers ORDER BY name", conn);

                // bind the customer name box to the query

                custNameBox.DataSource = getCustomers.ExecuteReader();
                custNameBox.DataBind();
            }
        }
    }

    // On selecting a customer, store customer info and redirect to quote creation form
    protected void selectCustomerButton_Click(object sender, EventArgs e)
    {
        // set connection string to legacyConn

        connString = ConfigurationManager.ConnectionStrings["legacyConn"].ConnectionString;
        
        // open a new connection

        using (conn = new MySqlConnection(connString))
        {
            conn.Open();

            getCustomers = new MySqlCommand("Select * FROM customers WHERE id = '" + Int32.Parse(custNameBox.SelectedItem.Value) + "'", conn);

            // read the results of the getCustomers query

            reader = getCustomers.ExecuteReader();

            // if the query was valid, store the customer info into session variables

            if (reader.Read())
            {
                Session["custName"] = reader["name"].ToString();
                Session["custCity"] = reader["city"].ToString();
                Session["custStreet"] = reader["street"].ToString();
                Session["custContact"] = reader["contact"].ToString();
            }
        }

        // redirect to the quote creation page

        Response.Redirect("CreateQuote.aspx");
    }

    // On clicking the logout button, redirect to the logout page
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // redirect to the logout page

        Response.Redirect("Logout.aspx");
    }
}