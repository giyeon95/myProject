
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
$Date=isset($_POST['date']) ? $_POST['date'] : '';
$Employees_Code=isset($_POST['Code']) ? $_POST['Code'] : '';   
$workTime=isset($_POST['workTime']) ? $_POST['workTime'] : '1';   
$pay=isset($_POST['pay']) ? $_POST['pay'] : '1';   
$pay_sum = $pay*$workTime;


  if ($Date !="" and $Employees_Code !="" and $workTime !="" and $pay !=""){   
  
    
      $sql="insert into PayManager(Date, Employees_Code, workTime, pay, pay_sum, Deposit) 
          values('$Date','$Employees_Code','$workTime','$pay','$pay_sum',0)";  
        $result=mysqli_query($link,$sql);  
    
        if($result){
          echo "<script>alert('일당 등록 완료.');
                window.open('about:blank','_self').close();</script>";
          //header("Location: ./index.php"); 
        
        }  
        else{  
          echo "<script>alert('오류 발생 재시도 바람');
          window.open('about:blank','_self').close();</script>";
          echo "SQL문 처리중 에러 발생 : "; 
          echo mysqli_error($link);
        } 
    
  }
  
  else {
      echo "<script>alert('데이터값 안넘어옴.');history.go(-1);</script>";
  }



mysqli_close($link);
?>
