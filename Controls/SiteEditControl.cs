

#region using statements

using DataJuggler.Tutorials.PasswordVault.Controls.Xml.Writers;
using XmlMirror.Runtime;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls.Objects;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Win.Controls.Enumerations;

#endregion

namespace DataJuggler.Tutorials.PasswordVault.Controls
{

    #region class SiteEditControl
    /// <summary>
    /// This control is used to create, edit and display sites.
    /// </summary>
    public partial class SiteEditControl : UserControl, ITextChanged
    {
        
        #region Private Variables
        private IListEditorHost parentListEditor;
        private Exception error;
        private string initialValues;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SiteEditControl' object.
        /// </summary>
        public SiteEditControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {  
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CopiedTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Copied Timer _ Tick
            /// </summary>
            private void CopiedTimer_Tick(object sender, EventArgs e)
            {
                // only run once
                CopiedTimer.Enabled = false;    

                // hide the CopiedImage
                CopiedImage.Visible = false;
            }
            #endregion
            
            #region CopyButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CopyButton' is clicked.
            /// </summary>
            private void CopyButton_Click(object sender, EventArgs e)
            {
                // if the PasswordControl.Text exists
                if (PasswordControl.HasText)
                {
                    // Copy to the Clipboard
                    Clipboard.SetText(PasswordControl.Text);

                    // Show the CopiedImage for five seconds
                    CopiedImage.Visible = true;

                    // Enable the CopiedTimer
                    CopiedTimer.Enabled = true;
                }
            }
            #endregion
            
            #region OnTextChanged(Control sender, string text)
            /// <summary>
            /// event is fired when On Text Changed
            /// </summary>
            public void OnTextChanged(Control sender, string text)
            {
                // set the textBox
                LabelTextBoxControl textBox = sender as LabelTextBoxControl;

                // if the value for HasSelectedSite is true
                if ((HasSelectedSite) && (NullHelper.Exists(textBox)))
                {
                    // if this the SiteControl
                    if (sender.Name == SiteControl.Name)
                    {   
                        // Set the Name
                        SelectedSite.Name = text;
                    }
                    else if (sender.Name == PasswordControl.Name)
                    {
                        // Set the Password
                        SelectedSite.Password = text;
                    }
                }

                // Call UIEnable
                UIEnable();
            }
            #endregion
            
        #endregion

        #region Methods

            #region Clear()
            /// <summary>
            /// This method Clear
            /// </summary>
            public void Clear()
            {
                // Erase both controls
                SiteControl.Text = "";
                PasswordControl.Text = "";
            }
            #endregion
           
            #region DisplaySelectedSite()
            /// <summary>
            /// This method Display Selected Site
            /// </summary>
            public void DisplaySelectedSite()
            {
                // initial value
                string name = "";
                string password = "";

                // if the value for HasSelectedItem is true (change to SelectedSite once references are added)
                if (HasSelectedSite)
                {
                    // set the values for name & password from the SelectedSite
                    name = SelectedSite.Name;
                    password = SelectedSite.Password;
                }

                // now display the values
                SiteControl.Text = name;
                PasswordControl.Text = password;
            }
            #endregion
            
            #region EnterEditMode(EditModeEnum editMode)
            /// <summary>
            /// method returns the Edit Mode
            /// </summary>
            public void EnterEditMode(EditModeEnum editMode)
            {
                // Enable controls
                UIEnable();

                // if Add
                if (editMode == EditModeEnum.Add)
                {
                    // Set Focus in the SiteControl for a new record
                    SiteControl.SetFocusToTextBox();
                }
                else if (editMode == EditModeEnum.Edit)
                {
                    // Set Focus to the PasswordControl for an edit.
                    PasswordControl.SetFocusToTextBox();
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set the DockStyle to Top
                Dock = DockStyle.Top;

                // Change the backcolor to transparent
                BackColor = Color.Transparent;

                // Setup the listeners
                SiteControl.OnTextChangedListener = this;
                PasswordControl.OnTextChangedListener = this;

                // Set the LabelColor
                SiteControl.LabelColor = Color.LemonChiffon;
                PasswordControl.LabelColor = Color.LemonChiffon;
            }
            #endregion
           
            #region StoreInitialValues()
            /// <summary>
            /// This method Store Initial Values
            /// </summary>
            public void StoreInitialValues()
            {
                // if the SelectedSite exists
                if (HasSelectedSite)
                {
                    // Create a new instance of a 'SitesWriter' object.
                    SitesWriter writer = new SitesWriter();
                        
                    // export the selected site
                    InitialValues = writer.ExportSite(this.SelectedSite);
                }
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // if HasSelectedSite
                if (HasSelectedSite)
                {
                    // Make Editable if not read only
                    SiteControl.Editable = EditMode != EditModeEnum.ReadOnly;
                    PasswordControl.Editable = EditMode != EditModeEnum.ReadOnly;

                    // If the Password exists for the SelectedSite
                    if (TextHelper.Exists(SelectedSite.Password))
                    {
                        // show the CopyButton if the Password is 8 characters or more
                        CopyButton.Visible = (SelectedSite.Password.Length >= 8);
                    }
                    else
                    {
                        // hide the CopyButton
                        CopyButton.Visible = false;
                    }

                    // if the value for HasParentListEditor is true
                    if (HasParentListEditor)
                    {
                        // this is a valid site if the Name and Password exists and the Password is at least 8 characters
                        bool isValid = (TextHelper.Exists(SelectedSite.Name, SelectedSite.Password) && (CopyButton.Visible));

                        // if the site is valid
                        if (isValid)
                        {
                            // should the save button be enabled
                            bool saveButtonEnabled = HasSiteChanged;

                            // Cannot save without a SelectedSite
                            ParentListEditor.EnableSaveButton(saveButtonEnabled);
                        }
                        else
                        {
                            // Cannot save an invalid site
                            ParentListEditor.EnableSaveButton(false);
                        }
                    }
                }
                else
                {
                    // Make Not Editable since read only
                    SiteControl.Editable = false;
                    PasswordControl.Editable = false;

                    // hide the CopyButton
                    CopyButton.Visible = false;
                    
                    // if the value for HasParentListEditor is true
                    if (HasParentListEditor)
                    {
                        // Cannot save without a SelectedSite
                        ParentListEditor.EnableSaveButton(false);
                    }
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region EditMode
            /// <summary>
            /// This property gets or sets the value for 'EditMode'.
            /// </summary>
            public EditModeEnum EditMode
            {
                get 
                { 
                    // initial value
                    EditModeEnum editMode = EditModeEnum.ReadOnly;

                    // if the value for HasParentListEditorHost is true
                    if (HasParentListEditor)
                    {
                        // set the return value
                        editMode = ParentListEditor.EditMode;
                    }

                    // return value
                    return editMode;
                }
            }
            #endregion
            
            #region Error
            /// <summary>
            /// This property gets or sets the value for 'Error'.
            /// </summary>
            public Exception Error
            {
                get { return error; }
                set { error = value; }
            }
            #endregion
            
            #region HasInitialValues
            /// <summary>
            /// This property returns true if the 'InitialValues' exists.
            /// </summary>
            public bool HasInitialValues
            {
                get
                {
                    // initial value
                    bool hasInitialValues = (!String.IsNullOrEmpty(this.InitialValues));
                    
                    // return value
                    return hasInitialValues;
                }
            }
            #endregion

            #region HasObjectChanged
            /// <summary>
            /// This read only property returns true if the InitialValues do not match
            /// the current values.
            /// </summary>
            public bool HasSiteChanged
            {
                get
                {
                    // initial value
                    bool hasSiteChanged = false;

                    // if we have both values
                    if ((HasInitialValues) && (HasSelectedSite))
                    {
                        // Create a new instance of a 'SitesWriter' object.
                        SitesWriter writer = new SitesWriter();

                        // get the currentValues
                        string currentValues = writer.ExportSite(SelectedSite);

                        // If the two strings are not equal, the site has changed
                        hasSiteChanged = !TextHelper.IsEqual(InitialValues, currentValues);
                    }

                    // return value
                    return hasSiteChanged;
                }
            }
            #endregion
            
            #region HasParentListEditor
            /// <summary>
            /// This property returns true if this object has a 'ParentListEditor'.
            /// </summary>
            public bool HasParentListEditor
            {
                get
                {
                    // initial value
                    bool hasParentListEditor = (this.ParentListEditor != null);
                    
                    // return value
                    return hasParentListEditor;
                }
            }
            #endregion
            
            #region HasSelectedSite
            /// <summary>
            /// This property returns true if this object has a 'SelectedSite'.
            /// </summary>
            public bool HasSelectedSite
            {
                get
                {
                    // initial value
                    bool hasSelectedSite = (this.SelectedSite != null);
                    
                    // return value
                    return hasSelectedSite;
                }
            }
            #endregion
            
            #region InitialValues
            /// <summary>
            /// This property gets or sets the value for 'InitialValues'.
            /// </summary>
            public string InitialValues
            {
                get { return initialValues; }
                set { initialValues = value; }
            }
            #endregion

            #region IsEditing
            /// <summary>
            /// If EditMode is not equal to ReadOnly
            /// </summary>
            public bool IsEditing
            {
                get
                {
                    // initial value
                    bool isEditing = (EditMode != EditModeEnum.ReadOnly);

                    // return value
                    return isEditing;
                }
            }
            #endregion
            
            #region ParentListEditor
            /// <summary>
            /// This property gets or sets the value for 'ParentListEditor'.
            /// </summary>
            public IListEditorHost ParentListEditor
            {
                get { return parentListEditor; }
                set { parentListEditor = value; }
            }
        #endregion

            #region SelectedSite
            /// <summary>
            /// This property gets or sets the value for 'SelectedSite'.
            /// </summary>
            public Site SelectedSite
            {
                get 
                { 
                    // initial value
                    Site selectredSite = null;

                    // if the value for HasParentListEditor is true
                    if (HasParentListEditor)
                    {
                        // set the site
                        selectredSite = ParentListEditor.SelectedItem as Site;
                    }

                    // return value
                    return selectredSite;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
