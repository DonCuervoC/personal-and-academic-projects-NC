SET SERVEROUTPUT ON
SET VERIFY OFF 

PROMPT ******* Facutre *******
ACCEPT LENOFOUR NUMBER PROMPT "Entrer le numero de fournisseur "

DECLARE
	varnofour COMPAGNIE.NACCPRODUITS.NOFOUR%TYPE := '&LENOFOUR';
	
	varAux COMPAGNIE.NACCPRODUITS.PRIX%TYPE :=0;
	varMontTax COMPAGNIE.NACCPRODUITS.PRIX%TYPE :=0;
	varSousTotal COMPAGNIE.NACCPRODUITS.PRIX%TYPE :=0;
	varTotal COMPAGNIE.NACCPRODUITS.PRIX%TYPE := 0;
	
	nbre NUMBER := 0;

BEGIN
	SELECT COUNT(NOFOUR) INTO nbre FROM COMPAGNIE.NACCPRODUITS WHERE COMPAGNIE.NACCPRODUITS.NOFOUR = varnofour;
	--DBMS_OUTPUT.PUT_LINE(nbre);
	IF nbre > 0 THEN
	
	DBMS_OUTPUT.PUT_LINE('-----------------------------------------------------------------------');
		FOR liste IN (select * from COMPAGNIE.NACCFOURNISSEURS 
			WHERE UPPER(NOFOUR)=UPPER(varnofour) order by NOFOUR)				
			LOOP
			DBMS_OUTPUT.PUT_LINE('NUMFOUR : '||RPAD(liste.NOFOUR,15));
			DBMS_OUTPUT.PUT_LINE('NOMFOUR : '||RPAD(liste.NOMFOUR,15));
			DBMS_OUTPUT.PUT_LINE('ADRESSE : '||RPAD(liste.NO,5)||RPAD(liste.RUE,10)||RPAD(liste.VILLE,10)||','||RPAD(liste.CODEPOSTAL,10));		
		END LOOP;
	DBMS_OUTPUT.PUT_LINE('-----------------------------------------------------------------------');
	
	DBMS_OUTPUT.PUT_LINE(RPAD('CODE PRODUIT',15)||RPAD('PRIX',20)||RPAD('QUANTITESTOCK',20)||RPAD('SOUS TOTAL',10));
		FOR maliste IN (select CODE, PRIX , QUANTITESTOCK from COMPAGNIE.NACCPRODUITS 
			WHERE UPPER(NOFOUR)=UPPER(varnofour) order by CODE)				
			LOOP
				DBMS_OUTPUT.PUT_LINE(RPAD(maliste.CODE,15)||RPAD(maliste.PRIX,20) 
				|| RPAD(maliste.QUANTITESTOCK,20)||COMPAGNIE.coutvente_nacc(maliste.PRIX,maliste.QUANTITESTOCK)
			);
			
			varAux := COMPAGNIE.coutvente_nacc(maliste.PRIX,maliste.QUANTITESTOCK);
			varSousTotal := varSousTotal + varAux;
			
		END LOOP;
		varMontTax := COMPAGNIE.tax_nacc(varSousTotal) - varSousTotal  ;		
		DBMS_OUTPUT.PUT_LINE(RPAD('TAXES <15%> :',55)||varMontTax);
		DBMS_OUTPUT.PUT_LINE(RPAD('GRAND TOTAL :',55)||COMPAGNIE.tax_nacc(varSousTotal));
	    DBMS_OUTPUT.PUT_LINE('-----------------------------------------------------------------------');
		
	ELSE	
	DBMS_OUTPUT.PUT_LINE('Le nombre de fournisseur'|| varnofour||'n''existe pas');
	DBMS_OUTPUT.PUT_LINE('Voici la liste des fournisseurs existentes : ');
	DBMS_OUTPUT.PUT_LINE(RPAD('NOFOUR',20)|| RPAD('NOMFOUR',20));
	FOR maliste IN (select NOFOUR,NOMFOUR from COMPAGNIE.NACCFOURNISSEURS  order by NOFOUR) LOOP
			DBMS_OUTPUT.PUT_LINE(RPAD(maliste.NOFOUR,20)||RPAD(maliste.NOMFOUR,20)
			);
		END LOOP;
	
	END IF;

END;
/


SET VERIFY ON

/*
	DBMS_OUTPUT.PUT_LINE('NOFOUR : '|| maliste.NOFOUR);
	DBMS_OUTPUT.PUT_LINE('NOMFOUR : '|| maliste.);
	DBMS_OUTPUT.PUT_LINE();
*/