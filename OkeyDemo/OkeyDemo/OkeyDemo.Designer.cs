namespace OkeyDemo
{
    partial class OkeyDemo
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
         {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player1 = new System.Windows.Forms.Label();
            this.MixButton = new System.Windows.Forms.Button();
            this.Player2 = new System.Windows.Forms.Label();
            this.Player3 = new System.Windows.Forms.Label();
            this.Player4 = new System.Windows.Forms.Label();
            this.OkeyLabel = new System.Windows.Forms.Label();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(44, 30);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(42, 13);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "Player1";
            // 
            // MixButton
            // 
            this.MixButton.Location = new System.Drawing.Point(241, 314);
            this.MixButton.Name = "MixButton";
            this.MixButton.Size = new System.Drawing.Size(75, 23);
            this.MixButton.TabIndex = 1;
            this.MixButton.Text = "Dağıt";
            this.MixButton.UseVisualStyleBackColor = true;
            this.MixButton.Click += new System.EventHandler(this.MixButton_Click);
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(44, 64);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(42, 13);
            this.Player2.TabIndex = 2;
            this.Player2.Text = "Player2";
            // 
            // Player3
            // 
            this.Player3.AutoSize = true;
            this.Player3.Location = new System.Drawing.Point(44, 106);
            this.Player3.Name = "Player3";
            this.Player3.Size = new System.Drawing.Size(42, 13);
            this.Player3.TabIndex = 3;
            this.Player3.Text = "Player3";
            // 
            // Player4
            // 
            this.Player4.AutoSize = true;
            this.Player4.Location = new System.Drawing.Point(44, 145);
            this.Player4.Name = "Player4";
            this.Player4.Size = new System.Drawing.Size(42, 13);
            this.Player4.TabIndex = 4;
            this.Player4.Text = "Player4";
            // 
            // OkeyLabel
            // 
            this.OkeyLabel.AutoSize = true;
            this.OkeyLabel.Location = new System.Drawing.Point(228, 236);
            this.OkeyLabel.Name = "OkeyLabel";
            this.OkeyLabel.Size = new System.Drawing.Size(32, 13);
            this.OkeyLabel.TabIndex = 5;
            this.OkeyLabel.Text = "Okey";
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Location = new System.Drawing.Point(219, 275);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(41, 13);
            this.WinnerLabel.TabIndex = 6;
            this.WinnerLabel.Text = "Winner";
            // 
            // OkeyDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 345);
            this.Controls.Add(this.WinnerLabel);
            this.Controls.Add(this.OkeyLabel);
            this.Controls.Add(this.Player4);
            this.Controls.Add(this.Player3);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.MixButton);
            this.Controls.Add(this.Player1);
            this.Name = "OkeyDemo";
            this.Text = "Okey Demo";
            this.Load += new System.EventHandler(this.OkeyDemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Button MixButton;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label Player3;
        private System.Windows.Forms.Label Player4;
        private System.Windows.Forms.Label OkeyLabel;
        private System.Windows.Forms.Label WinnerLabel;
    }
}

