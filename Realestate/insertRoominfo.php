<?php

	$conn=mysqli_connect("173.194.108.226","giyeon","1234");
	$db=mysqli_select_db($conn,'room_db') or die("DB connect Error");

    mysqli_set_charset($conn,'utf8');
?>

<html>
<head>
</head>
<body>
    <?php
        $roomName=isset($_POST['roomName']) ? $_POST['roomName'] : '';
        $displayName=isset($_POST['displayName']) ? $_POST['displayName'] : '';
        $saveName=isset($_POST['saveName']) ? $_POST['saveName'] : '';   
        $price=isset($_POST['price']) ? $_POST['price'] : '';   
        $latitude=isset($_POST['latitude']) ? $_POST['latitude'] : '';   
        $longitude=isset($_POST['longitude']) ? $_POST['longitude'] : '';   
        $fullAddress=isset($_POST['fullAddress']) ? $_POST['fullAddress'] : '';
        $showWindowHTML=isset($_POST['showWindowHTML']) ? $_POST['showWindowHTML'] : '';
        $Tel = isset($_POST['Tel']) ? $_POST['Tel'] : '';

        $file_name = isset($_FILES['photo']['name']) ? $_FILES['photo']['name'] : '';
        $file_type = isset($_FILES['photo']['type']) ? $_FILES['photo']['type'] : '';

        $target_dir = './image/';
        $target_file = $target_dir . basename($file_name);
        $imageFileType = pathinfo($target_file,PATHINFO_EXTENSION);


        $sql = "select * from roominfo where fullAddress='$fullAddress'";
        $result = mysqli_query($conn,$sql);
        $exist = mysqli_num_rows($result);

        if($exist){
            echo "<script>
                    window.alert('This address already exists.');
                    history.go(-1);
                </script>";
        	exit;
        } else {

            if($file_type != "image/png" && $file_type != "image/jpeg" && $file_type != "image/jpge" && $file_type != "image/jpg") {
                echo "<script>
                        window.alert('You Must be upload only Image FILE(.png, .jpeg, .jpge, .jpg)');
                        history.go(-1);
                    </script>";
                exit;
            } else {
                if(file_exists($target_file)) {
                    echo "<script>
                    window.alert('Sorry file already exists.');
                    history.go(-1);
                    </script>";
                } else {
                    if(move_uploaded_file($_FILES['photo']['tmp_name'],$target_file)) {
                       
                        $sql = "insert into roominfo (roomName, displayName, saveName, price, latitude, longtitude, fullAddress, showWindowHTML, imageURL, Tel)
                            values ('$roomName','$displayName','$saveName','$price','$latitude','$longitude','$fullAddress','$showWindowHTML','$target_file','$Tel')";
                            $tt = mysqli_query($conn,$sql);

                            echo $tt;
                            echo $sql;
                            mysqli_close($conn);

                            
                            echo "<script>
                                window.alert('Database insert Success!');
                                history.go(-1);
                                </script>";

                                exit;
                    } else {
                        echo "Error!";
                    }
                }

            }
        }
    ?>
</body>
</html>
