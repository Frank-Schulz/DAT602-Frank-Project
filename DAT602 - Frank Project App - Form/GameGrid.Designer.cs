
namespace DAT602___Frank_Project_App___Form
{
    partial class GameGrid
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
            this.gameGridData = new System.Windows.Forms.DataGridView();
            this.C1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameGridData)).BeginInit();
            this.SuspendLayout();
            // 
            // gameGridData
            // 
            this.gameGridData.AllowUserToAddRows = false;
            this.gameGridData.AllowUserToDeleteRows = false;
            this.gameGridData.AllowUserToResizeColumns = false;
            this.gameGridData.AllowUserToResizeRows = false;
            this.gameGridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gameGridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gameGridData.ColumnHeadersVisible = false;
            this.gameGridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C1,
            this.C2,
            this.C3,
            this.C4,
            this.C5,
            this.C6,
            this.C7,
            this.C8,
            this.C9,
            this.C10});
            this.gameGridData.Enabled = false;
            this.gameGridData.Location = new System.Drawing.Point(12, 12);
            this.gameGridData.MultiSelect = false;
            this.gameGridData.Name = "gameGridData";
            this.gameGridData.ReadOnly = true;
            this.gameGridData.RowHeadersVisible = false;
            this.gameGridData.RowHeadersWidth = 10;
            this.gameGridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gameGridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gameGridData.Size = new System.Drawing.Size(395, 376);
            this.gameGridData.TabIndex = 100;
            this.gameGridData.TabStop = false;
            // 
            // C1
            // 
            this.C1.DataPropertyName = "C1";
            this.C1.HeaderText = "C1";
            this.C1.Name = "C1";
            this.C1.ReadOnly = true;
            this.C1.Width = 5;
            // 
            // C2
            // 
            this.C2.DataPropertyName = "C2";
            this.C2.HeaderText = "C2";
            this.C2.Name = "C2";
            this.C2.ReadOnly = true;
            this.C2.Width = 5;
            // 
            // C3
            // 
            this.C3.DataPropertyName = "C3";
            this.C3.HeaderText = "C3";
            this.C3.Name = "C3";
            this.C3.ReadOnly = true;
            this.C3.Width = 5;
            // 
            // C4
            // 
            this.C4.DataPropertyName = "C4";
            this.C4.HeaderText = "C4";
            this.C4.Name = "C4";
            this.C4.ReadOnly = true;
            this.C4.Width = 5;
            // 
            // C5
            // 
            this.C5.DataPropertyName = "C5";
            this.C5.HeaderText = "C5";
            this.C5.Name = "C5";
            this.C5.ReadOnly = true;
            this.C5.Width = 5;
            // 
            // C6
            // 
            this.C6.DataPropertyName = "C6";
            this.C6.HeaderText = "C6";
            this.C6.Name = "C6";
            this.C6.ReadOnly = true;
            this.C6.Width = 5;
            // 
            // C7
            // 
            this.C7.DataPropertyName = "C7";
            this.C7.HeaderText = "C7";
            this.C7.Name = "C7";
            this.C7.ReadOnly = true;
            this.C7.Width = 5;
            // 
            // C8
            // 
            this.C8.DataPropertyName = "C8";
            this.C8.HeaderText = "C8";
            this.C8.Name = "C8";
            this.C8.ReadOnly = true;
            this.C8.Width = 5;
            // 
            // C9
            // 
            this.C9.DataPropertyName = "C9";
            this.C9.HeaderText = "C9";
            this.C9.Name = "C9";
            this.C9.ReadOnly = true;
            this.C9.Width = 5;
            // 
            // C10
            // 
            this.C10.DataPropertyName = "C10";
            this.C10.HeaderText = "C10";
            this.C10.Name = "C10";
            this.C10.ReadOnly = true;
            this.C10.Width = 5;
            // 
            // ExitGameButton
            // 
            this.ExitGameButton.Location = new System.Drawing.Point(547, 12);
            this.ExitGameButton.Name = "ExitGameButton";
            this.ExitGameButton.Size = new System.Drawing.Size(75, 23);
            this.ExitGameButton.TabIndex = 1;
            this.ExitGameButton.Text = "Exit";
            this.ExitGameButton.UseVisualStyleBackColor = true;
            this.ExitGameButton.Click += new System.EventHandler(this.ExitGameButton_Click);
            // 
            // GameGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.Controls.Add(this.ExitGameButton);
            this.Controls.Add(this.gameGridData);
            this.Name = "GameGrid";
            this.Text = "Snake Game";
            this.Load += new System.EventHandler(this.GameGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameGridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gameGridData;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3;
        private System.Windows.Forms.DataGridViewTextBoxColumn C4;
        private System.Windows.Forms.DataGridViewTextBoxColumn C5;
        private System.Windows.Forms.DataGridViewTextBoxColumn C6;
        private System.Windows.Forms.DataGridViewTextBoxColumn C7;
        private System.Windows.Forms.DataGridViewTextBoxColumn C8;
        private System.Windows.Forms.DataGridViewTextBoxColumn C9;
        private System.Windows.Forms.DataGridViewTextBoxColumn C10;
        private System.Windows.Forms.Button ExitGameButton;
    }
}