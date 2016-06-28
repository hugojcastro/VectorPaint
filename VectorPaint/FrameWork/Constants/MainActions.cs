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
    /// Enum to interoperate main window and child windows
    /// Identifies which action to do, cursor to show, etc.
    /// </summary>
    public enum MainActions
    {
        actionUnknown         = 0,
        actionNew             = 1,
        actionOpen            = 2,
        actionClose           = 3,
        actionPointer         = 4,
        actionLine            = 5,
        actionRectangle       = 6,
        actionCircle          = 7,
        actionDropper         = 8,
        actionZoomIn          = 10,
        actionZoomOut         = 11,
        actionGrid            = 12,
        actionAbout           = 13,
        actionExit            = 14,
        actionFilledRectangle = 15,
        actionFilledCircle    = 16
    }
}
