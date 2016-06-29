using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestClient
{
    public partial class GUI : Form
    {



        private List<Recept> listViewRecepty = new List<Recept>();
        
        public GUI()
        {
            InitializeComponent();
            /*  string endPoint = @"http://127.0.0.1:8080/chocolates/";
             var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: @"{""id"":""300"",""title"":""johny"",""percentage"":0}", ContentType: "application/json");
             try {
                 var json = client.MakeRequest();
                 Console.WriteLine(json.ToString());
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Mame vynimku!!!!!!!!!!!!!!!!!!!!!");
                 Console.WriteLine(ex.ToString());
             }
             finally
             {

             }

             Console.WriteLine("Test!!!!!!!!!!!!!!!!!!");*/
             /*
            List<Surovina> suroviny = new List<Surovina>();
            suroviny.Add(new Surovina("podravka", 10.6, "mg"));
            suroviny.Add(new Surovina("zeler", 11.9, "kg"));
            suroviny.Add(new Surovina("vacica", 1, "ks"));
            Recept recept = new Recept(suroviny, "Vyvar z vacice", "Vacicu pokraj, pridaj suroviny a nechaj varit 10000h. Lahodka pre ocka aj mamku", "Matko Kubko");
            Console.WriteLine(recept.print());



            string endPoint = @"http://127.0.0.1:8080/recepty/";
            string jsonpost = JsonConvert.SerializeObject(recept);
            Console.WriteLine(jsonpost);
            //Newtonsoft.Json.JsonConvert.SerializeObject(new { foo = "bar" });
            //var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "application/json");
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "");
            try
            {
                var json = client.MakeRequest();
                Console.WriteLine(json.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mame vynimku!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }

            Console.WriteLine("Test!!!!!!!!!!!!!!!!!!");
            */

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void addNew_Click(object sender, EventArgs e)
        {
            new AddNew().ShowDialog();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Value);
            string result = "";
            Recept recept = null;
            try {
                result = Connections.getOneById(id);
                Console.WriteLine(result);
                recept = new Recept(result);
                

            } catch (Exception ex)
            {
                if (ex.Message.Contains("(404) Not Found"))
                {
                    MessageBox.Show("Id not found! Id is: " + id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Some error, dont know why. Error message: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Console.WriteLine(ex.Message);
            }
            if (recept != null)
            {
                new AddNew(recept, false).ShowDialog();
            }
            //Console.WriteLine(result);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Value);
            try {
                Connections.delete(id);
                MessageBox.Show("Done! Deleted! Id: " + id.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    MessageBox.Show("Not found in database! Wrong ID. ID posted: " + id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Some error, dont know why. Error message: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getByID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Value);
            try
            {
                string result = Connections.getOneById(id);
                Console.WriteLine(result);
                Recept recept = new Recept(result);
                new AddNew(recept, true).ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    MessageBox.Show("Not found in database! Wrong ID. ID posted: " + id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Some error, dont know why. Error message: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void parse(string output)
        {
            listViewRecepty = new List<Recept>();
            var array = JArray.Parse(output.Trim('{', '}'));

            if (array.Count <= 0)
            {
                MessageBox.Show("Nothing found", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Console.WriteLine(array[0].ToString());
            foreach (var arrayValue in array)
            {
                Console.WriteLine(arrayValue.ToString());
                listViewRecepty.Add(new Recept(arrayValue.ToString()));
            }
            //Console.WriteLine("===========================");
            //Console.WriteLine(listViewRecepty[0].print());
            //Console.WriteLine(listViewRecepty[1].print());

            var columns = this.listView1.Columns;
            listView1.Items.Clear();
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;

            //listView1 = new ListView();
            //listView1.AllowColumnReorder = false;
            //listView1.AllowDrop = false;

            //this.listView1 = new ListView(row);
            foreach (var recept in listViewRecepty)
            {
                ListViewItem item1 = new ListViewItem(recept.id.ToString());
                item1.SubItems.Add(recept.getNazov());
                item1.SubItems.Add(recept.getAutor());
                listView1.Items.Add(item1);
                /*item1.SubItems.Add("SubItem1a");
                item1.SubItems.Add("SubItem1b");
                item1.SubItems.Add("SubItem1c");
                items.Add(recept);*/
            }
        }

        private void findByFullText_Click(object sender, EventArgs e)
        {
            string toFind = this.textBox1.Text;
            try
            {
               string output = Connections.findByName(toFind);
                this.parse(output);
                //listView1.Items.Add
                /*var recepty = JsonConvert.DeserializeObject<Recept>(array);
                foreach (var surovina in recepty.suroviny)
                {

                    sur.Add(surovina);
                }

                this.suroviny = sur;
                this.postup = recepty.postup;
                this.id = recepty.id;
                this.nazov = recepty.nazov;
                this.autor = recepty.autor;
                Console.WriteLine(this.print());*/
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Console.WriteLine();
                foreach (Recept recept in listViewRecepty)
                {
                    Console.WriteLine(recept.id.ToString());
                    if (listView1.SelectedItems[0].Text.Equals(recept.id.ToString()))
                    {
                        new AddNew(recept, true).ShowDialog();
                        return;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var form = new Resources())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<Surovina> suroviny = form.ReturnValue1;
                    if (suroviny.Count == 0)
                    {
                        MessageBox.Show("Error, we dont get any resources!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        string json = Connections.findByResources(suroviny);
                        this.parse(json);

                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
