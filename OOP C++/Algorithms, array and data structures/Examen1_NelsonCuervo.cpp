// Examen1_NelsonCuervo.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdio.h>
#include <string>
#include <stdlib.h>
using namespace std;



// Exercice 1)

//  La fonction suivante, écrite en langage C, permet de vérifier et de retourner vrai(1) ou faux(0)
//  selon que deux tableaux des entiers sont identiques(les deux contiennent le même nombre d’éléments
//  et les éléments correspondants sont égaux) ou non.

int estIdentique(int tableau1[], int n1, int tableau2[], int n2)
{
	int i;

	if (n1 != n2) {
		cout << "Tableau  " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : faux(0)" << endl;
		return 0;
	}

	for (i = 0; i < n1; i++) {
		if (tableau1[i] != tableau2[i]) {
			cout << "Tableau " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : faux(0)" << endl;
			return 0;
		}

		else
			cout << "Tableau " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : vrai(1)" << endl;
		return 1;
	}

}

int estIdentiqueChar(char tableau1[], int n1, char tableau2[], int n2)
{
	int i;

	if (n1 != n2) {
		cout << "Tableau  " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : faux(0)" << endl;
		return 0;
	}

	for (i = 0; i < n1; i++) {
		if (tableau1[i] != tableau2[i]) {
			cout << "Tableau " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : faux(0)" << endl;
			return 0;
		}

		else
			cout << "Tableau " << (unsigned int)&tableau1 << " et tableau " << (unsigned int)&tableau2 << " son identiques : vrai(1)" << endl;
		return 1;
	}

}


// Exercice 2)
//Écrivez une ou plusieurs fonctions(à votre jugement) et leurs appels pour tester la symétrie de la chaîne ville et du tableau age.

void CheckSymetieChar(char* ville) {

	bool symetrique = true;
	for (int i = 0; i < strlen(ville) / 2 && symetrique; i++) {
		if (ville[i] != ville[strlen(ville) - i - 1])
			symetrique = false;

	}
	if (symetrique)
		cout << "\nLa ville Laval est symetrique ";
	else
		cout << "\nLa ville Laval est asymetrique ";

}

void CheckSymetieInt(int* age) {

	int size = age[0];
	++age;

	bool symetrique = true;

	for (int i = 0; i < size / 2 && symetrique; i++) {
		if (age[i] = age[size - i - 1])
			symetrique = true;
	}
	if (symetrique == true)
		cout << "\nle tableau age est symetrique";
	else
		cout << "\nle tableau age est asymetrique";

}


/*
Exercice 3)

Pour la gestion la plus simple des immeubles à vendre (au maximum 5),
un courtier doit avoir les informations suivantes reliées à chaque immeuble :

-	année de construction (un entier, exemple 1989)
-	type de l'immeuble : un caractère
		   'P'   : résidence privée
		   'C'  : immeuble commercial
		   'A' : immeuble d'autre type
-	prix évalué par la ville :  un réel (exemple 123456.75 $)

1)	À l'aide d'une fonction lireInfos, permettez à l'utilisateur d'entrer les données des immeubles
2)	Écrire une fonction permettant d'afficher les informations des immeubles;
3)	Écrire une autre fonction portant le même nom qui permet d'afficher tous les
	immeubles d’un type donné.

*/

void exercice3() {


	int* anneConstruction;
	char* typeImmueble;
	double* prixEvalue;
	int size;

	cout << "\nCombien de propriétés souhaitez-vous insérer ? " << endl;
	cin >> size;

	anneConstruction = new int[size];
	typeImmueble = new char[size];
	prixEvalue = new double[size];

	cout << "\nVeuillez entrer les informations des immeubles : \n" << endl;

	for (int i = 0; i < size; i++) {

		cout << "\n****** Immeuble # " << i + 1 << "****** : \n" << endl;
		cout << "Année de construction (un entier, exemple 1989) : " << endl;
		cin >> anneConstruction[i]; 
		//getline(cin, anneConstruction[i]);
		cout << "Type de l'immeuble : un caractère :\n'P'   : résidence privée.\n'C'  : immeuble commercial.\n'A' : immeuble d'autre type." << endl;
		cin >> typeImmueble[i];
		//getline(cin, typeImmueble[i]);
		cout << "Prix évalué par la ville :  un réel (exemple 123456.75 $) : " << endl;
		cin >> prixEvalue[i];

	}

	// 3.1 Afficher les informations des immeubles
	for (int i = 0; i < size; i++) {
		cout << "\n\nImmeuble #   " << i << endl;
		cout << "Année de construction : " << anneConstruction[i] << endl;
		cout << "Type de l'immeuble : " << typeImmueble[i] << endl;
		cout << "Prix évalué par la ville %.02f: " << prixEvalue[i] << endl;

	}

}



// 3.1) Afficher les informations des immeubles

void afficherImmuebles(int* anneConstructionX[], char* typeImmuebleX[], double* prixEvalueX[], int sizeX) {

	for (int i = 0; i < sizeX; i++) {
		cout << "Immeuble #   " << i << endl;
		cout << "Année de construction : " << anneConstructionX[i] << endl;
		cout << "Type de l'immeuble : " << typeImmuebleX[i] << endl;
		cout << "Prix évalué par la ville : " << prixEvalueX[i] << endl;

	}

}


