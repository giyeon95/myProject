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
        $Code=isset($_GET['Code']) ? $_GET['Code'] : '???';  

        $sql="SELECT * FROM Employees WHERE Code='$Code'and Master_CompanyName='$CompanyName'";  
        $result=mysqli_query($link,$sql);
      
        $row = mysqli_fetch_array($result);
        $name = $row['name'];
        $gender = $row['gender'];
        $age = $row['age'];
        $workPart = $row['workPart'];
       
        
        echo "<h1>직원정보 삭제</h1>";
      
        
        echo "이름 : $name<br>";
        
        if($gender=='M') {
            echo "성별 : 남자<br>";
         
        } 
        else if($gender =='F') {
     
            echo "성별 : 여자<br>";
        }
       
        echo "나이 : $age<br>";
        echo "역활 : $workPart<br>";
   
        echo "<FORM METHOD='post' ACTION = 'deleteEmployResult.php'>";
        echo "<INPUT TYPE ='hidden' name='Code' value='$Code'>";
        echo "<br><br><INPUT TYPE='submit' VALUE='정보 삭제'>";
        echo "</form>";


        /*echo "<script>alert('".$CompanyName."님 환영합니다');";
          echo "window.location.replace('./index.php');</script>";     */
    }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>