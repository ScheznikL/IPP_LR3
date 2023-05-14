namespace IPP_LR3_Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.lbServerVoice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btRight
            // 
            this.btRight.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRight.Location = new System.Drawing.Point(168, 129);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(118, 51);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "Right";
            this.btRight.UseVisualStyleBackColor = false;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.BackColor = System.Drawing.Color.SandyBrown;
            this.btLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLeft.Location = new System.Drawing.Point(12, 129);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(118, 51);
            this.btLeft.TabIndex = 1;
            this.btLeft.Text = "Left";
            this.btLeft.UseVisualStyleBackColor = false;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // lbServerVoice
            // 
            this.lbServerVoice.AutoSize = true;
            this.lbServerVoice.Location = new System.Drawing.Point(12, 9);
            this.lbServerVoice.Name = "lbServerVoice";
            this.lbServerVoice.Size = new System.Drawing.Size(65, 13);
            this.lbServerVoice.TabIndex = 2;
            this.lbServerVoice.Text = "Server says:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(298, 208);
            this.Controls.Add(this.lbServerVoice);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btRight);
            this.Name = "ClientForm";
            this.Text = "LR3 Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Label lbServerVoice;
    }
}

