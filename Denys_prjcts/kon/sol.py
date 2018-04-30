import cv2
import math
import numpy as np

def findCircles(_image):
    bin = cv2.imread(_image)
    binGray = cv2.cvtColor(bin, cv2.COLOR_BGR2GRAY)

    countres = cv2.Canny(binGray, 100, 200)
    cv2.imshow('con', countres)

    storage = []
    contoursCont = cv2.findContours(countres,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
    print(cv2.contourArea(con))
    for con in contoursCont:
        area = math.fabs(cv2.contourArea(con))
        perim = cv2.arcLength(con)

        if (area / (perim*perim) > 0.07) & (area/(perim*perim)<0.087):
            imCon = cv2.drawContours(bin, con, (0,0,255), (0,255,0), -1,1,8 )

    cv2.imshow(_image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
    return
findCircles('srez.jpg')
im = cv2.imread('srez.jpg')
#cv2.imshow('srez',im)
cv2.waitKey(0)
cv2.destroyAllWindows()

