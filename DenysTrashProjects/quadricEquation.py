import sys
import math
a = int(sys.argv[1])
b = int(sys.argv[2])
c = int(sys.argv[3])

D = math.pow(b,2)-(4*a*c)
print(D)

if D>0:
    x1 = (-b-math.sqrt(D))/(2*a)
    x2 = (-b+math.sqrt(D))/(2*a)
    print(x1)
    print(x2)
else:
    x=-(b/(2*a))
    print(x)