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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using VectorPaint.FrameWork.Constants;
using VectorPaint.FrameWork.Types;
using VectorPaint.FrameWork.Windows;

namespace VectorPaint
{
    /// <summary>
    /// Class for main window of our Vector Paint test tool
    /// </summary>
    public partial class frmMain : Form
    {
        #region Properties
        #region Dialog with child windows
        /// <summary>
        /// Stores palette tool window to track its use from us
        /// </summary>
        private Palette palette { get; set; } = null;
        #endregion

        #region Objects lists
        /// <summary>
        /// List to store painted objects
        /// </summary>
        private List<MemoryObject> objects { get; set; } = new List<MemoryObject>();
        /// <summary>
        /// List to store erased/undo-ed objects, to allow redo operation
        /// </summary>
        private List<MemoryObject> redo { get; set; } = new List<MemoryObject>();
        #endregion

        #region Canvas and painting stuff
        /// <summary>
        /// Keeps track of original size of project or loaded file
        /// </summary>
        public Size originalSize { get; set; } = new Size();
        /// <summary>
        /// Keeps track of zoom factor for image
        /// </summary>
        private double zoomLevel { get; set; } = 1.0;
        /// <summary>
        /// Keeps track of original loaded image, or an empty created one
        /// </summary>
        private Bitmap mainImage { get; set; } = null;
        #endregion

        #region Drawing objects properties
        /// <summary>
        /// Snap graphics to grid (when used)
        /// </summary>
        private bool snapToGrid { get; set; } = false;
        /// <summary>
        /// To manage mouse events and allow to paint/insert objects
        /// </summary>
        private bool isDrawing { get; set; } = false;
        /// <summary>
        /// Stores first point when painting/drawing objects
        /// </summary>
        private Point startPoint { get; set; }
        /// <summary>
        /// Stores last point when painting/drawing objects
        /// </summary>
        private Point endPoint { get; set; }
        #endregion

        #region Custom Cursors
        /// <summary>
        /// Fancy cursors to get used by our window and child windows
        /// Simple arrow cursor
        /// </summary>
        public Cursor cursorArrow { get; set; }
        /// <summary>
        /// A color picker cursor
        /// </summary>
        public Cursor cursorPicker { get; set; }
        /// <summary>
        /// A pointer cursor (hand with pointing finger)
        /// </summary>
        public Cursor cursorPointer { get; set; }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for main window
        /// </summary>
        public frmMain()
        {
            // Initialize UI
            InitializeComponent();
            // Load fancy cursors from resources
            cursorArrow   = new Cursor(Properties.Resources.cursorArrow.GetHicon());
            cursorPicker  = new Cursor(Properties.Resources.cursorDropper.GetHicon());
            cursorPointer = new Cursor(Properties.Resources.cursorPointer.GetHicon());
            // Assign pointer cursor to menu bar
            tsMain.Cursor = cursorPointer;
            // Store original dimensions
            originalSize    = new Size(Config.DefaultWidth, Config.DefaultHeight);
            tsslblDims.Text = originalSize.Width + "x" + originalSize.Height;
        }

