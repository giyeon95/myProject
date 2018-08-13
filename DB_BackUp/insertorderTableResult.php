
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
  <div id="header">이부분은 헤더</div>
  <br>

</body>
</html>


<?php

$CompanyName = $_SESSION['CompanyName'];
$Balance = $_SESSION['Balance'];
$orderdate=isset($_POST['orderdate']) ? $_POST['orderdate'] : '';
$desDate=isset($_POST['desDate']) ? $_POST['desDate'] : '';
$allSum;

$count=isset($_POST['count']) ? $_POST['count'] : '';

$productEncoding=isset($_POST['productEncoding']) ? $_POST['productEncoding'] : '';
$priceEncoding=isset($_POST['priceEncoding']) ? $_POST['priceEncoding'] : '';


$productName = explode("!,!", $productEncoding);
$productPrice = explode("@,@", $priceEncoding);

    for($i=0 ; $i<$count; $i++) {
        $arrCount[$i] = $productCount=isset($_POST['productCount'.$i]) ? $_POST['productCount'.$i] : '0';
        $sumPrice[$i] = $arrCount[$i]*$productPrice[$i];
    }
$allSum = array_sum($sumPrice); 

    if($Balance < $allSum) {
        echo "<script>alert('통장 잔고가 부족합니다. 금액을 확인해주세요');history.go(-1);</script>";
    }   
    else {
        if ($orderdate !="" and $desDate !="" and $count !="" and $productEncoding !=""and $priceEncoding !=""){   
            $i=0;
            do {
                if(!isset($sql)) { //sql값이 처음이 아닐때
                    if($sumPrice[$i] !=0) { //첫물품 개수가 0이 아닐때
                        $sql="insert into orderTable(masterCompanyName,productName,count,
                                orderdate,desDate,processing,sumPrice) 
                                VALUES('$CompanyName','$productName[$i]','$arrCount[$i]','$orderdate',
                                '$desDate','0','$sumPrice[$i]');";
                        
                        $i++;
                    } else {
                        $i++;
                        while($i<$count) { //물품 개수가 1개 이상인것을찾는 알고리즘
                            if($sumPrice[$i] !=0) {
                                $sql="insert into orderTable(masterCompanyName,productName,count,
                                orderdate,desDate,processing,sumPrice) 
                                VALUES('$CompanyName','$productName[$i]','$arrCount[$i]','$orderdate',
                                '$desDate','0','$sumPrice[$i]');";
                                echo $i."<br>";
                                $i++;
                                break;
                            } else {
                                $i++;
                            }
                        }

                        //echo $i;

                        }
                } else {
                    if($sumPrice[$i] !=0) {
                        $sql .="insert into orderTable(masterCompanyName,productName,count,
                        orderdate,desDate,processing,sumPrice) 
                        VALUES('$CompanyName','$productName[$i]','$arrCount[$i]','$orderdate',
                        '$desDate','0','$sumPrice[$i]');";
                        echo $i."<br>";
                        $i++; 
                    } else {
                        $i++;
                    }

                }
            } while($i<$count);
                // echo $sql;
                    $sql = substr($sql,0,-1);
                
            $next= false;

        if(mysqli_multi_query($link, $sql)){
                $next=true;
            do {
                /* store first result set */
                if ($result = mysqli_store_result($link)) {
                    mysqli_free_result($result);
                }
            } while (mysqli_next_result($link));
        }
            if($next){
                echo "<script>
                window.location.replace('./productDepositMaster.php?price=".$allSum."');</script>";
            
            
            }  
            else{  
                echo "<script>alert('날짜를 입력하고 다시 시도하세요');
                history.go(-1);</script>";
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
