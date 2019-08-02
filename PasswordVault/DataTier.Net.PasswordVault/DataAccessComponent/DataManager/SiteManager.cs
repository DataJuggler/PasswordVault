

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class SiteManager
    /// <summary>
    /// This class is used to manage a 'Site' object.
    /// </summary>
    public class SiteManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SiteManager' object.
        /// </summary>
        public SiteManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteSite()
            /// <summary>
            /// This method deletes a 'Site' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteSite(DeleteSiteStoredProcedure deleteSiteProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteSiteProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllSites()
            /// <summary>
            /// This method fetches a  'List<Site>' object.
            /// This method uses the 'Sites_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Site>'</returns>
            /// </summary>
            public List<Site> FetchAllSites(FetchAllSitesStoredProcedure fetchAllSitesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Site> siteCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allSitesDataSet = this.DataHelper.LoadDataSet(fetchAllSitesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allSitesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allSitesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            siteCollection = SiteReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return siteCollection;
            }
            #endregion

            #region FindSite()
            /// <summary>
            /// This method finds a  'Site' object.
            /// This method uses the 'Site_Find' procedure.
            /// </summary>
            /// <returns>A 'Site' object.</returns>
            /// </summary>
            public Site FindSite(FindSiteStoredProcedure findSiteProc, DataConnector databaseConnector)
            {
                // Initial Value
                Site site = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet siteDataSet = this.DataHelper.LoadDataSet(findSiteProc, databaseConnector);

                    // Verify DataSet Exists
                    if(siteDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(siteDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Site
                            site = SiteReader.Load(row);
                        }
                    }
                }

                // return value
                return site;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertSite()
            /// <summary>
            /// This method inserts a 'Site' object.
            /// This method uses the 'Site_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertSite(InsertSiteStoredProcedure insertSiteProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertSiteProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateSite()
            /// <summary>
            /// This method updates a 'Site'.
            /// This method uses the 'Site_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateSite(UpdateSiteStoredProcedure updateSiteProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateSiteProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
