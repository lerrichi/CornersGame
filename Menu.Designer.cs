
namespace Corners
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Rules = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.button_Records = new System.Windows.Forms.Button();
            this.button_GameStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Rules);
            this.groupBox1.Controls.Add(this.button_Settings);
            this.groupBox1.Controls.Add(this.button_Records);
            this.groupBox1.Controls.Add(this.button_GameStart);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(872, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уголки";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(659, 225);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(178, 52);
            this.button_Exit.TabIndex = 5;
            this.button_Exit.Text = "Выход";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Rules
            // 
            this.button_Rules.Location = new System.Drawing.Point(459, 225);
            this.button_Rules.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Rules.Name = "button_Rules";
            this.button_Rules.Size = new System.Drawing.Size(178, 52);
            this.button_Rules.TabIndex = 4;
            this.button_Rules.Text = "Правила";
            this.button_Rules.UseVisualStyleBackColor = true;
            this.button_Rules.Click += new System.EventHandler(this.button_Rules_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Location = new System.Drawing.Point(459, 164);
            this.button_Settings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(378, 52);
            this.button_Settings.TabIndex = 3;
            this.button_Settings.Text = "Настройки";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // button_Records
            // 
            this.button_Records.Location = new System.Drawing.Point(459, 100);
            this.button_Records.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Records.Name = "button_Records";
            this.button_Records.Size = new System.Drawing.Size(378, 52);
            this.button_Records.TabIndex = 2;
            this.button_Records.Text = "Таблица рекордов";
            this.button_Records.UseVisualStyleBackColor = true;
            this.button_Records.Click += new System.EventHandler(this.button_Records_Click);
            // 
            // button_GameStart
            // 
            this.button_GameStart.Location = new System.Drawing.Point(459, 33);
            this.button_GameStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_GameStart.Name = "button_GameStart";
            this.button_GameStart.Size = new System.Drawing.Size(378, 52);
            this.button_GameStart.TabIndex = 1;
            this.button_GameStart.Text = "Играть";
            this.button_GameStart.UseVisualStyleBackColor = true;
            this.button_GameStart.Click += new System.EventHandler(this.button_GameStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 322);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Felix Titling", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Rules;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.Button button_Records;
        private System.Windows.Forms.Button button_GameStart;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}