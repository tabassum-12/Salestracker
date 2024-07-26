using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInterface
{
	class SalesPerson
	{
		private string name;
        private int sid;
		private string password;
		private float commission;
		private string address;
		private int empId;

		public SalesPerson()
		{

		}

		public SalesPerson(string nm, int nid, string pw, float comm, string add)
		{
			name = nm;
		    empId = nid;
			password = pw;
			commission = comm;
			address = add;
		}

        public SalesPerson(string nm, int nid, int nid2, string pw, float comm, string add)
        {
            name = nm;
            empId = nid;
            sid = nid2;
            password = pw;
            commission = comm;
            address = add;
        }

        public string getName()
        {
            return name;
        }

        public int getSId()
        {
            return sid;
        }

		public string getPassword()
		{
			return password;
		}

		public float getCommission()
		{
			return commission;
		}

		public string getAddress()
		{
			return address;
		}

		public void setName(string nm)
		{
			name = nm;
		}

        public void setSId(int idd)
        {
            sid = idd;
        }

		public void setPassword(string pw)
		{
			password = pw;
		}

		public void setCommission(float comm)
		{
			commission = comm;
		}

		public void setAddress(string add)
		{
			address = add;
		}

		public void setEmpId(int idd)
		{
			empId = idd;
		}

		public int getEmpId()
		{
			return empId;
		}
	}
}
