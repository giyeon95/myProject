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
        echo "<center>직원관리 입니다.<br><br>";
        echo "<a href='selectEmployees.php'> (1) 직원 조회(조회후 수정/삭제 가능)</a><br><br>";
        echo "<a href='insertEmployees.php'> (2) 신규 직원 등록</a><br><br>";
    }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>