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
       //작성부문
            echo "<h1>신규 직원 입력</h1>";
            echo "<FORM METHOD='post' ACTION = 'insertEmployResult.php'>";
            echo "이름 : <INPUT TYPE='text' name='name' placeholder='이름' size='4' maxlength='4'><br>";
            echo "성별 : <INPUT TYPE='radio' name='gender' value='M'>남자";
            echo "<INPUT TYPE='radio' name='gender' value='F'>여자<br>";
            echo "나이 : <INPUT TYPE='text' name='age' placeholder='나이'size='2' maxlength='2'><br>";
            echo "역활 : <select name='workPart'>".
                    "<option value='홀' selected>홀</option>".
                    "<option value='주방'>주방</option>".
                    "<option value='베터'>베터</option>".
                    "</select><br>";
            echo "은행 : <select name='bank'>".
                    "<option value='농협' selected>농협</option>".
                    "<option value='국민'>국민</option>".
                    "<option value='신한'>신한</option>".
                    "<option value='우리'>우리</option>".
                    "<option value='기업'>기업</option>".
                    "</select><Br>";
            echo "계좌번호 : <INPUT TYPE='text' name='bankNumber' placeholder='110-000-000000' size='15' maxlength='15'>";
            echo "<br><br><INPUT TYPE='submit' VALUE='등록'>";
            echo "</form>";
    }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>