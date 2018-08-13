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
      
        $sql="SELECT * FROM Master WHERE CompanyName='$CompanyName'"; 
        $result=mysqli_query($link,$sql);  
        $Balance;
        
        while($row = mysqli_fetch_array($result)) {
            $Balance = $row['Balance'];
        }
        echo "<center><br><h3>발주 관리입니다.</h3><br><br>";
        echo "현재 '".$_SESSION['CompanyName']."' 거래가능 금액은 ".$Balance."원 입니다.<br><hr>";
        echo "발주한 물품은 3일후에 도착합니다.<br><hr>";
        echo "<a href='orderProductlist.php'> <h3>(1) 신규 발주 (발주 신청하기)</h3></a><br>";
        echo "<a href='selectProductlist.php'> <h3>(2) 발주 내역 조회</h3></a><br><br>";
    }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>