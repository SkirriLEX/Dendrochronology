import cv2

img = cv2.imread('srz.jpg',0);
cannyEdges = cv2.Canny(img, 100 , 200);

_,contours,_ = cv2.findContours(cannyEdges,cv2.RETR_LIST,cv2.CHAIN_APPROX_NONE)
print(len(contours))

cv2.drawContours(cannyEdges,contours,-1,(255,255,255),1)

cv2.imshow("1",img)
cv2.imshow("2",cannyEdges)
cv2.waitKey(0)
cv2.destroyAllWindows()