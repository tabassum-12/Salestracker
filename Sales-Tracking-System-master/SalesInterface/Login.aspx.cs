using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Connects to the salestracking database to authenticate username
    // and password

    protected void loginButton_Click(object sender, EventArgs e)
    {
        if(Page.IsValid)
        {
            string userName = userNameBox.Text;
            string password;

            // set the connection string

            string connString = ConfigurationManager.ConnectionStrings["myDBConn"].ConnectionString;

            // connect to the database

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // create the query to get the password for the given username

                MySqlCommand getPassword = new MySqlCommand("SELECT * FROM employees WHERE id = '" + Int32.Parse(userName) + "'", conn);

                MySqlDataReader reader = getPassword.ExecuteReader();

                // if the results of the query were read, test the password

                if (reader.Read())
                {
                    // set password to the password from the database

                    password = reader["password"].ToString();
                    reader.Close();

                    // if the passwords match, get the user's name

                    if (password == passwordBox.Text)
                    {
                        // create query to get salesperson's name

                        MySqlCommand getUser = new MySqlCommand("SELECT sid FROM employees WHERE employees.id = '" + Int32.Parse(userName) + "'", conn);

                        // read the results of the query

                        reader = getUser.ExecuteReader();

                        // if the results were read, store the user's name in a session variable and redirect

                        if(reader.Read())
                        {
                            // store the name in a session variable

                            Session["sid"] = reader["sid"];

                            // redirect to default page

                            errorLabel.Text = "";
                            FormsAuthentication.RedirectFromLoginPage(userName, false);
                            reader.Close();
                        }
                    }

                    // if the passwords do not match, print an error message

                    else
                    {
                        errorLabel.Text = "Invalid Password. Please try again.";
                    }
                }

                // if the query wasn't valid, print an error message

                else
                {
                    errorLabel.Text = "Invalid Username. Please try again.";
                }

                // close the connection

                conn.Close();
            }
        }
    }
}