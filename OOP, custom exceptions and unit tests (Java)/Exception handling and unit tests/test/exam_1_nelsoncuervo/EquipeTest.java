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

/*Créez une classe de test EquipeTest pour la classe Equipe.*/
public class EquipeTest {

    Membre instance1;
    Membre instance;
    Membre instance2;

    public EquipeTest() {
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
    public void testConstructeur1() throws ExceptionSexeInconnu, ExceptionEquipeNonConforme {
        System.out.println("testConstructeur1");
        //ACT
        instance1 = new Membre("Nelson", 'M');
        instance = new Membre("Bibiana", 'F');

        Equipe equipe = new Equipe(instance1, instance);

    }

    @Test(expected = ExceptionEquipeNonConforme.class)
    public void testConstructeurAvecException() throws ExceptionEquipeNonConforme, ExceptionSexeInconnu {
        System.out.println("testConstructeurAvecException");
        //ACT
        instance1 = new Membre("Nelson", 'M');
        instance = new Membre("Samuel", 'M');

        Equipe equipe = new Equipe(instance1, instance);
    }

    @Test
    public void testRemplacerMembre() throws ExceptionEquipeNonConforme, ExceptionSexeInconnu, ExceptionRemplacementNonConforme {
        System.out.println("testRemplacerMembre");
        //ACT
        instance1 = new Membre("Nelson", 'M');
        instance = new Membre("Bibiana", 'F');
        instance2 = new Membre("Samuel", 'M');

        Equipe equipe = new Equipe(instance1, instance);
        equipe.remplacerMembre(instance1, instance2);

    }

    @Test (expected = ExceptionRemplacementNonConforme.class)
    public void testRemplacerMembreException() throws ExceptionEquipeNonConforme, ExceptionSexeInconnu, ExceptionRemplacementNonConforme {
        System.out.println("testRemplacerMembreException");
        //ACT
        instance1 = new Membre("Nelson", 'M');
        instance = new Membre("Bibiana", 'F');
        instance2 = new Membre("Samuel", 'M');

        Equipe equipe = new Equipe(instance1, instance);
        
        // membres égaux 
        //equipe.remplacerMembre(instance1, instance1);
        
        //membres de sexes différents 
        equipe.remplacerMembre(instance1, instance);

    }


}
