#pragma once
#include <iostream>
#include <iomanip>
using namespace std;

class Voiture {

private:

	string modele, marque, type;

public:

	Voiture(string modele, string marque, string type) {
		this->modele = modele;
		this->marque = marque;
		this->type = type;
	};

	void  afficherVoiture()  {

		cout << "\nModele : " << this->modele << "\nMarque : " << this->marque << "\nType : " << this->type << endl;
		//string info = "\nModele : " + this->modele + "\nMarque : " + this->marque + "\nType : " + this->type;
		//return info;	
	}

	string getModele() const { return modele; }
	string getMarque() const { return marque; }
	string getType() const { return type; }


};
