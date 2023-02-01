-- insertion de NACCFOURNISSEURS (NOFOUR,NOMFOUR,NO,RUE,VILLE,CODEPOSTAL,TELEPHONE)

--DEBUT:: SQLPLUS  2.
SET SERVEROUTPUT ON
SET VERIFY OFF
PROMPT ******* Insertion Fournisseurs *******
ACCEPT lenofour NUMBER PROMPT "Entrer le numero du fournisseur "
ACCEPT lenomfour CHAR  PROMPT "Entrer le nom du fournisseur: "
PROMPT -
PROMPT "**Entrer information del adresse**"
ACCEPT leno CHAR  PROMPT "Entrer le numero de la rue : "
ACCEPT lerue CHAR  PROMPT "Entrer le nombre de la rue : "
ACCEPT laville CHAR  PROMPT "Entrer le nombre de la ville : "
ACCEPT lecodepostal CHAR  PROMPT "Entrer le code postal : "
PROMPT -
PROMPT "*Exemple_format_telephonique (514)654 1278*"
ACCEPT letelephone CHAR  PROMPT "Entrer le numero de telephone : "
--FIN :: SQLPLUS


-- BLOC PLSQL
DECLARE
--Affectation des valeurs SQLPLUS aux variables PLSQL  3.
varnofour COMPAGNIE.NACCFOURNISSEURS.NOFOUR%TYPE := '&lenofour';
varnomfour COMPAGNIE.NACCFOURNISSEURS.NOMFOUR%TYPE := '&lenomfour';
varno COMPAGNIE.NACCFOURNISSEURS.NO%TYPE := '&leno';
varue COMPAGNIE.NACCFOURNISSEURS.RUE%TYPE := '&lerue';
varville COMPAGNIE.NACCFOURNISSEURS.VILLE%TYPE := '&laville';
varcodepostal COMPAGNIE.NACCFOURNISSEURS.CODEPOSTAL%TYPE := '&lecodepostal';
vartelephone COMPAGNIE.NACCFOURNISSEURS.TELEPHONE%TYPE := '&letelephone';

BEGIN
-- SQL  1.  Insertion dans la table NACCFOURNISSEURS (NOFOUR,NOMFOUR,NO,RUE,VILLE,CODEPOSTAL,TELEPHONE)
INSERT 
INTO COMPAGNIE.NACCFOURNISSEURS(NOFOUR,NOMFOUR,NO,RUE,VILLE,CODEPOSTAL,TELEPHONE) 
VALUES (varnofour,varnomfour,varno,varue,varville,varcodepostal,vartelephone);
COMMIT;
DBMS_OUTPUT.PUT_LINE('Insertion du fournisseur OK!');

COMPAGNIE.affiche_fournisseurs();

EXCEPTION 
WHEN dup_val_on_index
THEN DBMS_OUTPUT.PUT_LINE('Erreur de doublon de code!');
WHEN OTHERS
THEN DBMS_OUTPUT.PUT_LINE('Une errerur s''est produite!');

END;

/
SET VERIFY ON