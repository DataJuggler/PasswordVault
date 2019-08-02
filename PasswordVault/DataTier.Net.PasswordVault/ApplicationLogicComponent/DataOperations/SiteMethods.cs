

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class SiteMethods
    /// <summary>
    /// This class contains methods for modifying a 'Site' object.
    /// </summary>
    public class SiteMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'SiteMethods' object.
        /// </summary>
        public SiteMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteSite(Site)
            /// <summary>
            /// This method deletes a 'Site' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Site' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteSite(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteSiteStoredProcedure deleteSiteProc = null;

                    // verify the first parameters is a(n) 'Site'.
                    if (parameters[0].ObjectValue as Site != null)
                    {
                        // Create Site
                        Site site = (Site) parameters[0].ObjectValue;

                        // verify site exists
                        if(site != null)
                        {
                            // Now create deleteSiteProc from SiteWriter
                            // The DataWriter converts the 'Site'
                            // to the SqlParameter[] array needed to delete a 'Site'.
                            deleteSiteProc = SiteWriter.CreateDeleteSiteStoredProcedure(site);
                        }
                    }

                    // Verify deleteSiteProc exists
                    if(deleteSiteProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.SiteManager.DeleteSite(deleteSiteProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Site' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Site' to delete.
            /// <returns>A PolymorphicObject object with all  'Sites' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Site> siteListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllSitesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SiteParameter
                    // Declare Parameter
                    Site paramSite = null;

                    // verify the first parameters is a(n) 'Site'.
                    if (parameters[0].ObjectValue as Site != null)
                    {
                        // Get SiteParameter
                        paramSite = (Site) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllSitesProc from SiteWriter
                    fetchAllProc = SiteWriter.CreateFetchAllSitesStoredProcedure(paramSite);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    siteListCollection = this.DataManager.SiteManager.FetchAllSites(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(siteListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = siteListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindSite(Site)
            /// <summary>
            /// This method finds a 'Site' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Site' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindSite(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Site site = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindSiteStoredProcedure findSiteProc = null;

                    // verify the first parameters is a 'Site'.
                    if (parameters[0].ObjectValue as Site != null)
                    {
                        // Get SiteParameter
                        Site paramSite = (Site) parameters[0].ObjectValue;

                        // verify paramSite exists
                        if(paramSite != null)
                        {
                            // Now create findSiteProc from SiteWriter
                            // The DataWriter converts the 'Site'
                            // to the SqlParameter[] array needed to find a 'Site'.
                            findSiteProc = SiteWriter.CreateFindSiteStoredProcedure(paramSite);
                        }

                        // Verify findSiteProc exists
                        if(findSiteProc != null)
                        {
                            // Execute Find Stored Procedure
                            site = this.DataManager.SiteManager.FindSite(findSiteProc, dataConnector);

                            // if dataObject exists
                            if(site != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = site;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertSite (Site)
            /// <summary>
            /// This method inserts a 'Site' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Site' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertSite(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Site site = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertSiteStoredProcedure insertSiteProc = null;

                    // verify the first parameters is a(n) 'Site'.
                    if (parameters[0].ObjectValue as Site != null)
                    {
                        // Create Site Parameter
                        site = (Site) parameters[0].ObjectValue;

                        // verify site exists
                        if(site != null)
                        {
                            // Now create insertSiteProc from SiteWriter
                            // The DataWriter converts the 'Site'
                            // to the SqlParameter[] array needed to insert a 'Site'.
                            insertSiteProc = SiteWriter.CreateInsertSiteStoredProcedure(site);
                        }

                        // Verify insertSiteProc exists
                        if(insertSiteProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.SiteManager.InsertSite(insertSiteProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateSite (Site)
            /// <summary>
            /// This method updates a 'Site' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Site' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateSite(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Site site = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateSiteStoredProcedure updateSiteProc = null;

                    // verify the first parameters is a(n) 'Site'.
                    if (parameters[0].ObjectValue as Site != null)
                    {
                        // Create Site Parameter
                        site = (Site) parameters[0].ObjectValue;

                        // verify site exists
                        if(site != null)
                        {
                            // Now create updateSiteProc from SiteWriter
                            // The DataWriter converts the 'Site'
                            // to the SqlParameter[] array needed to update a 'Site'.
                            updateSiteProc = SiteWriter.CreateUpdateSiteStoredProcedure(site);
                        }

                        // Verify updateSiteProc exists
                        if(updateSiteProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.SiteManager.UpdateSite(updateSiteProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
