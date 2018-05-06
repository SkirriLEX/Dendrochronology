import numpy as np
import cv2

img = cv2.imread('zsrez.jpg', cv2.IMREAD_COLOR)

cv2.line(img, (0,0), (150,150), (255,255,255), 10)
cv2.rectangle(img, (15,25), (200,150), (0,255,0), 5)
cv2.circle(img, (100,65), 55, (0,0,255), -1)

pts = np.array([[10,5], [20,30], [70,20], [50,10]], np.int32)

cv2.polylines(img, [pts], True, (0,255,255), 5)

cv2.imshow('image', img)
cv2.waitKey(0)
cv2.destroyAllWindows()