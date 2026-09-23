namespace Smiley
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Smiley = new System.Windows.Forms.PictureBox();
            this.OopsLabel = new System.Windows.Forms.Label();
            this.Desc = new System.Windows.Forms.Label();
            this.GiveFile = new System.Windows.Forms.Button();
            this.GiveUpButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.LockOutLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).BeginInit();
            this.SuspendLayout();
            // 
            // Smiley
            // 
            this.Smiley.Image = ((System.Drawing.Image)(resources.GetObject("Smiley.Image")));
            this.Smiley.Location = new System.Drawing.Point(12, 12);
            this.Smiley.Name = "Smiley";
            this.Smiley.Size = new System.Drawing.Size(187, 185);
            this.Smiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Smiley.TabIndex = 0;
            this.Smiley.TabStop = false;
            // 
            // OopsLabel
            // 
            this.OopsLabel.AutoSize = true;
            this.OopsLabel.BackColor = System.Drawing.Color.Black;
            this.OopsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OopsLabel.ForeColor = System.Drawing.Color.White;
            this.OopsLabel.Location = new System.Drawing.Point(206, 9);
            this.OopsLabel.Name = "OopsLabel";
            this.OopsLabel.Size = new System.Drawing.Size(118, 42);
            this.OopsLabel.TabIndex = 1;
            this.OopsLabel.Text = "Oops!";
            // 
            // Desc
            // 
            this.Desc.AutoSize = true;
            this.Desc.BackColor = System.Drawing.Color.Black;
            this.Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Desc.ForeColor = System.Drawing.Color.White;
            this.Desc.Location = new System.Drawing.Point(383, 9);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(405, 186);
            this.Desc.TabIndex = 2;
            this.Desc.Text = "You downloaded the TrollWare!\r\nYou are an fucking idiot\r\nNow i can delete youre s" +
    "ystem\r\nAnd now..\r\nGET OUT AND SAY GOODBYE\r\nTO YOURE SYSTEM!\r\n";
            this.Desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GiveFile
            // 
            this.GiveFile.BackColor = System.Drawing.Color.Black;
            this.GiveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GiveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveFile.ForeColor = System.Drawing.Color.White;
            this.GiveFile.Location = new System.Drawing.Point(12, 394);
            this.GiveFile.Name = "GiveFile";
            this.GiveFile.Size = new System.Drawing.Size(187, 44);
            this.GiveFile.TabIndex = 3;
            this.GiveFile.Text = "Give file";
            this.GiveFile.UseVisualStyleBackColor = false;
            this.GiveFile.Click += new System.EventHandler(this.GiveFileButton_Click);
            // 
            // GiveUpButton
            // 
            this.GiveUpButton.BackColor = System.Drawing.Color.Black;
            this.GiveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GiveUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveUpButton.ForeColor = System.Drawing.Color.White;
            this.GiveUpButton.Location = new System.Drawing.Point(12, 344);
            this.GiveUpButton.Name = "GiveUpButton";
            this.GiveUpButton.Size = new System.Drawing.Size(187, 44);
            this.GiveUpButton.TabIndex = 4;
            this.GiveUpButton.Text = "Give up";
            this.GiveUpButton.UseVisualStyleBackColor = false;
            this.GiveUpButton.Click += new System.EventHandler(this.GiveUpButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.BackColor = System.Drawing.Color.Black;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(676, 399);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(112, 42);
            this.TimerLabel.TabIndex = 5;
            this.TimerLabel.Text = "Timer";
            // 
            // LockOutLabel
            // 
            this.LockOutLabel.AutoSize = true;
            this.LockOutLabel.BackColor = System.Drawing.Color.Black;
            this.LockOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LockOutLabel.ForeColor = System.Drawing.Color.White;
            this.LockOutLabel.Location = new System.Drawing.Point(12, 200);
            this.LockOutLabel.Name = "LockOutLabel";
            this.LockOutLabel.Size = new System.Drawing.Size(199, 42);
            this.LockOutLabel.TabIndex = 6;
            this.LockOutLabel.Text = "LOCKOUT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.LockOutLabel);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.GiveUpButton);
            this.Controls.Add(this.GiveFile);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.OopsLabel);
            this.Controls.Add(this.Smiley);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Smiley";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Smiley;
        private System.Windows.Forms.Label OopsLabel;
        private System.Windows.Forms.Label Desc;
        private System.Windows.Forms.Button GiveFile;
        private System.Windows.Forms.Button GiveUpButton;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label LockOutLabel;
    }
}