        #region Canvas events
        /// <summary>
        /// User moving pointer over canvas
        /// </summary>
        /// <param name="sender">Control that fires event (it's supossed to be pbCanvas)</param>
        /// <param name="e">Arguments for event</param>
        private void pbCanvasMouseMove(object sender, MouseEventArgs e)
        {
            // Show the right coords according to zoom value
            var aPoint   = (snapToGrid) ? General.snapToGrid(e.Location) : e.Location;
            endPoint = new Point((int)(aPoint.X / zoomLevel), (int)(aPoint.Y / zoomLevel));
            tsslblCoords.Text = String.Format("X:{0,5} Y:{1,5}", endPoint.X, endPoint.Y);

            // Nothing to do if not painting/drawing
            if (palette == null) return;

            // If drawing on canvas...
            if (isDrawing)
            {
                // Just refresh canvas content, to show actual object drawing
                refreshCanvas();
            }
        }
        /// <summary>
        /// User pressing mouse button on canvas
        /// </summary>
        /// <param name="sender">Control that fires event (it's supossed to be pbCanvas)</param>
        /// <param name="e">Arguments for event</param>
        private void pbCanvasMouseDown(object sender, MouseEventArgs e)
        {
            // Nothing to do if not painting/drawing
            if (palette == null) return;
            // Only left button is considered
            if (e.Button != MouseButtons.Left) return;
            // There's an action from palette? (so we want to draw...)
            if (
                (palette.action == MainActions.actionCircle) || 
                (palette.action == MainActions.actionLine) ||
                (palette.action == MainActions.actionFilledCircle) ||
                (palette.action == MainActions.actionFilledRectangle) ||
                (palette.action == MainActions.actionRectangle)
                )
            {
                // Acknowledge it
                isDrawing = true;
                // Apply grid snapping and zoom factor to get real draw area coord and store origin point
                var aPoint = (snapToGrid) ? General.snapToGrid(e.Location) : e.Location;
                startPoint = new Point((int)(aPoint.X / zoomLevel), (int)(aPoint.Y / zoomLevel));
            }
        }
        /// <summary>
        /// User releasing mouse button on canvas
        /// </summary>
        /// <param name="sender">Control that fires event (it's supossed to be pbCanvas)</param>
        /// <param name="e">Arguments for event</param>
        private void pbCanvasMouseUp(object sender, MouseEventArgs e)
        {
            // Nothing to do if not painting/drawing
            if (palette == null) return;
            // Get the final point according to grid snapping and zoom value
            var aPoint = (snapToGrid) ? General.snapToGrid(e.Location) : e.Location;
            endPoint = new Point((int)(aPoint.X / zoomLevel), (int)(aPoint.Y / zoomLevel));
            // If painting/drawing, finish action and create the new object
            if (isDrawing)
            {
                // Take pen/brush properties
                var color = palette.selectedColor;
                var size  = palette.size;
                Point firstPoint, lastPoint;
                // Create object based on selection
                switch (palette.action)
                {
                    case MainActions.actionLine: // Drawing line
                        objects.Add(new MemoryObject(ObjectEnum.objLine, startPoint, endPoint, color, size));
                        redo.Clear();
                        break;
                    case MainActions.actionRectangle: // Drawing rectangle
                        firstPoint = new Point(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y));
                        lastPoint = new Point(Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y));

                        objects.Add(new MemoryObject(ObjectEnum.objRectangle, firstPoint, lastPoint, color, size));
                        redo.Clear();
                        break;
                    case MainActions.actionFilledRectangle: // Drawing filled rectangle
                        firstPoint = new Point(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y));
                        lastPoint  = new Point(Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y));

