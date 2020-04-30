<?php 
include 'cnx.php';
$sql = "select antibio.libelle, antibio.unite, antibio.nombre_par_jour, antibio.doseKilo, 
antibio.dosePrise, antibio.type, categorie.libelle as catLibelle from antibio INNER JOIN categorie 
on antibio.categorie_id = categorie.id";
$sth = $cnx->prepare($sql);
$sth->execute();

$json = [];
 while($row = $sth->fetch()){
     if($row["type"] == "k"){
        $json[] = [
            "\$type"=> "App1.AntibioParKilo, App1",
            "doseKilo"=>intval($row["doseKilo"]),
            "libelle"=>$row["libelle"],
            "unite"=>$row["unite"],
            "laCategorie"=>[
                "libelle"=>$row["catLibelle"]
            ],
            "nombreParJour"=>intval($row["nombre_par_jour"])
        ];
     }else{
        $json[] = [
            "\$type"=> "App1.AntibioParPrise, App1",
            "dosePrise"=>intval($row["dosePrise"]),
            "libelle"=>$row["libelle"],
            "unite"=>$row["unite"],
            "laCategorie"=>[
                "libelle"=>$row["catLibelle"]
            ],
            "nombreParJour"=>intval($row["nombre_par_jour"])
        ];
     }
   
 }

 
echo json_encode($json);
 
?>


