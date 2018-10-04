<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Page Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <style>
        h2 {
            margin : 30px;
        }
        table {
            margin :30px;
            background-color:#505e85;
            padding:5px;
        }
        td {
            color:#fff;
            font-size:20px;
            padding:5px
        }
      
        .geoCoder {
            background-color :#000;
            color:#fff;
            padding:10px;
            text-decoration:none;
            margin-left: 30px;
            border-radius:3px solid #ccc;
            
        }
    </style>

</head>
<body>
<h2>INSERT DATABASES</h2>

<table>
   <tbody>
   <tr><td>Show Text : </td><td><INPUT TYPE ='textbox' id ='showText' placeholder ='ex)수빌리지 A동'></td></tr>
   <tr><td>Insert Address : </td><td><INPUT TYPE = 'textbox' id = 'insertAddress' placeholder ='ex)충청남도 천안시 동남구 안서동 312-5번지'  size='45'></td></tr>
   <tr><td>Insert Price : </td><td><INPUT TYPE = 'textbox' id = 'price' size='3' maxlength='3' placeholder ='460'> 만원</td></tr>
   <tr><td>Room Master Tel : </td><td><INPUT TYPE ='textbox' id = 'tel_1' size='3' maxlength='3' value='010' placeholder ='010'> - <INPUT TYPE ='textbox' id = 'tel_2' size='4' maxlength='4' placeholder ='9434'>  - <INPUT TYPE ='textbox' id = 'tel_3' size='4' maxlength='4' placeholder ='7521'></td></tr>
    <tr><td>Show Window HTML : </td><td><textArea cols='50' rows='10' id='windowHTML'>
위치정보 : 상명대 도보 5분거리
방정보 : 14평
요금청구 : 전기세, 수도세 무료
</textArea></td></tr>

<!--SEND DB -->
<form method=post id="myForm" enctype ="multipart/form-data" name=form action="./insertRoominfo.php">

<INPUT TYPE ='hidden' name='roomName' value='' id='H_roomName'>
 <INPUT TYPE ='hidden' name='displayName' value='' id='H_displayName'>
 <INPUT TYPE ='hidden' name='saveName' value=''  id='H_saveName'>
 <INPUT TYPE ='hidden' name='price' value=''  id='H_price'>
 <INPUT TYPE ='hidden' name='latitude' value=''  id='H_latitude'>
 <INPUT TYPE ='hidden' name='longitude' value=''  id='H_longitude'>
 <INPUT TYPE ='hidden' name='fullAddress' value=''  id='H_fullAddress'>
 <INPUT TYPE ='hidden' name='showWindowHTML' value=''  id='H_showWindowHTML'>
 <INPUT TYPE ='hidden' name='Tel' value=''  id='H_Tel'>

<tr><td>Insert Image File </td><td><input type ='file' name='photo' multiple accept ='image/*'></td></tr>


<tr><td>lat, lng : </td><td>AUTO CHANGED BASED GEO CODER</td></tr>
<tr><td>full Addr : </td><td>AUTO CHANGED BASED GEO CODER</td></tr>
   </table>
    
</form>
   <a href="#" class="geoCoder">Address INSERT</a>



<script>

    $(document).on({
        click: function () {
            searchAddress($('#insertAddress').val());
        }
    },'.geoCoder');


//geoCoder 

function searchAddress(addr) {
    
        let geocoder = new google.maps.Geocoder();

        geocoder.geocode({          
            address:addr
        }, function(results, status) {
            if(status == google.maps.GeocoderStatus.OK) {
                let latlng  = results[0].geometry.location; // reference LatLng value
                let fullAddress = results[0].formatted_address;
                console.log(results[0]);

                    let insert = valueChange(latlng, addr);
                    let textArea = textAreaChange($('#windowHTML').val());
                    let tel = $('#tel_1').val().toString() + ' - ' + $('#tel_2').val().toString() + ' - ' + $('#tel_3').val().toString(); 
                    $('#H_roomName').val($('#showText').val().toString()); // 방이름
                    $('#H_displayName').val(addr.toString()); // 도로명 주소값  
                    $('#H_saveName').val(insert.saveAddress.toString()); //자동 변환
                    $('input[name="price"]').val($('#price').val().toString()); // 집값
                    $('input[name="latitude"]').val(Number(insert.latValue.toString())); //위도
                    $('input[name="longitude"]').val(Number(insert.lngValue.toString())); //경도
                    $('input[name="fullAddress"]').val(fullAddress.toString()); //변환 주소 
                    $('#H_showWindowHTML').val(textArea); //채우기
                    $('#H_Tel').val(tel);
                    
                    
            
                 
                    $('#myForm').submit();
                
            } else {
                alert("Wrong Address, Please Check Address return");
            }
        });
    }
    
    function textAreaChange (str) {
        return str.replace(/(?:\r\n|\r|\n)/g, '<br />');
    }

    function valueChange(latlng, str) {
 
        let lookup = latlng.toString().slice(1,-1).split(',');
        let latValue = Number(lookup[0]);
        let lngValue = Number(lookup[1].trim());
        let saveAddress = str.replace(/(^ *)|( *$)/g, "").replace(/ +/g, " ").replace(/\s/g, "-").toLowerCase().replace(/\./g,"").replace(/\'/g, "");
        return {
            latValue : latValue,
            lngValue : lngValue,
            saveAddress : saveAddress
        };
    }


//document.readey
$(document).ready(function () {
    
});

</script>



<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBo1pWZUjkz8HmsvfUGyV69YsRHtwZwe7U" type="text/javascript"></script>
</body>
</html>
