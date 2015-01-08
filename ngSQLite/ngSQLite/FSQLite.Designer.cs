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
            this.btn_Updata = new System.Windows.Forms.Button();
            this.btn_TransactionCommit = new System.Windows.Forms.Button();
            this.btn_TransactionRollback = new System.Windows.Forms.Button();
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
            // btn_Updata
            // 
            this.btn_Updata.Location = new System.Drawing.Point(118, 12);
            this.btn_Updata.Name = "btn_Updata";
            this.btn_Updata.Size = new System.Drawing.Size(75, 23);
            this.btn_Updata.TabIndex = 4;
            this.btn_Updata.Text = "Update";
            this.btn_Updata.UseVisualStyleBackColor = true;
            this.btn_Updata.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_TransactionCommit
            // 
            this.btn_TransactionCommit.Location = new System.Drawing.Point(199, 12);
            this.btn_TransactionCommit.Name = "btn_TransactionCommit";
            this.btn_TransactionCommit.Size = new System.Drawing.Size(123, 23);
            this.btn_TransactionCommit.TabIndex = 5;
            this.btn_TransactionCommit.Text = "Transaction Commit";
            this.btn_TransactionCommit.UseVisualStyleBackColor = true;
            this.btn_TransactionCommit.Click += new System.EventHandler(this.btn_TransactionCommit_Click);
            // 
            // btn_TransactionRollback
            // 
            this.btn_TransactionRollback.Location = new System.Drawing.Point(199, 41);
            this.btn_TransactionRollback.Name = "btn_TransactionRollback";
            this.btn_TransactionRollback.Size = new System.Drawing.Size(123, 23);
            this.btn_TransactionRollback.TabIndex = 6;
            this.btn_TransactionRollback.Text = "Transaction Rollback";
            this.btn_TransactionRollback.UseVisualStyleBackColor = true;
            this.btn_TransactionRollback.Click += new System.EventHandler(this.btn_TransactionRollback_Click);
            // 
            // FSQLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 273);
            this.Controls.Add(this.btn_TransactionRollback);
            this.Controls.Add(this.btn_TransactionCommit);
            this.Controls.Add(this.btn_Updata);
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
        private System.Windows.Forms.Button btn_Updata;
        private System.Windows.Forms.Button btn_TransactionCommit;
        private System.Windows.Forms.Button btn_TransactionRollback;
    }
}

