<!DOCTYPE html>
<?php session_start(); ?>
<meta charset="utf-8" />
<html>
<head>
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>
</head>

<body>
	 <div id="header">이부분은 헤더</div>
	 <div id="contents">
	 <?php if(!isset($_SESSION['user_id']) || !isset($_SESSION['CompanyName'])) { ?>
        <form method="post" action="login_ok.php">
            <p>아이디: <input type="text" name="user_id" /></p>
            <p>비밀번호: <input type="password" name="user_pw" /></p>
            <p><input type="submit" value="로그인" /></p>
        </form>
        <?php } else {
            $user_id = $_SESSION['user_id'];
            $CompanyName = $_SESSION['CompanyName'];
            echo "<p><strong>$CompanyName</strong>($user_id)님은 이미 로그인하고 있습니다. ";
            echo "<a href=\"index.php\">[돌아가기]</a> ";
            echo "<a href=\"logout.php\">[로그아웃]</a></p>";
			
		}
		
		?>
	<div>
</body>
</html>
