/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projet_agenda;

import java.util.ArrayList;
import java.util.Objects;

/**
 *
 * @author Nelson
 */
public class Agenda {

    ArrayList<Evenement> listEvenements = new ArrayList<Evenement>();

    // Constructor
    public Agenda() throws ErreurDate, ErreurEvenement {

        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(14, 9, 2023, 14, 2);
        Date dateFin = new Date(15, 9, 2023, 15, 2);
        Evenement monEvenement = new Evenement("TestNelson", dateDebut, dateFin);
        listEvenements.add(monEvenement);

    }

    // Fonction TEST parcourir liste evenements
    public void parcourirListe(Evenement e) {

        int i = 0;
        Date dateEntree = e.debut;
        for (Evenement evenement : listEvenements) {
            if ((e.nom == evenement.nom) || (dateEntree.equals(evenement.debut))) {
                i++;
            }
        }
        if (i > 1) {
            System.out.println("Elemento existente");
        } else {
            System.out.println("Elemento inexistente");
        }
    }

    //Method ajouter
    public boolean Ajouter(Evenement e) throws ErreurAgenda {

        int i = 0;
        boolean evenementAjoute;
        Date dateEntree = e.debut;

        for (Evenement evenement : listEvenements) {
            //dateTest = evenement.getDebut();
            if ((e.nom == evenement.nom) || (dateEntree.equals(evenement.debut))) {
                i++;
            }
        }

        if (i >= 1) {
            throw new ErreurAgenda("duplication de l'information, vérifiez le nom et les dates de l'événement.");
        } else {
            System.out.println("*******************************************");
            System.out.println("Événement : " + e.getNom() + " a été ajouté à la liste ");
            listEvenements.add(e);
            evenementAjoute = true;
            return evenementAjoute;
        }
    }

//Méthode de suppression qui reçoit une valeur de type chaîne, recherche dans la liste et supprime l'objet qui
//correspond à la valeur saisie, s'il n'y a pas de correspondance elle renvoie une erreur. 
    public boolean Supprimer(String nom) throws ErreurAgenda {

        boolean supprime = false;
        Evenement ev1;
        int aux = 0;

        for (int i = 0; i < listEvenements.size(); i++) {
            ev1 = listEvenements.get(i);
            if (ev1.getNom() == nom) {
                listEvenements.remove(i);
                System.out.println("Événement : '" + ev1.getNom() + "' a été retiré de l'agenda");
                ++aux;
                supprime = true;
            }
        }
        if (aux == 0) {
            throw new ErreurAgenda("Aucun événement ne correspondant au nom saisi a été trouvé.");
        }
        return supprime;
    }

    //MEthode chercher evenement : chercher quel évènement a lieu à une date donnée
    public String ChercherEvenement(Date d) throws ErreurAgenda {

        Evenement evTrouve;
        String message = "veuillez vérifier la date de début correcte de l'événement que vous recherchez.";
        int i = 0;
        int aux = 0;
        Date dateCherche;

        for (Evenement evenement : listEvenements) {
            dateCherche = evenement.debut;
            i++;
            if (dateCherche.equals(d)) {
                aux = i;
                evTrouve = evenement;
                message = "L'événement " + evTrouve.getNom() + " a été trouvé à la position " + (aux - 1) + " de la liste. ";
            }
        }
        if (aux == 0) {
            throw new ErreurAgenda("Aucun événement ne correspond a la date saisi.");
        }
        return message;
    }

    // Methode de TEST rechercher par nom : reçoit un String, recherche dans la liste et affiche les résultats. 
    public void chercherParNom(String nom) {

        Evenement ev1 = new Evenement();
        //ev1.setNom(nom);
        for (int i = 0; i < listEvenements.size(); i++) {
            ev1 = listEvenements.get(i);

            if (ev1.getNom() == nom) {
                System.out.println("Événement : '" + ev1.getNom() + "' a été trouvé dans la position " + i + " de la Agenda");
            } else {
                System.out.println("événement non trouvé /nVoici la liste de vos événements actuels :  ");
                for (int j = 0; j < listEvenements.size(); j++) {
                    ev1 = listEvenements.get(j);
                    System.out.println(ev1.getNom());
                }
            }
        }
    }

    // Method date debut
    public Date DateDebut(String nom) throws ErreurAgenda {
        Evenement ev1;
        Date dt = new Date();
        int k = 0;

        for (int i = 0; i < listEvenements.size(); i++) {
            ev1 = listEvenements.get(i);
            if (ev1.getNom() == nom) {
                // s'il est trouvé, nous utilisons get debut pour renvoyer les paramètres de date entrés dans l'événement. 
                dt = ev1.getDebut();
                k++;
                System.out.println("Événement : '" + ev1.getNom() + "' a été trouvé dans la position " + i + " de la Agenda");
                System.out.println(" Date de début de l'événement : "
                        + "\n Année : " + dt.getAnnee()
                        + "\n" + " Mois : " + dt.getMois()
                        + "\n" + " Jour : " + dt.getJour()
                        + "\n" + " Heure : " + dt.getHeure() + " heures " + dt.getMinute() + " minutes");
            }
        }
        if (k == 0) {
            System.out.println("événement non trouvé \n Voici la liste de vos événements actuels :  ");
            for (int j = 0; j < listEvenements.size(); j++) {
                ev1 = listEvenements.get(j);
                System.out.println(ev1.getNom());
            }
            throw new ErreurAgenda("ERREUR : Aucun événement ne correspond a la date saisi.");
        }
        return dt;
    }

//Method date fin
    public Date DateFin(String nom) throws ErreurAgenda {

        Evenement ev1 = new Evenement();
        Date dt = new Date();
        int k = 0;

        for (int i = 0; i < listEvenements.size(); i++) {
            ev1 = listEvenements.get(i);
            if (ev1.getNom() == nom) {
                // s'il est trouvé, nous utilisons get fin pour renvoyer les paramètres de date entrés dans l'événement. 
                dt = ev1.getFin();
                k++;
                System.out.println("Événement : '" + ev1.getNom() + "' a été trouvé dans la position " + i + " de la Agenda");
                System.out.println("Date de début de l'événement : "
                        + "\n Année : " + dt.getAnnee()
                        + "\n" + " Mois : " + dt.getMois()
                        + "\n" + " Jour : " + dt.getJour()
                        + "\n" + " Heure : " + dt.getHeure() + " heures " + dt.getMinute() + " minutes");
            }
        }

        if (k == 0) {
            System.out.println("événement non trouvé \n Voici la liste de vos événements actuels :  ");
            for (int j = 0; j < listEvenements.size(); j++) {
                ev1 = listEvenements.get(j);
                System.out.println(ev1.getNom());
            }
            throw new ErreurAgenda("ERREUR : Aucun événement ne correspond a la date saisi.");
        }
        return dt;
    }

    public boolean prevu(String nom) throws ErreurAgenda {

        boolean dateTrouve = false;
        int i = 0;

        for (Evenement evenement : listEvenements) {
            if (evenement.getNom() == nom) {
                i++;
            }
        }
        if (i >= 1) {
            dateTrouve = true;
        }     
        return dateTrouve;
    }
}
