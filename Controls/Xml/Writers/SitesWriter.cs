

#region using statements

using ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;
using System.Text;

#endregion

namespace DataJuggler.Tutorials.PasswordVault.Controls.Xml.Writers
{

    #region class SitesWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Site' objects to xml.
    /// </summary>
    public class SitesWriter
    {

        #region Methods

            #region ExportList(List<Site> sites, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Site' objects to xml
            // </Summary>
            public string ExportList(List<Site> sites, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string sitesXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Site Node
                sb.Append("<Sites>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Site objects
                if ((sites != null) && (sites.Count > 0))
                {
                    // Iterate the sites collection
                    foreach (Site site  in sites)
                    {
                        // Get the xml for this sites
                        sitesXml = ExportSite(site, indent + 2);

                        // If the sitesXml string exists
                        if (TextHelper.Exists(sitesXml))
                        {
                            // Add this sites to the xml
                            sb.Append(sitesXml);
                        }
                    }
                }

                // Add the close SitesWriter Node
                sb.Append(indentString);
                sb.Append("</Sites>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportSite(Site site, int indent = 0)
            // <Summary>
            // This method is used to export a Site object to xml.
            // </Summary>
            public string ExportSite(Site site, int indent = 0)
            {
                // initial value
                string siteXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the site object exists
                if (NullHelper.Exists(site))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open site node
                    sb.Append("<Site>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Delete

                    sb.Append(indentString2);
                    sb.Append("<Delete>" + site.Delete + "</Delete>" + Environment.NewLine);

                    // Write out the value for Id

                    sb.Append(indentString2);
                    sb.Append("<Id>" + site.Id + "</Id>" + Environment.NewLine);

                    // Write out the value for IsNew

                    sb.Append(indentString2);
                    sb.Append("<IsNew>" + site.IsNew + "</IsNew>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + site.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for Password

                    sb.Append(indentString2);
                    sb.Append("<Password>" + site.Password + "</Password>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close site node
                    sb.Append("</Site>" + Environment.NewLine);

                    // set the return value
                    siteXml = sb.ToString();
                }
                // return value
                return siteXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
