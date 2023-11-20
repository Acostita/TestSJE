namespace TestJSE
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClickThis = new System.Windows.Forms.Button();
            this.dvgStudents = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_actualizar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClickThis
            // 
            this.btnClickThis.Location = new System.Drawing.Point(652, 117);
            this.btnClickThis.Name = "btnClickThis";
            this.btnClickThis.Size = new System.Drawing.Size(75, 23);
            this.btnClickThis.TabIndex = 0;
            this.btnClickThis.Text = "Buscar";
            this.btnClickThis.UseVisualStyleBackColor = true;
            this.btnClickThis.Click += new System.EventHandler(this.button1_Click);
            // 
            // dvgStudents
            // 
            this.dvgStudents.AllowUserToAddRows = false;
            this.dvgStudents.AllowUserToDeleteRows = false;
            this.dvgStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgStudents.Location = new System.Drawing.Point(54, 80);
            this.dvgStudents.Name = "dvgStudents";
            this.dvgStudents.Size = new System.Drawing.Size(369, 200);
            this.dvgStudents.TabIndex = 2;
            this.dvgStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(537, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Texto a buscar:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_actualizar
            // 
            this.bt_actualizar.Location = new System.Drawing.Point(348, 286);
            this.bt_actualizar.Name = "bt_actualizar";
            this.bt_actualizar.Size = new System.Drawing.Size(75, 23);
            this.bt_actualizar.TabIndex = 5;
            this.bt_actualizar.Text = "Reiniciar";
            this.bt_actualizar.UseVisualStyleBackColor = true;
            this.bt_actualizar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_actualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dvgStudents);
            this.Controls.Add(this.btnClickThis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickThis;
        private System.Windows.Forms.DataGridView dvgStudents;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_actualizar;
        private System.Windows.Forms.Button button1;
    }
}

