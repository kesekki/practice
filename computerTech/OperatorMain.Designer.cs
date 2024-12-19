namespace computerTech
{
    partial class OperatorMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewAllRequests = new System.Windows.Forms.DataGridView();
            this.buttonSort = new System.Windows.Forms.Button();
            this.textBoxSort = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxMaster = new System.Windows.Forms.ComboBox();
            this.buttonAddMaster = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Subheading", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Все заявки";
            // 
            // dataGridViewAllRequests
            // 
            this.dataGridViewAllRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllRequests.Location = new System.Drawing.Point(12, 71);
            this.dataGridViewAllRequests.Name = "dataGridViewAllRequests";
            this.dataGridViewAllRequests.Size = new System.Drawing.Size(437, 278);
            this.dataGridViewAllRequests.TabIndex = 3;
            this.dataGridViewAllRequests.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllRequests_CellEndEdit);
            this.dataGridViewAllRequests.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAllRequests_KeyDown);
            // 
            // buttonSort
            // 
            this.buttonSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.buttonSort.FlatAppearance.BorderSize = 0;
            this.buttonSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSort.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSort.Location = new System.Drawing.Point(161, 479);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(135, 38);
            this.buttonSort.TabIndex = 20;
            this.buttonSort.Text = "сортировать";
            this.buttonSort.UseVisualStyleBackColor = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // textBoxSort
            // 
            this.textBoxSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.textBoxSort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSort.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSort.Location = new System.Drawing.Point(12, 449);
            this.textBoxSort.Name = "textBoxSort";
            this.textBoxSort.Size = new System.Drawing.Size(437, 24);
            this.textBoxSort.TabIndex = 21;
            // 
            // textBoxCount
            // 
            this.textBoxCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(224)))), ((int)(((byte)(223)))));
            this.textBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCount.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.Location = new System.Drawing.Point(349, 44);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(100, 21);
            this.textBoxCount.TabIndex = 22;
            // 
            // comboBoxMaster
            // 
            this.comboBoxMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.comboBoxMaster.FormattingEnabled = true;
            this.comboBoxMaster.Location = new System.Drawing.Point(12, 526);
            this.comboBoxMaster.Name = "comboBoxMaster";
            this.comboBoxMaster.Size = new System.Drawing.Size(437, 21);
            this.comboBoxMaster.TabIndex = 23;
            // 
            // buttonAddMaster
            // 
            this.buttonAddMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.buttonAddMaster.FlatAppearance.BorderSize = 0;
            this.buttonAddMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddMaster.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddMaster.Location = new System.Drawing.Point(161, 553);
            this.buttonAddMaster.Name = "buttonAddMaster";
            this.buttonAddMaster.Size = new System.Drawing.Size(135, 38);
            this.buttonAddMaster.TabIndex = 24;
            this.buttonAddMaster.Text = "назначить";
            this.buttonAddMaster.UseVisualStyleBackColor = false;
            this.buttonAddMaster.Click += new System.EventHandler(this.buttonAddMaster_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.buttonBack.BackgroundImage = global::computerTech.Properties.Resources.icons8_назад_24;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(5, 5);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(23, 22);
            this.buttonBack.TabIndex = 25;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // OperatorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(224)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(461, 599);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddMaster);
            this.Controls.Add(this.comboBoxMaster);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxSort);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.dataGridViewAllRequests);
            this.Controls.Add(this.label1);
            this.Name = "OperatorMain";
            this.Text = "Все заявки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAllRequests;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.TextBox textBoxSort;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxMaster;
        private System.Windows.Forms.Button buttonAddMaster;
        private System.Windows.Forms.Button buttonBack;
    }
}