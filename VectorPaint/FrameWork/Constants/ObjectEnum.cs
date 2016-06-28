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
    /// Enum to define newly created objects
    /// Used mainly to decide which graphic element to paint, etc.
    /// </summary>
    public enum ObjectEnum
    {
        objLine      = 0,
        objRectangle = 1,
        objCircle    = 2,
        objUnknown   = 3
    }
}
