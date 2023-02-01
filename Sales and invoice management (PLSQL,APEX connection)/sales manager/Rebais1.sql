SET SERVEROUTPUT ON
SET VERIFY OFF

PROMPT ******* UPDATE prix produit *******
ACCEPT lenofour CHAR PROMPT "Entrer le NOFOUR du produit: "

DECLARE
-- 1.Declaration VARIABLES
varNOFOUR produit.code%TYPE := '&lenom';
varAug produit.code%TYPE := '&laAug';

-- 1.Declaration CURSEUR
CURSOR Cur_produit IS SELECT code, nom, prix FROM produit
FOR UPDATE OF  prix;
Le_curseur_produit Cur_produit%ROWTYPE;


BEGIN
DBMS_OUTPUT.PUT_LINE('**** Affichage curseur avant le update ****');
FOR Affichage IN(SELECT code, nom, prix FROM produit)LOOP
	DBMS_OUTPUT.PUT_LINE(RPAD(Affichage.code,10)||RPAD(Affichage.nom,10)||Affichage.prix);
END LOOP;

--2. Ouverture du curseur
OPEN Cur_produit;
--3. Traitment du curseur (posicioner inside du curseur))
FETCH Cur_produit INTO Le_curseur_produit;
    WHILE Cur_produit%FOUND LOOP
	    IF(Le_curseur_produit.nom = varNOFOUR ) THEN
		    UPDATE produit
		    SET prix = Le_curseur_produit.prix * varAug
		    WHERE CURRENT OF Cur_produit;
        --ELSE 
          -- DBMS_OUTPUT.PUT_LINE('aucun produit n''a ete mis a jour');
		END IF;
		FETCH Cur_produit INTO Le_curseur_produit;
	END LOOP;
--COMMIT;
--4.Fermature du curseur
CLOSE Cur_produit;

--Affichage curseur FOR avec variable CURSOR 
DBMS_OUTPUT.PUT_LINE('**** Affichage curseur apres le update ****');	
FOR Affichage IN(SELECT code, nom, prix FROM produit)LOOP
	DBMS_OUTPUT.PUT_LINE(RPAD(Affichage.code,10)||RPAD(Affichage.nom,10)||Affichage.prix);
END LOOP;
END;
/

SET VERIFY OFF

