namespace Pj_ConexionMySQL
{
    partial class frmAlumnos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            txtBuscar = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(696, 263);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(560, 10);
            button1.Name = "button1";
            button1.Size = new Size(93, 47);
            button1.TabIndex = 3;
            button1.Text = "Mostrar datos DataReader";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Enabled = false;
            txtBuscar.Location = new Point(51, 34);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(203, 23);
            txtBuscar.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(260, 29);
            button2.Name = "button2";
            button2.Size = new Size(52, 30);
            button2.TabIndex = 5;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(512, 370);
            button3.Name = "button3";
            button3.Size = new Size(105, 32);
            button3.TabIndex = 6;
            button3.Text = "modificar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(377, 368);
            button4.Name = "button4";
            button4.Size = new Size(115, 34);
            button4.TabIndex = 7;
            button4.Text = "Nuevo";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(634, 370);
            button5.Name = "button5";
            button5.Size = new Size(113, 33);
            button5.TabIndex = 8;
            button5.Text = "Eliminar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // frmAlumnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 431);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtBuscar);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "frmAlumnos";
            Text = "Form1";
            Load += frmAlumnosLista_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox txtBuscar;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}
