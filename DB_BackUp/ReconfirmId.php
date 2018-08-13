<?php
 include "/home/kbstar13/public_html/db_connect.php";

 
    $id=isset($_GET['Id']) ? $_GET['Id'] : '';  

    $sql="select count(*) from Master where Id='$id'";
    $result=mysqli_query($link,$sql);
    $row=mysqli_fetch_array($result);
    
    mysqli_close($conn);
?>

<script>

 var row="<?= $row[0] ?>";
 
 if(row==1){
    parent.document.getElementById("chk_id2").value="0";
    parent.alert("이미 사용중인 아이디입니다.");

 }

 else{
    parent.document.getElementById("chk_id2").value="1";
    parent.alert("사용 가능합니다.");
 }

</script>
