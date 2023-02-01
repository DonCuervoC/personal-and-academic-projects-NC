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
public class AgendaTest {

    public AgendaTest() {
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

    @Test
    public void testConstructeurAgenda() throws ErreurDate, ErreurEvenement {
        //System.out.println("testConstructeurAgenda");
        //ACT
        Agenda instance = new Agenda();
    }
    // test methode ajouter sans erreur

    @Test
    public void testAjouter() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testAjouter");

        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Evenement evenement1 = new Evenement("Test ajouter", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test ajouter 1 ", dateDebut1, dateFin1);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);

    }

    // Test methode Ajouter avec erreur
    @Test(expected = ErreurAgenda.class)
    public void testAjouterFailded() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testAjouterFailded");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Evenement evenement1 = new Evenement("Test ajouter", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test ajouter1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test ajouter1", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        // ajouter un événement à l'agenda : erreur de duplication de nom 
        agenda1.Ajouter(evenement3);

    }

    // test de la méthode de suppression sans erreur 
    @Test // (expected = ErreurAgenda.class)
    public void testSupprimer() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testSupprimer");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        // System.out.println("********* test suprimer ***********");
        agenda1.Supprimer("Test2");

    }
    // test de la méthode de suppression avec erreur 

    @Test(expected = ErreurAgenda.class)
    public void testSupprimerErreur() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testSupprimerErreur");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        // on introduit le nom d'un événement qui n'existe pas dans la liste 
        agenda1.Supprimer("T");

    }

    @Test // test de la méthode de Chercher sans erreur 
    public void testChercherEvenement() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testChercherEvenement");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);

        agenda1.ChercherEvenement(dateDebut2);

    }
    // test de la méthode de Chercher avec erreur 

    @Test(expected = ErreurAgenda.class)
    public void testChercherEvenementErreur() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("testChercherEvenementErreur");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);

        agenda1.ChercherEvenement(dateTest);

    }

    // test de la méthode de dateDebut sans erreur 
    @Test //(expected = ErreurAgenda.class)
    public void testDateDebut() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testDateDebut");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        Date stringDate = agenda1.DateDebut("Test2");
        boolean dateTrouve = dateDebut2.equals(stringDate);
        // System.out.println("Annee : " + stringDate.annee + " mois : " + stringDate.mois);
        assertEquals(true, dateTrouve);
    }

    // test de la méthode de dateDebut avec erreur 
    @Test(expected = ErreurAgenda.class)
    public void testDateDebutErreur() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testDateDebutErreur");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        Date stringDate = agenda1.DateDebut("Test44");
        boolean dateTrouve = dateDebut2.equals(stringDate);
        // System.out.println("Annee : " + stringDate.annee + " mois : " + stringDate.mois);
        //assertEquals(true, dateTrouve);
    }

    // test de la méthode de dateFin sans erreur 
    @Test //(expected = ErreurAgenda.class)
    public void testDateFin() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testDateFin");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        Date stringDate = agenda1.DateFin("Test2");
        boolean dateTrouve = dateFin2.equals(stringDate);
        // System.out.println("Annee : " + stringDate.annee + " mois : " + stringDate.mois);
        assertEquals(true, dateTrouve);
    }
    // test de la méthode de dateFin avec erreur 

    @Test(expected = ErreurAgenda.class)
    public void testDateFinErreur() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testDateFinErreur");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        // nous tapons le nom d'un événement qui n'existe pas dans la liste et provoquons une exception
        agenda1.DateFin("Test44");
        // Date stringDate = agenda1.DateFin("Test44");
        // boolean dateTrouve = dateFin2.equals(stringDate);
        // System.out.println("Annee : " + stringDate.annee + " mois : " + stringDate.mois);
        // assertEquals(true, dateTrouve);
    }

    // test de la méthode de Prevu : TRUE 
    @Test
    public void testPrevu() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testPrevu");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        agenda1.prevu("Test2");

        boolean trouve = agenda1.prevu("Test2");
        System.out.println("Événement trouvé dans la lista : " + trouve);
        assertEquals(true, trouve);
    }
    //   // test de la méthode de Prevu : FALSE

    @Test
    public void testPrevuFalse() throws ErreurDate, ErreurEvenement, ErreurAgenda {
        System.out.println("******************");
        System.out.println("testPrevuFalse");
        //                        J,  M,  A,   H,  M
        Date dateDebut = new Date(19, 1, 2023, 14, 2);
        Date dateFin = new Date(19, 1, 2023, 15, 2);

        Date dateDebut1 = new Date(19, 2, 2023, 14, 2);
        Date dateFin1 = new Date(19, 3, 2023, 15, 2);

        Date dateDebut2 = new Date(28, 4, 2023, 14, 2);
        Date dateFin2 = new Date(29, 4, 2023, 15, 2);

        Date dateTest = new Date(14, 9, 2023, 12, 30);

        Evenement evenement1 = new Evenement("Test", dateDebut, dateFin);
        Evenement evenement2 = new Evenement("Test1", dateDebut1, dateFin1);
        Evenement evenement3 = new Evenement("Test2", dateDebut2, dateFin2);

        Agenda agenda1 = new Agenda();
        agenda1.Ajouter(evenement1);
        agenda1.Ajouter(evenement2);
        agenda1.Ajouter(evenement3);
        System.out.println("******************");

        agenda1.prevu("Test2");

        boolean trouve = agenda1.prevu("Test2222");
        System.out.println("Événement trouvé dans la lista : " + trouve);
        assertEquals(false, trouve);
    }

}
