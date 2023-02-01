SET SERVEROUTPUT ON
-- PROCEDURE POUR AFFICHER LES EMPLOYEES_GR803
CREATE OR REPLACE PROCEDURE COMPAGNIE.rebais_affiche_fournisseurs(nfour IN NUMBER)
IS

BEGIN
	--utilisation d'un courseur FOR
	FOR maliste IN (select COMPAGNIE.NACCPRODUITS.NOFOUR,COMPAGNIE.NACCPRODUITS.PRIX,COMPAGNIE.NACCPRODUITS.QUANTITESTOCK 
					FROM COMPAGNIE.NACCPRODUITS 
					WHERE COMPAGNIE.NACCPRODUITS.NOFOUR = nfour)
					LOOP
		DBMS_OUTPUT.PUT_LINE(RPAD(maliste.NOFOUR,10)||||COMPAGNIE.coutvente_nacc(maliste.PRIX,maliste.QUANTITESTOCK)
		);
	END LOOP;
		
END;


