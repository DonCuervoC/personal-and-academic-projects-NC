/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exam_1_nelsoncuervo;

/**
 *
 * @author Nelson
 */

/*Créez une classe Equipe qui permet de créer des équipes de deux membres en
vue d’une compétition.*/
public class Equipe {

    Membre homme, femme;

    /*Créez un constructeur d'initialisation pour la classe.*/
    public Equipe(Membre homme, Membre femme) throws ExceptionEquipeNonConforme {

        /*Le constructeur doit lever l’exception ExceptionEquipeNonConforme si les
         deux membres sont de même sexe.*/
        if (checkEquipe(homme, femme)) {
            this.homme = homme;
            this.femme = femme;
        } else {
            throw new ExceptionEquipeNonConforme("les membres de l'équipe doivent être de genres différents !");
        }
//        if (homme.getSexe() == 'M' && femme.getSexe() == 'F') {
//            this.homme = homme;
//            this.femme = femme;
//        } else {
//            throw new ExceptionEquipeNonConforme("les membres de l'équipe doivent être de genres différents !");
//        }
    }

    public boolean checkEquipe(Membre homme, Membre femme) {

        boolean accepte;

        if (homme.getSexe() == 'M' && femme.getSexe() == 'F') {
            accepte = true;
            return accepte;
        } else {
            accepte = false;
            return accepte;
        }
    }

    /*
    Ajouter dans la classe EquipeTest, deux tests pour une méthode qui sera ajoutée
    à la classe Equipe. Cette méthode servira à remplacer un membre de l’équipe par un
    autre membre. Elle pourrait avoir la forme suivante : remplacerMembre(membre
    sortant, membre rentrant)
    */
    public void remplacerMembre(Membre sortant, Membre rentrant) throws ExceptionRemplacementNonConforme {

        System.out.println("Nom du membre sortant : " + sortant.getNom());
        System.out.println("Nom du membre entrant : " + rentrant.getNom());
        
        char sexeSortant = sortant.getSexe();
        char sexeRentrant = rentrant.getSexe();

        /*Cette exception doit être levée par
        La méthode remplacerMembre(…) si le membre sortant et le membre
        rentrant ne sont pas de même sexe, ou si le membre sortant et le membre
        rentrant sont les mêmes, ou si le membre sortant n’est pas un membre de
        l'équipe.*/
        if ((sexeSortant != sexeRentrant)) {
            System.out.println("la mise à jour n'a pas pu être effectuée ");
            throw new ExceptionRemplacementNonConforme("Le membre sortant doit être du même sexe que le membre entrant ");
        } else if (sortant.equals(rentrant)) {
            System.out.println("la mise à jour n'a pas pu être effectuée ");
            throw new ExceptionRemplacementNonConforme("Le membre sortant doit être différent du membre entrant.  ");
        }
        // vérifier que les changements d'équipement sont effectués en fonction du sexe 
        if (sexeRentrant == 'F') {
            this.femme = rentrant;
             System.out.println("Mis à jour nouveau membre : " + femme.getNom());
        } else {
            this.homme = rentrant;
            System.out.println("Mis à jour nouveau membre : " + homme.getNom());
        }     
    }

/*Ajoutez les getters et setters.*/   
    public Membre getHomme() {
        return homme;
    }

    public void setHomme(Membre homme) {
        this.homme = homme;
    }

    public Membre getFemme() {
        return femme;
    }

    public void setFemme(Membre femme) {
        this.femme = femme;
    }

}
