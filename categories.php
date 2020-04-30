<?php 
include 'cnx.php';
$sql = "select libelle from categorie";
$sth = $cnx->prepare($sql);
$sth->execute();

 

 
echo json_encode($sth->fetchAll(PDO::FETCH_ASSOC));
 
?>


