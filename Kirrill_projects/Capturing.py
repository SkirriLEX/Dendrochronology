import numpy as np
import cv2

cap = cv2.VideoCapture(0)

while(True):
    # Capture frame-by-frame
    ret, frame = cap.read()

    # Our operations on the frame come here
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    laplacay = cv2.Laplacian(frame,cv2.CV_64F)    
    #canny = cv2.Canny(frame,50,200)

    # Display the resulting frame

    # Display the resulting frame
    #cv2.imshow('frame',frame)
    cv2.imshow('laplacay',laplacay)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# When everything done, release the capture
cap.release()
cv2.destroyAllWindows()