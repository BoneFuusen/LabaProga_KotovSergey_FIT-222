import math

Reb = [(math.inf, -1, -1), (13, 1, 2), (18, 1, 3), (17, 1, 4), (14, 1, 5), (22, 1, 6),
       (26, 2, 3), (19, 2, 5), (30, 3, 4), (22, 4, 6)]

N = 6
ConVer = {1}
RebOst = []
sum = 0


def get_min(Reb, ConVer):
    rm = (math.inf, -1, -1)
    for v in ConVer:
        rr = min(Reb, key=lambda x: x[0] if (x[1] == v or x[2] == v) and (x[1] not in ConVer or x[2] not in ConVer) else math.inf)
        if rm[0] > rr[0]:
            rm = rr
    return rm


while len(ConVer) < N:
    r = get_min(Reb, ConVer)
    if r[0] == math.inf:
        break
    RebOst.append(r)
    ConVer.add(r[1])
    ConVer.add(r[2])

print(RebOst)
for rebro in RebOst:
    sum += rebro[0]
print(sum)
