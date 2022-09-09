#import math

#   Zadanie nr 4.1

# counter = 0

# with open("Dane_PR/liczby.txt", "r") as file:
#     row = file.readline()
#     while row != "":
#         number = int(row)
#         exponent = math.log(number, 3)
#         if exponent.is_integer():
#             print(row)
#             counter += 1

#         row = file.readline()

# print(counter) /// 14 <--- Błędna odpowiedź



#   Zadanie 4.2

# def silnia(n: int) -> int:
#     temp = 1
#     for i in range(1, n + 1):
#         temp *= i

#     return temp

# def suma(args) -> int:
#     wynik = 0 
#     for i in args:
#         wynik += i
#     return wynik

# with open("Dane_PR/przyklad.txt", "r") as file:
#     row = file.readline()
#     while row != "":
#         row = row.replace("\n", "")
#         lista = []
#         for i in row:
#             lista.append(
#                     silnia( int(i) )
#                 )
#         sum = suma(lista)
        
#         if sum == int(row):
#             print(row)

#         row = file.readline()


# Zadanie 4.3