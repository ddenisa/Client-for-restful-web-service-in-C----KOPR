namespace RestClient
{
    partial class AddNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelAddNew = new System.Windows.Forms.Button();
            this.postupTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nazovTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Coho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jednotky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAddNewButton = new System.Windows.Forms.Button();
            this.autorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelAddNew
            // 
            this.cancelAddNew.Location = new System.Drawing.Point(769, 382);
            this.cancelAddNew.Name = "cancelAddNew";
            this.cancelAddNew.Size = new System.Drawing.Size(99, 45);
            this.cancelAddNew.TabIndex = 0;
            this.cancelAddNew.Text = "Cancel";
            this.cancelAddNew.UseVisualStyleBackColor = true;
            this.cancelAddNew.Click += new System.EventHandler(this.quitAddNew_Click);
            // 
            // postupTextBox
            // 
            this.postupTextBox.Location = new System.Drawing.Point(562, 71);
            this.postupTextBox.Multiline = true;
            this.postupTextBox.Name = "postupTextBox";
            this.postupTextBox.Size = new System.Drawing.Size(306, 290);
            this.postupTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(558, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Postup:";
            // 
            // nazovTextBox
            // 
            this.nazovTextBox.Location = new System.Drawing.Point(12, 71);
            this.nazovTextBox.Name = "nazovTextBox";
            this.nazovTextBox.Size = new System.Drawing.Size(207, 20);
            this.nazovTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nazov:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coho,
            this.Kolko,
            this.Jednotky});
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 264);
            this.dataGridView1.TabIndex = 5;
            // 
            // Coho
            // 
            this.Coho.HeaderText = "Coho";
            this.Coho.Name = "Coho";
            // 
            // Kolko
            // 
            this.Kolko.HeaderText = "Kolko";
            this.Kolko.Name = "Kolko";
            // 
            // Jednotky
            // 
            this.Jednotky.HeaderText = "Jednotky";
            this.Jednotky.Name = "Jednotky";
            // 
            // addAddNewButton
            // 
            this.addAddNewButton.Location = new System.Drawing.Point(12, 382);
            this.addAddNewButton.Name = "addAddNewButton";
            this.addAddNewButton.Size = new System.Drawing.Size(99, 45);
            this.addAddNewButton.TabIndex = 6;
            this.addAddNewButton.Text = "Add";
            this.addAddNewButton.UseVisualStyleBackColor = true;
            this.addAddNewButton.Click += new System.EventHandler(this.addAddNewButton_Click);
            // 
            // autorTextBox
            // 
            this.autorTextBox.Location = new System.Drawing.Point(12, 25);
            this.autorTextBox.Name = "autorTextBox";
            this.autorTextBox.Size = new System.Drawing.Size(207, 20);
            this.autorTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Autor:";
            // 
            // AddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 439);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autorTextBox);
            this.Controls.Add(this.addAddNewButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nazovTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postupTextBox);
            this.Controls.Add(this.cancelAddNew);
            this.Name = "AddNew";
            this.Text = "AddNew";
            this.Load += new System.EventHandler(this.AddNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelAddNew;
        private System.Windows.Forms.TextBox postupTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazovTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jednotky;
        private System.Windows.Forms.Button addAddNewButton;
        private System.Windows.Forms.TextBox autorTextBox;
        private System.Windows.Forms.Label label3;
    }
}