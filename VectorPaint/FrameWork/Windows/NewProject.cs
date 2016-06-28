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
using System.Windows.Forms;

namespace VectorPaint.FrameWork.Windows
{
    /// <summary>
    /// Popup window to ask dimensions for a new file/project
    /// </summary>
    public partial class NewProject : Form
    {
        #region Properties
        /// <summary>
        /// Keep track of parent window (main window), mostly to use its fancy cursors
        /// </summary>
        private frmMain parent { get; set; }
        /// <summary>
        /// To get width for new file/project
        /// </summary>
        public int width
        {
            get
            {
                return Convert.ToInt32(txtWidth.Text);
            }
            set
            {
                txtWidth.Text = value.ToString();
            }
        }
        /// <summary>
        /// To get height for new file/project
        /// </summary>
        public int height
        {
            get
            {
                return Convert.ToInt32(txtHeight.Text);
            }
            set
            {
                txtHeight.Text = value.ToString();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor. It gets main window to reference as parent
        /// </summary>
        /// <param name="_parent">main window reference</param>
        public NewProject(frmMain _parent)
        {
            // As ever...
            InitializeComponent();
            // Store parent
            parent = _parent;
            // Assign fancy cursors
            btCancel.Cursor = parent.cursorPointer;
            btOk.Cursor     = parent.cursorPointer;
        }

        /// <summary>
        /// Both textboxes for width and height only accept numbers
        /// Event handler to allow only numerical inputs
        /// </summary>
        /// <param name="sender">Control that receives event</param>
        /// <param name="e">Arguments for event</param>
        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar));
        }
        #endregion
    }
}
