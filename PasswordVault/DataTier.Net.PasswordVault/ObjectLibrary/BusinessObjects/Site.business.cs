

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Site
    [Serializable]
    public partial class Site
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Site()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Site Clone()
            {
                // Create New Object
                Site newSite = (Site) this.MemberwiseClone();

                // Return Cloned Object
                return newSite;
            }
        #endregion

            #region ToString()
            /// <summary>
            /// This method returns the name of this Site when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the name of this Site
                return Name;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
