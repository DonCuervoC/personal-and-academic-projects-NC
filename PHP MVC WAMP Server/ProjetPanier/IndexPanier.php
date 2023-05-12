<?php
// require_once("PanierManager.php");

// busco el codigo de la pagina controlador y llamo a las funciones que estan en el 
require("Controleurs/controleurs.php");

if (isset($_GET['action'])) {

    /********************************/
    if (($_GET['action'] == 'produits')) {

        if (isset($_GET['idProduit'])) {

            afficherProduit($_GET['idProduit']);
        } else {

            afficherProduits();
        }
    }
    /********************************/
    if (($_GET['action'] == 'showPanier')) {

        afficherPanier();
    }

    /********************************/
    if ((($_GET['action'] == 'ajoutPanier'))) {

        if (isset($_GET['idProduitPanier'])) {

            $nombreProduit = $_GET['nomProduitPanier'];
            $idProduit = $_GET['idProduitPanier'];
            $quantiteDisponible = $_GET['quantiteProduitPanier'];
            $prix = $_GET['prixProduitPanier'];
            $quantiSele = $_POST['quantiteSelectione'];

            addList($nombreProduit, $idProduit, $quantiteDisponible, $prix, $quantiSele);
            afficherPanier();
        }

        // else {
        //     echo "error";
        // }
    }
    /********************************/
    if ((($_GET['action'] == 'supprimerItemPanier'))) {

        $idProduitSupprimer = $_GET['idElementSupprimer'];
        $idPanierSupprim  = $_GET['idPanierSupprimer'];
        $quantite_produit   = $_GET['quantiteProd'];
        $quantiteSupprimer = $_GET['quantiteSupprimer'];

        effacerPanier($idProduitSupprimer, $idPanierSupprim, $quantite_produit, $quantiteSupprimer);
        afficherPanier();
    }
    // else {
    //     afficherProduits();
    // }
    /********************************/
    if ((($_GET['action'] == 'modifierPanier'))) {

        $idProdModif = $_GET['idProduittModifier'];
        $idPanierModif = $_GET['idPanierModifier'];
        $quantiteProduit = $_GET['quantiteProduit'];
        $quantiModif = $_POST['quantiteModifierSelectione'];

        modifierPanierAchat($idProdModif, $idPanierModif, $quantiModif, $quantiteProduit);
    }
} else {
    afficherProduits();
}
