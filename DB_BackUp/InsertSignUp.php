
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

$Id=isset($_POST['Id']) ? $_POST['Id'] : '';  
$Password=isset($_POST['Password']) ? $_POST['Password'] : '';

$CompanyName=isset($_POST['CompanyName']) ? $_POST['CompanyName'] : '';   
$Address=isset($_POST['Address']) ? $_POST['Address'] : '';   
$Phone=isset($_POST['Phone']) ? $_POST['Phone'] : '';   
$Balance=isset($_POST['Balance']) ? $_POST['Balance'] : '';   




  if ($Id !="" and $Password !="" and $CompanyName !="" and $Address !="" and $Phone !="" and $Balance !=""){   
  
    
      $sql="insert into Master(Id,Password, CompanyName, Address,Phone,Balance) 
          values('$Id','$Password','$CompanyName','$Address','$Phone','$Balance')";  
        $result=mysqli_query($link,$sql);  
    
        if($result){
          echo "<script>alert('회원가입이 완료되었습니다.');
                window.location.replace('./index.php');</script>";
          //header("Location: ./index.php"); 
        
        }  
        else{  
          echo "<script>alert('이미 가입된 회사입니다. 다시 시도해주세요.');
          window.location.replace('./SignUp.php');</script>";
          echo "SQL문 처리중 에러 발생 : "; 
          echo mysqli_error($link);
        } 
    
  }
  
  else {
      echo "<script>alert('*를 채운후 다시 시도하세요.');history.go(-1);</script>";
  }



mysqli_close($link);
?>
