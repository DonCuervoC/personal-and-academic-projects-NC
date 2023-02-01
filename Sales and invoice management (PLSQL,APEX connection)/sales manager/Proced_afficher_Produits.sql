-- Procedure pour afficher les NACCPRODUITS
CREATE OR REPLACE PROCEDURE COMPAGNIE.affiche_produits
IS

BEGIN
--Message de table    
	DBMS_OUTPUT.PUT_LINE('***Table des produits***');
	DBMS_OUTPUT.PUT_LINE(RPAD('CODE',5)||RPAD('NOM',20)||RPAD('QUANTITESTOCK',15)||RPAD('PRIX',15)||
	RPAD('NOFOUR',5)
	);
--Utilisation d'un curseur FOR	
    FOR maliste IN(select * from NACCPRODUITS) LOOP
        DBMS_OUTPUT.PUT_LINE(RPAD(maliste.CODE,5)||RPAD(maliste.NOM,20)||RPAD(maliste.QUANTITESTOCK,15)||
		RPAD(maliste.PRIX,15)||RPAD(maliste.NOFOUR,5));
    END LOOP;

END;
/
