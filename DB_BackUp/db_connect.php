<?php
    error_reporting(E_ALL); 
    ini_set('display_errors',1); 
    
    
    $link=mysqli_connect("localhost","kbstar13","giyeon","kbstar13_db"); 
    if (!$link)  
    { 
       echo "MySQL 접속 에러 : ";
       echo mysqli_connect_error();
       exit();
    }  
    
    mysqli_set_charset($link,"utf8");  
?>
