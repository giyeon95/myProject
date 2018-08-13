
<?php session_destroy(); 
          session_start(); ?>
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

$CompanyName =isset($_GET['CompanyName']) ? $_GET['CompanyName'] : '';  



if($CompanyName != "") {
	 
	$sql="select Id,Password,CompanyName,Balance from Master where CompanyName='$CompanyName'";
	$result = mysqli_query($link,$sql);
	
	if($result){
        while($row = mysqli_fetch_array($result)) {

          $CompanyName = $row[2];
          $Balance = $row[3];
          echo "<script>";
          echo " window.open('about:blank','_self').close();</script>";    
          
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
    
}
else {
  echo "<script>alert('세션오류발생.');";
  echo "history.go(-1);</script>";  
}

mysqli_close($link);
?>    
