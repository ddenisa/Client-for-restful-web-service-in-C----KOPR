using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestClient
{
    public partial class Resources : Form
    {
        public List<Surovina> ReturnValue1 { get; set; }
        public Resources()
        {
            InitializeComponent();
        }

        private void Resources_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    List<Surovina> suroviny = new List<Surovina>();
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row != null)
                        {
                            if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) && (row.Cells[2].Value != null))
                            {
                                suroviny.Add(new Surovina(row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[1].Value.ToString()), row.Cells[2].Value.ToString()));
                            }
                            else
                            {

                            }
                        }

                    }
                    if (suroviny.Count == 0)
                    {
                        MessageBox.Show("Please add some resources!", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else {
                    this.ReturnValue1 = suroviny;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    //daco sprav so surovinami
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Input string was not in a correct format."))
                {
                    MessageBox.Show("Use , not . ! Or some error in quantity ! Check it !",
                    "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
