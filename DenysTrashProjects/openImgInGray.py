import cv2
import numpy as np
import matplotlib.pyplot as plt

img = cv2.imread('srez.jpg', cv2.IMREAD_GRAYSCALE)
cv2.imshow('image',img)
cv2.waitKey(0)
cv2.destroyAllWindows()