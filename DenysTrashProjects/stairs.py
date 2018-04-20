import sys
num_steps = int(sys.argv[1])

for i in range(1,num_steps+1):
    str =""
    for y in range(0,num_steps-i):
        str += " "
    for y in range(0,i):
        str += "#"
    print(str)