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
include "/home/kbstar13/public_html/db_connect.php";

$user_id=isset($_POST['user_id']) ? $_POST['user_id'] : '';  
$user_pw=isset($_POST['user_pw']) ? $_POST['user_pw'] : '';
$CompanyName = 'test';

if($user_id != "" && $user_pw != "") {
	 
	$sql="select Id,Password,CompanyName,Balance from Master where Id='$user_id'and Password='$user_pw'";
	$result = mysqli_query($link,$sql);
	

	if($result){
        while($row = mysqli_fetch_array($result)) {

          $CompanyName = $row[2];
          $Balance = $row[3];
          echo "<script>alert('".$CompanyName."님 환영합니다');";
          echo "window.location.replace('./index.php');</script>";    

          session_start();
        $_SESSION['user_id'] = $user_id;
        $_SESSION['CompanyName'] = $CompanyName;
        $_SESSION['Balance']= $Balance;
        }	
      //header("Location: ./index.php"); 
    }  
     else{  
      
       echo "SQL문 처리중 에러 발생 : "; 
       echo mysqli_error($link);
    }
    echo "<script>alert('아이디 또는 비밀번호가 다릅니다. 다시 시도해주세요.');";
    echo "window.location.replace('./login.php');</script>";  
}
else {
  echo "<script>alert('빈칸을 입력하세요.');";
  echo "history.go(-1);</script>";  
}

mysqli_close($link);
?>