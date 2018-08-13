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
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script src="./js/jquery-ui-1.12.1/datepicker-ko.js"></script> 

 <script>
        function bgcolor_yellow(obj) {
            obj.style.backgroundColor='yellow';
        }

        $(function() {
            $("#date").datepicker();
            
        });
       
    </script>

</head>


<body>
    <center>
<div id="miniHeader"><h1>잔액 충전<br></h1></div>

<br>
<div id="miniBody">



<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {
        
        $CompanyName = $_SESSION['CompanyName'];
      
       
        echo "<br>";

        echo '<table class="ex1"><caption>잔고 충전</caption><thead><tr>' .
                '<th>Info</th><th>Value</th></tr></thead>';

        echo "<FORM METHOD='post' ACTION = 'addMasterBalanceResult.php'>";
        echo '<tr><td>금액</td><td>'."<INPUT TYPE='text' name='addBalance' style='text-align:right' value='3000' size='4' onchange='bgcolor_yellow(this)'>원</td></tr>";
        echo '</table>';
        echo "<br><br><INPUT TYPE='submit' VALUE='잔액 충전'>";
        echo "</form>";

    }
        ?>


</div>

<div id="minifoot">
<div>
</body>
</html>