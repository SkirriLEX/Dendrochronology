import cv2
import numpy as np

image = cv2.imread('srez.jpg')
blurred = cv2.pyrMeanShiftFiltering(image, 10,31)
gray = cv2.cvtColor(blurred,cv2.COLOR_BGR2GRAY)
_,threshold = cv2.threshold(gray,0,255,cv2.THRESH_BINARY+cv2.THRESH_OTSU)

_,contours,_ = cv2.findContours(threshold,cv2.RETR_LIST,cv2.CHAIN_APPROX_NONE)
print(len(contours))

cv2.drawContours(image, contours, -1,(0,0,255), 1)
cv2.namedWindow('Display',cv2.WINDOW_NORMAL)
cv2.imshow('Display', image)
cv2.waitKey()
cv2.destroyAllWindows()