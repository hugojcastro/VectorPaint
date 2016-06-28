/*
 * This file is part of VectorPaint.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 *
 * VectorPaint is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *
 */

using System;
using System.Reflection;
using System.Windows.Forms;

namespace VectorPaint.FrameWork.Windows
{
    /// <summary>
    /// Class to show a fancy about box window :)
    /// </summary>
    public partial class AboutBox : Form
    {
        #region Assembly descriptors for attribute access (I'll only use Title)
        /// <summary>
        /// Get Title from Assembly
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        /// <summary>
        /// Get Version from Assembly
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        /// Get Description from Assembly
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        /// <summary>
        /// Get Product Name from Assembly
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// Get Copyright from Assembly
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// Get Company from Assembly
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main constructor for About dialog
        /// </summary>
        public AboutBox()
        {
            // As ever...
            InitializeComponent();
            // Just put a simple message on titlebar
            this.Text = String.Format("About {0}...", AssemblyTitle);
            // Unused interesting strings :D
            // this.labelProductName.Text   = AssemblyProduct;
            // this.labelVersion.Text       = String.Format("Versión {0}", AssemblyVersion);
            // this.labelCopyright.Text     = AssemblyCopyright;
            // this.labelCompanyName.Text   = AssemblyCompany;
            // this.textBoxDescription.Text = AssemblyDescription;

            // Assign fancy cursor to Ok button
            var cursor = new Cursor(Properties.Resources.cursorPointer.GetHicon());
            buttonOk.Cursor         = cursor;
        }
        #endregion
    }
}
