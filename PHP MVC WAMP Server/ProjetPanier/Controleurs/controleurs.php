
<?php
require_once("Modeles/ProduitManager.php");
require_once("Modeles/PanierManager.php");

//******************************   PRODUITS  ****************************/

function afficherProduits()
{
    $produitManager = new ProduitManager();
    $requete = $produitManager->getProduits();

    require("vues/vueProduits.php");
}

function afficherProduit($idProduit)
{
    $bproduitManager = new ProduitManager();
    $requete = $bproduitManager->getProduit($idProduit);
    require("vues/vueProduit.php");
}

//******************************   PANIER  ****************************/

function afficherPanier()
{
    $produitManager = new PanierManager();
    $requete = $produitManager->getPanier();

    if ($requete->rowCount() > 0) {
        require("vues/vuePanier.php");
    } else {
        require("vues/erreurPanier.php");
    }
}

function addList($nombreProduit, $idProd, $quantiteDisponible, $prixP, $quantSelect)
{
    $nomPr = $nombreProduit;
    $idProduit = intval($idProd);
    $quantDispo = intval($quantiteDisponible);
    $price = intval($prixP);
    $quantiSelec = intval($quantSelect);
    $prixTotal = $quantiSelec * $price;

    $panierManager = new PanierManager();
    //$produitManager = new ProduitManager();

    $requete = $panierManager->ajouterPanier($nomPr, $idProduit, $quantDispo, $price, $quantiSelec, $prixTotal);

    //Update data base, table Produits 
    //Lorsqu’il est ajout´e au panier, la quantit´e disponible du produit diminue.
    //$produitManager->substractProduit($idProd,$quantSelect,$quantDispo);

    // echo "Nom : ". $nomPr . "</br>";
    // echo gettype($nomPr). "</br>";

    //echo "Prueba numero productos en base de datos : " . intval($prueba);

    require("vues/vuePanier.php");
}


/* L’utilisateur peut supprimer un article ou en modifier la quantit´e. La facture s’actualise */
function effacerPanier($idProduitSupprimer, $idPanierSupprim, $quantite_produit, $quantiteSupprimer)
{

    $idProduit = intval($idProduitSupprimer);
    $idPanier = intval($idPanierSupprim);
    $quantDisponible = intval($quantite_produit);
    $ajoutQuantite = intval($quantiteSupprimer);

    $panierManager = new PanierManager();
    $produitManager = new ProduitManager();

    //retourner les quantités du produit sélectionné dans le tableau des produits
    $produitManager->insererProduit($idProduit, $ajoutQuantite, $quantDisponible);

    //supprimer le panier par id
    $requete = $panierManager->effacerItemPanier($idPanier);

    require("vues/vuePanier.php");
}

/* (automatiquement ou avec un bouton). La base de donn´ees est mise `a jour en cons´equence.  */
function modifierPanierAchat($idProdModif, $idPanierModif, $quantiModif, $quantiteProduit)
{

    $idProduitModifier = intval($idProdModif);
    $idPanierModifier = intval($idPanierModif);
    $quantiModifier = intval($quantiModif);
    $quantiteDisponible = intval($quantiteProduit);

    if (($quantiModifier > 0) && ($quantiteDisponible > $quantiModifier)) {

        // modifierPanierAchat($idProdModif,$idPanierModif,$quantiModif,$quantiteProduit);
        // afficherPanier();

        echo "Todo lindo todo bello";
    } else {
        echo "Verifier la qantite disponible";
    }

    //    require("vues/vuePanier.php");
}
