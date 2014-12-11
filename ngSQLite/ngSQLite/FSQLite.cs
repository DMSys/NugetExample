using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ngSQLite
{
    public partial class FSQLite : Form
    {
        private String _DataSource = "";

        public FSQLite()
        {
            InitializeComponent();

            _DataSource = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TestBase.db");
            
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase())
                {
                    db.Open();

                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }
    }
}