// 3.2)	Écrire une fonction permettant d'afficher les informations des immeubles;
static void AfficherTypeImmueble(int *anneC[], char *typeI[], double *prixE[],char lettre, string nomImmueble) {

	

	for (int i = 0; i < sizeof *typeI; i++) {

		if (*typeI[i] == lettre)
		cout << "\n\nImmeuble #   " << i << endl;
		cout << "Tyoe d'immueble :" << nomImmueble << endl;
		cout << "Année de construction : " << anneC[i] << endl;
		cout << "Type de l'immeuble : " << typeI[i] << endl;
		cout << "Prix évalué par la ville : " << prixE[i] << endl;
		
	}
	
}

// 3.3)	Écrire une autre fonction portant le même nom qui permet d'afficher tous les
// immeubles d’un type donné.

static void PrixMax(int* anneC[], char* typeI[], double* prixE[], char lettre, string nomImmueble) {

	int max = -1;

	for (int i = 0; i < sizeof prixE; i++) {

		if (*typeI[i] == lettre)
			if (*prixE[i] >= max) {
				max = *prixE[i];
			}
	}
	cout << "Le prix le plus élevé des " << nomImmueble << " : " << max << "\n" << endl;

}


void Exercice4_Tableau() {

	int tab[10];
	int min, max;

	cout << "Donnez " << 10 << " valeurs " << endl;

	for (int i = 0; i < 10; i++) {
		cout << "Valeur # :" << i+1 << endl;
		cin >> tab[i];
	}

	min = max = tab[0];

	for (int j = 1; j < 10; j++) {

		if (tab[j] < min)
		{
			min = tab[j];
		}
		if (tab[j] > max)
		{
			max = tab[j];
		}
	}

	cout << "Max value :" << max << endl;
	cout << "Min value :" << min << endl;

}


void Exercice4_Pointeur() {

	
	int tab[10];
	int min, max;

	cout << "Donnez " << 10 << " valeurs " << endl;

	for (int i = 0; i < 10; i++)
		
		cin >> *(tab + i); 


	min = max = *tab;

	for (int i = 1; i < 10; i++) {

		if (*(tab + i) < min)
		{
			min = *(tab + i);
		}
		if (*(tab + i) > max)
		{
			max = *(tab + i);
		}
	}

	cout << "Max value :" << max << endl;
	cout << "Min value :" << min << endl;

}




int main()
{

	// ******* EXER 01 : *******

	/*
	Ré-écrivez la fonction estIdentique, en utilisant les nouveautés possibles du C++ et écrivez les instructions
	pour tester et afficher les résultats des tests des tableaux suivants :

	age1 vs age2, age1 vs age3 où :

	*/

	int age1[10] = { 50, 27, 62, 14, 58, 40 },
		age2[15] = { 50, 27, 62, 14, 58, 40, 70 },
		age3[10] = { 50, 72, 62, 14, 58, 40 };

	cout << "Le numéro (284161536) correspond à l'emplacement de la mémoire virtuelle du tableau. " << endl;
	cout << "\nnage1 vs age2 :" << endl;
	estIdentique(age1, 10, age2, 15);
	cout << "\nnage1 vs age3 :" << endl;
	estIdentique(age1, 10, age3, 10);
	///*
	//et : sexe1 vs sexe2  où :
	//*/
	char sexe1[5] = { 'F', 'F', 'M', 'M', 'M' },
		sexe2[7] = { 'F', 'F', 'M', 'M', 'M' };
	cout << "\nsexe1 vs sexe2   :" << endl;
	estIdentiqueChar(sexe1, 5, sexe2, 7);


	// ****** EXER02 *******
	/*
	Exercice 2)

      Soit la fonction principale incomplète suivante :
      void main() {
      char ville[20] = "laval";
      int age[15] = { 5, 25, 12, 12, 25, 5 };
      // à compléter :
        …….	
     }     

     La ville "laval" est symétrique   car  ville[0] == ville[4], ville[1] == ville[3].
     Le tableau age est aussi symétrique car age[0] == age[5], age[1] == age[4], 
     age[2] == age[3].

     Écrivez une ou plusieurs fonctions (à votre jugement) et leurs appels pour tester la symétrie de la chaîne ville et du tableau age.

	*/

	char ville[20] = "laval";
	int age[15] = { 5, 25, 12, 12, 25, 5 };
	CheckSymetieChar(ville);
	CheckSymetieInt(age);


	// ******* EXER03 : *******

	 //exercice3();

	 int anneConstruction;
	 char typeImmueble;
	 double prixEvalue;
	 int size;

	// ******* EXER04 : ******* 

	/*
	Écrire, de deux façons différentes, un programme qui lit 10 nombres entiers dans un tableau avant d’en calculer la moyen de ces valeurs: 
     a. en utilisant uniquement le « formalisme tableau » ; 
     b. en utilisant le « formalisme pointeur », à chaque fois que cela est possible.
	*/

	Exercice4_Tableau();
	Exercice4_Pointeur();




}




