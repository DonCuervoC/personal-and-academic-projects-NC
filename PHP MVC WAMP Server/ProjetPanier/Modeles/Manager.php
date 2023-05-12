<?php

class Manager{

    public function connexionBD(){
        //1. conexion a la base de datos
       try
       {
        $bdd = new PDO('mysql:host=localhost;dbname=projetpanier;charset=utf8', 'root', '');
        return $bdd;
       }
       catch(Exception $e)
       {
               die('Erreur : '.$e->getMessage());
       }
    }
}