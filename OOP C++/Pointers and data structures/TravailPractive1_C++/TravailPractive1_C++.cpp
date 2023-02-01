// TravailPractive1_C++.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdio.h>
#include <string>
#include <stdlib.h>

using namespace std;

//                    Série -4-

char* mon_strcpy(char* destination, char* source)
{
	char* debut = destination;

	while (*source != '\0')
	{
		*destination = *source;
		destination++;
		source++;
	}

	*destination = '\0'; // add '\0' à la fin 
	return debut;
}


void Exercice1() {

	// **************** Exercice -1 ****************
//                   Série -1-

// Q1 : Déclarez les deux pointeurs « ptrx » et « ptry » qui pointent des valeurs du type « int ».
	int* ptrx, * ptry;
	// Q2 : Déclarez la variable « varx » du type « int » sans l’initialiser et faites en sorte que « ptrx » pointe cette variable. 
	int varx;
	ptrx = &varx;
	cout << "\nQ2 :\nAdresse &ptrx " << (unsigned int)&ptrx << " Valeur : (ptrx = varx) " << *ptrx << endl;
	cout << "Adresse &varx " << (unsigned int)&varx << " Valeur : (varx = ptrx ) " << varx << endl;
	// Q3: Déréférencez le pointeur « ptry » pour qu’il contient la valeur « 53 ».
	int valeur1 = 53;
	//cout << "\nAdresse &valeur1 : " << (unsigned int)&valeur1 << " Valeur *ptrx = *ptry = *valeur1:" << valeur1 << endl;
	ptry = &valeur1;
	//*ptry = 199;
	//cout << "\nAdresse &valeur1 : " << (unsigned int)&valeur1 << " Valeur *ptrx = *ptry = *valeur1:" << valeur1 << endl;
	cout << "\nQ3 :\nAdresse &ptry : " << (unsigned int)&ptry << " Valeur *ptry : " << *ptry << endl;
	// Q4:  Assignez « ptrx » à « ptry ».
	ptry = ptrx;
	cout << "\nQ4 :\nAdresse &valeur1 : " << (unsigned int)&valeur1 << " Valeur *(ptrx = ptry) != *valeur1 : " << valeur1 << endl;
	cout << "Adresse &ptry : " << (unsigned int)&ptrx << " Valeur *ptrx = *ptry :" << *ptrx << endl;
	cout << "Adresse &ptrx : " << (unsigned int)&ptry << " Valeur *ptry = *ptrx :" << *ptry << endl;

	// Q5: Déréférencez le pointeur « ptry » pour qu’il contient la valeur « 99 ». 
	*ptrx = 99;
	//Q6: Quel est la valeur pointée par « ptrx »?
	cout << "\nQ6 :\nValeur *ptrx : " << *ptrx << endl;
	cout << "Valeur *ptry : " << *ptry << endl;
	cout << "La valeur de *ptrx == a *ptry (99)" << endl;
	//Q7: À l’aide de votre programme de test, indiquez la valeur des adresses mémoires associées aux variables « ptrx », « ptry » et « varx ».
	cout << "\nQ7 :\nAdresse memoire &ptrx : " << (unsigned int)&ptrx << endl;
	cout << "Adresse memoire &ptry : " << (unsigned int)&ptry << endl;
	cout << "Adresse memoire &varx : " << (unsigned int)&varx << endl;
	cout << "L'Adresse memoire &ptrx !=  &ptry != &varx " << endl;
	// Q8: Affichez la valeur contenue dans les variables « ptrx » et « ptry ». (Attention, il ne s’agit pas de déréférencer les pointeurs).
	cout << "\nQ6 :\nValeur ptrx : " << ptrx << endl;
	cout << "Valeur ptry : " << ptry << endl;
	cout << "Valeur ptry == valeur ptrx" << endl;

	system("pause");
	cout << "\x1B[2J\x1B[H";


	//                    Série -2-

	//Q9: Déclarez deux pointeurs « ptra » et « ptrb » qui pointent des valeurs du type « int ».
	int* ptra, * ptrb;
	const int size = 1;
	//cout << "\nQ9 : \n&ptra : " << (unsigned int)&ptra << endl;
	//cout << "&ptrb : " << (unsigned int)&ptrb <<endl;

	// Q10: Faites en sorte que pour chaque pointeur « ptra » et « ptrb » il lui soit alloué une zone mémoire permettant de contenir un seul élément du type « int ».

	ptra = new int[size];
	ptrb = new int[size];

	//Zone de memoire et contenue du pointeur ptra (type array)
	cout << "\nQ10 : " << endl;
	cout << "Zone memoire &ptra : " << (unsigned int)&ptra << " Valeur *ptra : " << *ptra << endl;
	for (int i = 0; i < size; i++) {
		cout << "Element # :" << i + 1 << " " << *(ptra + i) << endl;
		cout << "le pointeur ptra qui permet de stocker des elements de type int , est vide " << endl;
	}


	//Zone de memoire et contenue du pointeur ptrb (type array)	
	cout << "\nZone memoire &ptrb : " << (unsigned int)&ptrb << " Valeur *ptrb : " << *ptrb << endl;
	for (int i = 0; i < size; i++) {
		cout << "Element # :" << i + 1 << " " << *(ptrb + i) << endl;
		cout << "le pointeur ptrb qui permet de stocker des elements de type int , est vide " << endl;
	}

	// Q11: Déréférencez les pointeurs « ptra » et « ptrb » pour permettre de stocker respectivement les valeurs « 5 » et « 6 ».


	// on donne des valeurs manuellement
	ptra[0] = 5;
	ptrb[0] = 6;


	// On demand al utilisateur de faicon dimamique de introduir les infos.

	//cout << "\nQ11 : \nEntrer la valeur a stocker dans le pointeur ptra " << endl;
	//for (int i = 0; i < size; i++) {

	//	cout << "Entrer la valeur de l'element # (de preference le nombre 5)" << i + 1 << " : \n" << endl;
	//	cin >> ptra[i];
	//}

	//cout << "Entrer la valeur a stocker dans le pointeur ptrb (de preference le nombre 6)" << endl;
	//for (int i = 0; i < size; i++) {

	//	cout << "Entrer la valeur de l'element # " << i + 1 << " : \n" << endl;
	//	cin >> ptrb[i];
	//}

	cout << "\n" << "Stockage al interieur des pointeurs ptra et ptrb :" << endl;
	for (int i = 0; i < size; i++) {

		cout << "Donnes stockees al interieur du pointeur ptra : " << ptra[i] << endl;
		cout << "Donnes stockees al interieur du pointeur ptrb : " << ptrb[i] << endl;
	}

	system("pause");
	cout << "\x1B[2J\x1B[H";


	//                    Série -3-


	// Q12 : Soit le fragment de code suivant :
	int untab[] = { 5, 19, 14, 8, -10, 99 };
	int* unptr;

	//Q12 : Initialisez de deux manières différentes le pointeur « unptr » avec le premier élément du tableau.
	cout << "\nQ12 : " << endl;
	unptr = untab;
	cout << "1. (unptr = untab) unptr : " << unptr << "\nAdresse &unptr : " << (unsigned int)&unptr << "\nValeur *unptr : " << *unptr << endl;
	unptr[0] = untab[0];
	cout << "\n2. (unptr[0] = untab[0]) unptr : " << unptr << "\nAdresse &unptr : " << (unsigned int)&unptr << "\nValeur *unptr : " << *unptr << endl;

	// Q13 : Expliquez pourquoi cette instruction est incorrecte ?
	//untab = unptr;
	cout << "\nQ13 : " << "\nLa instruction (untab = unptr;) est incorrecte \nparce que nous assignons la valeur d'un pointeur à une variable de tableau, \nles pointeurs sont des références à des valeurs ou des données en mémoire." << endl;

	/*
	Parce que nous assignons la valeur d'un pointeur à une variable de tableau,
	les pointeurs sont des références à des valeurs ou des données en mémoire.
	*/

	//Q14 : Expliquez le fragment de code suivant et que va - t - il s’afficher en sortie ?

	cout << "\nQ14 : " << endl;

	for (int i = 0; i < 6; i++) {
		cout << "tab[" << i << "]" << untab[i] << endl; // ligne –A-
		cout << "unptr+" << i << "= " << *(unptr + i) << endl; // ligne –B-
	}

	/*
	La ligne A affiche les valeurs du tableau a l'écran Sur,
	la ligne B affiche les valeurs du tableau à l’aide du pointeur et avance à chaque itération
	*/

	// Q15 : Si vous permutez la ligne « -B » par ce qui suit, le fragment de code sera-t-il correct? Si oui, que va-t-il s’afficher en sortie?

	cout << "\nQ15 : " << endl;

	for (int i = 0; i < 6; i++) {
		cout << "tab[" << i << "]" << untab[i] << endl; // ligne –A-
		//cout << "unptr+" << i << "= " << *(unptr + i) << endl; // ligne –B-
		cout << "unptr+" << i << "= " << *unptr++ << endl; // NEW ligne –B-

		/*
		la nouvelle ligne B affiche les valeurs du tableau à l’aide du pointeur et avance à chaque itération
		*/
	}

	cout << "\nQ16 : " << endl;
	//Q16 : Si vous permutez la ligne « - B » par ce qui suit, le fragment de code sera - t - il correct ? Si oui, que va - t - il s’afficher en sortie ?

	for (int i = 0; i < 6; i++) {
		cout << "tab[" << i << "]" << untab[i] << endl; // ligne –A-
		//cout << "unptr+" << i << "= " << *(unptr + i) << endl; // ligne –B-
		//cout << "unptr+" << i << "= " << *unptr++ << endl; // NEW ligne –B-
		cout << "unptr+" << i << "= " << *(++unptr) << endl; // ligne –B-
		// Le fragment de code est correct et il affiche les valeurs du tableau à l’aide du pointeur et avance à chaque itération 
	}


	system("pause");
	cout << "\x1B[2J\x1B[H";


	//                    Série -4-

/*
	 La fonction suppose que la destination a assez d’espace pour contenir la chaîne source. Récrivez cette fonction en n’utilisant que les pointeurs.
	 Il ne doit y avoir aucune référence aux tableaux. La signature d’une telle fonction est comme suit :

	 char *mon_strcpy(char destination*, char source*);

*/

	char nom0[15] = "Nelson Cuervo";
	char nomCopy[15];

	cout << "valeur originale de la première et de la deuxième variable  : " << "\nchar nom0[15] = " << nom0 << "\nchar nomCopy[15] = " << *nomCopy << endl;
	mon_strcpy(nomCopy, nom0);
	cout << "valeurs copiées à l'aide de la fonction avec des pointeurs  : " << "\nchar nom0[15] = " << nom0 << "\nchar nomCopy[15] = " << nomCopy << endl;




}

