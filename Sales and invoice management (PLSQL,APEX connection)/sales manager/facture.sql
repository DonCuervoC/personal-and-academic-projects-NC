SET SERVEROUTPUT ON
SET VERIFY OFF


PROMPT ******* Facutre *******
ACCEPT lenofour NUMBER PROMPT "Entrer le numero de fournisseur "



Declare
--1.Declatarion
CURSOR cur_facture IS SELECT CODE, PRIX , QUANTITESTOCK,NOFOUR FROM COMPAGNIE.NACCPRODUITS;

varnofour COMPAGNIE.NACCPRODUITS.NOFOUR%TYPE := '&lenofour';

le_curseur_facture cur_facture%ROWTYPE;

varAux COMPAGNIE.NACCPRODUITS.PRIX%TYPE :=0;
varSousTotal COMPAGNIE.NACCPRODUITS.PRIX%TYPE :=0;
varTotal COMPAGNIE.NACCPRODUITS.PRIX%TYPE := 0;

BEGIN


--2. Ouverture du curseur
    IF NOT cur_facture%ISOPEN THEN 
        OPEN cur_facture;
    END IF;
--3. Traitement du curseur
    FETCH cur_facture INTO le_curseur_facture;	
	IF cur_facture%NOTFOUND THEN 
	    DBMS_OUTPUT.PUT_LINE('Aucune donne trouvee!');
	ELSE
		
	--Affichage facture
    DBMS_OUTPUT.PUT_LINE(RPAD('CODE PRODUIT',15)||RPAD('PRIX',10)||RPAD('QUANTITESTOCK',20)||RPAD('SOUS TOTAL',10));		 
	WHILE cur_facture%FOUND LOOP 

	    IF (le_curseur_facture.NOFOUR = varnofour) THEN		
	
				DBMS_OUTPUT.PUT_LINE(RPAD(le_curseur_facture.CODE,15)||RPAD(le_curseur_facture.PRIX,10)||
				RPAD(le_curseur_facture.QUANTITESTOCK,20)|| 
				COMPAGNIE.coutvente_nacc(le_curseur_facture.PRIX,le_curseur_facture.QUANTITESTOCK));
			
				varAux := COMPAGNIE.coutvente_nacc(le_curseur_facture.PRIX,le_curseur_facture.QUANTITESTOCK);
				varSousTotal := varSousTotal + varAux;
		END IF;
		
		
			
		FETCH cur_facture INTO le_curseur_facture;
    END LOOP;
	DBMS_OUTPUT.PUT_LINE(RPAD('GRAND TOTAL :',45)||COMPAGNIE.tax_nacc(varSousTotal));
	
	END IF;

	EXCEPTION
	WHEN no_data_found THEN
		DBMS_OUTPUT.PUT_LINE('Le fournisseur n''existe pas');
	
--4. Fermateur du curseur
CLOSE cur_facture;

END;
/

SET VERIFY ON