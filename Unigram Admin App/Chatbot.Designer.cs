namespace Unigram_Admin_App
{
    partial class Chatbot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chatbot));
            this.SendBtn = new System.Windows.Forms.PictureBox();
            this.MainLogo = new System.Windows.Forms.PictureBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.OutputBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SendBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.White;
            this.SendBtn.Image = ((System.Drawing.Image)(resources.GetObject("SendBtn.Image")));
            this.SendBtn.Location = new System.Drawing.Point(420, 646);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(69, 27);
            this.SendBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SendBtn.TabIndex = 7;
            this.SendBtn.TabStop = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // MainLogo
            // 
            this.MainLogo.BackColor = System.Drawing.Color.White;
            this.MainLogo.Image = ((System.Drawing.Image)(resources.GetObject("MainLogo.Image")));
            this.MainLogo.Location = new System.Drawing.Point(148, 39);
            this.MainLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainLogo.Name = "MainLogo";
            this.MainLogo.Size = new System.Drawing.Size(205, 166);
            this.MainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainLogo.TabIndex = 4;
            this.MainLogo.TabStop = false;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(456, 0);
            this.gunaControlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(48, 47);
            this.gunaControlBox1.TabIndex = 17;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(400, 0);
            this.gunaControlBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(48, 47);
            this.gunaControlBox2.TabIndex = 18;
            // 
            // OutputBox
            // 
            this.OutputBox.Animated = true;
            this.OutputBox.BackColor = System.Drawing.Color.White;
            this.OutputBox.BorderColor = System.Drawing.Color.Blue;
            this.OutputBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OutputBox.DefaultText = "\r\n                                   Chào bạn!\r\n                     Tôi có thể g" +
    "iúp gì cho bạn?\r\n\r\n";
            this.OutputBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OutputBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OutputBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OutputBox.DisabledState.Parent = this.OutputBox;
            this.OutputBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OutputBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.OutputBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OutputBox.FocusedState.Parent = this.OutputBox;
            this.OutputBox.Font = new System.Drawing.Font("Arial", 11.25F);
            this.OutputBox.ForeColor = System.Drawing.Color.Black;
            this.OutputBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OutputBox.HoverState.Parent = this.OutputBox;
            this.OutputBox.Location = new System.Drawing.Point(12, 208);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.PasswordChar = '\0';
            this.OutputBox.PlaceholderText = "";
            this.OutputBox.SelectedText = "";
            this.OutputBox.ShadowDecoration.Parent = this.OutputBox;
            this.OutputBox.Size = new System.Drawing.Size(480, 436);
            this.OutputBox.TabIndex = 72;
            // 
            // InputBox
            // 
            this.InputBox.BackColor = System.Drawing.Color.White;
            this.InputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(12, 644);
            this.InputBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(479, 30);
            this.InputBox.TabIndex = 73;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // Chatbot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 709);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.gunaControlBox2);
            this.Controls.Add(this.gunaControlBox1);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.MainLogo);
            this.Controls.Add(this.InputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Chatbot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chatbot";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SendBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox SendBtn;
        private System.Windows.Forms.PictureBox MainLogo;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI2.WinForms.Guna2TextBox OutputBox;
        private System.Windows.Forms.TextBox InputBox;
    }
}