// **************** Exercice -2 ****************


// ***  A.)

struct complexe { float re_part, im_part; };

//void sommeComplexe(struct complexe *a, struct complexe* b) {
//
//	*a = ((a->re_part * b->im_part) - (a->im_part * b->im_part) + ( a ->re_part * b -> im_part )+ (a ->im_part * b ->re_part));
//
//}

void sommeComplexe1(struct complexe* a, struct complexe* b) {

	complexe sum;

	sum.re_part = a->re_part + b->re_part;
	sum.im_part = a->im_part + b->im_part;

	if (sum.im_part >= 0)
		cout << sum.re_part << " + " << sum.im_part << "i" << endl;
	else
		cout << sum.re_part << " - " << sum.im_part << "i" << endl;

}

// ***  B.)

struct complexe1 { float re_part1, im_part1; } cmplx, * pointeur_complexe1 = &cmplx;

void multiComplexe(float reel, struct complexe1* strcomplex) {

	strcomplex->im_part1 = reel * strcomplex->im_part1;
	strcomplex->re_part1 = reel * strcomplex->re_part1;

}

// *** DERNIÈRE PARTIE DE L'EXERCICE 2 


// fonction prenant en entrée un tableau de structures de type complexe, ainsi que sa taille, 
// et retournant une structure de type complexe correspondant à la somme des ´éléments de ce tableau.
// pour retourner la valeur de la sum et remplir la structure, nous utilisons un pointeur 

