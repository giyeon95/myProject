<?php

    $conn=mysqli_connect("your ip","user","password");
    $db=mysqli_select_db($conn,'db_name');
    
    mysqli_set_charset($conn,'utf8');    
?>  
