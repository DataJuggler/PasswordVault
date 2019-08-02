

#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// The Gateway to the FlyingElephantWeb.
        /// </summary>
        public Gateway()
        {
            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods

            #region DeleteSite(int id, Site tempSite = null)
            /// <summary>
            /// This method is used to delete Site objects.
            /// </summary>
            /// <param name="id">Delete the Site with this id</param>
            /// <param name="tempSite">Pass in a tempSite to perform a custom delete.</param>
            public bool DeleteSite(int id, Site tempSite = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSite does not exist
                    if (tempSite == null)
                    {
                        // create a temp Site
                        tempSite = new Site();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSite.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.SiteController.Delete(tempSite);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
        #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
        /// <summary>
        /// This method Executes a Non Query StoredProcedure
        /// </summary>
        public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
        {
            // initial value
            PolymorphicObject returnValue = new PolymorphicObject();

            // locals
            List<PolymorphicObject> parameters = new List<PolymorphicObject>();

            // create the parameters
            PolymorphicObject procedureNameParameter = new PolymorphicObject();
            PolymorphicObject sqlParametersParameter = new PolymorphicObject();

            // if the procedureName exists
            if (!String.IsNullOrEmpty(procedureName))
            {
                // Create an instance of the SystemMethods object
                SystemMethods systemMethods = new SystemMethods();

                // setup procedureNameParameter
                procedureNameParameter.Name = "ProcedureName";
                procedureNameParameter.Text = procedureName;

                // setup sqlParametersParameter
                sqlParametersParameter.Name = "SqlParameters";
                sqlParametersParameter.ObjectValue = sqlParameters;

                // Add these parameters to the parameters
                parameters.Add(procedureNameParameter);
                parameters.Add(sqlParametersParameter);

                // get the dataConnector
                DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                // Execute the query
                returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
            }

            // return value
            return returnValue;
        }
        #endregion

            #region FindSite(int id, Site tempSite = null)
            /// <summary>
            /// This method is used to find 'Site' objects.
            /// </summary>
            /// <param name="id">Find the Site with this id</param>
            /// <param name="tempSite">Pass in a tempSite to perform a custom find.</param>
            public Site FindSite(int id, Site tempSite = null)
            {
                // initial value
                Site site = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSite does not exist
                    if (tempSite == null)
                    {
                        // create a temp Site
                        tempSite = new Site();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSite.UpdateIdentity(id);
                    }

                    // perform the find
                    site = this.AppController.ControllerManager.SiteController.Find(tempSite);
                }

                // return value
                return site;
            }
            #endregion

        #region GetDataConnector()
        /// <summary>
        /// This method (safely) returns the Data Connector from the
        /// AppController.DataBridget.DataManager.DataConnector
        /// </summary>
        private DataConnector GetDataConnector()
        {
            // initial value
            DataConnector dataConnector = null;

            // if the AppController exists
            if (this.AppController != null)
            {
                // return the DataConnector from the AppController
                dataConnector = this.AppController.GetDataConnector();
            }

            // return value
            return dataConnector;
        }
        #endregion

        #region GetLastException()
        /// <summary>
        /// This method returns the last Exception from the AppController if one exists.
        /// Always test for null before refeferencing the Exception returned as it will be null 
        /// if no errors were encountered.
        /// </summary>
        /// <returns></returns>
        public Exception GetLastException()
        {
            // initial value
            Exception exception = null;

            // If the AppController object exists
            if (this.HasAppController)
            {
                // return the Exception from the AppController
                exception = this.AppController.Exception;

                // Set to null after the exception is retrieved so it does not return again
                this.AppController.Exception = null;
            }

            // return value
            return exception;
        }
        #endregion

        #region Init()
        /// <summary>
        /// Perform Initializations for this object.
        /// </summary>
        private void Init()
        {
            // Create Application Controller
            this.AppController = new ApplicationController();
        }
        #endregion

            #region LoadSites(Site tempSite = null)
            /// <summary>
            /// This method loads a collection of 'Site' objects.
            /// </summary>
            public List<Site> LoadSites(Site tempSite = null)
            {
                // initial value
                List<Site> sites = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    sites = this.AppController.ControllerManager.SiteController.FetchAll(tempSite);
                }

                // return value
                return sites;
            }
            #endregion

            #region SaveSite(ref Site site)
            /// <summary>
            /// This method is used to save 'Site' objects.
            /// </summary>
            /// <param name="site">The Site to save.</param>
            public bool SaveSite(ref Site site)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.SiteController.Save(ref site);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

        #region AppController
        /// <summary>
        /// This property gets or sets the value for 'AppController'.
        /// </summary>
        public ApplicationController AppController
        {
            get { return appController; }
            set { appController = value; }
        }
        #endregion

        #region HasAppController
        /// <summary>
        /// This property returns true if this object has an 'AppController'.
        /// </summary>
        public bool HasAppController
        {
            get
            {
                // initial value
                bool hasAppController = (this.AppController != null);

                // return value
                return hasAppController;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}

