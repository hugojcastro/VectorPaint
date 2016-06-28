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
using System.Drawing;
using System.Windows.Forms;

using VectorPaint.FrameWork.Constants;

namespace VectorPaint.FrameWork.Windows
{
    /// <summary>
    /// Tool Window (palette) with painting controls
    /// It allows to choose objects to paint, color and pen size
    /// </summary>
    public partial class Palette : Form
    {
        #region Properties (mainly dialog with Parent Window)
        /// <summary>
        /// When user click on palette buttons, window "sends" actions to parent window
        /// "Send" an action is as simple as using a parent method to notify the action
        /// </summary>
        public MainActions action { get; set; } = MainActions.actionUnknown;
        /// <summary>
        /// Parent window (to send actions)
        /// Set at object creation
        /// </summary>
        public frmMain parent { get; set; } = null;
        /// <summary>
        /// Color used to paint objects
        /// </summary>
        public Color selectedColor
        {
            get
            {
                return btColor.BackColor;
            }
            set
            {
                btColor.BackColor = value;
            }
        }
        /// <summary>
        /// Size of pen to paint objects
        /// </summary>
        public int size
        {
            get
            {
                return (int)nudSize.Value;
            }
            set
            {
                var size = Math.Max(1, Math.Min(5, value));
                nudSize.Value = size;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for palette window
        /// </summary>
        /// <param name="_parent">Parent window to "send" actions</param>
        public Palette(frmMain _parent)
        {
            // Initialize UI
            InitializeComponent();
            // Assign parent
            parent = _parent;
            // Assign fancy pointer cursor to buttons
            Button[] btn = new[] { btCircle, btColor, btCursor, btDropper, btLine, btRectangle, btFilledCircle, btFilledRectangle };
            foreach (var button in btn)
            {
                button.Cursor = parent.cursorPointer;
            }
            // Position window
            Top  = parent.Top;
            Left = parent.Left - Width;
            // Set initial paint values
            action = MainActions.actionPointer;
            size = 1;
        }
        /// <summary>
        /// When clicking a button it "sends" to parent an action
        /// Action will tell parent what to do: paint an object (with type), etc.
        /// </summary>
        /// <param name="sender">Button object that receives the event</param>
        /// <param name="e">Arguments for event</param>
        private void toolButtonClick(object sender, EventArgs e)
        {
            // If button for color, just skip (no action send)
            if (sender == btColor) return;
            // Get button and define default action (pointer selection)
            var item      = sender as Button;
            var newAction = MainActions.actionPointer;
            // Actions are stored in "tags" as integers; we "send" to parent its enum version
            if (item.Tag.ToString() != "")
            {
                newAction = (MainActions)Convert.ToInt16(item.Tag.ToString());
            }
            // "Send" action to parent
            parent.receiveCanvasAction(newAction);
            // Store actual selected action
            action = newAction;
        }
        /// <summary>
        /// Event when clicking on color button
        /// Just show color selector and assign new color if necessary
        /// </summary>
        /// <param name="sender">Object that receives event</param>
        /// <param name="e">Arguments for event</param>
        private void btColorClick(object sender, EventArgs e)
        {
            // If color dialog returned a value
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                // Take it as selected color
                selectedColor = dlgColor.Color;
            }
        }
        #endregion
    }
}
