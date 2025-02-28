namespace Examen
{
    partial class FormPrincipal
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnHabitaciones = new System.Windows.Forms.Button();
            this.btnReservaciones = new System.Windows.Forms.Button();
            this.btnHuespedes = new System.Windows.Forms.Button();
            this.salirbtn = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panelMenu.Controls.Add(this.btnHabitaciones);
            this.panelMenu.Controls.Add(this.btnReservaciones);
            this.panelMenu.Controls.Add(this.btnHuespedes);
            this.panelMenu.Controls.Add(this.salirbtn);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(225, 463);
            this.panelMenu.TabIndex = 7;
            // 
            // btnHabitaciones
            // 
            this.btnHabitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHabitaciones.Font = new System.Drawing.Font("Garamond", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabitaciones.ForeColor = System.Drawing.Color.SeaShell;
            this.btnHabitaciones.Location = new System.Drawing.Point(22, 270);
            this.btnHabitaciones.Name = "btnHabitaciones";
            this.btnHabitaciones.Size = new System.Drawing.Size(184, 30);
            this.btnHabitaciones.TabIndex = 7;
            this.btnHabitaciones.Text = "Habitaciones";
            this.btnHabitaciones.UseVisualStyleBackColor = true;
            this.btnHabitaciones.Click += new System.EventHandler(this.btnHabitaciones_Click);
            // 
            // btnReservaciones
            // 
            this.btnReservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReservaciones.Font = new System.Drawing.Font("Garamond", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservaciones.ForeColor = System.Drawing.Color.SeaShell;
            this.btnReservaciones.Location = new System.Drawing.Point(22, 333);
            this.btnReservaciones.Name = "btnReservaciones";
            this.btnReservaciones.Size = new System.Drawing.Size(184, 30);
            this.btnReservaciones.TabIndex = 6;
            this.btnReservaciones.Text = "Reservaciones";
            this.btnReservaciones.UseVisualStyleBackColor = true;
            this.btnReservaciones.Click += new System.EventHandler(this.btnReservaciones_Click);
            // 
            // btnHuespedes
            // 
            this.btnHuespedes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuespedes.Font = new System.Drawing.Font("Garamond", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuespedes.ForeColor = System.Drawing.Color.SeaShell;
            this.btnHuespedes.Location = new System.Drawing.Point(22, 209);
            this.btnHuespedes.Name = "btnHuespedes";
            this.btnHuespedes.Size = new System.Drawing.Size(184, 30);
            this.btnHuespedes.TabIndex = 5;
            this.btnHuespedes.Text = "Huespedes";
            this.btnHuespedes.UseVisualStyleBackColor = true;
            this.btnHuespedes.Click += new System.EventHandler(this.btnHuespedes_Click);
            // 
            // salirbtn
            // 
            this.salirbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.salirbtn.Font = new System.Drawing.Font("Garamond", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirbtn.ForeColor = System.Drawing.Color.SeaShell;
            this.salirbtn.Location = new System.Drawing.Point(22, 394);
            this.salirbtn.Name = "salirbtn";
            this.salirbtn.Size = new System.Drawing.Size(184, 30);
            this.salirbtn.TabIndex = 4;
            this.salirbtn.Text = "Salir del Sistema";
            this.salirbtn.UseVisualStyleBackColor = true;
            this.salirbtn.Click += new System.EventHandler(this.salirbtn_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.SeaShell;
            this.panelContenedor.Controls.Add(this.label2);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(225, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(798, 463);
            this.panelContenedor.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SeaShell;
            this.label2.Font = new System.Drawing.Font("Garamond", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(206, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hotel del Valle";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 463);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnHabitaciones;
        private System.Windows.Forms.Button btnReservaciones;
        private System.Windows.Forms.Button btnHuespedes;
        private System.Windows.Forms.Button salirbtn;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label label2;
    }
}

