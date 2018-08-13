<!DOCTYPE html>
<?php session_start();
include "/home/kbstar13/public_html/db_connect.php";
 ?>


<html>
<head>
<meta charset="UTF-8">
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>
</head>

<body>
<div id="header">이부분은 헤더</div>


<div id="contents">



<?php


if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
   echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
   } else {

       $CompanyName = $_SESSION['CompanyName'];
      
       echo "<br><center><h3>환영합니다.'$CompanyName'님</h3>";
     
       $sql="SELECT * FROM Master WHERE CompanyName='$CompanyName'";  
       $result=mysqli_query($link,$sql);  
   
         
       
         
        echo "<TABLE class='ex1'><CAPTION>Master INFO</CAPTION>
                <thead><HR><th>INFO</th><th>CONTENTS</th><th>Other</th></HR></thead>";
        echo "<tBOdy>";
       while($row = mysqli_fetch_array($result)) {
           echo "<tr class='odd'><td>Id </td><td> ".$row['Id']."</td><td></td></tr>";
           echo "<tr><td>CompanyName </td><td> ".$row['CompanyName']."</td><td></td></tr>";
           echo "<tr class='odd'><td>Address </td><td> ".$row['Address']."</td><td></td></tr>";
           echo "<tr><td>Phone </td><td> ".$row['Phone']."</td><td></td></tr>";
           echo "<tr class='odd'><td>남은 잔고 </td><td> ".$row['Balance']."원</td>
                <td><a href='#' onclick=window.open('addMasterBalance.php','window','width=500,height=500,left=0,top=0');>충전하기</a></td></tr>";
                
       }
       echo "</tbody>";
       echo "</TABLE>";
       
       
       mysqli_close($link);
           }
       ?>


</div>

<div id="footer">이부분은 푸터</div>



</body>
</html>