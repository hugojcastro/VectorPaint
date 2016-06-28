/*
 * This file is part of VectorPaint.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 *
 * VectorPaint is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *
 */

namespace VectorPaint.FrameWork.Constants
{
    /// <summary>
    /// Configuration used in the app
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Offsets used to resize and avoid scrollbars: width
        /// </summary>
        public static int ResizeWidth { get; } = 16;
        /// <summary>
        /// Offsets used to resize and avoid scrollbars: height
        /// </summary>
        public static int ResizeHeight { get; } = 42;
        /// <summary>
        /// Default dimension when resetting windows: width
        /// </summary>
        public static int DefaultWidth { get; } = 500;
        /// <summary>
        /// Default dimension when resetting windows: height
        /// </summary>
        public static int DefaultHeight { get; } = 350;
        /// <summary>
        /// Step to increase / decrease zoom level
        /// </summary>
        public static double zoomStep { get; } = 0.25;
        /// <summary>
        /// Min. zoom value to show picture
        /// </summary>
        public static double minZoomValue { get; } = 0.25;
        /// <summary>
        /// Max. zoom value to show picture
        /// </summary>
        public static double maxZoomValue { get; } = 3.5;
        /// <summary>
        /// Default grid size
        /// </summary>
        public static int DefaultGrid { get; } = 5;
    }
}
