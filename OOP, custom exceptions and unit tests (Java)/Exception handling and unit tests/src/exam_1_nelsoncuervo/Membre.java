/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exam_1_nelsoncuervo;

import java.util.Objects;

/**
 *
 * @author Nelson
 */

/*
Créez une classe Membre qui permet de créer les membres affiliés à la ligue du
jeu en question. Chaque membre étant décrit par son nom et son sexe
*/

public class Membre {

    private String nom;
    private char sexe;

    /*Créez un constructeur d'initialisation pour la classe*/

    public Membre(String nom, char sexe) throws ExceptionSexeInconnu {
        this.nom = nom;  
      /*Le constructeur doit lever l’exception ExceptionSexeInconnu si le sexe est
      différent de M ou de F.*/
        setSexe(sexe);
    }

    
    /*Ajouter les méthodes getters, equals.*/
    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public char getSexe() {
        return sexe;
    }
    
    public void setSexe(char sexe) throws ExceptionSexeInconnu {

        char sexeU = Character.toUpperCase(sexe);

        if (sexeU == 'M' || sexeU == 'F') {
            this.sexe = sexeU;
        } else {
            throw new ExceptionSexeInconnu("Le sexe doit être M ou F !");
        }
    }

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
        final Membre other = (Membre) obj;
        if (this.sexe != other.sexe) {
            return false;
        }
        if (!Objects.equals(this.nom, other.nom)) {
            return false;
        }
        return true;
    }

}
