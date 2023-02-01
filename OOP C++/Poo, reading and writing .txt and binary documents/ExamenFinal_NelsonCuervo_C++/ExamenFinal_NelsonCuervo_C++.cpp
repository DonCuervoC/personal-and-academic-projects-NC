// ExamenFinal_NelsonCuervo_C++.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <fstream>
#include <iomanip>
#include "Vecteur.h"
#include "Voiture.h"
#include <list>
using namespace std;


void Exercice1() {


	Vecteur v1 = Vecteur(5, 5);
	Vecteur v2 = Vecteur(10, 10);
	Vecteur v3;

	cout << "Vecteur V1 : \n";
	cout << v1 << endl;

	cout << "Vecteur V2 : \n";
	cout << v2 << endl;

	cout << "Vecteur V3 avant la surcharge d'operateur (=) va afficher seulement son adresse en memoire  \n";
	cout << v3 << endl;


	cout << "Surcharge de l'operateur = (v3 = v2)" << endl;
	v3 = v2;
	cout << "Vecteur v3 : \n";
	cout << v3 << endl;


	cout << "**************  VECTEUR 3D **************" << endl;

	Vecteur3d v3d1 = Vecteur3d(5, 5, 5);
	Vecteur3d v3d2 = Vecteur3d(5, 10, 15);
	Vecteur3d v3d3;

	cout << "Vecteur3d v3d1 : \n";
	cout << v3d1 << endl;

	cout << "Vecteur3d v3d2 : \n";
	cout << v3d2 << endl;

	cout << "Vecteur v3d3 avant la surcharge d'operateur (=) va afficher seulement son adresse en memoire  \n";
	cout << v3d3 << endl;


	cout << "Surcharge de l'operateur = (v3d3 = v3d2)" << endl;
	v3d3 = v3d2;
	cout << "Vecteur3d v3d3 : \n";
	cout << v3d3 << endl;


}

void afficherListe(list<Voiture> liste, const char* message) {

	int compteur = 0;

	if (liste.size() == 0)
		cout << message << " est vide\n";
	else
	{
		cout << "Contenue de : " << message << endl;

		for (list<Voiture>::const_iterator il = liste.begin(); il != liste.end(); il++) {
			cout << "\nVouture trouvee # : " << (compteur + 1) << endl;
			cout << "Type   : " << il->getType() << endl;
			cout << "Marque : " << il->getMarque() << endl;
			cout << "Modele : " << il->getModele() << endl;
			compteur++;
		}
		cout << "\nNombre de voitures dans la liste : " << compteur << endl;
	}
}

void  AfficherType(const list<Voiture>& liste, string typeVoulu, const char* message)
{

	int compteur = 0;

	if (liste.size() == 0)
		cout << message << " est vide\n";
	else
	{
		for (list<Voiture>::const_iterator il = liste.begin(); il != liste.end(); il++)
			if (il->getType() == typeVoulu)
			{
				++compteur;

				cout << "\nVouture trouvee # : " << compteur << endl;
				cout << "Type   : " << il->getType() << endl;
				cout << "Marque : " << il->getMarque() << endl;
				cout << "Modele : " << il->getModele() << endl;
			}
	}
	cout << "\nNombre total de voitures de type " << "<<" << typeVoulu << ">>" << " trouves avec les donnees saisies = " << compteur << endl;
}

void AfficherModele(const list<Voiture>& liste, string modeleVoulu, const char* message)
{
	int compteur = 0;

	if (liste.size() == 0)
		cout << message << " est vide\n";
	else
	{
		for (list<Voiture>::const_iterator il = liste.begin(); il != liste.end(); il++)
			if (il->getModele() == modeleVoulu)
			{
				++compteur;

				cout << "\nVouture trouvee # : " << compteur << endl;
				cout << "Modele : " << il->getModele() << endl;
				cout << "Marque : " << il->getMarque() << endl;
				cout << "Type   : " << il->getType() << endl;
			}
	}
	cout << "\nNombre total de voitures de type " << "<<" << modeleVoulu << ">>" << " trouves avec les donnees saisies = " << compteur << endl;
}

