namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    partial class FormContactar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContactar));
            this.label12 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnContactar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label12.Location = new System.Drawing.Point(33, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(220, 19);
            this.label12.TabIndex = 71;
            this.label12.Text = "Ingrese CODIGO del Cliente";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(33, 51);
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(220, 25);
            this.txtTelefono.TabIndex = 72;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnContactar
            // 
            this.btnContactar.BackColor = System.Drawing.Color.Lime;
            this.btnContactar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactar.ForeColor = System.Drawing.Color.Black;
            this.btnContactar.Location = new System.Drawing.Point(33, 96);
            this.btnContactar.Name = "btnContactar";
            this.btnContactar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnContactar.Size = new System.Drawing.Size(220, 42);
            this.btnContactar.TabIndex = 70;
            this.btnContactar.Text = "CONTACTAR 📞";
            this.btnContactar.UseVisualStyleBackColor = false;
            this.btnContactar.Click += new System.EventHandler(this.btnContactar_Click);
            // 
            // FormContactar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(283, 150);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnContactar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormContactar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONTACTAR CLIENTE 📞";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnContactar;
    }
}