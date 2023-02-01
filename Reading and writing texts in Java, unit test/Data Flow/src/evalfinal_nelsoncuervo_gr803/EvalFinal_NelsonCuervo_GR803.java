/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package evalfinal_nelsoncuervo_gr803;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.StringTokenizer;

/**
 *
 * @author Nelson
 */
public class EvalFinal_NelsonCuervo_GR803 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException, IOException {
        // TODO code application logic here

        Exercice01();
        Exercice02();
        Exercice03();
        Exercice04();
    }

    /*
    Écrire un programme en Java permettant de lire les nombres à partir d'un fichier texte « entree1.txt », 
    et stocke ensuite le carré de ces nombres dans fichier texte "sortie1.txt".
     */
    static public void Exercice01() throws FileNotFoundException, IOException {

        BufferedReader entree = null;
        BufferedWriter sortie = null;

        try {

            entree = new BufferedReader(new FileReader("entree1.txt"));
            sortie = new BufferedWriter(new FileWriter("sortie1.txt"));
            //int n = Integer.parseInt(entree.readLine());
            StringTokenizer st;
            int i = 0;
            String resutat;

            while (i < 5) {

                st = new StringTokenizer(entree.readLine());
                int a = Integer.parseInt(st.nextToken());
                resutat = String.valueOf(a * 2);

                System.out.println(resutat);
                sortie.write(resutat);
                sortie.newLine();
                i++;
            }

        } catch (FileNotFoundException e) {
            System.out.println("Fichier introuvable");
        } catch (IOException e) {
            System.out.println("Impossible de lire les données");
        } finally {
            try {
                if (entree != null) {
                    entree.close();
                }
                if (entree != null) {
                    entree.close();
                }
                sortie.close();
                System.out.println("Traitement terminé!");
            } catch (IOException e) {
                System.out.println("Impossible de fermer l'un des fichiers");
            }
        }
    }

    /*
    Écrire un programme qui lit le fichier « entree2.txt » et qui recopie dans l’ordre et sur une même ligne,
    toutes les voyelles minuscules contenues dans ce fichier, dans un autre fichier nommé «voyelles.txt ». 
    Si une exception est levée, le programme doit écrire un message d'erreur et se terminer.
     */
    static public void Exercice02() throws FileNotFoundException, IOException {

        ArrayList<Character> maListe = new ArrayList<>();
        BufferedReader entree = null;
        BufferedWriter sortie = null;
        char v;
        char aux;

        try {
            entree = new BufferedReader(new FileReader("entree2.txt"));
            sortie = new BufferedWriter(new FileWriter("voyelles.txt"));

            while (entree.ready()) {
                v = (char) entree.read();
                if (v == 'a' || v == 'A') {
                    aux = v;
                    //  System.out.println(aux);
                    maListe.add(aux);
                } else if (v == 'e' || v == 'E') {
                    aux = v;
                    // System.out.println(aux);
                    maListe.add(aux);
                } else if (v == 'i' || v == 'I') {
                    aux = v;
                    // System.out.println(aux);
                    maListe.add(aux);
                } else if (v == 'o' || v == 'O') {
                    aux = v;
                    // System.out.println(aux);
                    maListe.add(aux);
                } else if (v == 'u' || v == 'U') {
                    aux = v;
                    // System.out.println(aux);
                    maListe.add(aux);
                }

            }
            entree.close();

        } catch (FileNotFoundException e) {
            System.out.println("Le fichier ne peut etre lu.");
        } catch (IOException e) {
            System.out.println("Erreur d'entree / sortie.");
        }

        char xxx;
        for (int i = 0; i < maListe.size(); i++) {
            xxx = maListe.get(i);
            sortie.write(xxx);
            sortie.newLine();
            // System.out.println(xxx);
        }

//        for (Character monChar : maListe) {
//
//            System.out.println(monChar);
//            sortie.write(monChar);
//        }
        sortie.close();
        System.out.println("Traitement terminé!");
    }

    /*
    Écrire un programme en Java permettant de lire les données à partir d'un fichier texte "entree3.txt", 
    la première ligne contient des nombres séparés par un espace.
    -3 4 2 8 9 1 -3 -8 -4 2 5 2 -8 1 23
    Trouvez les entiers distincts positifs impaires. Vous devez écrire le résultat dans le fichier de sortie "sortie3.txt".
     */
    static public void Exercice03() throws FileNotFoundException, IOException {

        ArrayList<Integer> maListe = new ArrayList<>();
        ArrayList<Integer> listPositifImpaires = new ArrayList<>();
        // ArrayList<Integer> listPositifImpaires = new ArrayList<>();

        BufferedReader entree = new BufferedReader(new FileReader("entree3.txt"));

        String ligne = entree.readLine();
        String[] nombres = ligne.split(" ");
        for (int i = 0; i < 15; i++) {
            maListe.add(Integer.parseInt(nombres[i]));
        }
        int n1;
        for (Integer nombre : maListe) {
            n1 = nombre;
            if ((n1 > 0) && (n1 % 2 != 0) && (maListe.contains(n1))) {
                if (!listPositifImpaires.contains(n1)) {
                    //System.out.println("POSITIV MA LISTE n1 :" + n1);
                    listPositifImpaires.add(n1);
                }
            }
        }

//        for (Integer nombre : listPositifImpaires) {
//
//            System.out.println("POSITIF LIST NON REPETE : " + nombre);
//        }
        EcrireFichier(listPositifImpaires);
    }

    public static void EcrireFichier(ArrayList<Integer> list) throws IOException {
        //Ouverture du flux de sortie                
        BufferedWriter sortie = null;
        try {
            sortie = new BufferedWriter(new FileWriter("sortie3.txt"));
        } catch (IOException ex) {
            System.out.println(ex.getMessage());
        }

        for (Integer chiffre : list) {
            String lechiffre = String.valueOf(chiffre);
            sortie.write(lechiffre + " ");
        }
        sortie.close();
        System.out.println("Traitement terminé!");
    }

    /*
    Écrire une méthode nommée selectionner qui prend en paramètre un entier représentant le mois d’une date. 
    Votre méthode doit lire le fichier dates.txt (qui contient une date par ligne) et recopier, 
    dans un fichier nommé selection.txt, toutes les dates qui ont le mois donné en paramètre.
Chaque date, dans le fichier dates.txt, est écrite sous le format AAAAMMJJ,
    mais il peut y avoir des espaces superflues avant ou après la date. Au moment de la recopie, 
    votre méthode doit enlever ces espaces superflues.
     */
    public static void Exercice04() throws IOException {

        int nombre = 4;
        selectionner(nombre);
    }

    public static void selectionner(int nombre) throws FileNotFoundException, IOException {

        BufferedReader br = new BufferedReader(new FileReader("dates.txt"));
        BufferedWriter bw = new BufferedWriter(new FileWriter("selection.txt"));
        int i = 0;
        int stringSize;
        String line;
        char ch1, ch2;
        int aux1, aux2, aux3;

        while (i < 10) {

            StringTokenizer st = new StringTokenizer(br.readLine());
            line = st.nextToken();
            stringSize = line.length();

            ch1 = line.charAt(4);
            ch2 = line.charAt(5);

            aux1 = Character.getNumericValue(ch1);
            aux2 = Character.getNumericValue(ch2);

            aux3 = aux1 + aux2;
            //System.out.println(aux3);
            if (aux3 == nombre) {
                bw.write(line);
                bw.newLine();
            }
            i++;
        }
        br.close();
        bw.close();
    }

}
