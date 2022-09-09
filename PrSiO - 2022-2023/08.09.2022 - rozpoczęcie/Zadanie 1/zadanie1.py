tekst = input('Wporwadź tekst: ')
if tekst == "":
    tekst = 'bcmbmcomcocooemeuuu'

samogloski = ['a', 'o', 'e', 'u']
spolgloski = ['b', 'c', 'm', 'g']



# Liczenie samogłosek

max_sam = 0
sam = 0

for i in tekst:
    if i in samogloski:
        sam += 1
    else:
        if max_sam < sam:
            max_sam = sam
        sam = 0

if max_sam < sam:
    max_sam = sam

# Liczenie spółgłosek

max_spol = 0
spol = 0

for i in tekst:
    if i in spolgloski:
        spol += 1
    else:
        if max_spol < spol:
            max_spol = spol
        spol = 0

if max_spol < spol:
    max_spol = spol


print('Najdłuższa sekwencja samogłosek: ', max_sam)
print('Najdłuższa sekwencja spółgłosek: ', max_spol)