
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

$Code=isset($_POST['Code']) ? $_POST['Code'] : '';



  if ($Code !=""){   
        $sql = "DELETE FROM Employees WHERE Code='$Code'";
        $result=mysqli_query($link,$sql);  
    
        if($result){
          echo "<script>alert('직원 삭제 완료.');
                window.location.replace('./selectEmployees.php');</script>";
        }  
        else{  
          echo "<script>alert('오류 발생 재시도 바람');
          window.location.replace('./selectEmployees.php');</script>";
          echo "SQL문 처리중 에러 발생 : "; 
          echo mysqli_error($link);
        } 
    
  }
  
  else {
      echo "<script>alert('데이터값 안넘어옴.');history.go(-1);</script>";
  }



mysqli_close($link);
?>
