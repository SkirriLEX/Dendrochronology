#canvas in video capture

import cv2
import numpy as np

webcam = cv2.VideoCapture(0)

while (webcam.isOpened()):
    _, frame = webcam.read()

    laplacian = cv2.Laplacian(frame, cv2.CV_64F)
    #    sobelx=cv2.Sobel(frame,cv2.CV_64F,1,0,ksize=5)
    #    sobely=cv2.Sobel(frame,cv2.CV_64F,0,1,ksize=5)
    edges = cv2.Canny(frame, 100, 90)

    cv2.imshow("laplacian", laplacian)
    cv2.imshow("color img", frame)
    #    cv2.imshow("sobelx",sobelx)
    #    cv2.imshow("sobely",sobely)
    cv2.imshow("edges", edges)
    if (cv2.waitKey(1) & 0xff == ord("c")):
        break
webcam.release()
cv2.destroyAllWindows()
