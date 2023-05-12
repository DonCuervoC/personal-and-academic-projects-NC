
<?php
require_once("Manager.php");



//$listProduits = isset($listProduits) ? $listProduits: array();

class PanierManager extends Manager
{

    public function getPanier()
    {
        $bdd = $this->connexionBD();

        $requete = $bdd->query("SELECT * FROM panierachat");
       // $requete->execute(array());
        return $requete;
    }

    public function ajouterPanier($nomPr,$idProduit1,$quantiteP1,$prixP1,$quantiSelec,$prixTotal)
    {
            // echo "Prix Total :  " . $prixTotal . "</br>";;
            // echo gettype($prixTotal) . "</br>";
            // echo "Nom Produit :  " . $nomPr . "</br>";
            // echo gettype($nomPr) . "</br>";
         
            /* VERIFY nom_produit values in request (requete)*/
        $bdd = $this->connexionBD();
        $requete = $bdd->prepare("INSERT INTO panierachat (
                                                          Date_modification,
                                                          id_prod,
                                                          nom_produit,
                                                          quantite_p,
                                                          quantite_Selectione,
                                                          prix,
                                                          prixTotal)
                                                          VALUES(
                                                          NOW(),
                                                        :id_prod,
                                                        :nom_produit,
                                                        :quantite_p,
                                                        :quantite_Selectione,
                                                        :prix,
                                                        :prixTotal
                                                                    )");

        $requete->execute(array(

        'id_prod' => $idProduit1,
        'nom_produit' => $nomPr,
        'quantite_p'=> $quantiteP1,
        'quantite_Selectione'=>$quantiSelec,
        'prix'=>$prixP1,
        'prixTotal'=>$prixTotal,
        ));

        return $requete;
    }

    public function effacerItemPanier($idPanier){

        $bdd = $this->connexionBD();
        $requete = $bdd->prepare(" DELETE FROM panierachat WHERE id_panier:=idPanier");
        
        $requete->execute(array(
            'id_panier' => $idPanier,
        ));

    }
}

