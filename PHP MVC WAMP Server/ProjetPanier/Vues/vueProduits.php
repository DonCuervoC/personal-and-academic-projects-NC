<?php $titre = "Liste des produits" ?>

<?php ob_start(); ?>

<?php

while ($donnees = $requete->fetch()) {

?>
    <div class="solid">

        <div>
            <h2> <?= $donnees['nom_produit'] ?> </h2>

        </div>

        <div>
            <img class="imgPet" src="Images/<?= $donnees['image'] ?>">
            </p>
            <p> prix :<?= $donnees['prix'] ?> </br>
        </div>

        <a href="indexPanier.php?action=produits&idProduit=<?= $donnees['id_produit'] ?>">Voir la description du produit</a> </p>

        <div>
        
            <form action="indexPanier.php?action=ajoutPanier&idProduitPanier=<?= $donnees['id_produit'] ?>
                &nomProduitPanier=<?= $donnees['nom_produit'] ?>
                &prixProduitPanier=<?= $donnees['prix'] ?>
                &quantiteProduitPanier=<?= $donnees['quantite_disponible'] ?>" method="post">

                quantité souhaitée : <input type="text" name="quantiteSelectione"> </br>
                <input type="submit" value="Ajouter au panier">
            </form>

        </div>

    </div>

<?php

}
?>

<?php $contenu = ob_get_clean(); ?>
<?php ob_start(); ?>

<footer>Projet Panier <?php echo "Date ajourd'hui : " . date("y/m/d"); ?></footer>

<?php $footer = ob_get_clean(); ?>
<?php require('template.php'); ?>