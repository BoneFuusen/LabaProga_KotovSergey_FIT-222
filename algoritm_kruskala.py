Reb = [(13, 1, 2), (18, 1, 3), (17, 1, 4), (14, 1, 5), (22, 1, 6),
     (26, 2, 3), (22, 2, 5), (3, 3, 4), (19, 4, 6)]

sum = 0

RebS = sorted(Reb, key=lambda x: x[0])
ConVer = set()
IsoVer = {}
RebOst = []

for r in RebS:
    if r[1] not in ConVer or r[2] not in ConVer:
        if r[1] not in ConVer and r[2] not in ConVer:
            IsoVer[r[1]] = [r[1], r[2]]
            IsoVer[r[2]] = IsoVer[r[1]]
        else:
            if not IsoVer.get(r[1]):
                IsoVer[r[2]].append(r[1])
                IsoVer[r[1]] = IsoVer[r[2]]
            else:
                IsoVer[r[1]].append(r[2])
                IsoVer[r[2]] = IsoVer[r[1]]

        RebOst.append(r)
        ConVer.add(r[1])
        ConVer.add(r[2])

for r in RebS:
    if r[2] not in IsoVer[r[1]]:
        RebOst.append(r)
        gr1 = IsoVer[r[1]]
        IsoVer[r[1]] += IsoVer[r[2]]
        IsoVer[r[2]] += gr1

print(RebOst)
for rebro in RebOst:
    sum += rebro[0]
print(sum)
