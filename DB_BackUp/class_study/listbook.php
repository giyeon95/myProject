<?php

	$con = mysqli_connect('localhost','kbstar13','giyeon');
	if(!$con) {
		die('could not connect: ' . mysqli_error($con));
	}
	mysqli_select_db($con,'kbstar13_db');
		
	echo mysqli_character_set_name($con);
	mysqli_set_charset($con,'utf8');

	$id = $_POST['bookid'];
	$price = $_POST['price'];
	$name = $_POST['bookname'];
	$publisher = $_POST['publisher'];

	echo "<pre>";
	print_r($_POST);
	echo"</pre>";

	$sql = "SELECT * FROM book";
	echo "$sql";

	$result = mysqli_query($con,$sql);

	echo "<table border =\"2\">";
	echo "<tr>
	<td><h2>bookID</h2></td>
	<td><h2>bookname</h2></td>
	<td><h2>bookPrice</h2></td>
	</tr>";

	while($row = mysqli_fetch_assoc($result)) {
		echo '<tr>
		<td><h3> '.$row["bookid"]."</h3></td>
		<td><h3>".$row["bookname"]."</h3></td>
		<td><h3>".$row['price']."</h3></td>
		</tr>";		
	}

	echo"</table>";
	mysqli_free_result($result);
	mysqli_close($con);

	?>
