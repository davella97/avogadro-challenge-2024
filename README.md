# Introduzione 
La disposizione dei container in un cargo (stowage plan) deve essere fatta in base a diverse considerazioni 
https://en.wikipedia.org/wiki/Stowage_plan_for_container_ships
In questo esercizio ci focalizzeremo su un singolo fattore:
per questioni di stabilità, il baricentro (centro di gravita) dei container deve essere il più possibile vicino al centro X e Y della nave 
e il più possibile in basso rispetto a Z.

Soluzione Brute Force
Con questo termine si intende un algoritmo che prova tutte le combinazioni di disposizioni disponibili ed estrae da queste quella migliore.
Questa soluzione è impraticabile dal punto di vista computazionale:
La nave MSC più grande ha una capacità di 24,116 TEU, dove un container 20DV corrisponde a 1 TEU. 
Per semplicità ignoriamo che ci sono container di diverse dimensioni (tipo i 40DV).
Il numero di disposizioni possibili è N! E quindi 24116! = 6.584685784 * 10^95212  
(1*10^9 è un miliardo).

# Metodi alternativi
Siccome una soluzione ottimale non puà essere trovata con un algoritmo brute force, occorre definire non la soluzione migliore ma quella accettabile. 
Accettabile significa che il baricentro è "sufficentemente" vicino alla sua posizione ideale.
Semplifichiamo il problema nella seguente maniera 
a) I contaner sono dei cubi di dimenzione a
	 
b) La nave è modellata come una griglia a forma di parallelepipedo dove ci stanno 
NX contaner su asse x (larghezza), 
NY contaner su asse y (lunghezza), 
NZ contaner su asse z (altezza)
	
c) la nave non ha peso

Il baricentro ideale è al centro del pavimento della nave. 
Lungo asse z non si potra mai raggiungere ale valore siccome i contaner sono tutti sopra.

Come volume accettabile in cui il barcentro cade, si definisce un parallelepipedo che sia 
x% attorno al centro della nave (rispetto alla larghezza della nave)
y% attorno al centro della nave (rispetto alla lunghezza della nave)
z% sopra il pavimento della nave  (rispetto alla altezza della nave)

# Scopo algoritmo 
Dato in input 
- una nave che accoglie X*Y*Z contaners di dimensione a
- una distribuzione casuale del peso degli X*Y*Z containers (attorno ad un valore medio) (usare funzione C# Random)
- un target % di scostamento dal baricentro ideale 

Identificare un algoritmo che definisce una logica di distribuisce ottimizzata i container dentro la nave in base ad un certa logica.
Ottimizzata significa provare a portare il barcentro verso la sua pisizone ideale

Si suggerisce di procedere a scomporre il problema: 
- ottimizzare prima la distribuzione sui diversi paini della nave (asse z) 
- poi focalizzarsi su una ottimizzazione sui diversi piani (direzione x e y).

Applicato l'algoritmo, calcolare il baricentro della nave (supporre che la nave ha zero peso, considerare solo il peso dei container nel calcolo del baricentro).
Verificare che il punto del baricentro è all'interno del volume di tolleranza.


# Setup ambiente 
Installare Visual Studio 2022 (community edition, gratuita)
Se non gia disponibile crearsi un account su github (gratuito)
Fare fork del repo https://github.com/msc-technology/avogadro-challenge-2024 sul proprio account
Il repository clonato contiene la solution container-placement.sln
La solzione contentiene due progetti : 
- ContainerPlacementCalculator : class library doce scrivere l'algoritmo ed i tipi di "input/output"
- ContainerPlacementUnitTests : progetto che accoglie gli unit tests per testare il comportamento dell'algoritmo


