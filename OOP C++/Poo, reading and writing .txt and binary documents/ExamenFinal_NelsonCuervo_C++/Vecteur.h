#pragma once
#include <iostream>
#include <iomanip>
using namespace std;



class Vecteur {

protected:

	double x, y;

public:

	Vecteur() {}

	Vecteur(double x, double y) {

		this->x = x;
		this->y = y;
	}

	virtual void afficher(ostream&) const {
		cout << "\nX : " << this->x << "\nY : " << this->y << endl;
	}

	friend ostream& operator << (ostream& out, const Vecteur& v)
	{
		v.afficher(out);
		return out;
	}

	Vecteur& operator = (const Vecteur& v) {
		cout << "Appel l'operateur = \n";
		if (this == &v)
			return *this;
		else
		{
			x = v.x;
			y = v.y;
			return *this;
		}
	}

	//Getters
	double getX() { return this->x; }
	double getY() { return this->y; }

};


class Vecteur3d : public Vecteur {

private:
	double z;
public:

	Vecteur3d() {}

	Vecteur3d(double x, double y, double z) : Vecteur(x, y)
	{
		this->z = z;
	}

	void afficher(ostream&) const {
		cout << "\nX : " << x << "\nY : " << this->y << "\nZ : " << this->z << endl;
	}

	friend ostream& operator << (ostream& out, const Vecteur3d& v)
	{
		v.afficher(out);
		return out;
	}

	Vecteur3d& operator = (const Vecteur3d& v) {
		cout << "Appel l'operateur = \n";
		if (this == &v)
			return *this;
		else
		{
			x = v.x;
			y = v.y;
			z = v.z;
			return *this;
		}
	}

};