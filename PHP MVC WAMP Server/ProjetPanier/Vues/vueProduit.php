<?php $titre = "Liste des produit" ?>


<?php ob_start(); ?>
        

        <div class="mainProduit">
            <img  src="Images/<?= $requete['image'] ?>">
            <h2><strong>Description du <?= $requete['nom_produit'] ?> </br></strong> </h2>
            <p class="descipt" ><?= $requete['description'] ?>  </p>
        </div>
        
        <p style="color: red ;" > Prix : CAD $ <?= $requete['prix'] ?> </p>
        <a href="indexPanier.php">Retourner au menu principal</a> 

        

        <!-- <button>Ajouter au Panier</button> -->

        <!-- Enviar valores del input por POST a la tabla de productos y a la tabla de Panier. -->


<?php $contenu = ob_get_clean(); ?>
<?php ob_start(); ?>

        <footer class="fixed-footer">Veu de un produit <?php echo "Date ajourd'hui : " . date("l jS \of F Y h:i:s A"); ?></footer>

<?php $footer = ob_get_clean(); ?>
<?php require('template.php'); ?>