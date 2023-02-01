CLEAR SCREEN
PROMPT ********* Sous Menu afficher Fournisseurs et Produits *********
PROMPT 1: Procedure afficher Fournisseurs.
PROMPT 2: Procedure afficher Produits.
PROMPT 3: Retourner au menu principal.

ACCEPT selection PROMPT " Entrer option 1-3: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'Proc_affich_Fourni_test.sql'
WHEN '2' THEN 'Proc_affich_Produits_test.sql' 
WHEN '3' THEN 'Menu.sql' 

ELSE 'Menu' 
END AS script 
FROM dual; 
SET TERM ON 
PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script





/*

CLEAR SCREEN
PROMPT ********* Sous Menu requetes d’insertion dans les tables. *********


PROMPT 1: Procedure afficher Fournisseurs.
PROMPT 2: Procedure afficher Produits.
PROMPT 3: Retourner au menu principal.


ACCEPT selection PROMPT " Entrer option 1-3: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'Proc_affich_Fourni_test.sql'
WHEN '2' THEN 'Proc_affich_Produits_test.sql' 
WHEN '3' THEN 'Menu.sql' 

ELSE 'MenuVelos' 
END AS script 
FROM dual; 
SET TERM ON 
PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script

*/

/**

PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\Menu.sql
