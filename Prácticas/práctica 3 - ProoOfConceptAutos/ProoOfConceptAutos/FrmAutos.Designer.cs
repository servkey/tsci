﻿namespace ProoOfConceptAutos
{
    partial class FrmAutos
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
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tbRegistro = new System.Windows.Forms.TabPage();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtAnio = new ProoOfConceptAutos.Base.CustomTextBox();
            this.txtMarca = new ProoOfConceptAutos.Base.CustomTextBox();
            this.txtModelo = new ProoOfConceptAutos.Base.CustomTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbConsulta = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblClave = new System.Windows.Forms.Label();
            this.cmbClave = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnioConsulta = new System.Windows.Forms.TextBox();
            this.txtMarcaConsulta = new System.Windows.Forms.TextBox();
            this.txtModeloConsulta = new System.Windows.Forms.TextBox();
            this.tabPrincipal.SuspendLayout();
            this.tbRegistro.SuspendLayout();
            this.tbConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tbRegistro);
            this.tabPrincipal.Controls.Add(this.tbConsulta);
            this.tabPrincipal.Location = new System.Drawing.Point(12, 24);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(305, 234);
            this.tabPrincipal.TabIndex = 7;
            this.tabPrincipal.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabPrincipal_Selected);
            // 
            // tbRegistro
            // 
            this.tbRegistro.Controls.Add(this.lblAnio);
            this.tbRegistro.Controls.Add(this.lblMarca);
            this.tbRegistro.Controls.Add(this.lblModelo);
            this.tbRegistro.Controls.Add(this.txtAnio);
            this.tbRegistro.Controls.Add(this.txtMarca);
            this.tbRegistro.Controls.Add(this.txtModelo);
            this.tbRegistro.Controls.Add(this.btnGuardar);
            this.tbRegistro.Location = new System.Drawing.Point(4, 22);
            this.tbRegistro.Name = "tbRegistro";
            this.tbRegistro.Padding = new System.Windows.Forms.Padding(3);
            this.tbRegistro.Size = new System.Drawing.Size(297, 208);
            this.tbRegistro.TabIndex = 0;
            this.tbRegistro.Text = "Registro";
            this.tbRegistro.UseVisualStyleBackColor = true;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(69, 119);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 13;
            this.lblAnio.Text = "Año";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(58, 74);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 12;
            this.lblMarca.Text = "Marca";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(53, 31);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 11;
            this.lblModelo.Text = "Modelo";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(146, 119);
            this.txtAnio.Mask = "s[5]";
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Required = false;
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 2;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(146, 74);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 1;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(146, 28);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(146, 160);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbConsulta
            // 
            this.tbConsulta.Controls.Add(this.btnEliminar);
            this.tbConsulta.Controls.Add(this.btnActualizar);
            this.tbConsulta.Controls.Add(this.lblClave);
            this.tbConsulta.Controls.Add(this.cmbClave);
            this.tbConsulta.Controls.Add(this.label1);
            this.tbConsulta.Controls.Add(this.label2);
            this.tbConsulta.Controls.Add(this.label3);
            this.tbConsulta.Controls.Add(this.txtAnioConsulta);
            this.tbConsulta.Controls.Add(this.txtMarcaConsulta);
            this.tbConsulta.Controls.Add(this.txtModeloConsulta);
            this.tbConsulta.Location = new System.Drawing.Point(4, 22);
            this.tbConsulta.Name = "tbConsulta";
            this.tbConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tbConsulta.Size = new System.Drawing.Size(297, 208);
            this.tbConsulta.TabIndex = 1;
            this.tbConsulta.Text = "Actualización";
            this.tbConsulta.UseVisualStyleBackColor = true;
            this.tbConsulta.Click += new System.EventHandler(this.tbConsulta_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(152, 179);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(71, 179);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 22;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(59, 21);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 21;
            this.lblClave.Text = "Clave";
            // 
            // cmbClave
            // 
            this.cmbClave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClave.FormattingEnabled = true;
            this.cmbClave.Location = new System.Drawing.Point(145, 18);
            this.cmbClave.Name = "cmbClave";
            this.cmbClave.Size = new System.Drawing.Size(100, 21);
            this.cmbClave.TabIndex = 20;
            this.cmbClave.SelectedIndexChanged += new System.EventHandler(this.cmbClave_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Modelo";
            // 
            // txtAnioConsulta
            // 
            this.txtAnioConsulta.Location = new System.Drawing.Point(145, 138);
            this.txtAnioConsulta.Name = "txtAnioConsulta";
            this.txtAnioConsulta.Size = new System.Drawing.Size(100, 20);
            this.txtAnioConsulta.TabIndex = 16;
            // 
            // txtMarcaConsulta
            // 
            this.txtMarcaConsulta.Location = new System.Drawing.Point(145, 96);
            this.txtMarcaConsulta.Name = "txtMarcaConsulta";
            this.txtMarcaConsulta.Size = new System.Drawing.Size(100, 20);
            this.txtMarcaConsulta.TabIndex = 15;
            // 
            // txtModeloConsulta
            // 
            this.txtModeloConsulta.Location = new System.Drawing.Point(145, 53);
            this.txtModeloConsulta.Name = "txtModeloConsulta";
            this.txtModeloConsulta.Size = new System.Drawing.Size(100, 20);
            this.txtModeloConsulta.TabIndex = 14;
            // 
            // FrmAutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 270);
            this.Controls.Add(this.tabPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de autos";
            this.Load += new System.EventHandler(this.FrmAutos_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tbRegistro.ResumeLayout(false);
            this.tbRegistro.PerformLayout();
            this.tbConsulta.ResumeLayout(false);
            this.tbConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tbRegistro;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModelo;
        private Base.CustomTextBox txtAnio;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabPage tbConsulta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.ComboBox cmbClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnioConsulta;
        private System.Windows.Forms.TextBox txtMarcaConsulta;
        private System.Windows.Forms.TextBox txtModeloConsulta;
        private System.Windows.Forms.Button btnEliminar;

    }
}

