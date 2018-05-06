import cv2
import numpy as np

img1 = cv2.imread('1.jpg')
img2 = cv2.imread('2.jpg')
img3 = cv2.imread('logo.jpg')

#add value pixels of 2 imgs
#add = cv2.add(img1, img2)
#add = cv2.addWeighted(img1,0.9,img2,1,0)

rows,cols,channels = img3.shape
roi = img1[0:rows, 0:cols]

img3gray = cv2.cvtColor(img3, cv2.COLOR_BGR2GRAY)
ret, mask = cv2.threshold(img3gray, 90, 255, cv2.THRESH_BINARY)
mask_inv = cv2.bitwise_not(mask)

img1_bg = cv2.bitwise_and(roi,roi,mask=mask_inv)
img3_fg = cv2.bitwise_and(img3,img3,mask=mask)

dst=cv2.add(img1_bg,img3_fg)
img1[0:rows, 0:cols] = dst

cv2.imshow('1_bg',img1_bg)
cv2.imshow('3_fg',img3_fg)
cv2.imshow('dst',dst)
cv2.waitKey(0)
cv2.destroyAllWindows()