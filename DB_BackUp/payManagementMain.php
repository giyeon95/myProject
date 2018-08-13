<!DOCTYPE html>
<?php session_start(); 
    include "/home/kbstar13/public_html/db_connect.php";
?>
<html>
<head>
<meta charset="UTF-8">
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<link rel="stylesheet" href="./css/border.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>
</head>


<body>
<div id="header">이부분은 헤더</div>


<div id="contents">
   
    <br><br><br>
   
<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {

        $CompanyName = $_SESSION['CompanyName'];
      
        
        $sql="SELECT * FROM Employees WHERE Master_CompanyName='$CompanyName'";  
        $result=mysqli_query($link,$sql);  
    
          
        
          
        echo '<table class="ex1"><caption>일당 관리 System</caption><thead><tr>' .
            '<th>Code</th><th>name</th><th>workPart</th>' .
            '<th>저장</th><th>내역확인</th></tr></thead>';


        while($row = mysqli_fetch_array($result)) {
          
            echo '<tr><td>' . $row['Code'] . '</td>' .
                '<td>' . $row['name'] . '</td>' .
                '<td>' . $row['workPart'] . '</td>'.
                
                '<td>' . "<a href='#' onclick=window.open('insertPay.php?Code=".$row['Code']."','window','width=500,height=500,left=0,top=0'); >일당 추가</a></td>".
                '<td>' . "<a href='#' onclick=window.open('selectPay.php?name=".$row['name']."&Code=".$row['Code']."','window','width=1000,height=500,left=0,top=0'); >내역확인</a></td>".
                '</tr>';
            
        }
       
        //onclick='return confirm("."Are".")

        echo '</table>';

         mysqli_close($link);
            }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>