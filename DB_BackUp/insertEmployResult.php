
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
$name=isset($_POST['name']) ? $_POST['name'] : '';
$gender=isset($_POST['gender']) ? $_POST['gender'] : '';   
$age=isset($_POST['age']) ? $_POST['age'] : '';   
$workPart=isset($_POST['workPart']) ? $_POST['workPart'] : '';   
$bankNumber=isset($_POST['bankNumber']) ? $_POST['bankNumber'] : '';   
$bank=isset($_POST['bank']) ? $_POST['bank'] : '';



  if ($name !="" and $gender !="" and $age !="" and $workPart !="" and $bankNumber !="" and $bank !=""){   
  
    
      $sql="insert into Employees(name, gender, age, workPart, bankNumber, bank, Master_CompanyName) 
          values('$name','$gender','$age','$workPart','$bankNumber','$bank','$CompanyName')";  
        $result=mysqli_query($link,$sql);  
    
        if($result){
          echo "<script>alert('직원 등록 완료.');
                window.location.replace('./employeesMain.php');</script>";
          //header("Location: ./index.php"); 
        
        }  
        else{  
          echo "<script>alert('오류 발생 재시도 바람');
          window.location.replace('./insertEmployees.php');</script>";
          echo "SQL문 처리중 에러 발생 : "; 
          echo mysqli_error($link);
        } 
    
  }
  
  else {
      echo "<script>alert('데이터값 안넘어옴.');history.go(-1);</script>";
  }



mysqli_close($link);
?>
