import cv2
import argparse
import numpy
import math

class Point:
    def __init__(self, x, y):
        self.X = x
        self.Y = y

    def setX(self, x):
        self.X = x

    def setY(self, y):
        self.Y = y

    def getX(self):
        return self.X

    def getY(self):
        return self.Y

    def distance(self, other):
        dx = self.X - other.X
        dy = self.Y - other.Y
        return math.sqrt(dx ** 2 + dy ** 2)

startPoint = Point(None, None)
endPoint = Point(None, None)
mousePressed = False
line = None

img = cv2.imread('srez.jpg',0)
secImg = img.copy()
cannyEdges = cv2.Canny(img.copy(), 100 , 200)

_,contours,_ = cv2.findContours(cannyEdges,cv2.RETR_LIST,cv2.CHAIN_APPROX_NONE)
cv2.drawContours(cannyEdges,contours,-1,(255,255,255),1)

# initialize the list of reference points and boolean indicating
# whether cropping is being performed or not

print(contours[0])

def click_and_crop(event, x, y, flags, param):
    # grab references to the global variables
    global startPoint, endPoint, mousePressed, img, line

    # if the left mouse button was clicked, record the starting
    # (x, y) coordinates and indicate that cropping is being
    # performed
    if event == cv2.EVENT_LBUTTONDOWN:
        startPoint = Point(x,y)
        mousePressed = True

    elif event == cv2.EVENT_MOUSEMOVE:
        if mousePressed == True:
            img = secImg.copy()
            cv2.imshow("image", img)
            endPoint = Point(x, y)
            line = cv2.line(img, (startPoint.getX(), startPoint.getY()), (endPoint.getX(), endPoint.getY()), (255, 0, 0), 1)
            #cv2.drawContours(img, contours, -1, (180, 180, 180), 1)
            tmp=0
            #for i in contours:
            for j in line:
                print(j)
                    #if i == j:
                     #   cv2.drawContours(img,contours,tmp,(0,180,180),1)
                      #  print("yea con")
                #tmp+=1
                #print(i)
            cv2.imshow("image", img)

    # check to see if the left mouse button was released
    elif event == cv2.EVENT_LBUTTONUP:
        # record the ending (x, y) coordinates and indicate that
        # the cropping operation is finished
        endPoint = Point(x,y)
        mousePressed = False
        # draw a rectangle around the region of interest
        cv2.line(img, (startPoint.getX(), startPoint.getY()), (endPoint.getX(), endPoint.getY()), (255, 0, 0), 1)
        cv2.imshow("image", img)

cv2.imshow("image", img)
clone = img.copy()
cv2.namedWindow("image")
cv2.setMouseCallback("image", click_and_crop)

#cv2.imshow("1",img)
#cv2.imshow("2",cannyEdges)
cv2.waitKey(0)
cv2.destroyAllWindows()

