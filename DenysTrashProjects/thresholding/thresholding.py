import cv2
import numpy as np

img = cv2.imread('bookpage.jpg')

ret, threshold = cv2.threshold(img,7, 255, cv2.THRESH_BINARY)
grayScale = cv2.cvtColor(threshold, cv2.COLOR_BGR2GRAY)
ret, threshold1 = cv2.threshold(grayScale, 12 , 255, cv2.THRESH_BINARY)
gaus = cv2.adaptiveThreshold(grayScale, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 115, 1)
retval2, otsu = cv2.threshold(grayScale,125,255,cv2.THRESH_BINARY+cv2.THRESH_OTSU)
cv2.imshow('orig', img)
cv2.imshow('threshold', threshold)
cv2.imshow('grayScale', grayScale)
#cv2.imshow('th2', threshold1)
cv2.imshow('gaus',gaus)
cv2.imshow('otsu', otsu)
cv2.waitKey(0)
cv2.destroyAllWindows()