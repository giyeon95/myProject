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
<div id="miniHeader"><h1>일당 지급<br></h1></div>

<br>
<div id="miniBody">



<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {
        
        $CompanyName = $_SESSION['CompanyName'];
        $Code=isset($_GET['Code']) ? $_GET['Code'] : '';  
   
        $sql="SELECT * FROM Employees WHERE Code='$Code'and Master_CompanyName='$CompanyName'";  
        $result=mysqli_query($link,$sql);
        
        $row = mysqli_fetch_array($result);
        $name = $row['name'];
        $workPart = $row['workPart'];
        
        echo "<br>";
    

        echo '<table class="ex1"><caption>Pay Management</caption><thead><tr>' .
                '<th>Info</th><th>Value</th></tr></thead>';

        echo "<FORM METHOD='post' ACTION = 'insertPayResult.php'>";
        echo "<INPUT TYPE ='hidden' name='Code' value='$Code'>";
        
        echo "<tr><td>이름</td><td> $name</td></tr>";
        if($row['workPart']=='홀') {
            echo '<tr><td>시급</td><td>' ."<INPUT TYPE='text' name='pay' value='6480' style='text-align:right' size='2' onchange='bgcolor_yellow(this)'>원</td></tr>";
        } else if($row['workPart']=='주방') {
            echo '<tr><td>시급</td><td>' ."<INPUT TYPE='text' name='pay' value='6680' style='text-align:right' size='2' onchange='bgcolor_yellow(this)'>원</td></tr>";
        } else if($row['workPart']=='베터') {
            echo '<tr><td>시급</td><td>' ."<INPUT TYPE='text' name='pay' value='7000' style='text-align:right' size='2' onchange='bgcolor_yellow(this)'>원</td></tr>";
        }
        echo '<tr><td>근무시간</td><td>'."<INPUT TYPE='text' name='workTime' style='text-align:right' value='8' size='1' onchange='bgcolor_yellow(this)'>시간</td></tr>";
        echo '<tr><td>근무 날짜</td><td>'."<input type='text' name='date' id='date' size='6' onchange='bgcolor_yellow(this)' />";
        echo '</table>';
                 
        echo "<br><br><INPUT TYPE='submit' VALUE='일당 지급'>";
        echo "</form>";

    }
        ?>


</div>

<div id="minifoot">
<div>
</body>
</html>