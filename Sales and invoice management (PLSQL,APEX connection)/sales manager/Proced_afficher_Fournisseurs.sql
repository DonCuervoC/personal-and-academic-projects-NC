-- Procedure pour afficher les NACCFOURNISSEURS
CREATE OR REPLACE PROCEDURE COMPAGNIE.affiche_fournisseurs
IS

BEGIN
--Message de table    
	DBMS_OUTPUT.PUT_LINE('***Table des fournisseurs***');
	DBMS_OUTPUT.PUT_LINE(RPAD('NOFOUR',8)||RPAD('NOMFOUR',15)||
	RPAD('NO',5)||RPAD('RUE',15)||RPAD('VILLE',15)||RPAD('CODEPOSTAL',10)||
	RPAD('TELEPHONE',10)
	);
	
--Utilisation d'un curseur FOR	
    FOR maliste IN(select * from NACCFOURNISSEURS) LOOP
        DBMS_OUTPUT.PUT_LINE(RPAD(maliste.NOFOUR,8)||RPAD(maliste.NOMFOUR,15)||
		RPAD(maliste.NO,5)||RPAD(maliste.RUE,15)||RPAD(maliste.VILLE,15)||RPAD(maliste.CODEPOSTAL,10)||
		RPAD(maliste.TELEPHONE,10));
    END LOOP;

END;
/

