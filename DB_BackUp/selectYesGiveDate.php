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
        function checkvalue(obj) {
            var date1 = $("#date").val();
            var date2 = $("#date2").val();
            
            if(!(date1=="" || date2=="")) {
                if(date2 <= date1) {
                    alert("날짜값이 크거나 작습니다.");
                    $("#date2").val("");
                } else {
                    obj.style.backgroundColor='yellow';    
                }
            }
        }

        $(function() {
            $("#date").datepicker();
            $("#date2").datepicker();
            
        });
       
    </script>
</head>


<body>



<?php


 if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) {
    echo "<br><center><h3><p>로그인을 해 주세요. <a href=\"login.php\">[로그인]</a></p><h3>";
    } else {

        $CompanyName = $_SESSION['CompanyName'];
        $Balance = $_SESSION['Balance'];
        $date=isset($_POST['date']) ? $_POST['date'] : '';  
        $date2=isset($_POST['date2']) ? $_POST['date2'] : '';  
     
        $monthNoArray = array(0,0,0,0,0,0,0,0,0,0,0,0);
        $monthOkArray = array(0,0,0,0,0,0,0,0,0,0,0,0);


        echo "<div id='header'><center></div>";
       
        echo "<div id='miniBody'><center>";
        
        echo "<FORM METHOD='post' ACTION = 'selectYesGiveDate.php'>";
        echo '<br><table class="ex2"><caption><h4>날짜 조회</h4></caption>
            <tr><td>기간</td><td>'.
            "<input type='text' name='date' id='date' size='6' onchange='checkvalue(this)' /><td>~  </td>";
        echo '<td>'."<input type='text' name='date2' id='date2' size='6' onchange='checkvalue(this)' /></td>
                <td><INPUT TYPE='submit' VALUE='재 조회'></td><tr></table>";

        echo "</form>";
      
        echo "<br><h3>".$CompanyName." 의 알바비 지출 여부</h3>";

                #SELECT Employees.name, 
                
        $sql="SELECT Employees.name,PayManager.Date,PayManager.workTime,PayManager.pay,PayManager.pay_sum,PayManager.Deposit
        FROM Employees
        RIGHT OUTER JOIN PayManager 
        ON Employees.Code = PayManager.Employees_Code 
        WHERE PayManager.Deposit='1' AND Employees.Master_CompanyName='$CompanyName' AND DATE(PayManager.Date) BETWEEN '$date' AND '$date2'
        ORDER BY DATE ASC;";  
        $result=mysqli_query($link,$sql);  
    
          
        
          
        echo '<table class="ex1"><thead><tr>' .
            '<th>이름</th><th>Date</th><th>workTime</th><th>시급</th>' .
            '<th>총액</th><th>입금여부</th><th>입금하기</th></tr></thead>';
        echo "<TBODY>";

        
        if(!$result) {
            echo $date."<br>";
            echo $date2."<br>";
            echo "<script>alert('조회결과가 존재하지 않습니다.');history.go(-1);</script>";
        } else {
                
        
                while($row = mysqli_fetch_array($result)) {
                    echo '<tr class='.'odd'.'>'.
                    
                        '<td>' .$row['name'].'</td>'.
                        
                        '<td>' . $row['Date'] . '</td>' .
                        '<td>' . $row['workTime'] . '시간</td>' .
                        '<td>' . $row['pay'] . '원</td>'.
                        '<td>' . $row['pay_sum'] . '원</td>';
                    if($row['Deposit']==0) {
                        echo '<td><font color='.'red'.'>미 지급</td>';
                    } else {
                        echo '<td><font color='.'green'.'>지급 완료</td>';
                    }
                    
                    if($row['Deposit']==0) {
                        echo '<td><a href='.'DepositMaster.php?num=&pay_sum='.$row['pay_sum'].'>입금하기</a></td></tr>';
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
                echo '</tbody></table></div>';
                    

            }
      
        mysqli_close($link);
            }
        ?>


</div>








</body>
</html>