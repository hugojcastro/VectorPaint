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

using VectorPaint.FrameWork.Constants;

namespace VectorPaint.FrameWork.Types
{
    /// <summary>
    /// Class used to keep general function/methods
    /// </summary>
    public static class General
    {
        /// <summary>
        /// Snap to the nearest grid point
        /// From given point, returns "snapped" point to grid
        /// </summary>
        /// <param name="point">Real point from canvas</param>
        /// <returns>Nearest grid point for canvas</returns>
        public static Point snapToGrid(Point point)
        {
            // Calculate each coordinate
            var x = Config.DefaultGrid * (int)Math.Round((double)(point.X / Config.DefaultGrid));
            var y = Config.DefaultGrid * (int)Math.Round((double)(point.Y / Config.DefaultGrid));
            // And return a point with these coordinates
            return new Point(x, y);
        }
    }
}
