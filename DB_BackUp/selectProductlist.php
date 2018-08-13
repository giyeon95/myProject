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
    
        
        $sql="SELECT orderdate,sum(sumPrice) FROM orderTable where MasterCompanyName='$CompanyName' GROUP BY orderDate ORDER BY orderdate DESC";  
        $result=mysqli_query($link,$sql);  
    
        
     
        echo '<table class="ex1"><caption>날짜별 발주금액 조회</caption><thead><tr>' .
            '<th>주문 날짜</th><th>지출 금액</th><th>상세 정보</th>'.
            '</tr></thead>';
        echo '<tbody>';

        while($row = mysqli_fetch_array($result)) {
          
            echo '<tr><td>' . $row['orderdate'] . '</td>' .
                '<td>' . $row['sum(sumPrice)'] . '원</td>';
            echo "<td><a href='selectProductinfolist.php?orderdate=".$row['orderdate']."'> 발주 내역 조회</a></td>";
            echo '</tr>'; 
        }
       
        mysqli_close($link);
            }
        ?>


</div>





</body>
</html>