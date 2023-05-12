<?php $titre = "Erreur Panier" ?>


<?php ob_start(); ?>


<div class="mainProduit">

    <p><strong>
            Aucun article n'a été ajouté à votre panier : </br>
            Veuillez vous assurer que vous avez ajouté un produit au panier .
        </strong></p>

</div>


<?php $contenu = ob_get_clean(); ?>
<?php ob_start(); ?>

<footer class="fixed-footer">Veu de un produit <?php echo "Date ajourd'hui : " . date("l jS \of F Y h:i:s A"); ?></footer>

<?php $footer = ob_get_clean(); ?>
<?php require('template.php'); ?>