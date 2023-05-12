

<!DOCTYPE html>
<html lang="en">
    
    <head>
        <meta charset="utf-8"/>
        <title><?= $titre ?> </title>
        <link href="styles/style.css" rel="stylesheet"/>
    </head>

    <!-- Mi template va a contener todo lo comun entre las vistas -->
    <!-- vamos a llenar todo lo que no se encuentre alla -->
    <body>
       <header>Pépinière Labranche</header>

       <ul>
         <li><a class="active" href="indexPanier.php">Home</a></li>
         <li><a href="indexPanier.php?action=showPanier">Panier d'achat</a></li>
       </ul>

       <?= $contenu ?>
       <?= $footer ?>
           

    </body>
</html>






