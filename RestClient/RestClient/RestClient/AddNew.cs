using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace RestClient
{
    public partial class AddNew : Form
    {
        private Recept recept;
        private bool update = false;
        private int id;

        public AddNew()
        {
            InitializeComponent();
            postupTextBox.ScrollBars = ScrollBars.Vertical;
           // postupTextBox.WordWrap = false;
        }

        public AddNew(Recept recept, bool view)
        {
            InitializeComponent();
            postupTextBox.ScrollBars = ScrollBars.Vertical;
            //postupTextBox.WordWrap = false;
            this.recept = recept;
            update = true;
            this.autorTextBox.Text = this.recept.autor;
            this.postupTextBox.Text = this.recept.postup;
            this.nazovTextBox.Text = this.recept.nazov;
            this.id = recept.id;
            foreach (Surovina surovina in this.recept.suroviny)
            {
                DataGridViewRow row = (DataGridViewRow)this.dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = surovina.nazov;
                row.Cells[1].Value = surovina.mnozstvo;
                row.Cells[2].Value = surovina.jednotka;
                this.dataGridView1.Rows.Add(row);
            }
            if (!view)
            {
                this.addAddNewButton.Text = "Update";
            }
            else
            {
                this.addAddNewButton.Enabled = false;
                this.dataGridView1.ReadOnly = true;
                this.autorTextBox.ReadOnly = true;
                this.postupTextBox.ReadOnly = true;
                this.nazovTextBox.ReadOnly = true;
            }
        }

        private void quitAddNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateRest()
        {
            try
            {
                if (String.IsNullOrEmpty(nazovTextBox.Text) && String.IsNullOrEmpty(postupTextBox.Text) && String.IsNullOrEmpty(autorTextBox.Text))
                {
                    MessageBox.Show("Fill every field", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
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
                        MessageBox.Show("Fill every field! Suroviny is 0 :P ", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else {
                        Recept recept = new Recept(this.id, suroviny, this.nazovTextBox.Text, this.postupTextBox.Text, this.autorTextBox.Text);
                        Console.WriteLine(recept.print());
                        this.updateToRest(recept);
                    }
                }
                MessageBox.Show("Updated!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void uploadRest()
        {
            try
            {
                if (String.IsNullOrEmpty(nazovTextBox.Text) && String.IsNullOrEmpty(postupTextBox.Text) && String.IsNullOrEmpty(autorTextBox.Text))
                {
                    MessageBox.Show("Fill every field", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
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
                        MessageBox.Show("Fill every field! Suroviny is 0 :P ", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else {
                        Recept recept = new Recept(suroviny, this.nazovTextBox.Text, this.postupTextBox.Text, this.autorTextBox.Text);
                        Console.WriteLine(recept.print());
                        this.upload(recept);
                    }
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
                if (ex.Message.Contains("418"))
                {
                    MessageBox.Show("TEAPOT: " + ex.Message + "; NULL REFERENCE!", "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (ex.Message.Contains("204"))
                {
                    MessageBox.Show("Null object: " + ex.Message, "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show(ex.Message, "Warning, some error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
        }

        private void addAddNewButton_Click(object sender, EventArgs e)
        {
            if (update)
            {
                this.updateRest();
            }
            else {
                this.uploadRest();
            }
        }

        private void updateToRest(Recept recept)
        {
            try
            {
                Connections.update(recept);
            } catch (Exception ex)
            {
                if (ex.Message.Contains("(404) Not Found"))
                {
                    MessageBox.Show("Id not found! Id is: " + id.ToString() + "Maybe it was deleted until you edited it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.update = false;
                    this.addAddNewButton.Text = "Upload";
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void upload(Recept recept)
        {
            try {

                int id = Connections.upload(recept);
                if (id != -1)
                {
                    MessageBox.Show("Yours data was uploaded. Id is " + id.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.showError(null);
                }
            } catch (Exception ex)
            {
                this.showError(ex);
            }

        }

        private void showError(Exception ex)
        {
            MessageBox.Show("Error in upload, check data and try again later. Error: " + ex.Message, "Error upload data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void AddNew_Load(object sender, EventArgs e)
        {

        }
    }
}
