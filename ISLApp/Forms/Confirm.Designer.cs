namespace ISLApp
{
    partial class Confirm
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
            if(disposing && (components != null)) {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmDeleteButton = new System.Windows.Forms.Button();
            this.declineDeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lulo Clean Outline", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proceed?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "You\'re about to perform";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "an irreversible action.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Do you wish to proceed?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(456, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "________________________________________________________";
            // 
            // confirmDeleteButton
            // 
            this.confirmDeleteButton.BackColor = System.Drawing.Color.White;
            this.confirmDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmDeleteButton.ForeColor = System.Drawing.Color.Black;
            this.confirmDeleteButton.Location = new System.Drawing.Point(255, 199);
            this.confirmDeleteButton.Name = "confirmDeleteButton";
            this.confirmDeleteButton.Size = new System.Drawing.Size(162, 23);
            this.confirmDeleteButton.TabIndex = 5;
            this.confirmDeleteButton.Text = "Yes";
            this.confirmDeleteButton.UseVisualStyleBackColor = false;
            this.confirmDeleteButton.Click += new System.EventHandler(this.confirmDeleteButton_Click);
            // 
            // declineDeleteButton
            // 
            this.declineDeleteButton.BackColor = System.Drawing.Color.White;
            this.declineDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.declineDeleteButton.ForeColor = System.Drawing.Color.Black;
            this.declineDeleteButton.Location = new System.Drawing.Point(35, 199);
            this.declineDeleteButton.Name = "declineDeleteButton";
            this.declineDeleteButton.Size = new System.Drawing.Size(162, 23);
            this.declineDeleteButton.TabIndex = 5;
            this.declineDeleteButton.Text = "No";
            this.declineDeleteButton.UseVisualStyleBackColor = false;
            this.declineDeleteButton.Click += new System.EventHandler(this.declineDeleteButton_Click);
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(449, 236);
            this.Controls.Add(this.declineDeleteButton);
            this.Controls.Add(this.confirmDeleteButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lulo Clean Outline", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.Name = "Confirm";
            this.Text = "Confirm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button confirmDeleteButton;
        private System.Windows.Forms.Button declineDeleteButton;
    }
}