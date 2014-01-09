using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRepair
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Connector.getInstance().Send("auth?login=" + textBoxLogin.Text + "&password=" +textBoxPassword.Text);
            //MessageBox.Show(textBoxLogin.Text + textBoxPassword.Text);
        }


    }
}
