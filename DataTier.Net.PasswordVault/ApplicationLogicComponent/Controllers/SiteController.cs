

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class SiteController
    /// <summary>
    /// This class controls a(n) 'Site' object.
    /// </summary>
    public class SiteController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'SiteController' object.
        /// </summary>
        public SiteController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateSiteParameter
            /// <summary>
            /// This method creates the parameter for a 'Site' data operation.
            /// </summary>
            /// <param name='site'>The 'Site' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateSiteParameter(Site site)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = site;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Site tempSite)
            /// <summary>
            /// Deletes a 'Site' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Site_Delete'.
            /// </summary>
            /// <param name='site'>The 'Site' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Site tempSite)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteSite";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempsite exists before attemptintg to delete
                    if(tempSite != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteSiteMethod = this.AppController.DataBridge.DataOperations.SiteMethods.DeleteSite;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSiteParameter(tempSite);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteSiteMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Site tempSite)
            /// <summary>
            /// This method fetches a collection of 'Site' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Site_FetchAll'.</summary>
            /// <param name='tempSite'>A temporary Site for passing values.</param>
            /// <returns>A collection of 'Site' objects.</returns>
            public List<Site> FetchAll(Site tempSite)
            {
                // Initial value
                List<Site> siteList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.SiteMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSiteParameter(tempSite);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Site> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        siteList = (List<Site>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return siteList;
            }
            #endregion

            #region Find(Site tempSite)
            /// <summary>
            /// Finds a 'Site' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Site_Find'</param>
            /// </summary>
            /// <param name='tempSite'>A temporary Site for passing values.</param>
            /// <returns>A 'Site' object if found else a null 'Site'.</returns>
            public Site Find(Site tempSite)
            {
                // Initial values
                Site site = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempSite != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.SiteMethods.FindSite;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSiteParameter(tempSite);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Site != null))
                        {
                            // Get ReturnObject
                            site = (Site) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return site;
            }
            #endregion

            #region Insert(Site site)
            /// <summary>
            /// Insert a 'Site' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Site_Insert'.</param>
            /// </summary>
            /// <param name='site'>The 'Site' object to insert.</param>
            /// <returns>The id (int) of the new  'Site' object that was inserted.</returns>
            public int Insert(Site site)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Siteexists
                    if(site != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.SiteMethods.InsertSite;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSiteParameter(site);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Site site)
            /// <summary>
            /// Saves a 'Site' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='site'>The 'Site' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Site site)
            {
                // Initial value
                bool saved = false;

                // If the site exists.
                if(site != null)
                {
                    // Is this a new Site
                    if(site.IsNew)
                    {
                        // Insert new Site
                        int newIdentity = this.Insert(site);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            site.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Site
                        saved = this.Update(site);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Site site)
            /// <summary>
            /// This method Updates a 'Site' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Site_Update'.</param>
            /// </summary>
            /// <param name='site'>The 'Site' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Site site)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(site != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.SiteMethods.UpdateSite;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSiteParameter(site);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
