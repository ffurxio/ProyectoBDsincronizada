namespace PuntoVenta.Vistas
{
    partial class ActualizarSistema
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
            this.btnActualizarCategorias = new System.Windows.Forms.Button();
            this.prBar1 = new System.Windows.Forms.ProgressBar();
            this.btnActualizarEmpleados = new System.Windows.Forms.Button();
            this.btnActualizarProductos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActualizarCategorias
            // 
            this.btnActualizarCategorias.Location = new System.Drawing.Point(24, 156);
            this.btnActualizarCategorias.Name = "btnActualizarCategorias";
            this.btnActualizarCategorias.Size = new System.Drawing.Size(75, 40);
            this.btnActualizarCategorias.TabIndex = 0;
            this.btnActualizarCategorias.Text = "Actualizar Categorias";
            this.btnActualizarCategorias.UseVisualStyleBackColor = true;
            this.btnActualizarCategorias.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // prBar1
            // 
            this.prBar1.Location = new System.Drawing.Point(24, 61);
            this.prBar1.Name = "prBar1";
            this.prBar1.Size = new System.Drawing.Size(237, 26);
            this.prBar1.TabIndex = 1;
            // 
            // btnActualizarEmpleados
            // 
            this.btnActualizarEmpleados.Location = new System.Drawing.Point(105, 156);
            this.btnActualizarEmpleados.Name = "btnActualizarEmpleados";
            this.btnActualizarEmpleados.Size = new System.Drawing.Size(75, 40);
            this.btnActualizarEmpleados.TabIndex = 2;
            this.btnActualizarEmpleados.Text = "Actualizar Empleados";
            this.btnActualizarEmpleados.UseVisualStyleBackColor = true;
            this.btnActualizarEmpleados.Click += new System.EventHandler(this.btnActualizarEmpleados_Click);
            // 
            // btnActualizarProductos
            // 
            this.btnActualizarProductos.Location = new System.Drawing.Point(186, 156);
            this.btnActualizarProductos.Name = "btnActualizarProductos";
            this.btnActualizarProductos.Size = new System.Drawing.Size(75, 40);
            this.btnActualizarProductos.TabIndex = 3;
            this.btnActualizarProductos.Text = "Actualizar Productos";
            this.btnActualizarProductos.UseVisualStyleBackColor = true;
            this.btnActualizarProductos.Click += new System.EventHandler(this.btnActualizarProductos_Click);
            // 
            // ActualizarSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnActualizarProductos);
            this.Controls.Add(this.btnActualizarEmpleados);
            this.Controls.Add(this.prBar1);
            this.Controls.Add(this.btnActualizarCategorias);
            this.Name = "ActualizarSistema";
            this.Text = "ActualizarSistema";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarCategorias;
        private System.Windows.Forms.ProgressBar prBar1;
        private System.Windows.Forms.Button btnActualizarEmpleados;
        private System.Windows.Forms.Button btnActualizarProductos;
    }
}