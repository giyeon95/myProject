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



<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {

        $CompanyName = $_SESSION['CompanyName'];
        $Balance = $_SESSION['Balance'];
        $Code=isset($_GET['Code']) ? $_GET['Code'] : '???'; 
        $name=isset($_GET['name']) ? $_GET['name'] : '???';  
     
        $monthNoArray = array(0,0,0,0,0,0,0,0,0,0,0,0);
        $monthOkArray = array(0,0,0,0,0,0,0,0,0,0,0,0);
        echo "<div id='miniHeader'><center>";
        echo "<h3>".$name."의 일당 내역입니다.</h3></div>";

        echo "<div id='miniBody'><center>";
      
        $sql="SELECT * FROM PayManager WHERE Employees_Code='$Code' ORDER BY DATE ASC";  

        $result=mysqli_query($link,$sql);  
    
          
        
          
        echo '<table class="ex1"><thead><tr>' .
            '<th>Date</th><th>workTime</th><th>시급</th>' .
            '<th>총액</th><th>입금여부</th><th>입금하기</th></tr></thead>';
        echo "<TBODY>";
        while($row = mysqli_fetch_array($result)) {
            echo '<tr class='.'odd'.'><td>' . $row['Date'] . '</td>' .
                '<td>' . $row['workTime'] . '시간</td>' .
                '<td>' . $row['pay'] . '원</td>'.
                '<td>' . $row['pay_sum'] . '원</td>';
            if($row['Deposit']==0) {
                echo '<td><font color='.'red'.'>미 지급</td>';
            } else {
                echo '<td><font color='.'green'.'>지급 완료</td>';
            }
            
            if($row['Deposit']==0) {
                echo '<td><a href='.'DepositMaster.php?num='.$row['Prinum'].'&pay_sum='.$row['pay_sum'].'>입금하기</a></td></tr>';
            }
            else {
                echo '<td><b>입금 완료</b></td>';
            }
                $month = substr($row['Date'],0,7);
                $month = substr($month,5,6);
                
                if($month<10 and $row['Deposit']==0) {
                    $month = substr($month,1);
                    $monthNoArray[$month-1] += $row['pay_sum'];

                } else if ($row['Deposit']==0) {
                    $monthNoArray[$month-1] += $row['pay_sum'];
                }

                if($month<10 and $row['Deposit']==1) {
                    $month = substr($month,1);
                    $monthOkArray[$month-1] += $row['pay_sum'];

                } else if($row['Deposit']==1) {
                    $monthOkArray[$month-1] += $row['pay_sum'];
                }

               
        }
        
        echo "</TBODY>";
        echo '</table>';

        echo "<h3>월별 임금 조회</h3>";
           
        echo '<table class="ex1"><thead><tr>' .
            '<th></th><th>1월</th><th>2월</th><th>3월</th>' .
            '<th>4월</th><th>5월</th><th>6월</th>'.
            '<th>7월</th><th>8월</th><th>9월</th>'.
            '<th>10월</th><th>11월</th><th>12월</th><th><b>총액</b></th>'.
            '</thead></tr>';
        echo '<tbody><tr class="odd"><td><font color='.'red'.'><b>미지급 임금</b></td>'.
             '<td>'.$monthNoArray[0].'원</td><td>'.$monthNoArray[1].'원</td><td>'.$monthNoArray[2].'원</td>'.
             '<td>'.$monthNoArray[3].'원</td><td>'.$monthNoArray[4].'원</td><td>'.$monthNoArray[5].'원</td>'.
             '<td>'.$monthNoArray[6].'원</td><td>'.$monthNoArray[7].'원</td><td>'.$monthNoArray[8].'원</td>'.
             '<td>'.$monthNoArray[9].'원</td><td>'.$monthNoArray[10].'원</td><td>'.$monthNoArray[11].'원</td>'.
             '<td><font color='.'red'.'><b>'.array_sum($monthNoArray).'원</b></td></tr>';
        echo '<tr class="odd"><td><font color='.'green'.'><b>지급 임금</b></td>'.
             '<td>'.$monthOkArray[0].'원</td><td>'.$monthOkArray[1].'원</td><td>'.$monthOkArray[2].'원</td>'.
             '<td>'.$monthOkArray[3].'원</td><td>'.$monthOkArray[4].'원</td><td>'.$monthOkArray[5].'원</td>'.
             '<td>'.$monthOkArray[6].'원</td><td>'.$monthOkArray[7].'원</td><td>'.$monthOkArray[8].'원</td>'.
             '<td>'.$monthOkArray[9].'원</td><td>'.$monthOkArray[10].'원</td><td>'.$monthOkArray[11].'원</td>'.
             '<td><font color='.'green'.'><b>'.array_sum($monthOkArray).'원</b></td></tr>';
        echo '</tbody></table>';
             


      
        mysqli_close($link);
            }
        ?>


</div>








</body>
</html>