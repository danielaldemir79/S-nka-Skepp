# Sänka Skepp

Ett klassiskt "Sänka Skepp"-spel där du spelar mot datorn i konsolen. Spelet är skrivet i C# och körs på .NET 8.

## Spelregler

- Spelplanen är 4 rader x 6 kolumner.
- Både spelaren och datorn har 3 skepp var, som placeras slumpmässigt på sina respektive kartor.
- Målet är att träffa alla motståndarens skepp innan dina egna blir träffade.

## Så här spelar du

1. Starta programmet.
2. Din och datorns kartor skapas och skeppen placeras ut automatiskt.
3. Du får se din egen karta och en dold version av datorns karta.
4. Ange koordinater för att skjuta på datorns karta:
   - X-koordinat: 1-6 (kolumn)
   - Y-koordinat: 1-4 (rad)
5. Efter varje skott får du veta om du träffade eller missade.
6. Datorn skjuter sedan på din karta.
7. Spelet fortsätter tills någon har träffat alla motståndarens 3 skepp.

## Symboler på kartan

- `O` = Skepp
- `X` = Tom ruta (din egen karta)
- `T` = Träff
- `-` = Miss

## Färger

- Grön: Träff
- Röd: Miss
- Gul: Datorns karta
- Cyan: Din karta

## Krav

- .NET 8 SDK
- C# 12

## Kom igång

1. Klona repot:
