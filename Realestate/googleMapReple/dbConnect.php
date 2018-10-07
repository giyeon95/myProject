<?php
    $conn=mysqli_connect("173.194.226.1","giyeon","1234") or die("DB connect Missed!");
    $db=mysqli_select_db($conn,'reple_db');
    
    mysqli_set_charset($conn,'utf8');    
?>