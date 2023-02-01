--Creation de l;ebtete de package_afficher_prod_fourni
CREATE OR REPLACE PACKAGE COMPAGNIE.package_afficher_prod_fourni AS

	PROCEDURE affiche_fournisseurs;	
	PROCEDURE affiche_produits;
	
END package_afficher_prod_fourni;
/

--Creation de l'entete de package_afficher_prod_fourni
CREATE OR REPLACE PACKAGE BODY COMPAGNIE.package_afficher_prod_fourni AS

	PROCEDURE affiche_fournisseurs IS
	BEGIN
	DBMS_OUTPUT.PUT_LINE('***Table des fournisseurs***');
	DBMS_OUTPUT.PUT_LINE(RPAD('NOFOUR',8)||RPAD('NOMFOUR',15)||
	RPAD('NO',5)||RPAD('RUE',15)||RPAD('VILLE',15)||RPAD('CODEPOSTAL',10)||
	RPAD('TELEPHONE',10)
	);
	
    FOR maliste IN(select * from NACCFOURNISSEURS) LOOP
        DBMS_OUTPUT.PUT_LINE(RPAD(maliste.NOFOUR,8)||RPAD(maliste.NOMFOUR,15)||
		RPAD(maliste.NO,5)||RPAD(maliste.RUE,15)||RPAD(maliste.VILLE,15)||RPAD(maliste.CODEPOSTAL,10)||
		RPAD(maliste.TELEPHONE,10));
    END LOOP;
	END affiche_fournisseurs;
	
	PROCEDURE affiche_produits IS
	BEGIN
	DBMS_OUTPUT.PUT_LINE('***Table des produits***');
	DBMS_OUTPUT.PUT_LINE(RPAD('CODE',5)||RPAD('NOM',20)||RPAD('QUANTITESTOCK',15)||RPAD('PRIX',15)||
	RPAD('NOFOUR',5)
	);
	--Utilisation d'un curseur FOR
    FOR maliste IN(select * from NACCPRODUITS) LOOP
        DBMS_OUTPUT.PUT_LINE(RPAD(maliste.CODE,5)||RPAD(maliste.NOM,20)||RPAD(maliste.QUANTITESTOCK,15)||
		RPAD(maliste.PRIX,15)||RPAD(maliste.NOFOUR,5));
    END LOOP;
	END	affiche_produits;
	
END package_afficher_prod_fourni;
/



	
--Utilisation d'un curseur FOR	
