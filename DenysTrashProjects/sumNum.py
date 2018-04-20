import sys
digit_string = sys.argv[1]

answer = 0
for num in digit_string:
    answer  += int(num)

print(answer)