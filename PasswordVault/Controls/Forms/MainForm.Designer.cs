

#region using statements


#endregion

namespace DataJuggler.Tutorials.PasswordVault.Forms
{

    #region class MainForm
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ListEditorControl = new DataJuggler.Win.Controls.ListEditorControl();
            this.SuspendLayout();
            // 
            // ListEditorControl
            // 
            this.ListEditorControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ListEditorControl.BackgroundImage")));
            this.ListEditorControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ListEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListEditorControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListEditorControl.List = null;
            this.ListEditorControl.Location = new System.Drawing.Point(0, 0);
            this.ListEditorControl.Name = "ListEditorControl";
            this.ListEditorControl.ParentListEditorHost = null;
            this.ListEditorControl.SaveControl = null;
            this.ListEditorControl.Size = new System.Drawing.Size(720, 480);
            this.ListEditorControl.Sorted = true;
            this.ListEditorControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.Controls.Add(this.ListEditorControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Vault";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.ListEditorControl ListEditorControl;
    }
    #endregion

}
