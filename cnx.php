<?php
$user = "id13085564_sylvain";
$pass = "Admin1Admin2Admin3?";
try {
    $cnx = new PDO('mysql:host=localhost;dbname=id13085564_mobilegsb;charset=utf8', $user, $pass);
    
} catch (PDOException $e) {
    print "Erreur !: " . $e->getMessage() . "<br/>";
    die();
}
?>