<?php
	$con = mysqli_connect('localhost','kbstar13','giyeon','kbstar13_db');
	if(!$con) {
	die ('could not connect:' . mysqli_error($con));
	echo '연결실패';
}
	$sql = "CREATE TABLE HELLO (num int, name varchar(30))";
	$result = mysqli_query($con,$sql);
	mysql_close($con);

?>
