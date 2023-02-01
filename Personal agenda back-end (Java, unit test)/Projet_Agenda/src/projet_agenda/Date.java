/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projet_agenda;

/**
 *
 * @author Nelson
 */
public class Date {

    int jour, mois, annee, heure, minute;
    String messageErreur = "veuillez respecter le format du jour :"
            + " \n 1. jour est inclus entre 1 et 31 si mois égale à 1, 3, 5, 7, 8, 10 ou 12."
            + " \n 2. jour est inclus entre 1 et 30 si mois égale à 4, 6, 9 ou 11."
            + " \n 3. jour est inclus entre 1 et 29 si mois égale à 2 et annee est bissextile."
            + " \n 4. jour est inclus entre 1 et 28 si mois égale à 2 et annee n’est pas une année bissextile.";

    //Empty Coinstructor
    public Date() {
    }


    //Constructor with parameters and verifications
    public Date(int jour, int mois, int annee, int heure, int minute) throws ErreurDate {

        int verifierDate = jour + mois + annee + heure + minute;

        if (verifierDate > 2024) {

            // jour est inclus entre 1 et 31 si mois égale à 1, 3, 5, 7, 8, 10 ou 12.
            if ((mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12) && (jour >= 1 && jour <= 31)) {
                this.jour = jour;

                //jour est inclus entre 1 et 30 si mois égale à 4, 6, 9 ou 11.
            } else if ((mois == 4 || mois == 6 || mois == 9 || mois == 11) && (jour >= 1 && jour <= 30)) {
                this.jour = jour;

                // jour est inclus entre 1 et 29 si mois égale à 2 et annee est bissextile.
            } else if ((mois == 2 && isBissextite(annee)) && (jour >= 1 && jour <= 29)) {
                this.jour = jour;

                // jour est inclus entre 1 et 28 si mois égale à 2 et annee n’est pas une année bissextile.
            } else if ((mois == 2 && isBissextite(annee) == false) && (jour >= 1 && jour <= 28)) {
                this.jour = jour;

            } else {
                throw new ErreurDate(messageErreur);
            }

            // mois est inclus entre 1 et 12.
            if (mois >= 1 && mois <= 12) {

                this.mois = mois;
            } else {
                throw new ErreurDate("veuillez respecter le format du mois :"
                        + " \n 1. mois est inclus entre 1 et 12. ");
            }

            // heure est inclus entre 0 et 23.
            if (heure >= 0 && heure <= 23) {
                this.heure = heure;
            } else {
                throw new ErreurDate("veuillez respecter le format du heure :"
                        + " \n 1. heure est inclus entre 0 et 23. ");
            }

            if (annee >= 2022) {
                this.annee = annee;
            } else {
                throw new ErreurDate(" l'année doit être postérieure ou égale à 2022 ");
            }

            // minute est inclus entre 0 et 59.
            if (minute >= 0 && minute <= 59) {
                this.minute = minute;
            } else {
                throw new ErreurDate("veuillez respecter le format du minute :"
                        + " \n 1. minute est inclus entre 0 et 59.. ");
            }
        } else {
            throw new ErreurDate("date doit être postérieure au 1er janvier 2022, 0h00 !");
        }
    }

    // **** GETTERS
    public int getJour() {
        return jour;
    }

    public int getMois() {
        return mois;
    }

    public int getAnnee() {
        return annee;
    }

    public int getHeure() {
        return heure;
    }

    public int getMinute() {
        return minute;
    }

    // **** SETTERS
    public void setMinute(int minute) {
        this.minute = minute;
    }

    public void setHeure(int heure) {
        this.heure = heure;
    }

    public void setAnnee(int annee) {
        this.annee = annee;
    }

    public void setMois(int mois) {
        this.mois = mois;
    }

    public void setJour(int jour) {
        this.jour = jour;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        return hash;
    }

    // *** Methos overrided : Compare two objects Dates type
    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Date other = (Date) obj;
        if (this.jour != other.jour) {
            return false;
        }
        if (this.mois != other.mois) {
            return false;
        }
        if (this.annee != other.annee) {
            return false;
        }
        if (this.heure != other.heure) {
            return false;
        }
        if (this.minute != other.minute) {
            return false;
        }
        return true;
    }

    private boolean isBissextite(int annee) {

        if (annee % 4 == 0 && annee % 100 != 0 || annee % 400 == 0) {
            return true;
        }
        return false;
    }

}
