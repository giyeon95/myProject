
<?php session_start(); 
    include "/home/kbstar13/public_html/db_connect.php";
?>

<html>
<head>
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>
</head>
<body>
  <div id="miniHeader">송금중 ....</div>
  <br>
  <div id="miniBody">송금중 ....</div>
  <div id="minifooter">송금중 ....</div>

</body>
</html>


<?php

        $CompanyName = $_SESSION['CompanyName'];  
        
        $addBalance=isset($_POST['addBalance']) ? $_POST['addBalance'] : '';
      

    if ($addBalance !="" and $CompanyName !=""){   
  
        $sql ="UPDATE Master AS T1, (
                SELECT Balance FROM Master WHERE CompanyName ='$CompanyName') AS T2
                SET T1.Balance = T2.Balance+$addBalance
                WHERE T1.CompanyName = '$CompanyName'";
                
        
        $result=mysqli_query($link,$sql);  
    
        if($result){
        
          echo "<script>alert('잔액 충전완료');";
         
          echo"  window.location.replace('./sessionRestart.php?CompanyName=$CompanyName');</script>";
        
     
        }  
        else{  
          //echo "<script>alert('오류 발생 재시도 바람');
         // window.location.replace('./insertEmployees.php');</script>";
          echo "SQL문 처리중 에러 발생 : "; 
          echo mysqli_error($link);
        } 
    
  }
  
  else {
      echo "<script>alert('데이터값 안넘어옴.');history.go(-1);</script>";
  }



mysqli_close($link);

?>
