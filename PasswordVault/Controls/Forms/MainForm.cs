

#region using statements

using DataGateway;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Tutorials.PasswordVault.Controls;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Win.Controls.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Tutorials.PasswordVault.Forms
{

    #region class MainForm
    /// <summary>
    /// This form is the main form for this application.
    /// </summary>
    public partial class MainForm : Form, IListEditorHost
    {
        
        #region Private Variables
        private object selectedItem;
        private SiteEditControl siteEditControl;
        private bool setupComplete;
        private EditModeEnum editMode;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region MainForm_Activated(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Main Form _ Activated
            /// </summary>
            private void MainForm_Activated(object sender, EventArgs e)
            {
                // If not Setup yet
                if (!SetupComplete)
                {
                    // Enable the controls
                    ListEditorControl.UIEnable();

                    // create a siteEdit control
                    SiteEditControl = new SiteEditControl();

                    // Set the ParentListEditor
                    SiteEditControl.ParentListEditor = this;

                    // Start the app
                    ListEditorControl.Start(SiteEditControl, this);
                }

                // Set Setup Complete to true
                SetupComplete = true;
            }
            #endregion
            
        #endregion

        #region Methods

            #region Add()
            /// <summary>
            /// method Add
            /// </summary>
            public void Add()
            {
                // if the SiteEditControl exists
                if (HasSiteEditControl)
                {
                    // Set EditMode to Add
                    EditMode = EditModeEnum.Add;

                    // Create a new site
                    Site site = new Site();

                    // set the SelectedItem
                    SelectedItem = site;

                    // Store the InitialValues
                    SiteEditControl.StoreInitialValues();
                    
                    // Display the SelectedSite
                    SiteEditControl.DisplaySelectedSite();

                    // Set the Site
                    ListEditorControl.SetSelectedItemLabelText("Add New Site");

                    // Enable controls
                    ListEditorControl.UIEnable();

                    // Set the site to be enabled
                    SiteEditControl.EnterEditMode(EditModeEnum.Add);
                }
            }
            #endregion
            
            #region Cancel()
            /// <summary>
            /// method Cancel
            /// </summary>
            public void Cancel()
            {
                // if this was an Add
                if (EditMode == EditModeEnum.Add)
                {
                    // erase the SelectedItem
                    SelectedItem = null;    
                }
                else
                {
                    // Reselect the SelectedItem
                    ListEditorControl.LoadAndDisplayList(SelectedItem);    
                }

                // No longer editing
                EditMode = EditModeEnum.ReadOnly;

                // Disable editing on both controls                
                SiteEditControl.UIEnable();
            }
            #endregion

            #region Clear()
            /// <summary>
            /// method clears the selected site
            /// </summary>
            public void Clear()
            {
                // if the value for HasSiteEditControl is true
                if (HasSiteEditControl)
                {
                    // Clear the SiteEditControl
                    SiteEditControl.Clear();
                }
            }
            #endregion
            
            #region Delete()
            /// <summary>
            /// method Delete
            /// </summary>
            public void Delete()
            {
                
            }
            #endregion

            #region Edit()
            /// <summary>
            /// method Edit
            /// </summary>
            public void Edit()
            {
                // if the SiteEditControl exists
                if ((HasSiteEditControl) && (SiteEditControl.HasSelectedSite))
                {
                    // Set EditMode to Add
                    EditMode = EditModeEnum.Edit;

                    // Change the text
                    ListEditorControl.SetSelectedItemLabelText("Edit Site");

                    // Enable controls
                    ListEditorControl.UIEnable();

                    // Set the SelectedSite on the SiteEditorControl
                    SiteEditControl.StoreInitialValues();

                    // Display the SelectedSite
                    SiteEditControl.DisplaySelectedSite();

                    // Set the site to be enabled
                    SiteEditControl.EnterEditMode(EditModeEnum.Edit);
                }
            }
            #endregion
            
            #region EnableSaveButton(bool enabled)
            /// <summary>
            /// method returns the Save Button
            /// </summary>
            public void EnableSaveButton(bool enabled)
            {
                // Enable or disable the SaveButton
                ListEditorControl.SaveControl.EnableSaveButton = enabled;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set the text for the All Items label
                ListEditorControl.SetAllItemsLabelText("All Sites");
            }
            #endregion
            
            #region ItemSelected(object selectedItem)
            /// <summary>
            /// An item was selected in the ListBox
            /// </summary>
            public void ItemSelected(object selectedItem)
            {
                // Store the arg
                SelectedItem = selectedItem;

                // if the EditControl
                if (HasSiteEditControl)
                {
                    // We are not editing when an item is selected (need to make sure ListBox is disabled)
                    EditMode = EditModeEnum.ReadOnly;

                    // Display the SelectedSite
                    SiteEditControl.DisplaySelectedSite();
                }

                // Change the text
                ListEditorControl.SetSelectedItemLabelText("Selected Site");
            }
            #endregion
            
            #region LoadList()
            /// <summary>
            /// method Load List
            /// </summary>
            public List<object> LoadList()
            {
                // initial value
                List<object> sites = null;

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway();

                // Load all the sites
                List<Site> sitesList = gateway.LoadSites();

                // if the sitesList exists
                if (ListHelper.HasOneOrMoreItems(sitesList))
                {
                    // set the return value
                    sites = sitesList.Cast<object>().ToList();
                }

                // return value
                return sites;
            }
            #endregion
            
            #region Save()
            /// <summary>
            /// method returns the
            /// </summary>
            public bool Save()
            {
                // initial value
                bool saved = false;

                // if the value for HasSelectedSite is true
                if (HasSelectedSite)
                {
                    // get a local copy
                    Site site = SelectedSite;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // save this site
                    saved = gateway.SaveSite(ref site);

                    // if saved
                    if (saved)
                    {
                        // Change the EditMode back to Read Only
                        EditMode = EditModeEnum.ReadOnly;

                        // Set the SelectedSite
                        this.SelectedItem = site;

                        // return to read only mode
                        SiteEditControl.UIEnable();
                    }
                }

                // return value
                return saved;
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
                get { return editMode; }
                set { editMode = value; }
            }
            #endregion
            
            #region HasSelectedItem
            /// <summary>
            /// This property returns true if this object has a 'SelectedItem'.
            /// </summary>
            public bool HasSelectedItem
            {
                get
                {
                    // initial value
                    bool hasSelectedItem = (this.SelectedItem != null);
                    
                    // return value
                    return hasSelectedItem;
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
            
            #region HasSiteEditControl
            /// <summary>
            /// This property returns true if this object has a 'SiteEditControl'.
            /// </summary>
            public bool HasSiteEditControl
            {
                get
                {
                    // initial value
                    bool hasSiteEditControl = (this.SiteEditControl != null);
                    
                    // return value
                    return hasSiteEditControl;
                }
            }
            #endregion

            #region IsEditing
            /// <summary>
            /// This read only property returns true if EditMode is not equal to Read Only
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
            
            #region SelectedItem
            /// <summary>
            /// This property gets or sets the value for 'SelectedItem'.
            /// </summary>
            public object SelectedItem
            {
                get { return selectedItem; }
                set { selectedItem = value; }
            }
            #endregion

            #region SelectedSite
            /// <summary>
            /// This read only property returns the SelctedItem cast as a Site.
            /// </summary>
            public Site SelectedSite
            {
                get 
                { 
                    // initial value
                    Site site = SelectedItem as Site;

                    // return the site if it exists
                    return site;
                }
            }
        #endregion

            #region SetupComplete
            /// <summary>
            /// This property gets or sets the value for 'SetupComplete'.
            /// </summary>
            public bool SetupComplete
            {
                get { return setupComplete; }
                set { setupComplete = value; }
            }
            #endregion
            
            #region SiteEditControl
            /// <summary>
            /// This property gets or sets the value for 'SiteEditControl'.
            /// </summary>
            public SiteEditControl SiteEditControl
            {
                get { return siteEditControl; }
                set { siteEditControl = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
