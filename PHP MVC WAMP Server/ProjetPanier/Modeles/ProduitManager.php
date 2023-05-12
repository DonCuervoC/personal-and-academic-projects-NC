<?php
require_once("Manager.php");

class ProduitManager extends Manager
{

    private $quantiteDisponible;


    public function getProduits()
    {

        //1. conexion a la base de datos
        $bdd = $this->connexionBD();

        $requete = $bdd->query('SELECT * FROM produits ORDER BY nom_produit ASC');

        return $requete;
    }

    public function getProduit($idProduit)
    {
        $bdd = $this->connexionBD();

        $requete = $bdd->prepare("SELECT * FROM produits WHERE id_produit =?");
        //Ejecuto mi request con mi id billet
        $requete->execute(array($idProduit));
        //devolvemos lo que tengamos en la linea en forma de link y no de tabla
        //si queremos devolver un objeto link de entrada debemos hacer el ->fetch()
        return $requete->fetch();
    }
    

    public function substractProduit($id_produit, $quantiSele,$quantDispo)
    {
        $updateQuanti = $quantDispo - $quantiSele;

        $bdd = $this->connexionBD();

         $requete = $bdd->prepare("UPDATE produits SET quantite_disponible=:updateQuanti WHERE id_produit = :idProduit");

        $requete->execute(array(
           
            'id_produit' => $id_produit,
            'quantite_disponible' => $updateQuanti,
        ));

        return $requete;
    }
    
    public function insererProduit($id_produit, $QuantiProdAdd, $quantDis)
    {
        // $updateQuanti = $quantDispo + $quantiSele;

        $bdd = $this->connexionBD();

         $requete = $bdd->prepare("UPDATE prodproduitsuits SET quantite_disponible=:updateQuanti WHERE id_produit = :idProduit");

        $requete->execute(array(
           
            // 'id_produit' => $id_produit,
            // 'quantite_disponible' => $updateQuanti,
        ));

        return $requete;
    }
}
