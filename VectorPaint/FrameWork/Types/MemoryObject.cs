/*
 * This file is part of VectorPaint.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 *
 * VectorPaint is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *
 */

using System.Drawing;

using VectorPaint.FrameWork.Constants;

namespace VectorPaint.FrameWork.Types
{
    /// <summary>
    /// Class to identify and keep data for memory object
    /// Memory objects are used to draw graphics on picture and create the "map".
    /// They are lines, rectangles and/or circles.
    /// They are also used to keep track of undo/redo actions over "map".
    /// </summary>
    public class MemoryObject
    {
        #region Properties
        /// <summary>
        /// Size of pen to draw object
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// Type of object
        /// </summary>
        public ObjectEnum type { get; set; }
        /// <summary>
        /// Start point for object
        /// Point for lines and rectangles, upper left corner for ellipses/circles
        /// </summary>
        public Point start { get; set; }
        /// <summary>
        /// End point for object
        /// Point for lines and rectangles, lower right corner for ellipses/circles
        /// </summary>
        public Point end { get; set; }
        /// <summary>
        /// Color to draw object
        /// </summary>
        public Color color { get; set; }
        /// <summary>
        /// If circle/rectangle is filled or not (with same color)
        /// </summary>
        public bool filled { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor to create a memory object
        /// </summary>
        /// <param name="_type">Type for object</param>
        /// <param name="_start">Start point (or upper left point for ellipses/circles)</param>
        /// <param name="_end">End point (or lower right point for ellipses/circles)</param>
        /// <param name="_color">Color to paint object</param>
        /// <param name="_size">Size of pen to paint object</param>
        /// <param name="_filled">Ellipse/Rectangle is filled or not</param>
        public MemoryObject(ObjectEnum _type, Point _start, Point _end, Color _color, int _size, bool _filled = false)
        {
            // Assign values to properties from constructor parameters.
            type   = _type;
            start  = _start;
            end    = _end;
            color  = _color;
            size   = _size;
            filled = _filled;
        }
        #endregion
    }
}