                        objects.Add(new MemoryObject(ObjectEnum.objRectangle, firstPoint, lastPoint, color, size, true));
                        redo.Clear();
                        break;
                    case MainActions.actionCircle: // Drawing circle
                        objects.Add(new MemoryObject(ObjectEnum.objCircle, startPoint, endPoint, color, size));
                        redo.Clear();
                        break;
                    case MainActions.actionFilledCircle: // Drawing filled circle
                        objects.Add(new MemoryObject(ObjectEnum.objCircle, startPoint, endPoint, color, size, true));
                        redo.Clear();
                        break;
                }
                // No more drawing
                isDrawing = false;
                // And show new object on canvas
                refreshCanvas();
            }
            // Not painting; check other features on mouseup (only on left click, of course, and only eyedropper feature atm.)
            else if ((e.Button == MouseButtons.Left) && (palette.action == MainActions.actionDropper))
            {
                // Put color in color picker if needed
                updateColorValue(new Point((int)(e.Location.X / zoomLevel), (int)(e.Location.Y / zoomLevel)));
            }
        }
        #endregion

        #region Zoom Methods
        /// <summary>
        /// Update canvas view after changes on zoom value
        /// </summary>
        private void zoomUpdate()
        {
            // Loaded / Created image? resize canvas
            if (mainImage != null)
            {
                // Show new value for zoom
                tsslblZoom.Text = String.Format("{0}%", (int)(zoomLevel * 100));
                // Take new size for image based on zoom value
                var height    = (int)(originalSize.Height * zoomLevel);
                var width     = (int)(originalSize.Width * zoomLevel);
                var newSize = new Size(width + Config.ResizeWidth, height + Config.ResizeHeight + tsMain.Height + ssStatus.Height);
                // Assign new max size for global window
                MaximumSize = newSize;
                Size        = newSize;
                // Same for picture box
                pbCanvas.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                pbCanvas.Size   = new Size(width, height);
            }
            else
            {
                // No image? Assign new max size for global window
                var newSize = new Size(Config.DefaultWidth, Config.DefaultHeight);
                MaximumSize = newSize;
                MinimumSize = newSize;
                Size        = newSize;
            }
        }
        /// <summary>
        /// User clicks Zoom In button in menu bar
        /// </summary>
        /// <param name="sender">Control that fires event (Zoom In button, I guess)</param>
        /// <param name="e">Event arguments</param>
        private void tsbZoomInClick(object sender, EventArgs e)
        {
            // Zoom value not max.?
            if (zoomLevel < Config.maxZoomValue)
            {
                // Increase it
                zoomLevel += Config.zoomStep;
                // And update window
                zoomUpdate();
            }
        }
        /// <summary>
        /// User clicks Zoom Out button in menu bar
        /// </summary>
        /// <param name="sender">Control that fires event (Zoom Out button, I guess)</param>
        /// <param name="e">Event arguments</param>
        private void tsbZoomOutClick(object sender, EventArgs e)
        {
            // Zoom value not min.?
            if (zoomLevel > Config.minZoomValue)
            {
                // Decrease it
                zoomLevel -= Config.zoomStep;
                // And update window
                zoomUpdate();
            }
        }
        #endregion

        #region General & common methods
        /// <summary>
        /// Update UI
        /// Show/hide palette tool window and enable/disable buttons from menu bar
        /// </summary>
        private void updateButtonStatus()
        {
            // No image? all disabled/hidden
            var enabled = (mainImage != null);
            // File actions
            tsbClose.Enabled = enabled;
            // Zoom and grid
            tsbZoomIn.Enabled  = enabled;
            tsbZoomOut.Enabled = enabled;
            tsbGrid.Enabled    = enabled;
            // Palette: hide + remove + nullify
            if (palette != null)
            {
                palette.Hide();
                palette.Close();
                palette.Dispose();
                palette = null;
            }
            // If needed, create and show palette tool window, and focus ourself after that
            if (enabled)
            {
                palette = new Palette(this);
                palette.Show();
                Focus();
            }
        }
        /// <summary>
        /// Steps to do when closing a projec/file
        /// Free resources, set default window size, update UI and set info texts
        /// </summary>
        private void closeProject()
        {
            // If there's image, just dispose it
            if (mainImage != null)
            {
                if (pbCanvas.Image != null)
                {
                    pbCanvas.Image.Dispose();
                    pbCanvas.Image = null;
                }
                mainImage.Dispose();
                mainImage = null;
            }
            // Free lists
            objects.Clear();
            redo.Clear();
            // Restore window to default size, including picturebox
            var defaultSize = new Size(Config.DefaultWidth, Config.DefaultHeight);
            // Assign new max size for global window
            Size        = defaultSize;
            MaximumSize = defaultSize;
            MinimumSize = defaultSize;
            // Reset pbCanvas
            pbCanvas.Size   = panelContainer.Size;
            pbCanvas.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            // Set default zoom value
            zoomLevel = 1.0;
            zoomUpdate();
            // Update UI
            updateButtonStatus();
            tsbUndo.Enabled = false;
            tsbRedo.Enabled = false;
            tsbSave.Enabled = false;
            // Set info texts
            tsslblZoom.Text   = String.Format("{0}%", (int)(zoomLevel * 100));
            tsslblDims.Text   = "";
            tsslblCoords.Text = "";
        }
        /// <summary>
        /// Refresh canvas content
        /// Updates undo/redo buttons and draws canvas according to created objects and grid setup
        /// </summary>
        private void refreshCanvas()
        {
            // No image? finish
            if (mainImage == null) return;
            // Update undo & redo buttons
            updateUndoRedo();
            tsbSave.Enabled = true;
            // Create new picture
            var bitmap = new Bitmap(mainImage);
            // Grid? paint it
            if (snapToGrid)
            {
                var col = 0;
                var lin = 0;
                while (lin < bitmap.Height)
                {
                    bitmap.SetPixel(col, lin, Color.Black);
                    col += Config.DefaultGrid;
                    if (col >= bitmap.Width)
                    {
                        col = 0;
                        lin += Config.DefaultGrid;
                    }
                }
            }
            // Let's draw objects if necessary
            using (var graphic = Graphics.FromImage(bitmap))
            {
                // First of all, all created objects (one by one)
                foreach (var obj in objects)
                {
                    // Config pen/brush setup
                    var pen   = new Pen(obj.color, obj.size);
                    var brush = new SolidBrush(obj.color);
                    // According to object type, draw it
                    switch (obj.type)
                    {
                        case ObjectEnum.objLine: // Draw line
                            graphic.DrawLine(pen, obj.start.X, obj.start.Y, obj.end.X, obj.end.Y);
                            break;
                        case ObjectEnum.objRectangle:
                            if (obj.filled)
                            {
                                graphic.FillRectangle(brush, obj.start.X, obj.start.Y, obj.end.X - obj.start.X, obj.end.Y - obj.start.Y);
                            }
                            else
                            {
                                graphic.DrawRectangle(pen, obj.start.X, obj.start.Y, obj.end.X - obj.start.X, obj.end.Y - obj.start.Y);
                            }
                            break;
                        case ObjectEnum.objCircle:
                            if (obj.filled)
                            {
                                graphic.FillEllipse(brush, obj.start.X, obj.start.Y, obj.end.X - obj.start.X, obj.end.Y - obj.start.Y);
                            }
                            else
                            {
                                graphic.DrawEllipse(pen, obj.start.X, obj.start.Y, obj.end.X - obj.start.X, obj.end.Y - obj.start.Y);
                            }
                            break;
                    }
                }
                // After created objects, check if painting a new one
                if (isDrawing)
                {
                    // Config pen/brush
                    var color = new Pen(palette.selectedColor, palette.size);
                    var brush = new SolidBrush(palette.selectedColor);
                    Point firstPoint, lastPoint;
                    // And draw object based on first/last points and object type
                    switch (palette.action)
                    {
                        case MainActions.actionLine: // Draw line
                            graphic.DrawLine(color, startPoint, endPoint);
                            break;
                        case MainActions.actionRectangle: // Draw rectangle
                            firstPoint = new Point(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y));
                            lastPoint = new Point(Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y));

                            graphic.DrawRectangle(color, firstPoint.X, firstPoint.Y, lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y);
                            break;
                        case MainActions.actionFilledRectangle: // Draw filled rectangle
                            firstPoint = new Point(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y));
                            lastPoint = new Point(Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y));

                            graphic.FillRectangle(brush, firstPoint.X, firstPoint.Y, lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y);
                            break;
                        case MainActions.actionCircle: // Draw circle
                            graphic.DrawEllipse(color, new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
                            break;
                        case MainActions.actionFilledCircle: // Draw filled circle
                            graphic.FillEllipse(brush, new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
                            break;
                    }
                }
            }
            // If there's a previous image, free it (just to be sure it's disposed)
            if (pbCanvas.Image != null)
            {
                pbCanvas.Image.Dispose();
            }
            // And load the new one
            pbCanvas.Image = bitmap;
        }
        /// <summary>
        /// Get color from pixel, when using eyedrop
        /// </summary>
        /// <param name="_point">Point to get color from</param>
        public void updateColorValue(Point _point)
        {
            // Take color from real image
            using (var bitmap = new Bitmap(pbCanvas.Image))
            {
                var color = bitmap.GetPixel(_point.X, _point.Y);
                palette.selectedColor = color;
            }
        }
        #endregion

        #region Main menu button actions
        /// <summary>
        /// Enable/Disable the use of grid to draw objects
        /// Using a grid means to snap cursor actions to the grid points
        /// Caution: using eyedrop and grid enabled can cause the capture of grid point colors
        /// </summary>
        /// <param name="sender">Control that fires the event</param>
        /// <param name="e">Event arguments</param>
        private void tsbGridClick(object sender, EventArgs e)
        {
            // Swap the use of Grid feature: If using grid...
            if (tsbGrid.Tag.ToString() == "off")
            {
                // Change button interface
                tsbGrid.Tag         = "on";
                tsbGrid.ToolTipText = "Enable Grid";
                tsbGrid.Image       = Image.FromHbitmap(Properties.Resources.icon_grid_on.GetHbitmap());
                // Disable snap to grid
                snapToGrid = false;
            }
            else
            // If not using grid...
            {
                // Change button interface
                tsbGrid.Tag         = "off";
                tsbGrid.ToolTipText = "Disable Grid";
                tsbGrid.Image       = Image.FromHbitmap(Properties.Resources.icon_grid_off.GetHbitmap());
                // And enable snap to grid
                snapToGrid = true;
            }
            // Refresh canvas content
            refreshCanvas();
        }
        /// <summary>
        /// Open button click
        /// Show dialog asking for picture and loads it as image if selected
        /// </summary>
        /// <param name="sender">Control that fires the event</param>
        /// <param name="e">Event arguments</param>
        private void tsbOpenClick(object sender, EventArgs e)
        {
            // Show dialog and check if something was selected
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                // Reset all
                closeProject();
                // Load image
                mainImage = new Bitmap(Image.FromFile(dlgOpen.FileName));
                // Store original dimensions
                originalSize = new Size(mainImage.Width, mainImage.Height);
                // Assign image to canvas
                pbCanvas.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                pbCanvas.Image = new Bitmap(mainImage);
                // Update UI
                zoomUpdate();
                updateButtonStatus();
                // Show info
                tsslblDims.Text = mainImage.Width + "x" + mainImage.Height;
            }
        }
        /// <summary>
        /// Create new picture when user clicks 'New' button
        /// Pop ups a window asking for dimensions of new picture and use them if selected
        /// </summary>
        /// <param name="sender">Control that fires the event</param>
        /// <param name="e">Event arguments</param>
        private void tsbNewClick(object sender, EventArgs e)
        {
            // Show popup window asking for size of new picture
            using (var newwindow = new NewProject(this))
            {
                // Assign default values
                newwindow.width  = Config.DefaultWidth;
                newwindow.height = Config.DefaultHeight;
                // Show dialog and ask for confirmation
                if (newwindow.ShowDialog() == DialogResult.OK)
                {
                    // Ok? close previous project
                    closeProject();
                    // Take new size
                    var w = newwindow.width;
                    var h = newwindow.height;
                    // Create picture and resize all
                    originalSize   = new Size(w, h);
                    mainImage      = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                    using (var graphic = Graphics.FromImage(mainImage))
                    {
                        graphic.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, w, h));
                    }
                    // Assign picture to canvas
                    pbCanvas.Image = new Bitmap(mainImage);
                    // Update UI
                    zoomUpdate();
                    updateButtonStatus();
                    // Show new size in info text
                    tsslblDims.Text = originalSize.Width + "x" + originalSize.Height;
                }
            }
        }
        /// <summary>
        /// User clicks on "close project" button
        /// Removes all and free resources
        /// </summary>
        /// <param name="sender">Control that fires the event</param>
        /// <param name="e">Event arguments</param>
        private void tsbCloseClick(object sender, EventArgs e)
        {
            // Call to "close project" common method
            closeProject();
        }
        /// <summary>
        /// User clicks exit button
        /// Closes project if necessary and exists program
        /// </summary>
        /// <param name="sender">Control that fires the event</param>
        /// <param name="e">Event arguments</param>
        private void tsbExitClick(object sender, EventArgs e)
        {
            // Call to "close project" common method
            closeProject();
            // Close program
            Close();
        }
        /// <summary>
        /// User clicks "About" button
        /// Just shows a simple and fancy about window :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event arguments</param>
        private void tsbAboutClick(object sender, EventArgs e)
        {
            // Create new window
            using (var about = new AboutBox())
            {
                // And show it as dialog ^^
                about.ShowDialog();
            }
        }
        /// <summary>
        /// User clicks save button
        /// Save actual picture/canvas and disable button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event arguments</param>
        private void tsbSaveClick(object sender, EventArgs e)
        {
            // Show dialog to save picture: user saves?
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                // save picture
                pbCanvas.Image.Save(dlgSave.FileName, ImageFormat.Png);
                // Disable button
                tsbSave.Enabled = false;
            }
        }
        #endregion

        #region Dialog with child windows
        /// <summary>
        /// Change canvas cursor according to action sent from palette tool window
        /// </summary>
        /// <param name="action"></param>
        public void receiveCanvasAction(MainActions action)
        {
            // Change cursor to pointer when adding new objects
            if (
                (action == MainActions.actionCircle) || (action == MainActions.actionFilledCircle) || (action == MainActions.actionLine) ||
                (action == MainActions.actionRectangle) || (action == MainActions.actionFilledRectangle)
                )
            {
                pbCanvas.Cursor = cursorPointer;
            }
            // Change cursor to color picker if picking colors
            else if (action == MainActions.actionDropper)
            {
                pbCanvas.Cursor = cursorPicker;
            }
            // Default cursor: arrow
            else
            {
                pbCanvas.Cursor = cursorArrow;
            }
        }
        #endregion

        #region Undo & Redo
        /// <summary>
        /// Update UI buttons for undo/redo
        /// </summary>
        private void updateUndoRedo()
        {
            // Undo button is enabled if there is any object in objects list
            tsbUndo.Enabled = (objects.Count > 0);
            // Redo button is enabled if there is any object in redo list
            tsbRedo.Enabled = (redo.Count > 0);
        }
        /// <summary>
        /// Actions to do when user clicks redo button
        /// Take last object from redo list and put it in objects list
        /// </summary>
        /// <param name="sender">Control that fires event (Redo button, I guess)</param>
        /// <param name="e">Event arguments</param>
        private void tsbRedoClick(object sender, EventArgs e)
        {
            // No redo list? finish
            if (redo.Count < 1) return;
            // Take last object from redo list
            var obj = redo[redo.Count - 1];
            // Remove from list and put it in objects list
            redo.Remove(obj);
            objects.Add(obj);
            // Refresh canvas content
            refreshCanvas();
        }
        /// <summary>
        /// Actions to do when user clicks undo button
        /// Take last object from object list and put it in redo list
        /// </summary>
        /// <param name="sender">Control that fires event (Undo button, I guess)</param>
        /// <param name="e">Event arguments</param>
        private void tsbUndoClick(object sender, EventArgs e)
        {
            // If no objects in list, finish
            if (objects.Count < 1) return;
            // Take last object from objects list
            var obj = objects[objects.Count - 1];
            // Remove it from objects list and put it in redo list
            objects.Remove(obj);
            redo.Add(obj);
            // Refresh canvas content
            refreshCanvas();
        }
        #endregion
        #endregion
    }
}
