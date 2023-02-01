-- insertion de NACCPRODUITS (CODE,NOM,QUANTITESTOCK,PRIX,NOFOUR)

--DEBUT:: SQLPLUS  2.
SET SERVEROUTPUT ON
SET VERIFY OFF
PROMPT ******* Insertion Produits *******
ACCEPT lecode NUMBER PROMPT "Entrer le code: "
ACCEPT lenom CHAR PROMPT "Entrer le nom: "
ACCEPT laquantite NUMBER PROMPT "Entrer la quantite de stock: "
ACCEPT leprix NUMBER PROMPT "Entrer le prix: "
ACCEPT lenofour NUMBER PROMPT "Entrer le numero de fournisseur "
--FIN :: SQLPLUS

-- BLOC PLSQL
DECLARE
--Affectation des valeurs SQLPLUS aux variables PLSQL  3.
varcode COMPAGNIE.NACCPRODUITS.CODE%TYPE := '&lecode';
varnom COMPAGNIE.NACCPRODUITS.NOM%TYPE := '&lenom';
varquantite COMPAGNIE.NACCPRODUITS.QUANTITESTOCK%TYPE := '&laquantite';
varprix COMPAGNIE.NACCPRODUITS.PRIX%TYPE := '&leprix';
varnofour COMPAGNIE.NACCPRODUITS.NOFOUR%TYPE := '&lenofour';

BEGIN
-- SQL  1.  Insertion dans la table NACCPRODUITS (CODE,NOM,QUANTITESTOCK,PRIX,NOFOUR)
INSERT INTO COMPAGNIE.NACCPRODUITS(CODE,NOM,QUANTITESTOCK,PRIX,NOFOUR) 
VALUES (varcode,varnom,varquantite,varprix,varnofour);
COMMIT;
DBMS_OUTPUT.PUT_LINE('Insertion de produit OK!');

COMPAGNIE.affiche_produits();

EXCEPTION 
WHEN dup_val_on_index
THEN DBMS_OUTPUT.PUT_LINE('Erreur de doublon de code!');
/*
WHEN OTHERS
THEN DBMS_OUTPUT.PUT_LINE('Une errerur s''est produite!');
*/
END;

/
SET VERIFY ON