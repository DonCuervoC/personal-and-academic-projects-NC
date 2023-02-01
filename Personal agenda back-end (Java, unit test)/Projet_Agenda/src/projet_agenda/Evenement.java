/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projet_agenda;

import java.util.Objects;

/**
 *
 * @author Nelson
 */
public class Evenement {

    String nom;
    Date debut, fin;

    public Evenement() {

    }

    public Evenement(String nom) {
        this.nom = nom;
    }

    public Evenement(String nom, Date debut, Date fin) throws ErreurEvenement {

//        if ((nom != null || nom != " ") && Objects.isNull(debut) == false && Objects.isNull(fin) == false) {
        if (ValiderDates(debut, fin) && ValiderNom(nom) && ValiderObject(debut, fin)) {
//        if (ValiderDates(debut, fin) && ValiderNom(nom) && debut != null && fin != null) {

            this.nom = nom;
            this.debut = debut;
            this.fin = fin;

        } else {
            throw new ErreurEvenement(" Merci de vérifier : \n 1. Le nom d’un évènement ne doit pas être vide.\n 2.Un évènement ne peut pas avoir une durée nulle. \n 3.La date de début doit précéder sa date de fin  !");
        }
    }

    // Methode pour valider que la date de début est précédente à la date de fin, retourne une valeur booléenne en fonction du résultat. 
    public boolean ValiderDates(Date dateDebut, Date dateFin) {

        boolean precedente;
        // somme des valeurs numériques à la date de début 
        int sumDateDebut = dateDebut.getAnnee() + dateDebut.getHeure() + dateDebut.jour + dateDebut.getMinute() + dateDebut.mois;
        // somme des valeurs numériques à la date de fin 
        int sumDateFin = dateFin.getAnnee() + dateFin.getHeure() + dateFin.jour + dateFin.getMinute() + dateFin.mois;

        if (dateDebut.equals(dateFin) || sumDateDebut > sumDateFin) {
            return precedente = false;
        } else {
            return precedente = true;
        }
    }

    // Methode validation nom 
    public boolean ValiderNom(String nom) {

        if (nom == null || nom.trim().length() == 0) {
            return false;
        } else {

            return true;
        }
    }

    // MEthode validation object not null 
    private boolean ValiderObject(Date debut, Date fin) throws NullPointerException {

        //if(debut != null && fin != null){
        if (Objects.isNull(debut) || Objects.isNull(fin)) {
            return false;
        } else {
            return true;
        }

    }

    // ********** GETTERS & SETTERS
    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public Date getDebut() {
        return debut;
    }

    public void setDebut(Date debut) {
        this.debut = debut;
    }

    public Date getFin() {
        return fin;
    }

    public void setFin(Date fin) {
        this.fin = fin;
    }

}
