

#region using statements


#endregion

namespace DataJuggler.Tutorials.PasswordVault.Controls
{

    #region class SiteEditControlBuilt
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class SiteEditControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Win.Controls.LabelTextBoxControl SiteControl;
        private Win.Controls.LabelTextBoxControl PasswordControl;
        private System.Windows.Forms.Timer CopiedTimer;
        private System.Windows.Forms.PictureBox CopiedImage;
        private System.Windows.Forms.PictureBox CopyButton;
        private System.Windows.Forms.ToolTip ToolTip;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.PasswordControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SiteControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.CopiedTimer = new System.Windows.Forms.Timer(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CopyButton = new System.Windows.Forms.PictureBox();
            this.CopiedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CopyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordControl
            // 
            this.PasswordControl.BackColor = System.Drawing.Color.Transparent;
            this.PasswordControl.BottomMargin = 0;
            this.PasswordControl.Editable = true;
            this.PasswordControl.Encrypted = false;
            this.PasswordControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordControl.LabelBottomMargin = 0;
            this.PasswordControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.PasswordControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.PasswordControl.LabelText = "Password:";
            this.PasswordControl.LabelTopMargin = 0;
            this.PasswordControl.LabelWidth = 120;
            this.PasswordControl.Location = new System.Drawing.Point(16, 54);
            this.PasswordControl.MultiLine = false;
            this.PasswordControl.Name = "PasswordControl";
            this.PasswordControl.OnTextChangedListener = null;
            this.PasswordControl.PasswordMode = true;
            this.PasswordControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordControl.Size = new System.Drawing.Size(348, 32);
            this.PasswordControl.TabIndex = 1;
            this.PasswordControl.TextBoxBottomMargin = 0;
            this.PasswordControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.PasswordControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.PasswordControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.PasswordControl.TextBoxTopMargin = 0;
            // 
            // SiteControl
            // 
            this.SiteControl.BackColor = System.Drawing.Color.Transparent;
            this.SiteControl.BottomMargin = 0;
            this.SiteControl.Editable = true;
            this.SiteControl.Encrypted = false;
            this.SiteControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiteControl.LabelBottomMargin = 0;
            this.SiteControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.SiteControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.SiteControl.LabelText = "Site:";
            this.SiteControl.LabelTopMargin = 0;
            this.SiteControl.LabelWidth = 120;
            this.SiteControl.Location = new System.Drawing.Point(16, 16);
            this.SiteControl.MultiLine = false;
            this.SiteControl.Name = "SiteControl";
            this.SiteControl.OnTextChangedListener = null;
            this.SiteControl.PasswordMode = false;
            this.SiteControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SiteControl.Size = new System.Drawing.Size(348, 32);
            this.SiteControl.TabIndex = 0;
            this.SiteControl.TextBoxBottomMargin = 0;
            this.SiteControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SiteControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.SiteControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.SiteControl.TextBoxTopMargin = 0;
            // 
            // CopiedTimer
            // 
            this.CopiedTimer.Interval = 4000;
            this.CopiedTimer.Tick += new System.EventHandler(this.CopiedTimer_Tick);
            // 
            // CopyButton
            // 
            this.CopyButton.BackgroundImage = global::DataJuggler.Tutorials.PasswordVault.Properties.Resources.Copy_Transparent_2;
            this.CopyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton.Location = new System.Drawing.Point(292, 92);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(72, 80);
            this.CopyButton.TabIndex = 4;
            this.CopyButton.TabStop = false;
            this.ToolTip.SetToolTip(this.CopyButton, "Copy Password");
            this.CopyButton.Visible = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            this.CopyButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CopyButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CopiedImage
            // 
            this.CopiedImage.BackgroundImage = global::DataJuggler.Tutorials.PasswordVault.Properties.Resources.Copied;
            this.CopiedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopiedImage.Location = new System.Drawing.Point(190, 110);
            this.CopiedImage.Name = "CopiedImage";
            this.CopiedImage.Size = new System.Drawing.Size(96, 54);
            this.CopiedImage.TabIndex = 3;
            this.CopiedImage.TabStop = false;
            this.CopiedImage.Visible = false;
            // 
            // SiteEditControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.CopiedImage);
            this.Controls.Add(this.PasswordControl);
            this.Controls.Add(this.SiteControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SiteEditControl";
            this.Size = new System.Drawing.Size(384, 231);
            ((System.ComponentModel.ISupportInitialize)(this.CopyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).EndInit();
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
