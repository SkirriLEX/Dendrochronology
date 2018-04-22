from PIL import Image, ImageFilter
#Read image
im = Image.open( '9613095_300x300' )
#Display image
im.show()
print(im.split())
a = input()

#Applying a filter to the image
im_sharp = im.filter( ImageFilter.SHARPEN )
#Saving the filtered image to a new file
#im_sharp.save( 'image_sharpened.jpg', 'JPEG' )

#Splitting the image into its respective bands, i.e. Red, Green,
#and Blue for RGB
print(im_sharp.split())
im_sharp.show()


#Viewing EXIF data embedded in image
#exif_data = im._getexif()
#exif_data