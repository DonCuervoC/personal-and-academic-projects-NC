CLEAR SCREEN
PROMPT ********* Sous Menu requetes d’insertion dans les tables *********

PROMPT 1: Insertion des fournisseurs.
PROMPT 2: Insertion des produits.
PROMPT 3: Menu Principal.

ACCEPT selection PROMPT " Entrer option 1-3: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'insert_naccFournisseurs.sql'
WHEN '2' THEN 'Insert_naccproduits.sql' 
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


PROMPT 1: Insertion des fournisseurs.
PROMPT 2: Insertion des produits.
PROMPT 3: Menu Principal.


ACCEPT selection PROMPT " Entrer option 1-3: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'insert_naccFournisseurs.sql'
WHEN '2' THEN 'Insert_naccproduits.sql' 
WHEN '3' THEN 'Menu.sql' 

ELSE 'Menu' 
END AS script 
FROM dual; 
SET TERM ON 
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script
*/

/**

PAUSE "Appuyer sur une touche pour continuer..."
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\Menu.sql

*/