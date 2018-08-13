
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
  <div id="header">이부분은 헤더</div>
  <br>

</body>
</html>


<?php

        $CompanyName = $_SESSION['CompanyName'];  
        $num=isset($_GET['num']) ? $_GET['num'] : '';

    if ($CompanyName !="" and $num != ""){   
  
        $sql ="UPDATE PayManager SET Deposit =1 WHERE Prinum ='$num'";
        
        $result=mysqli_query($link,$sql);  
    
        if($result){
        
          echo "<script>alert('송금 완료');
                window.open('about:blank','_self').close();</script>";
     
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
