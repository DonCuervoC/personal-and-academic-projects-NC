/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exam_1_nelsoncuervo;

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

/*Créez une classe de test MembreTest pour la classe Membre.*/
public class MembreTest {

    public MembreTest() {
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
    public void testConstructeur1() throws ExceptionSexeInconnu {
        System.out.println("testConstructeur1");
        //ACT
        Membre instance = new Membre("Nelson", 'M');
        String nomAttendu = "Nelson";
        char sexeAttendu = 'M';

        //Appele
        String nomReelle = instance.getNom();
        char sexeReelle = instance.getSexe();

        //Assert
        assertEquals(nomAttendu, nomReelle);
        assertEquals(sexeAttendu, sexeReelle);
    }

    @Test
    public void testConstructeur2() throws ExceptionSexeInconnu {
        System.out.println("testConstructeur2");
        //ACT
        Membre instance = new Membre("Bibiana", 'F');
        String nomAttendu = "Bibiana";
        char sexeAttendu = 'F';

        //Appele
        String nomReelle = instance.getNom();
        char sexeReelle = instance.getSexe();

        //Assert
        assertEquals(nomAttendu, nomReelle);
        assertEquals(sexeAttendu, sexeReelle);
    }

    @Test
    public void testConstructeur3() throws ExceptionSexeInconnu {
        System.out.println("testConstructeur3");
        //ACT
        Membre instance = new Membre("Adriana", 'f');
        String nomAttendu = "Adriana";
        char sexeAttendu = 'F';

        //Appele
        String nomReelle = instance.getNom();
        char sexeReelle = instance.getSexe();

        //Assert
        assertEquals(nomAttendu, nomReelle);
        assertEquals(sexeAttendu, sexeReelle);
    }

    @Test(expected = ExceptionSexeInconnu.class)
    public void testConstructeurAvecException() throws ExceptionSexeInconnu {
        System.out.println("testConstructeurAvecException");
        //ACT
        Membre instance = new Membre("Camilo", 'Z');

    }


}
