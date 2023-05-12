<?php $titre = "Panier Achat" ?>

<?php ob_start(); ?>

<?php

while ($donnees = $requete->fetch()) {

?>
    <div class="thin">


        <p>Date Modification : <?= $donnees['Date_modification'] ?> </p> </br>
        <p>Id produit : <?= $donnees['id_prod'] ?> </p> </br>
        <p>Nom produit : <?= $donnees['nom_produit'] ?> </p> </br>
        <p>Quantite selectione : <?= $donnees['quantite_Selectione'] ?> </p> </br>
        <p>Prix unitaire : <?= $donnees['prix'] ?> </p> </br>
        <p>prix Total : <?= $donnees['prixTotal'] ?> </p> </br>


        <form method="post" action="indexPanier.php?action=supprimerItemPanier&idElementSupprimer=<?= $donnees['id_prod'] ?>&idPanierSupprimer=<?= $donnees['id_panier'] ?>&quantiteSupprimer=<?= $donnees['quantite_Selectione']?>&quantiteProd=<?= $donnees['quantite_p'] ?>">
            <input type="submit" value="Supprimer">
        </form>

        <form method="post" action="indexPanier.php?action=modifierPanier&idProduittModifier=<?= $donnees['id_prod'] ?>&idPanierModifier=<?= $donnees['id_panier'] ?>&quantiteProduit=<?= $donnees['quantite_p'] ?>">
            Quantite a modifier : <input type="text" name="quantiteModifierSelectione" width="30px"/>
            <input type="submit" value="modifier">
        </form>


    </div>


<?php

}
?>



<!-- <button>Ajouter au Panier</button> -->

<!-- Enviar valores del input por POST a la tabla de productos y a la tabla de Panier. -->


<?php $contenu = ob_get_clean(); ?>
<?php ob_start(); ?>

<footer class="fixed-footer">Veu de un produit <?php echo "Date ajourd'hui : " . date("l jS \of F Y h:i:s A"); ?></footer>

<?php $footer = ob_get_clean(); ?>
<?php require('template.php'); ?>