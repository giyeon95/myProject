
<?php
    include "./dbConnect.php";

     $roomName = $_POST['roomName'];

    
    $sql = "select * from repleinfo where roomName='$roomName'";
    $result = mysqli_query($conn, $sql);


    $count = 0;
    $obj = new stdClass();

    while($row = mysqli_fetch_object($result)){
            $obj->$count = $row;
            $count++;
        }
         mysqli_close($conn);

         $myJSON = json_encode($obj); 

        header("Content-Type: application/json");
         echo $myJSON;
    ?>