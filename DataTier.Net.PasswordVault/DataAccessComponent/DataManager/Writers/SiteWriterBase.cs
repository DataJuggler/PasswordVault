

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class SiteWriterBase
    /// <summary>
    /// This class is used for converting a 'Site' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SiteWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Site site)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='site'>The 'Site' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Site site)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (site != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", site.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteSiteStoredProcedure(Site site)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteSite'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Site_Delete'.
            /// </summary>
            /// <param name="site">The 'Site' to Delete.</param>
            /// <returns>An instance of a 'DeleteSiteStoredProcedure' object.</returns>
            public static DeleteSiteStoredProcedure CreateDeleteSiteStoredProcedure(Site site)
            {
                // Initial Value
                DeleteSiteStoredProcedure deleteSiteStoredProcedure = new DeleteSiteStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteSiteStoredProcedure.Parameters = CreatePrimaryKeyParameter(site);

                // return value
                return deleteSiteStoredProcedure;
            }
            #endregion

            #region CreateFindSiteStoredProcedure(Site site)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindSiteStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Site_Find'.
            /// </summary>
            /// <param name="site">The 'Site' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindSiteStoredProcedure CreateFindSiteStoredProcedure(Site site)
            {
                // Initial Value
                FindSiteStoredProcedure findSiteStoredProcedure = null;

                // verify site exists
                if(site != null)
                {
                    // Instanciate findSiteStoredProcedure
                    findSiteStoredProcedure = new FindSiteStoredProcedure();

                    // Now create parameters for this procedure
                    findSiteStoredProcedure.Parameters = CreatePrimaryKeyParameter(site);
                }

                // return value
                return findSiteStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Site site)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new site.
            /// </summary>
            /// <param name="site">The 'Site' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Site site)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify siteexists
                if(site != null)
                {
                    // Create [Name] parameter
                    param = new SqlParameter("@Name", site.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Password] parameter
                    param = new SqlParameter("@Password", site.Password);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertSiteStoredProcedure(Site site)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertSiteStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Site_Insert'.
            /// </summary>
            /// <param name="site"The 'Site' object to insert</param>
            /// <returns>An instance of a 'InsertSiteStoredProcedure' object.</returns>
            public static InsertSiteStoredProcedure CreateInsertSiteStoredProcedure(Site site)
            {
                // Initial Value
                InsertSiteStoredProcedure insertSiteStoredProcedure = null;

                // verify site exists
                if(site != null)
                {
                    // Instanciate insertSiteStoredProcedure
                    insertSiteStoredProcedure = new InsertSiteStoredProcedure();

                    // Now create parameters for this procedure
                    insertSiteStoredProcedure.Parameters = CreateInsertParameters(site);
                }

                // return value
                return insertSiteStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Site site)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing site.
            /// </summary>
            /// <param name="site">The 'Site' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Site site)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify siteexists
                if(site != null)
                {
                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", site.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Password]
                    param = new SqlParameter("@Password", site.Password);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", site.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateSiteStoredProcedure(Site site)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateSiteStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Site_Update'.
            /// </summary>
            /// <param name="site"The 'Site' object to update</param>
            /// <returns>An instance of a 'UpdateSiteStoredProcedure</returns>
            public static UpdateSiteStoredProcedure CreateUpdateSiteStoredProcedure(Site site)
            {
                // Initial Value
                UpdateSiteStoredProcedure updateSiteStoredProcedure = null;

                // verify site exists
                if(site != null)
                {
                    // Instanciate updateSiteStoredProcedure
                    updateSiteStoredProcedure = new UpdateSiteStoredProcedure();

                    // Now create parameters for this procedure
                    updateSiteStoredProcedure.Parameters = CreateUpdateParameters(site);
                }

                // return value
                return updateSiteStoredProcedure;
            }
            #endregion

            #region CreateFetchAllSitesStoredProcedure(Site site)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllSitesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Site_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllSitesStoredProcedure' object.</returns>
            public static FetchAllSitesStoredProcedure CreateFetchAllSitesStoredProcedure(Site site)
            {
                // Initial value
                FetchAllSitesStoredProcedure fetchAllSitesStoredProcedure = new FetchAllSitesStoredProcedure();

                // return value
                return fetchAllSitesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
