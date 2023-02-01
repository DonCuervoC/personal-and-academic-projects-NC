/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projet_agenda;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Nelson
 */
public class EvenementTest {

    public EvenementTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }

    //les attributs de la date de début sont inférieurs à ceux de la date de fin, respectent les règles.
    @Test
    public void testConstructeur() throws ErreurEvenement, ErreurDate {
        System.out.println("testConstructeur");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        //                      J,  M,  A,   H,  M
        Date dateFin = new Date(19, 1, 2023, 15, 2);
        Evenement instance = new Evenement("Test unitaire sans exception", dateDebut, dateFin);
        // System.out.println("les attributs de la date de début sont inférieurs à ceux de la date de fin.");
    }

    //le nom de l'attribut est saisi sans aucune valeur, raison de l'exception .
    @Test(expected = ErreurEvenement.class)
    public void testConstructeur_ExceptionNomVide() throws ErreurEvenement, ErreurDate {
        System.out.println("testConstructeur_ExceptionNomVide");
        //                        J, M,    A,  H, M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        //                      J, M,    A,  H, M
        Date dateFin = new Date(19, 1, 2023, 10, 2);
        Evenement instance = new Evenement("", dateDebut, dateFin);
       
    }

    //la instance dateDebut de type Date est initialisé à null , raison de l'exception .
    @Test(expected = ErreurEvenement.class)
    public void testConstructeur_ExceptionDureNull() throws ErreurEvenement, ErreurDate {
        System.out.println("testConstructeur_ExceptionDureNull");
        //                        J, M, A,  H, M
        Date dateDebut = new Date();
        //                      J, M,   A,  H, M
        Date dateFin = new Date(19, 1, 2023, 10, 2);
        Evenement instance = new Evenement("", dateDebut, dateFin);
       
    }

    // les deux objets contiennent les mêmes valeurs sauf pour l'heure, dans ce paramètre la date de fin est inférieure à la date de début.
    @Test(expected = ErreurEvenement.class)
    public void testConstructeur_ExceptionDatePrecedent() throws ErreurEvenement, ErreurDate {
        System.out.println("testConstructeur_ExceptionDatePrecedent");
        //                        J, M,   A,  H, M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        //                      J, M,    A,  H, M
        Date dateFin = new Date(19, 1, 2023, 10, 2);
        Evenement instance = new Evenement("Test unitaire avec exception", dateDebut, dateFin);
      
    }
    

}
