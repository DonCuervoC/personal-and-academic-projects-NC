
CREATE OR REPLACE PROCEDURE COMPAGNIE.Rebais_NACC
IS

SET SERVEROUTPUT ON

DECLARE

-- 1.Declaration
CURSOR cur_rebais IS SELECT * FROM COMPAGNIE.NACCPRODUITS
FOR UPDATE OF  COMPAGNIE.NACCPRODUITS.PRIX;
Le_curseur_rebais cur_rebais%ROWTYPE;


BEGIN

--2. Ouverture du curseur
OPEN cur_rebais;
--3. Traitment du curseur (posicioner inside du curseur))
FETCH cur_rebais INTO Le_curseur_rebais;
    WHILE cur_rebais%FOUND LOOP
	    IF(Le_curseur_rebais.PRIX <= 1000) THEN
		    UPDATE COMPAGNIE.NACCPRODUITS
		    SET COMPAGNIE.NACCPRODUITS.PRIX = Le_curseur_rebais.prix - ( Le_curseur_rebais.prix * 5)/100);	
		    WHERE CURRENT OF cur_rebais;
			
	    ELSIF(Le_curseur_rebais.PRIX BETWEEN 1001 AND 5000) THEN
		    UPDATE COMPAGNIE.NACCPRODUITS
		    SET COMPAGNIE.NACCPRODUITS.PRIX = Le_curseur_rebais.prix - ( Le_curseur_rebais.prix * 10)/100);
			WHERE CURRENT OF cur_rebais;
			
        ELSIF(Le_curseur_rebais.PRIX  = 5000) THEN
		    UPDATE COMPAGNIE.NACCPRODUITS
		    SET COMPAGNIE.NACCPRODUITS.PRIX = Le_curseur_rebais.prix - ( Le_curseur_rebais.prix * 15)/100);
		    WHERE CURRENT OF cur_rebais;
			
		END IF;
		FETCH cur_rebais INTO Le_curseur_rebais;
	END LOOP;
--COMMIT;
--4.Fermature du curseur
	CLOSE cur_rebais;

--Affichage curseur FOR avec variable CURSOR 
/*
DBMS_OUTPUT.PUT_LINE('**** Affichage curseur apres le update ****');	
FOR Affichage IN(SELECT code, nom, prix FROM COMPAGNIE.NACCPRODUITS )LOOP
	DBMS_OUTPUT.PUT_LINE(RPAD(Affichage.code,10)||RPAD(Affichage.nom,10)||Affichage.prix);
END LOOP;
*/
END;
/


/*


SET VERIFY OFF



	FOR liste IN (select * from COMPAGNIE.NACCPRODUITS)
	LOOP
			
		IF(liste.PRIX <= 1000) THEN 
			UPDATE COMPAGNIE.NACCPRODUITS 
			SET COMPAGNIE.NACCPRODUITS.PRIX = COMPAGNIE.NACCPRODUITS.PRIX - (COMPAGNIE.NACCPRODUITS.PRIX * 5)/100);
		END IF;
		
		ELSIF(liste.PRIX BETWEEN 1001 AND 5000 ) THEN 
			UPDATE COMPAGNIE.NACCPRODUITS 
			SET COMPAGNIE.NACCPRODUITS.PRIX = COMPAGNIE.NACCPRODUITS.PRIX - (COMPAGNIE.NACCPRODUITS.PRIX * 10)/100);
		END IF;
		
		ELSIF(liste.PRIX > 5000 ) THEN 
			UPDATE COMPAGNIE.NACCPRODUITS 
			SET COMPAGNIE.NACCPRODUITS.PRIX = COMPAGNIE.NACCPRODUITS.PRIX - (COMPAGNIE.NACCPRODUITS.PRIX * 15)/100);	
		END IF;
		
	END LOOP;

*/