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

            if(t<stringDate) {
                obj.style.backgroundColor='white';
            } else {
                obj.style.backgroundColor='yellow';
            }
            
        }

        $(function() {
            $("#date").datepicker();
            
        });
       
    </script>

</head>


<body>
<div id="header">이부분은 헤더</div>


<div id="contents">

<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {

        $CompanyName = $_SESSION['CompanyName'];
        $OrderDate = isset($_GET['orderdate']) ? $_GET['orderdate'] : '';
    //$sql="SELECT orderdate,sum(sumPrice) FROM orderTable where MasterCompanyName='$CompanyName' GROUP BY orderDate ORDER BY orderdate";  
        
       $sql="SELECT desDate,productName,count,sumPrice
         FROM orderTable where MasterCompanyName='$CompanyName'AND orderdate='$OrderDate' GROUP BY desDate,productName,count,sumPrice ORDER BY desDate";  
        $result=mysqli_query($link,$sql);  
    
      
        echo '<table class="ex1"><caption>발주 조회</caption><thead><tr>' .
            '<th>수령</th><th>제품 명</th><th>수량</th><th>총액</th>' .
            '</tr></thead>';
        echo '<tbody>';

        while($row = mysqli_fetch_array($result)) {
          
            echo '<tr><td>' . $row['desDate'] . '</td>' .
                '<td>' . $row['productName'] . '</td>' .
                '<td>' . $row['count'] . '개</td>'.
                '<td>' . $row['sumPrice'] . '원</td>';
           
            echo '</tr>'; 
        }
       
        mysqli_close($link);
            }
        ?>


</div>





</body>
</html>