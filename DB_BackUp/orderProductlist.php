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
        $EncodingName='';
        $EncodingPrice='';
        $count=0;
      
        $sql="SELECT * FROM Product ORDER BY price";  
        $result=mysqli_query($link,$sql);  
    
        echo "<FORM METHOD='post' ACTION = 'insertorderTableResult.php'>";
          
        echo "<table class='ex1'><caption>발주 날짜</caption><thead><tr>
                <th></th><th>신청 날짜</th><th>수령 날짜</th></thead></tr>
                <tbody><tr><td>날짜 선택</td>
                <td><INPUT TYPE='TEXT' VALUE=".date("Y-m-d")." NAME='orderdate' readonly style='background-color:yellow';></td>
                <td><INPUT TYPE='TEXT' VALUE=".date("Y-m-d",strtotime("+3 days"))." NAME='desDate' readonly style='background-color:yellow';></td></tr></tbody></table><br>";


        echo '<table class="ex1"><caption>주문 하기</caption><thead><tr>' .
            '<th>ProductName</th><th>group</th><th>price</th>' .
            '<th>단위</th><th>count</th>'.
            '</tr></thead>';
        echo '<tbody>';

        while($row = mysqli_fetch_array($result)) {
          
            $EncodingName .= $row['name'].'!,!';
            $EncodingPrice .= $row['price'].'@,@';

            echo '<tr><td>' . $row['name'] . '</td>' .
                '<td>' . $row['group'] . '</td>' .
                '<td>' . $row['price'] . '</td>'.
                '<td>1 BAG*6 BOX</td>'.
                '<td>' ."<INPUT TYPE='text' name='productCount".$count."' placeholder='0'size='1' maxlength='3'>". '개</td>'.
                '</tr>'; 
               
                $count++;
               
                
        }
        $EncodingName = substr($EncodingName,0,-3);
        $EncodingPrice = substr($EncodingPrice,0,-3);
        echo "<INPUT TYPE='hidden' NAME='productEncoding' value='$EncodingName'>";
        echo "<INPUT TYPE='hidden' NAME='priceEncoding' value='$EncodingPrice'>";

        echo "<INPUT TYPE='hidden' NAME='count' value='$count'>";
        echo '</tbody>';
        echo '</table>';
        
        echo "<br><br><center><INPUT TYPE='submit' VALUE='발주 하기'>";
        echo "</form>";
        
        mysqli_close($link);
            }
        ?>


</div>





<div id="footer">이부분은 푸터</div>



</body>
</html>