<html>
<head>
<meta charset="UTF-8">
<link rel="stylesheet" href="./css/frame.css" type="text/css">
<script src="//code.jquery.com/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="./js/frame.js"></script>

<style>
        span {color:red;font-size:20px;}
        #SignUp {
            margin-left:30px;
            
        }
</style>

<script type="text/javascript">
  
    function check() {
        var check_id2 = document.getElementById("chk_id2").value;
        var chk_pw2 = document.getElementById("chk_pw2").value;

        if(check_id2==0) {
            alert("아이디 중복검사를 해주세요");
            return false;
        }

        else if(chk_pw2 == 0) {
            alert("비밀번호가 다릅니다 다시 확인해주세요.");
            return false;
        }

        return true;
    }

    //ID값 DB에서 중복되는지 확인
    function child() {
     
        document.getElementById("chk_id2").value=0;
        var id = document.getElementById("Id").value;
       
        if(id=="") {
            alert("빈칸입니다.");
            exit;
        }

        ifrm1.location.href="ReconfirmId.php?Id="+id; 
    }


    function pwCheck() {

        var password = document.getElementById("Password").value;
        var passwordCheck = document.getElementById("passwordCheck").value;
        var getPwCheck = document.getElementById("pwCheck_Text");
        document.getElementById("chk_pw2").value=0;



        if((password != passwordCheck )&& passwordCheck !=null) {
            getPwCheck.innerHTML = "<b><font color=red> 비밀번호가 불일치합니다.</font></b>"
            document.getElementById("chk_pw2").value=0;
        }

        else if(password == passwordCheck) {
            getPwCheck.innerHTML = "<b><font color=green> 비밀번호가 일치합니다.</font></b>"
            document.getElementById("chk_pw2").value=1;
        }
    }

</script>

</head>
<body>


<div id="header">이부분은 헤더</div>



<center> <div id="contents">
<br>
<br>
<h2>Giyeon 회원가입 Form</h2>
<p><span>* 필수입력</span></p>

<form method = "post" action ="InsertSignUp.php" onsubmit="return check()">
    <center>
<div id="signUp">
    <table>
        <tr>
           
                <td>Id : </td>
                <td> <input type = "text" name = "Id" id="Id"></td>
                <td> <span> * <input type=button value="중복검사" onClick=child()> <span> </td>
                <input type = hidden id="chk_id2" name=chk_id2 value="0">

        </tr>
        
        <tr>
            <td>Password :</td>
            <td> <input type = "password" name = "Password" id="Password"></td>
            <td> <span> * </span></td>
        </tr>

        <tr>
            <td>Check Password</td>
            <td><input type="password" name="passwordCheck" id="passwordCheck" onkeyup="pwCheck()"/></td>
            <td id="pwCheck_Text"> </td>
            <input type = hidden id="chk_pw2" name=chk_pw2 value="0">
        </tr>


        <tr>
            <td>CompanyName :</td>
            <td> <input type = "text" name = "CompanyName"></td>
            <td> <span> * </span></td>
        </tr>
        
        <tr>
            <td>Address : </td>
            <td><input type = "text" name = "Address"></td>
            <td> <span> * </span></td>
        </tr>
        
        <tr>
            <td>Phone :</td>
            <td> <input type = "text" name = "Phone"></td>
            <td> <span> * </span></td>
        </tr>
    
        <tr>
            <td>Balance :</td>
            <td><input type = "text" name = "Balance"></td>
            <td> <span> * </span></td>
        </tr>
    </table>
</div>


<input type = "submit" name = "submit" value = "회원가입">

</form>

</div>

<iframe src="" id="ifrm1" scrolling=no frameborder=no width=0 height=0 name="ifrm1"></iframe>


</body>
</html>