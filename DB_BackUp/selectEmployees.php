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

<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {

        $CompanyName = $_SESSION['CompanyName'];
        
        
      
        $sql="SELECT * FROM Employees WHERE Master_CompanyName='$CompanyName'";  
        $result=mysqli_query($link,$sql);  
    
          
        
          
        echo '<table class="ex1"><caption>직원관리 System</caption><thead><tr>' .
            '<th>Code</th><th>name</th><th>gender</th>' .
            '<th>age</th><th>workPart</th><th>bankNumber</th>' .
            '<th>bank</th><th>CompanyName</th>' .
            '<th>수정</th><th>삭제</th>' .
            '</tr></thead>';
        echo '<tbody>';
        while($row = mysqli_fetch_array($result)) {
            echo '<tr><td>' . $row['Code'] . '</td>' .
                '<td>' . $row['name'] . '</td>' .
                '<td>' . $row['gender'] . '</td>'.
                '<td>' . $row['age'] . '</td>'.
                '<td>' . $row['workPart'] . '</td>'.
                '<td>' . $row['bankNumber'] . '</td>'.
                '<td>' . $row['bank'] . '</td>'.
                '<td>' . $row['Master_CompanyName'] . '</td>'.
                '<td>' . "<a href='updateEmployees.php?Code=".$row['Code']."'>수정</a></td>".
                '<td>' . "<a href='deleteEmployees.php?Code=".$row['Code']."'>삭제</a></td>".
                '</tr>';
        }
       
        //onclick='return confirm("."Are".")
        echo '</tbody>';
        echo '</table>';
        mysqli_close($link);
            }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>