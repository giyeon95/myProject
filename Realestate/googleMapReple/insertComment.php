
<?php
     include "./dbConnect.php";

     

     $roomName=isset($_POST['roomName']) ? $_POST['roomName'] : '';
     $writter=isset($_POST['writter']) ? $_POST['writter'] : '';
     $contants=isset($_POST['contants']) ? $_POST['contants'] : '';   
    

     $sql = "insert into repleinfo (roomName, writter, contants)
                            values ('$roomName','$writter','$contants')";

    $result = mysqli_query($conn,$sql);
    
    if($result) { 
                            echo "<script>
                                window.alert('Database insert Success!');
                                history.go(-1);
                                </script>";
    } else {
         echo "<script>
                    window.alert('Sorry Error');
                    history.go(-1);
                    </script>";
    }
    mysqli_close($conn);

    ?>