/************************************************************************
 * Program Licence :                                                    *
 *                                                                      *
 * Copyright 2015 , Perić Željko                                        *
 * (periczeljkosmederevo@yahoo.com)                                     *
 *                                                                      *
 * According to it's main purpose , this program is licensed            *
 * under the therms of 'Free Software' licence agreement.               *
 *                                                                      *
 * If You do not know what those therms applies to                      *
 * please read explanation at the following link :                      *
 * (http://www.gnu.org/philosophy/free-sw.html.en)                      *
 *                                                                      *
 * Since it is Free Software this program has no warranty of any kind.  *
 ************************************************************************
 * Ethical Notice :                                                     *
 *                                                                      *
 * It is not ethical to change program code signed by it's author       *
 * and then to redistribute it under the same author name ,             *
 * especially if it is incorrect.                                       *
 *                                                                      *
 * It is recommended that if You make improvement in program code ,     *
 * to make remarks of it and then to sign it with Your own name ,       *
 * for further redistribution as new major version of program.          *
 *                                                                      *
 * Author name and references of old program code version should be     *
 * kept , for tracking history of program development.                  *
 *                                                                      *
 * For any further information please contact code author at his email. *
 ************************************************************************/

/************************************
 * List Of Revisions                *
 ************************************
 *                                  *
 *                                  *
 *                                  *
 ************************************/

/******************************************************************************************************
 * Program name    : Detection of the contours of objects in the picture                              *
 * Program version : 1.0                                                                              *
 * Created in      : IDE SharpDevelop ver. 4.4                                                        *
 * Code autor      : Perić Željko                                                                     *
 * Code language   : C#, вер. 4.0                                                                     *
 * Date            : 17.04.2015 - 03.05.2015                                                          *
 *                                                                                                    *
 *                                                                                                    *
 * Program description : Program detects contours (edges) of objects at image                         *
 *                       saved at JPЕG or BMP standard 24 bits RGB format.                            *
 *                                                                                                    *
 * 			Detection of edge points is performed by algorithm which represents a variation of        *
 * 			"Difference Edge Detection" algorithm shown at Code Project site by                       *
 * 			author Christian Graus, software developer, Australia.                                    *
 *          ( http://www.codeproject.com/Members/ChristianGraus )                                     *
 *                                                                                                    *
 *          This algorithm is based on the assumption that the contour (edge) of the object           *
 *          at the image is noticeable with the naked eye if there is a significant difference        *
 *          between the color of pairs of opposing pixels positioned directly around the              *
 *          observed point that belongs to the edge of object. This refers to the pairs               *
 *          of points which can form the straight line that passes through the observed point.        *
 *                                                                                                    *
 *                   0 0 0   0 1 0   1 0 0   0 0 1   2 - observed point                               *
 *                   1 2 1   0 2 0   0 2 0   0 2 0   1 - a pair of opposing points                    *
 *                   0 0 0   0 1 0   0 0 1   1 0 0                                                    *
 *                                                                                                    *
 *          In the essence, we must find the maximum value of color differences,                      *
 *          for four pairs of oposing points and if this value is different from                      *
 *          the pre-defined, we assign a different value for the color to the observed point.         *
 *          At the resulting picture this point becomes edge point. At the link below,                *
 *          You can view the implementation of the algorithm in C # programming language,             *
 *          showing excellent results in detecting edges of objects in the image,                     *
 *          as well as several different algorithms for the same purposes.                            *
 *  ( http://www.codeproject.com/Articles/2056/Image-Processing-for-Dummies-with-C-and-GDI-Part )     *
 *                                                                                                    *
 *          A variation of the previous algorithm consists in the fact that instead of color values,  *
 *          we observe brightness value of pairs of opposing points in the image. If the maximum      *
 *          value for the brightness difference of pairs of opposing points is less than the lower    *
 *          limit of the brightness , point is changing its base color to Black, and if it is greater *
 *          than the value of the upper limit of brightness point changes its base color to White.    *
 *                                                                                                    *
 *                 Program controls :                                                                 *
 *                                                                                                    *
 *                 - Click on the original image will open a dialog to load a new image               *
 *                 - Click on the resulting image will open a dialog to save a result image           *
 *                 - Changing the limit values for brightness of points, automatically starts         *
 *                   New processing of the original image                                             *
 *                 - Changing the type of display of the processed image, automatically starts        *
 *                   New processing of the original image                                             *
 *                                                                                                    *
 *                                                                                                    *
 *                                                                              All the best,         *
 *                                                                              Author                *
 *                                                                                                    *
 ******************************************************************************************************/

#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Detection of the contours of objects in the picture")]
[assembly: AssemblyDescription("Program detects contours (edges) of objects " +
                               "at image saved at JPЕG or BMP standard 24 bits RGB format.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Perić Željko Smederevo, periczeljkosmederevo@yahoo.com")]
[assembly: AssemblyProduct("Detection of the contours of objects in the picture")]
[assembly: AssemblyCopyright("© 2015, Perić Željko, Free software")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// This sets the default COM visibility of types in the assembly to invisible.
// If you need to expose a type to COM, use [ComVisible(true)] on that type.
[assembly: ComVisible(false)]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all the values or you can use the default the Revision and 
// Build Numbers by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0")]
