
CLEAR SCREEN
PROMPT ********* MENU UPDATE_TABLES *********

PROMPT 1: Trigger_Update Fournisseur.
PROMPT 2: Trigger_Delete Produits.
PROMPT 3: Delete_ Fournisseurs.
PROMPT 4: Delete_ DeleteProduits.
PROMPT 5: Update_ NOFOR fournisseur et Produit.
PROMPT 6: Menu Principal  

ACCEPT selection PROMPT " Entrer option 1-6: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'TRIGGERFOUR.sql'
WHEN '2' THEN 'TRIGGERPRODUIT.sql' 
WHEN '3' THEN 'DeleteFournisseur.sql' 
WHEN '4' THEN 'DeleteProduits.sql' 
WHEN '5' THEN 'Update_Fournisseur_NOFOUR.sql' 
WHEN '6' THEN 'Menu.sql' 
ELSE 'Menu' 
END AS script 
FROM dual; 
SET TERM ON 
PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script








/*CLEAR SCREEN
PROMPT ********* Sous Menu requetes d’insertion dans les tables. *********


PROMPT 1: Trigger Update Fournisseur.
PROMPT 2: Trigger Delete Produits.
PROMPT 3: Delete Fournisseurs.
PROMPT 4: Delete DeleteProduits.
PROMPT 5: Update NOFOR fournisseur et Produit.


ACCEPT selection PROMPT " Entrer option 1-5: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'TRIGGERFOUR.sql'
WHEN '2' THEN 'TRIGGERPRODUIT.sql' 
WHEN '3' THEN 'DeleteFournisseur.sql'
WHEN '4' THEN 'DeleteProduits.sql' 
WHEN '5' THEN 'Update_Fournisseur_NOFOUR.sql' 


ELSE 'MenuVelos' 
END AS script 
FROM dual; 
SET TERM ON 
PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script

*/
/*

PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\Menu.sql


*/