void Exercice2() {

	int tailleList = 0;
	list<Voiture> ListVoiture;

	Voiture v1 = Voiture("X", "Tesla", "Electrique");
	Voiture v2 = Voiture("Raw", "Toyota", "Hybride");
	Voiture v3 = Voiture("Jetta", "Volkswagen", "Essence");
	Voiture v4 = Voiture("Id4", "Volkswagen", "Electrique");
	Voiture v5 = Voiture("E-tron", "Audi", "Hybride");
	Voiture v6 = Voiture("CR-V", "Honda", "Essence");


	// 1.	Afficher l’ensemble des voitures
	afficherListe(ListVoiture, "Liste Voitures avant inserer des elements");

	ListVoiture.insert(ListVoiture.end(), v1);
	ListVoiture.insert(ListVoiture.end(), v2);
	ListVoiture.insert(ListVoiture.end(), v3);
	ListVoiture.insert(ListVoiture.end(), v4);
	ListVoiture.insert(ListVoiture.end(), v5);
	ListVoiture.insert(ListVoiture.end(), v6);

	// 1.	Afficher l’ensemble des voitures
	afficherListe(ListVoiture, "Liste Voitures apres inserer des elements");

	//2.	Afficher la première et la dernière voiture.

	Voiture v01 = ListVoiture.front();
	Voiture v02 = ListVoiture.back();

	cout << "\nPremier element de la liste Voiture : " << endl;
	v01.afficherVoiture();
	cout << "\nDernier element de la liste Voiture : " << endl;
	v02.afficherVoiture();


	// 3.	Afficher les voitures selon leurs types.
	AfficherType(ListVoiture, "Electrique", "Liste Voiture");

	//4.	Afficher les voitures selon leurs modèles.
	AfficherModele(ListVoiture, "X", "Liste modele X ");
	//AfficherModele(ListVoiture, "Raw", "Liste modele Raw ");
	//AfficherModele(ListVoiture, "Jetta", "Liste modele Jetta ");
	//AfficherModele(ListVoiture, "Id4", "Liste modele Id4 ");
	//AfficherModele(ListVoiture, "E-tron", "Liste modele E-tron ");
	//AfficherModele(ListVoiture, "CR-V", "Liste modele CR-V ");


}

void creerFichier(const char* nomFich, int max, int mult) {

	string message = "multiples de : ";

	ofstream f(nomFich);

	if (!f.is_open())
		cout << "Impossible d'ouvrir le fichier en écriture !" << endl;
	else
	{
		f << message << mult << endl;

		for (int i = 0; i < max; i++) {
			if (i % mult == 0) {

				f << i << endl;
			}
		}
	}
	f.close();
}

void lireMultiples(const char* nomFich, int mult) {



	ofstream f(nomFich);

	if (!f.is_open()) {
		cout << "Impossible d'ouvrir le fichier en lecture !" << endl;
		exit(-1);
	}
	else {

		

		for (int i = 0; i < 100; i++) {
			if (i % mult == 0) {
				f << i << endl;
				cout << i << endl;
			}
		}
	}

	f.close();
	
}


void Exercice3() {

	/*
	Écrivez une méthode et son appel pour créer un fichier texte des entiers entre 1 et 100
	qui sont des multiples de 3 dont le nom est "Multip3.text".
	*/

	creerFichier("Multip3.txt", 100, 3);

	//a)	les multiples de 9  qui se trouvent dans ce fichier.

	cout << "\nNombres multiples de 9 dans le fichier <<Multip3.txt>> : " << endl;
	lireMultiples("Multip3.txt", 9);

	cout << "\nNombres multiples de 6 dans le fichier <<Multip3.txt>> : " << endl;
	//b)	les multiples de 6  qui se trouvent dans ce fichier.
	lireMultiples("Multip3.txt", 6);


}

int main()
{
	//Exercice1();
	//Exercice2();
	Exercice3();

	return 0;
}

