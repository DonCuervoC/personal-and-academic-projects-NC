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
public class DateTest {

    public DateTest() {
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

    // Test constructeur: validation #1 a implementer ok 
    @Test
    public void testConstructeurValidation1() throws ErreurDate {
        System.out.println("testConstructeurValidation1 # 1");
        //                        J, M,   A,   H,  M
        Date instance = new Date(31, 12, 2023, 23, 59);
    }

    // Test est constructeur: validation #1 a implementer avec Erreur (jour = 31, jour est inclus entre 1 et 31 si mois égale à 1, 3, 5, 7, 8, 10 ou 12.)
    @Test(expected = ErreurDate.class)
    public void testConstructeurValidation1Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation1 # 1 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 4, 2023, 23, 59);
    }

    // Test constructeur: validation #2 a implementer ok 
    @Test
    public void testConstructeurValidation2() throws ErreurDate {
        System.out.println("testConstructeurValidation2 # 2");
        //                        J, M,   A,  H,  M
        Date instance = new Date(30, 4, 2023, 23, 59);
    }
    
    // Test est constructeur: validation #2 a implementer avec Erreur 
    //(jour = 31, jour est inclus entre 1 et 30 si mois égale à 4, 6, 9 ou 11.)
    @Test (expected = ErreurDate.class)
    public void testConstructeurValidation2Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation2 # 2 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 4, 2023, 23, 59);
    }
    
    // Test constructeur: validation #3 a implementer ok 
    @Test
    public void testConstructeurValidation3() throws ErreurDate {
        System.out.println("testConstructeurValidation3 # 3");
        //                        J, M,  A,   H,  M
        Date instance = new Date(29, 2, 2024, 23, 59);
    }
    
    // Test est constructeur: validation #3 a implementer avec Erreur 
    //(jour = 31, mois = 2 ,annee = 2024, jour est inclus entre 1 et 29 si mois égale à 2 et annee est bissextile..)
    @Test (expected = ErreurDate.class)
    public void testConstructeurValidation3Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation3 # 3 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 2, 2024, 23, 59);
    }
    
        // Test constructeur: validation #4 a implementer ok 
    @Test
    public void testConstructeurValidation4() throws ErreurDate {
        System.out.println("testConstructeurValidation4 # 4");
        //                        J, M,   A,  H,  M
        Date instance = new Date(28, 2, 2023, 23, 59);
    }
    
    // Test est constructeur: validation #4 a implementer avec Erreur 
    //(jour = 29, mois = 2 ,annee = 2023, jour est inclus entre 1 et 28 si mois égale à 2 et annee n’est pas une année bissextile..)
    @Test (expected = ErreurDate.class)
    public void testConstructeurValidation4Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation4 # 4 Erreur");
        //                        J, M,  A,  H,   M
        Date instance = new Date(29, 2, 2023, 23, 59);
    }
    
    // Test constructeur: validation #5 a implementer ok 
    @Test
    public void testConstructeurValidation5() throws ErreurDate {
        System.out.println("testConstructeurValidation5 # 5");
        //                        J, M,   A,   H,  M
        Date instance = new Date(31, 12, 2023, 23, 59);
    }

    // Test est constructeur: validation #5 a implementer avec Erreur 
    //(mois = 13, mois est inclus entre 1 et 12.)
    @Test(expected = ErreurDate.class)
    public void testConstructeurValidation5Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation5 # 5 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 13, 2023, 23, 59);
    }
    
    // Test constructeur: validation #6 a implementer ok 
    @Test
    public void testConstructeurValidation6() throws ErreurDate {
        System.out.println("testConstructeurValidation6 # 6");
        //                        J, M,   A,   H,  M
        Date instance = new Date(31, 12, 2023, 23, 59);
    }

    // Test est constructeur: validation #6 a implementer avec Erreur 
    //(heure = 24, heure est inclus entre 0 et 23.)
    @Test(expected = ErreurDate.class)
    public void testConstructeurValidation6Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation6 # 6 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 4, 2023, 24, 59);
    }
    

    // Test est constructeur: validation #7 a implementer avec Erreur 
    //(minute = 60, minute est inclus entre 0 et 59.)
    @Test(expected = ErreurDate.class)
    public void testConstructeurValidation7Erreur() throws ErreurDate {
        System.out.println("testConstructeurValidation7 # 7 Erreur");
        //                        J, M,   A,  H,  M
        Date instance = new Date(31, 4, 2023, 23, 60);
    }


}
