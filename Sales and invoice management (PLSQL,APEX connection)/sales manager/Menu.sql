

CLEAR SCREEN
PROMPT ********* MENU PRINCIPAL *********
PROMPT ******** Bienvenue a TP FINAL  ********
PROMPT 1: Sous Menu presente les requetes d insertion dans les tables..
PROMPT 2: Sous-menu d affichages des enregistrements.
PROMPT 3: Afficher la facturation.
PROMPT 4: Rabais avec la procedure.
PROMPT 5: Sous Menu Mise a jour et suppression.
PROMPT 6: Quitter  

ACCEPT selection PROMPT " Entrer option 1-6: " 
SET TERM OFF
COLUMN script NEW_VALUE v_script 
SELECT CASE '&selection' 
WHEN '1' THEN 'sousMenuInsertioDansTables.sql'
WHEN '2' THEN 'sousMenu_Afficher_Enregistrements.sql' 
WHEN '3' THEN 'facture_courseur.sql' 
WHEN '4' THEN 'procrebais.sql' 
WHEN '5' THEN 'SousMenuUpdates.sql' 
WHEN '6' THEN 'QuitterTP.sql' 
ELSE 'Menu' 
END AS script 
FROM dual; 
SET TERM ON 
@C:\Sripts_PL_SQL_PLUS\TP_Final_NelsonCuervo\&v_script



