namespace ngSQLite
{
    partial class FSQLite
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
            this.btn_Initialize = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_DropTables = new System.Windows.Forms.Button();
            this.btn_DropDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Initialize
            // 
            this.btn_Initialize.Location = new System.Drawing.Point(12, 12);
            this.btn_Initialize.Name = "btn_Initialize";
            this.btn_Initialize.Size = new System.Drawing.Size(100, 23);
            this.btn_Initialize.TabIndex = 0;
            this.btn_Initialize.Text = "Initialize";
            this.btn_Initialize.UseVisualStyleBackColor = true;
            this.btn_Initialize.Click += new System.EventHandler(this.btn_Initialize_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Location = new System.Drawing.Point(12, 41);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(100, 23);
            this.btn_Clean.TabIndex = 1;
            this.btn_Clean.Text = "Clear";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_DropTables
            // 
            this.btn_DropTables.Location = new System.Drawing.Point(12, 70);
            this.btn_DropTables.Name = "btn_DropTables";
            this.btn_DropTables.Size = new System.Drawing.Size(100, 23);
            this.btn_DropTables.TabIndex = 2;
            this.btn_DropTables.Text = "Drop Tables";
            this.btn_DropTables.UseVisualStyleBackColor = true;
            this.btn_DropTables.Click += new System.EventHandler(this.btn_DropTables_Click);
            // 
            // btn_DropDatabase
            // 
            this.btn_DropDatabase.Location = new System.Drawing.Point(12, 99);
            this.btn_DropDatabase.Name = "btn_DropDatabase";
            this.btn_DropDatabase.Size = new System.Drawing.Size(100, 23);
            this.btn_DropDatabase.TabIndex = 3;
            this.btn_DropDatabase.Text = "Drop Database";
            this.btn_DropDatabase.UseVisualStyleBackColor = true;
            this.btn_DropDatabase.Click += new System.EventHandler(this.btn_DropDatabase_Click);
            // 
            // FSQLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 273);
            this.Controls.Add(this.btn_DropDatabase);
            this.Controls.Add(this.btn_DropTables);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.btn_Initialize);
            this.Name = "FSQLite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuGet: SQLite";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Initialize;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Button btn_DropTables;
        private System.Windows.Forms.Button btn_DropDatabase;
    }
}