void sumArray(complexe mon_array[], struct complexe* x)
{

	for (int i = 0; i < 1/*sizeof(mon_array)*/; i++) {

		x->im_part = mon_array[i].im_part + mon_array[i + 1].im_part;
		x->re_part = mon_array[i].re_part + mon_array[i + 1].re_part;
	}

}



int main()
{

	// **************** Exercice -1 ****************

	Exercice1();

   // **************** Exercice -2 ****************

	 //  On considère la structure suivante qui permet d’encoder les nombres complexes : 



	// On demande d’implémenter et de tester les deux fonctions suivantes :

   // *** a) Une fonction prenant deux structures complexe en argument et retournant (par valeur)
   //       une structure complexe contenant la somme des deux nombres complexes ; 

	complexe c1, c2, sum;

	c1.im_part = 15;
	c1.re_part = 12.3;
	c2.im_part = 25;
	c2.re_part = 12.3;

	//sum.re_part = c1.re_part + c2.re_part;
	//sum.im_part = c1.im_part + c2.im_part;

	//if (sum.im_part >= 0)
	//	cout << sum.re_part << " + " << sum.im_part << "i" << endl;
	//else
	//	cout << sum.re_part << " - " << sum.im_part << "i" << endl;

	sommeComplexe1(&c1, &c2);

	//b) Une fonction prenant en argument un réel(flottant) ainsi qu’un pointeur sur une structure de type complexe,
	//   qui modifie le complexe contenu dans la structure en le multipliant par le réel.

	cmplx.im_part1 = 25;
	cmplx.re_part1 = 12.3;
	cout << "\nValeurs de la structure avant d'utiliser la fonction : " << endl;
	cout << "Part imaginaire : " << cmplx.im_part1 << "\nPart reel : " << cmplx.re_part1 << endl;

	float reel_multipli = 8;

	multiComplexe(reel_multipli, pointeur_complexe1);

	cout << "\nValeurs de la structure apres d'utiliser la fonction avec un pointeur de type Complexe: " << endl;
	cout << "\nStructure multiplie par : " << reel_multipli << endl;
	cout << "Part imaginaire : " << cmplx.im_part1 << "\nPart reel : " << cmplx.re_part1 << endl;

	//VÉRIFICATION DU FONCTIONNEMENT DE LA FONCTION EN DOUBLANT LA VALEUR RÉELLE DU MULTIPLICATEUR

	//multiplicateur = 2;
	//multiComplexe(reel_multipli, pointeur_complexe1);

	//cout << "\nValeurs de la structure apres d'utiliser la fonction avec un pointeur de type Complexe: " << endl;
	// cout << "\n Structure multiplie par : " << reel_multipli << endl;
	//cout << "Part imaginaire : " << cmplx.im_part1 << "\nPart reel : " << cmplx.re_part1 << endl;


	// ***  DERNIÈRE PARTIE DE L'EXERCICE 2 

	/*
	En utilisant le code développé dans la partie précédente, ´écrire et tester une fonction prenant
	en entrée un tableau de structures de type complexe, ainsi que sa taille, et retournant une
	structure de type complexe correspondant à la somme des ´éléments de ce tableau.
	*/

	complexe* point_sum = &sum;
	complexe cmplx_array[3] = { c1, c2 };

	cout << "\nSTRUCT SUM avant avant d'etre affectee par la fonction :" << endl;
	cout << "Part reel : " << sum.re_part << "\nSTRUCT SUM Part imaginaire : " << sum.im_part << "i" << endl;

	sumArray(cmplx_array, point_sum);

	cout << "\nSTRUCT SUM apres d'etre affectee par la fonction :" << endl;
	cout << "Part reel : " << sum.re_part << "\nSTRUCT SUM Part imaginaire : " << sum.im_part<<"i"<< endl;


	return 0;

}

