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

namespace Detection_of_the_contours_of_objects_in_the_picture
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.Image_1 = new System.Windows.Forms.PictureBox();
			this.Image_2 = new System.Windows.Forms.PictureBox();
			this.Load_Image_Dialog = new System.Windows.Forms.OpenFileDialog();
			this.Invert_Edge_Color = new System.Windows.Forms.CheckBox();
			this.Избор_Врсте_Приказа = new System.Windows.Forms.GroupBox();
			this.Gray_Scale = new System.Windows.Forms.RadioButton();
			this.Black_White = new System.Windows.Forms.RadioButton();
			this.RGB = new System.Windows.Forms.RadioButton();
			this.Lower_Brightness_Limit = new System.Windows.Forms.NumericUpDown();
			this.Upper_Brightness_Limit = new System.Windows.Forms.NumericUpDown();
			this.Избор_Одступања_Осветљења = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Save_Image_Dialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.Image_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Image_2)).BeginInit();
			this.Избор_Врсте_Приказа.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Lower_Brightness_Limit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Upper_Brightness_Limit)).BeginInit();
			this.Избор_Одступања_Осветљења.SuspendLayout();
			this.SuspendLayout();
			// 
			// Image_1
			// 
			this.Image_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.Image_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Image_1.Location = new System.Drawing.Point(12, 12);
			this.Image_1.Name = "Image_1";
			this.Image_1.Size = new System.Drawing.Size(600, 400);
			this.Image_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image_1.TabIndex = 0;
			this.Image_1.TabStop = false;
			this.Image_1.Click += new System.EventHandler(this.Image_1_Click);
			// 
			// Image_2
			// 
			this.Image_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.Image_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Image_2.Location = new System.Drawing.Point(660, 12);
			this.Image_2.Name = "Image_2";
			this.Image_2.Size = new System.Drawing.Size(600, 400);
			this.Image_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image_2.TabIndex = 1;
			this.Image_2.TabStop = false;
			this.Image_2.Click += new System.EventHandler(this.Image_2_Click);
			// 
			// Load_Image_Dialog
			// 
			this.Load_Image_Dialog.Filter = "Битмапе|*.bmp|Јпег|*.jpg|Сви типови|*.*";
			this.Load_Image_Dialog.Title = "Одаберите слику за обраду";
			// 
			// Invert_Edge_Color
			// 
			this.Invert_Edge_Color.Location = new System.Drawing.Point(413, 29);
			this.Invert_Edge_Color.Name = "Invert_Edge_Color";
			this.Invert_Edge_Color.Size = new System.Drawing.Size(179, 26);
			this.Invert_Edge_Color.TabIndex = 4;
			this.Invert_Edge_Color.Text = " Invert edge color";
			this.Invert_Edge_Color.UseVisualStyleBackColor = true;
			this.Invert_Edge_Color.CheckedChanged += new System.EventHandler(this.Invert_Edge_Color_CheckedChanged);
			// 
			// Избор_Врсте_Приказа
			// 
			this.Избор_Врсте_Приказа.Controls.Add(this.Gray_Scale);
			this.Избор_Врсте_Приказа.Controls.Add(this.Invert_Edge_Color);
			this.Избор_Врсте_Приказа.Controls.Add(this.Black_White);
			this.Избор_Врсте_Приказа.Controls.Add(this.RGB);
			this.Избор_Врсте_Приказа.Location = new System.Drawing.Point(660, 418);
			this.Избор_Врсте_Приказа.Name = "Избор_Врсте_Приказа";
			this.Избор_Врсте_Приказа.Size = new System.Drawing.Size(600, 66);
			this.Избор_Врсте_Приказа.TabIndex = 13;
			this.Избор_Врсте_Приказа.TabStop = false;
			this.Избор_Врсте_Приказа.Text = "Type of display of the processed image";
			// 
			// Gray_Scale
			// 
			this.Gray_Scale.Location = new System.Drawing.Point(288, 31);
			this.Gray_Scale.Name = "Gray_Scale";
			this.Gray_Scale.Size = new System.Drawing.Size(122, 24);
			this.Gray_Scale.TabIndex = 2;
			this.Gray_Scale.Text = "Gray scale";
			this.Gray_Scale.UseVisualStyleBackColor = true;
			this.Gray_Scale.CheckedChanged += new System.EventHandler(this.Gray_Scale_CheckedChanged);
			// 
			// Black_White
			// 
			this.Black_White.Location = new System.Drawing.Point(142, 31);
			this.Black_White.Name = "Black_White";
			this.Black_White.Size = new System.Drawing.Size(140, 24);
			this.Black_White.TabIndex = 1;
			this.Black_White.Text = "Black and White";
			this.Black_White.UseVisualStyleBackColor = true;
			this.Black_White.CheckedChanged += new System.EventHandler(this.Black_White_CheckedChanged);
			// 
			// RGB
			// 
			this.RGB.Checked = true;
			this.RGB.Location = new System.Drawing.Point(16, 31);
			this.RGB.Name = "RGB";
			this.RGB.Size = new System.Drawing.Size(110, 24);
			this.RGB.TabIndex = 0;
			this.RGB.TabStop = true;
			this.RGB.Text = "RGB Color";
			this.RGB.UseVisualStyleBackColor = true;
			this.RGB.CheckedChanged += new System.EventHandler(this.RGB_CheckedChanged);
			// 
			// Lower_Brightness_Limit
			// 
			this.Lower_Brightness_Limit.DecimalPlaces = 2;
			this.Lower_Brightness_Limit.Increment = new decimal(new int[] {
									1,
									0,
									0,
									131072});
			this.Lower_Brightness_Limit.Location = new System.Drawing.Point(136, 31);
			this.Lower_Brightness_Limit.Maximum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.Lower_Brightness_Limit.Name = "Lower_Brightness_Limit";
			this.Lower_Brightness_Limit.Size = new System.Drawing.Size(124, 26);
			this.Lower_Brightness_Limit.TabIndex = 11;
			this.Lower_Brightness_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Lower_Brightness_Limit.Value = new decimal(new int[] {
									10,
									0,
									0,
									131072});
			this.Lower_Brightness_Limit.ValueChanged += new System.EventHandler(this.Lower_Brightness_Limit_ValueChanged);
			// 
			// Upper_Brightness_Limit
			// 
			this.Upper_Brightness_Limit.DecimalPlaces = 2;
			this.Upper_Brightness_Limit.Increment = new decimal(new int[] {
									1,
									0,
									0,
									131072});
			this.Upper_Brightness_Limit.Location = new System.Drawing.Point(337, 30);
			this.Upper_Brightness_Limit.Maximum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.Upper_Brightness_Limit.Name = "Upper_Brightness_Limit";
			this.Upper_Brightness_Limit.Size = new System.Drawing.Size(124, 26);
			this.Upper_Brightness_Limit.TabIndex = 17;
			this.Upper_Brightness_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Upper_Brightness_Limit.Value = new decimal(new int[] {
									10,
									0,
									0,
									131072});
			this.Upper_Brightness_Limit.ValueChanged += new System.EventHandler(this.Upper_Brightness_Limit_ValueChanged);
			// 
			// Избор_Одступања_Осветљења
			// 
			this.Избор_Одступања_Осветљења.Controls.Add(this.label3);
			this.Избор_Одступања_Осветљења.Controls.Add(this.label2);
			this.Избор_Одступања_Осветљења.Controls.Add(this.label1);
			this.Избор_Одступања_Осветљења.Controls.Add(this.Upper_Brightness_Limit);
			this.Избор_Одступања_Осветљења.Controls.Add(this.Lower_Brightness_Limit);
			this.Избор_Одступања_Осветљења.Location = new System.Drawing.Point(12, 418);
			this.Избор_Одступања_Осветљења.Name = "Избор_Одступања_Осветљења";
			this.Избор_Одступања_Осветљења.Size = new System.Drawing.Size(600, 66);
			this.Избор_Одступања_Осветљења.TabIndex = 15;
			this.Избор_Одступања_Осветљења.TabStop = false;
			this.Избор_Одступања_Осветљења.Text = "Lower and upper limit of value for brightness of pixel ( 0 - 1 )";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(467, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 20);
			this.label3.TabIndex = 19;
			this.label3.Text = ">>  edge";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(53, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 20);
			this.label2.TabIndex = 19;
			this.label2.Text = " edge  <<";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(266, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 20);
			this.label1.TabIndex = 18;
			this.label1.Text = "PIXEL";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Save_Image_Dialog
			// 
			this.Save_Image_Dialog.DefaultExt = "bmp";
			this.Save_Image_Dialog.FileName = "*.bmp";
			this.Save_Image_Dialog.Filter = "Битмапе|*.bmp|Јпег|*.jpg|Сви типови|*.*";
			this.Save_Image_Dialog.Title = "Снимање обрађене слике";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1272, 571);
			this.Controls.Add(this.Избор_Одступања_Осветљења);
			this.Controls.Add(this.Избор_Врсте_Приказа);
			this.Controls.Add(this.Image_2);
			this.Controls.Add(this.Image_1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Name = "MainForm";
			this.Text = "Detection of the contours of objects in the picture";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.Image_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Image_2)).EndInit();
			this.Избор_Врсте_Приказа.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Lower_Brightness_Limit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Upper_Brightness_Limit)).EndInit();
			this.Избор_Одступања_Осветљења.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.SaveFileDialog Save_Image_Dialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown Upper_Brightness_Limit;
		private System.Windows.Forms.GroupBox Избор_Одступања_Осветљења;
		private System.Windows.Forms.RadioButton RGB;
		private System.Windows.Forms.RadioButton Black_White;
		private System.Windows.Forms.RadioButton Gray_Scale;
		private System.Windows.Forms.GroupBox Избор_Врсте_Приказа;
		private System.Windows.Forms.NumericUpDown Lower_Brightness_Limit;
		private System.Windows.Forms.CheckBox Invert_Edge_Color;
		private System.Windows.Forms.OpenFileDialog Load_Image_Dialog;
		private System.Windows.Forms.PictureBox Image_2;
		private System.Windows.Forms.PictureBox Image_1;
	}
}
