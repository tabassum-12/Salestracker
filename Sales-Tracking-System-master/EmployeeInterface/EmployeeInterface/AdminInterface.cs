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
    public partial class AdminInterface : Form
    {
		EmployeeMaintainer em;
		List<string> empNames;
		List<SalesPerson> employees = new List<SalesPerson>();
		bool addNew = false;

        public AdminInterface()
        {
            InitializeComponent();
			em = new EmployeeMaintainer();
			empNames = new List<string>();
        }

		private void idSearchButton_Click(object sender, EventArgs e)
		{
			empNames.Clear();
			selectBox.DataSource = null;

			if (idSearchBox.Text != "")
			{
				employees = em.searchById(Int32.Parse(idSearchBox.Text));
				for (int i = 0; i < employees.Count; i++)
					empNames.Add(employees[i].getName());
			}

			selectBox.DataSource = empNames;
		}

		private void nameSearchButton_Click(object sender, EventArgs e)
		{
			empNames.Clear();
			selectBox.DataSource = null;

			if (nameSearchBox.Text != "")
			{
				employees = em.searchByName(nameSearchBox.Text);
				for (int i = 0; i < employees.Count; i++)
					empNames.Add(employees[i].getName());
			}

			selectBox.DataSource = empNames;
		}

		private void selectButton_Click(object sender, EventArgs e)
		{
			if (selectBox.SelectedIndex > -1)
			{
				em.selectSalesPerson(employees[selectBox.SelectedIndex]);

				editGroupBox.Visible = true;
				nameBox.Text = em.getCurrentSalesPerson().getName();
				addressBox.Text = em.getCurrentSalesPerson().getAddress();
				passwordBox.Text = em.getCurrentSalesPerson().getPassword();
				idBox.Text = em.getCurrentSalesPerson().getEmpId() + "";
				commissionBox.Text = em.getCurrentSalesPerson().getCommission() + "";
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete " + employees[selectBox.SelectedIndex].getName() + "?", "Confirm sales person deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
				em.deleteSalesPerson(employees[selectBox.SelectedIndex]);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			editGroupBox.Visible = true;
			nameBox.Text = "";
			addressBox.Text = "";
			passwordBox.Text = "";
			idBox.Text = "";
			commissionBox.Text = "";
			addNew = true;
		}

		private void submitButton_Click(object sender, EventArgs e)
		{
			if (addNew)
			{
				SalesPerson sp = new SalesPerson(nameBox.Text, Int32.Parse(idBox.Text), passwordBox.Text, float.Parse(commissionBox.Text), addressBox.Text);
				em.addSalesPerson(sp);
				addNew = false;
				MessageBox.Show("Successfully added " + sp.getName());
			}
			else
			{
				em.getCurrentSalesPerson().setAddress(addressBox.Text);
				em.getCurrentSalesPerson().setName(nameBox.Text);
				em.getCurrentSalesPerson().setPassword(passwordBox.Text);
				em.getCurrentSalesPerson().setEmpId(Int32.Parse(idBox.Text));
				em.getCurrentSalesPerson().setCommission(float.Parse(commissionBox.Text));
				em.updateSalesPerson(em.getCurrentSalesPerson());
				MessageBox.Show("Successfully updated " + em.getCurrentSalesPerson().getName());
			}
		}
    }
}
