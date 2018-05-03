import cv2
import numpy as np
from matplotlib import pyplot as plt

img = cv2.imread('12761830.bmp', 0)
img2 = np.empty(img.shape, dtype=int)
print(img.shape)

laplacian = cv2.Laplacian(img, cv2.CV_64F)
sobelx = cv2.Sobel(img, cv2.CV_64F, 1, 0, ksize=5)
sobely = cv2.Sobel(img, cv2.CV_64F, 0, 1, ksize=5)

plt.subplot(2, 2, 1), plt.imshow(img, cmap='gray')
plt.title('Original'), plt.xticks([]), plt.yticks([])

plt.subplot(2, 2, 2), plt.imshow(laplacian, cmap = 'gray')
plt.title('Laplacian'), plt.xticks([]), plt.yticks([])

plt.subplot(2, 2, 3), plt.imshow(sobelx, cmap='gray')
plt.title('Sobel X'), plt.xticks([]), plt.yticks([])

plt.subplot(2,2,4),plt.imshow(sobely,cmap = 'gray')
plt.title('Sobel Y'), plt.xticks([]), plt.yticks([])
plt.show()

hist = cv2.calcHist([img],[0],None,[256],[0,256])
plt.hist(img.ravel(),256,[0,256])
plt.show()

for i in range (0, img.shape[0]-1):
    for j in range(0, img.shape[1]-1):
        if (img[i][j]-img[i+1][j]) > 20:
            img2[i][j]=255
        else:
            img2[i][j]=0
plt.imshow(img2,cmap = 'gray')
plt.show()
