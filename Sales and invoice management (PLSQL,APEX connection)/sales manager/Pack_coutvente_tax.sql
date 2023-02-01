--creation de l entete du taxpackage

CREATE OR REPLACE PACKAGE COMPAGNIE.taxpackage AS 

-- Description: Cette fonction permet de faire calculer le cout* prix 
--Elle demande deux parametres numeriques. Elle retourne un nombre 
-- Auteurs: Nelson Cuervo
-- Date de creation: 18 aout 2022 
-- Date de modification: 18 aout 2022 
-- ** 
FUNCTION coutvente_nacc( prix  IN NUMBER ,   QUANTITESTOCK IN NUMBER) RETURN NUMBER; 
-- Description: Cette fonction permet de calculer les taxes
--Elle demande un parametre numerique. Elle retourne un nombre 
-- Auteur: Nelson Cuervo 
-- Date de creation: 18 aout 2022 
-- Date de modification: 18 aout 2022 
-- ** 
FUNCTION func_taxe(total number) RETURN NUMBER; 
END taxpackage; 
/ 

--Creation du corps du taxpackage 

CREATE OR REPLACE PACKAGE BODY COMPAGNIE.taxpackage AS
FUNCTION coutvente_nacc(prix IN NUMBER, QUANTITESTOCK IN NUMBER) RETURN NUMBER IS 
		total NUMBER; 

	BEGIN 
		total:=prix * QUANTITESTOCK; 
		RETURN (total); 
	END coutvente_nacc; 

FUNCTION func_taxe(total IN  number)RETURN NUMBER IS 
		totApresTax NUMBER; 

	BEGIN 
		totApresTax:= total+((total*15)/100);
		RETURN(totApresTax); 
	END func_taxe; 

END taxpackage; 
/