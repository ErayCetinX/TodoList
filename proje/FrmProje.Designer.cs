namespace proje
{
    partial class FrmProje
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
            this.Create = new System.Windows.Forms.Button();
            this.Todos = new System.Windows.Forms.ListBox();
            this.Doing = new System.Windows.Forms.ListBox();
            this.Done = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(949, 204);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(103, 31);
            this.Create.TabIndex = 3;
            this.Create.Text = "Oluştur";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.button1_Click);
            // 
            // Todos
            // 
            this.Todos.BackColor = System.Drawing.Color.White;
            this.Todos.FormattingEnabled = true;
            this.Todos.ItemHeight = 16;
            this.Todos.Location = new System.Drawing.Point(12, 204);
            this.Todos.Name = "Todos";
            this.Todos.Size = new System.Drawing.Size(272, 292);
            this.Todos.TabIndex = 4;
            // 
            // Doing
            // 
            this.Doing.FormattingEnabled = true;
            this.Doing.ItemHeight = 16;
            this.Doing.Location = new System.Drawing.Point(319, 204);
            this.Doing.Name = "Doing";
            this.Doing.Size = new System.Drawing.Size(272, 292);
            this.Doing.TabIndex = 5;
            // 
            // Done
            // 
            this.Done.FormattingEnabled = true;
            this.Done.ItemHeight = 16;
            this.Done.Location = new System.Drawing.Point(616, 204);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(272, 292);
            this.Done.TabIndex = 6;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(949, 241);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(103, 31);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Sil";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(949, 278);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(103, 31);
            this.back.TabIndex = 8;
            this.back.Text = "Geri";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // FrmProje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 595);
            this.Controls.Add(this.back);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.Doing);
            this.Controls.Add(this.Todos);
            this.Controls.Add(this.Create);
            this.Name = "FrmProje";
            this.Text = "FrmProje";
            this.Load += new System.EventHandler(this.FrmProje_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.ListBox Todos;
        private System.Windows.Forms.ListBox Doing;
        private System.Windows.Forms.ListBox Done;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button back;
    }
}