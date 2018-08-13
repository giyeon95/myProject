
<?php session_start(); 
    include "/home/kbstar13/public_html/db_connect.php";
?>

<html>
<head>
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>
</head>
<body>
  <div id="miniHeader">송금중 ....</div>
  <br>
  <div id="miniBody">송금중 ....</div>
  <div id="minifooter">송금중 ....</div>

</body>
</html>


<?php

        $CompanyName = $_SESSION['CompanyName'];  
        $Balance = $_SESSION['Balance'];
        $pay_sum=isset($_GET['pay_sum']) ? $_GET['pay_sum'] : '';
        $num=isset($_GET['num']) ? $_GET['num'] : '';

    if($Balance < $pay_sum) {
        echo "<script>alert('통장 잔고가 부족합니다. 금액을 확인해주세요');history.go(-1);</script>";
    }   
    else { 
            if ($pay_sum !="" and $CompanyName !="" and $num != ""){   
        
                $sql ="UPDATE Master AS T1, (
                        SELECT Balance FROM Master WHERE CompanyName ='$CompanyName') AS T2
                        SET T1.Balance = T2.Balance-$pay_sum
                        WHERE T1.CompanyName = '$CompanyName'";
                        
                
                        //$sql .="UPDATE PayManager SET Deposit =0 WHERE Prinum =3";
                $result=mysqli_query($link,$sql);  
            
                if($result){
                
                echo "<script>alert('잔액이 빠져나감.');
                        window.location.replace('./DepositMasterResult.php?num=".$num."');</script>";
            
                }  
                else{  
                //echo "<script>alert('오류 발생 재시도 바람');
                // window.location.replace('./insertEmployees.php');</script>";
                echo "SQL문 처리중 에러 발생 : "; 
                echo mysqli_error($link);
                } 
            
        }
        
        else {
            echo "<script>alert('데이터값 안넘어옴.');history.go(-1);</script>";
        }

    }

mysqli_close($link);

?>
