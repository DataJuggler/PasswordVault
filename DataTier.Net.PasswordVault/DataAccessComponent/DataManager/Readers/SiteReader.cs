

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SiteReader
    /// <summary>
    /// This class loads a single 'Site' object or a list of type <Site>.
    /// </summary>
    public class SiteReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Site' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Site' DataObject.</returns>
            public static Site Load(DataRow dataRow)
            {
                // Initial Value
                Site site = new Site();

                // Create field Integers
                int idfield = 0;
                int namefield = 1;
                int passwordfield = 2;

                try
                {
                    // Load Each field
                    site.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    site.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    site.Password = DataHelper.ParseString(dataRow.ItemArray[passwordfield]);
                }
                catch
                {
                }

                // return value
                return site;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Site' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Site Collection.</returns>
            public static List<Site> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Site> sites = new List<Site>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Site' from rows
                        Site site = Load(row);

                        // Add this object to collection
                        sites.Add(site);
                    }
                }
                catch
                {
                }

                // return value
                return sites;
            }
            #endregion

        #endregion

    }
    #endregion

}
