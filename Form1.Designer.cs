﻿namespace ImssAnalysis
{
    partial class Form1
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
            this.Procesar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEmpresaFecha = new System.Windows.Forms.RadioButton();
            this.rbFechaIngreso = new System.Windows.Forms.RadioButton();
            this.rbSinOrdenamineto = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Procesar
            // 
            this.Procesar.Location = new System.Drawing.Point(728, 91);
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(75, 23);
            this.Procesar.TabIndex = 0;
            this.Procesar.Text = "Procesar";
            this.Procesar.UseVisualStyleBackColor = true;
            this.Procesar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta archivo";
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(159, 9);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(410, 20);
            this.filePath.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(758, 307);
            this.dataGridView1.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSinOrdenamineto);
            this.groupBox1.Controls.Add(this.rbEmpresaFecha);
            this.groupBox1.Controls.Add(this.rbFechaIngreso);
            this.groupBox1.Location = new System.Drawing.Point(50, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el tipo de ordenamiento";
            // 
            // rbEmpresaFecha
            // 
            this.rbEmpresaFecha.AutoSize = true;
            this.rbEmpresaFecha.Location = new System.Drawing.Point(239, 19);
            this.rbEmpresaFecha.Name = "rbEmpresaFecha";
            this.rbEmpresaFecha.Size = new System.Drawing.Size(179, 17);
            this.rbEmpresaFecha.TabIndex = 1;
            this.rbEmpresaFecha.Text = "Por Empresa y Fecha de Ingreso";
            this.rbEmpresaFecha.UseVisualStyleBackColor = true;
            this.rbEmpresaFecha.CheckedChanged += new System.EventHandler(this.RbEmpresaFecha_CheckedChanged);
            // 
            // rbFechaIngreso
            // 
            this.rbFechaIngreso.AutoSize = true;
            this.rbFechaIngreso.Location = new System.Drawing.Point(6, 45);
            this.rbFechaIngreso.Name = "rbFechaIngreso";
            this.rbFechaIngreso.Size = new System.Drawing.Size(123, 17);
            this.rbFechaIngreso.TabIndex = 0;
            this.rbFechaIngreso.Text = "Por fecha de ingreso";
            this.rbFechaIngreso.UseVisualStyleBackColor = true;
            // 
            // rbSinOrdenamineto
            // 
            this.rbSinOrdenamineto.AutoSize = true;
            this.rbSinOrdenamineto.Checked = true;
            this.rbSinOrdenamineto.Location = new System.Drawing.Point(6, 16);
            this.rbSinOrdenamineto.Name = "rbSinOrdenamineto";
            this.rbSinOrdenamineto.Size = new System.Drawing.Size(109, 17);
            this.rbSinOrdenamineto.TabIndex = 2;
            this.rbSinOrdenamineto.TabStop = true;
            this.rbSinOrdenamineto.Text = "Sin Ordenamiento";
            this.rbSinOrdenamineto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Procesar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Procesar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEmpresaFecha;
        private System.Windows.Forms.RadioButton rbFechaIngreso;
        private System.Windows.Forms.RadioButton rbSinOrdenamineto;
    }
}

