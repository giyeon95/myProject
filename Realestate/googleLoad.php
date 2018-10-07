
<?php
    include "./sql/dbConnect.php";
?>


<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>GoogleMap Project</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="./css/myCss.css">
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <style>
        .infoWindowH3 {
            font-size:20px;
            margin-bottom: -0.1em;
            margin-top: 0.5em;
        }

        .infoWindowFullAddress {
            margin-bottom: 7px;
            color: #0000ff;
        }


        .divLine {
            width:400px;
            height:3px;
            background-color:green;
        }
        .divLine2 {
            width:400px;
            height:1px;
            background-color:#ccc;
            margin-bottom:1px;
        }
    
        .infoWindowContainer {
            position:relative;
        }

        .roomPhoto {
            margin: 5px 0px;
            width: 100%;
            height: 220px;
        }
    
        .textContainer {
            display:block;
            width:100%;
         
            font-size: 14px;
            font-weight: 600;
            margin: 8px 0px;
        }
        .phoneNum {
            font-size: 14px;
            margin-top: 3px;
            text-align: right;
            font-weight: 900;
        }
        /* .infoWindowContainer {
            background-color: #fff;
        } */
    </style>

</head>
<body>
    <h3>GoogleMap Project</h3> <hr>

<div id="map" style="float: left; width: 50%; height: 100%; ">My map will go here</div>


<div style="padding-left: 50px; overflow-y: scroll; height: 100%;">
    <div>
        <h3>Check Price</h3>
        <div>
            <input type="checkbox" name="category" value="school" id="scSchool" data-name="category-school" checked> 300(만원) 이하
            <input type="checkbox" name="category" value="park" id="scPark" data-name="category-park" checked> 300-400(만원)
            <input type="checkbox" name="category" value="restaurant" id="scRest" data-name="category-restaurant" checked> 400-500(만원)
            <input type="checkbox" name="category" value="public" id="scPublic" data-name="category-publicTransportation" checked> 500-600(만원)
            <input type="checkbox" name="category" value="shopping" id="scShopping" data-name="category-shoppingCenter" checked>600(만원) 이상
           
        </div>
    </div>

    <div>
        <h3>Search Address in Map</h3>
        Address : <input class="searchMap" type="text" hint="insert Address">
        <a href="#" class="searchButton">Search</a>
    </div>


    <h3 id="headerSchool" class="categoryHeader">300(만원) 이하</h3>
    <div id="insertSchool" class="categoryDiv"></div>

    <h3 id="headerPark" class="categoryHeader">300-400(만원)</h3>
    <div id="insertPark"  class="categoryDiv"></div>

    <h3 id="headerRestaurant" class="categoryHeader">400-500(만원)</h3>
    <div id="restaurant"  class="categoryDiv"></div>

    <h3 id="headerPublicTransportation" class="categoryHeader">500-600(만원)</h3>
    <div id="publicTransportation"  class="categoryDiv"></div>

     <h3 id="headerSchoolShoppingCenter" class="categoryHeader">600(만원) 이상</h3>
    <div id="shoppingCenter"  class="categoryDiv"></div>



</div>

<script>
    var homeMarker = [];
    var mMarker = [];
    var map;
    var startbool = false;

    const homeMarkerPath = "./img/marker32_black.png";
    const schoolMarkerPath = "./img/marker32_blue.png";
    const parkMarkerPath = "./img/marker32_green.png";
    const restaurantsMarkerPath = "./img/marker32_yellow.png";
    const publicMarkerPath = "./img/marker32_pouple.png";
    const shoppingMarkerPath = "./img/marker32_red.png";
   

    $('.searchButton').click(function () {
        let address = $('.searchMap').val();

        if(!address) {
            alert("Please Insert Text Value");
        } else {            
            searchAddress(address, callDatabase);
        }
    });


    $('[type="checkbox"]').on('change',function () {
        
        let dataName = $(this).data('name');
        let pDiv = $(this);
        
        switch (dataName) {
            case 'category-school' : chooseDataName(0, dataName, pDiv); break;
            case 'category-park' : chooseDataName(1, dataName, pDiv); break;
            case 'category-restaurant' : chooseDataName(2, dataName, pDiv); break;
            case 'category-publicTransportation' : chooseDataName(3, dataName, pDiv); break;
            case 'category-shoppingCenter' : chooseDataName(4, dataName, pDiv); break;
            default : console.log('Check Box error!'); break;
        }
    });

    function chooseDataName(j, dataName, pDiv) {

         if(!(pDiv.prop('checked'))) { //check false 일때
                    $('#'+dataName+' > p').each(function (i, item) {
                        $(this).addClass('gray');
                    });
                        categoryMarkerHidden(j, false);
                }
                else {
                    $('#'+dataName+' > p').each(function (i, item) {
                        $(this).removeClass('gray');
                    });
                        categoryMarkerHidden(j, true);
                }
    }

    $(document).on({
        click : function () {
            let pTag = $(this);
            let dataVal = $(this).data("mapFull");
            markerHidden(dataVal, pTag);
        },
        mouseover : function() {
            let dataVal = $(this).data("mapFull");
            animation(dataVal, true);
        },
        mouseout : function() {
            let dataVal = $(this).data("mapFull");
            animation(dataVal, false);
        }
    },'div > p');

    function initMap() {
            let loadPosition = {lat: 49.1444590, lng: -122.8202910}; //basic lat, lng
            map = new google.maps.Map(
                document.getElementById('map'), {zoom: 16, center: loadPosition}); // 새로운 지도객체 생성 및 속성 추가
               
                   let marker = new google.maps.Marker({position: loadPosition, map : map, icon : homeMarkerPath});
                    homeMarker.marker = marker;
                      
            google.maps.event.addListener(map, 'dragend', function() {
                callDatabase();
            });
            // google.maps.event.addListener(map, 'idle', function() {
                
            // });
    }

    function addMarker() {
       
       $.each(mMarker, function(i,item) {
           
            let roomName = item.roomName;
            let category = item.category;
            let displayName = item.displayName;
            let fullAddress = item.fullAddress;
            let number = item.num;
            let markerIcon;
            if(category == "school") { markerIcon = schoolMarkerPath; }
            if(category == "park") { markerIcon = parkMarkerPath; }
            if(category == "restaurants") { markerIcon = restaurantsMarkerPath; }
            if(category == "publicTransportation") { markerIcon = publicMarkerPath; }
            if(category == "shoppingCenter") { icon = shoppingMarkerPath; }
        
        
            let marker = new google.maps.Marker({
                
                position : mMarker[i].latlng,
                map:map,
                draggable:false,
               
                title:mMarker[i].fullAddress,
                icon:markerIcon,
                label:number.toString()
            });
            item.markers = marker;

            marker.addListener('mouseover', function() {
                let dataVal = marker.getTitle();
                let mappingText = $('p[data-map-full="'+dataVal+'"]');
                mappingText.addClass('hilight');
            });

             marker.addListener('mouseout', function() {
                let dataVal = marker.getTitle();
                let mappingText = $('p[data-map-full="'+dataVal+'"]');
                let parentId = mappingText.parent().attr('id');
                mappingText.removeClass('hilight');
                //infowindow.close(map, marker);            
                //mappingText.removeClass('gray');  
                $('[data-name="'+parentId+'"]').prop('checked',true);
            });

          
            let con ='<div class="infoWindowContainer">'+
                '<h3 class="infoWindowH3">'+item.roomName+'</h3>'+
                '<p class="infoWindowFullAddress">'+item.fullAddress+'</p>'+
                '<div class="divLine"></div>'+
                '<div class="roomPhoto"></div>'+
                '<div class="divLine2"></div>'+
                '<div class="divLine2"></div>'+
                '<div class="textContainer">'+item.showWindowHTML+'</div>'+
                '<div class="divLine"></div>'+
                '<div class="phoneNum">Tel : '+item.Tel+'&emsp;&emsp;<a style='+'padding:2px; border-radius:5px;'+' href='+'./googleMapReple/index.php?roomName='+item.roomName+'>후기확인</a>&emsp;&emsp;가격(년세) :'+item.price+'만원</div>'
                '</div>';

            let infowindow = new google.maps.InfoWindow({
                content : con,
                maxWidth: 400
            });
            item.infowindows = infowindow;

            marker.addListener('click',function() {

                $.each(mMarker, function(i, item) {
                    if(item.infoStatus) {
                        console.log(infowindow);
                        item.infowindows.close(map, item.markers);
                        item.infoStatus = false;
                    }
                });

                infowindow.open(map, marker);
                item.infoStatus = true;
                $('.gm-style-iw').prev('div').remove();
                $('.gm-style-iw').parent().css({
                    'background-color' : 'rgba(255,255,255,0.9)',
                    'border-radius' : '20px',
                    'box-shadow' : '1px 1px 3px green'
                });
                $('.gm-style-iw').css('left','25px');

                $('.roomPhoto').css({
                    'background-image' : 'url('+item.imageURL+')',
                    'background-size' : 'cover',
                    'background-position' : 'center center'
                    
                });
                
            });

            // marker.addListener('click',function() {
            //     let dataVal = marker.getTitle();
            //     let mappingText = $('p[data-map-full="'+dataVal+'"]');
            //     let parentId = mappingText.parent().attr('id');
            //     let countList = $("#"+parentId+" > p").length;
            //     let count = 0;
            //     $.each(mMarker, function(i, item) {
            //         if(dataVal == item.fullAddress) {
                        
            //             if(mappingText.hasClass('gray')) {
            //                 item.markers.setVisible(false);
            //                 mappingText.removeClass('hilight');

            //             } else{
            //                 mappingText.addClass('gray');
            //             }   
            //         }           
            //     });

            //     $.each($("#"+parentId+" > p"), function(i, item) {
            //         if($(this).hasClass('gray')) {
            //             count ++;  
            //         }
            //     }); 
            //     if(countList == count) { $('[data-name="'+parentId+'"]').prop('checked',false);}
               
            // });

        });
    }
    
    function addView() {

        let schoolHtml = ['<div id='+'category-school'+'>'];
        let parkHtml = ['<div id='+'category-park'+'>'];
        let restaurantHtml = ['<div id='+'category-restaurant'+'>'];
        let publicTransportationHtml = ['<div id='+'category-publicTransportation'+'>'];
        let shoppingCenterHtml = ['<div id='+'category-shoppingCenter'+'>'];
       
        
        $.each(mMarker, function(i, item) {
            if(item.category=="school") { schoolHtml.push('<p data-map-num="'+i+'" data-map-full="'+item.fullAddress+'">'+i+' : '+ item.roomName +'</p>'); }
            if(item.category=="park") { parkHtml.push('<p data-map-num="'+i+'" data-map-full="'+item.fullAddress+'">'+i+' : '+ item.roomName +'</p>'); }
            if(item.category=="restaurants") { restaurantHtml.push('<p data-map-num="'+i+'" data-map-full="'+item.fullAddress+'">'+i+' : '+ item.roomName +'</p>'); }
            if(item.category=="publicTransportation") { publicTransportationHtml.push('<p data-map-num="'+i+'" data-map-full="'+item.fullAddress+'">'+i+' : '+ item.roomName +'</p>'); }
            if(item.category=="shoppingCenter") { shoppingCenterHtml.push('<p data-map-num="'+i+'" data-map-full="'+item.fullAddress+'">'+i+' : '+ item.roomName +'</p>'); }
        });

            schoolHtml.push('</div>');
            parkHtml.push('</div>');
            restaurantHtml.push('</div>');
            publicTransportationHtml.push('</div>');
            shoppingCenterHtml.push('</div>');

            $('#insertSchool').html(schoolHtml.join(''));
            $('#insertPark').html(parkHtml.join(''));
            $('#restaurant').html(restaurantHtml.join(''));
            $('#publicTransportation').html(publicTransportationHtml.join(''));
            $('#shoppingCenter').html(shoppingCenterHtml.join(''));
       
    }
    
    function searchAddress(addr, callback) {
    
        let geocoder = new google.maps.Geocoder();
      
        geocoder.geocode({          
            address:addr
        }, function(results, status) {
            if(status == google.maps.GeocoderStatus.OK) {
                let latlng  = results[0].geometry.location; // reference LatLng value
                let fullAddress = results[0].formatted_address;
                console.log(results[0]);
                map.setCenter(latlng);
                homeMarker.marker.setMap(null);
                let marker = new google.maps.Marker({position: latlng, map : map, icon : homeMarkerPath});
                homeMarker.marker = marker; 
                map.setCenter(latlng);
                   
                    callback();
            } else {
                alert("Wrong Address, Please Check Address return");
            }
        });
    }

    function categoryMarkerHidden(i, boolType) {

        switch(i) {
            case 0 : 
                $.each(mMarker,function(i, item) {
                    if(item.category == 'school') {
                        if(!boolType) item.infowindows.close(map, item.markers);
                        item.markers.setVisible(boolType);
                         
                    }
                });
                break;        
            case 1 : 
                $.each(mMarker,function(i, item) {
                    if(item.category == 'park') { 
                        if(!boolType) item.infowindows.close(map, item.markers); 
                        item.markers.setVisible(boolType);
                        
                    }
                });
                break;
            case 2 :
                $.each(mMarker,function(i, item) {
                    if(item.category == 'restaurants') { 
                        item.markers.setVisible(boolType); 
                        if(!boolType) item.infowindows.close(map, item.markers); 
                    }
                });
                break;
            case 3 :
                $.each(mMarker,function(i, item) {
                    if(item.category == 'publicTransportation') {
                        item.markers.setVisible(boolType);
                        if(!boolType) item.infowindows.close(map, item.markers); 
                    }
                });
                break;
            case 4 :
                $.each(mMarker,function(i, item) {
                    if(item.category == 'shoppingCenter') { item.markers.setVisible(boolType); }
                });
                break;

            default :
                console.log("switch Error!");
                break;
        }
    }
    
    function callDatabase() {
        
        let x1 = map.getBounds().getSouthWest().lat();
        let y1 = map.getBounds().getSouthWest().lng();
        let x2 = map.getBounds().getNorthEast().lat();
        let y2 = map.getBounds().getNorthEast().lng();
        let addNum = 0;
       
        $.each(mMarker, function(i,item) {
            mMarker[i].markers.setMap(null);
        });

        mMarker=[];
       
        $.ajax({
            method: "POST",
            url: "./json/pin_json.php",
            data: { 
                x1: x1,
                x2: x2,
                y1: y1,
                y2: y2
            },
            success: function(data) { 
                $.each(data, function(i,item) {            
                        let obj = new Object();
                        obj.num = addNum;
                        obj.roomName = item.roomName;
                        obj.displayName = item.displayName;
                        obj.latlng = new google.maps.LatLng(item.latitude,item.longtitude);
                        obj.fullAddress = item.fullAddress;
                        obj.price = item.price;
                        obj.showWindowHTML = item.showWindowHTML;
                        obj.imageURL = item.imageURL;
                        obj.Tel = item.Tel;
                        obj.infoStatus = false;
                        if(item.price < 300) obj.category = 'school';
                        if(item.price >= 300 && item.price < 400) obj.category = 'park';
                        if(item.price >= 400 && item.price < 500) obj.category = 'restaurants';
                        if(item.price >= 500 && item.price < 600) obj.category ='publicTransportation';
                        if(item.price >= 600) obj.category ='shoppingCenter';

                        mMarker[addNum] = obj;
                        addNum++;
                });
                categoryEmpty();
                addMarker();
                addView();
            } 
        });
        console.log(mMarker);
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

    function animation(dataVal,bool) {
        $.each(mMarker, function(i, item) {
            if(dataVal == item.fullAddress) {
                if(!bool) {
                    item.markers.setAnimation(null);
                } else {
                    item.markers.setAnimation(google.maps.Animation.BOUNCE);
                }           
            }         
        });
    }

   

    function markerHidden(dataVal, pTag) {
       
        let parentId = pTag.parent().attr('id');
        let count = 0;
        let boolCheckbox = false;
        let childCount = $("#"+parentId+" > p").length;

        $("#"+parentId+" > p").each(function (i, item) {
            if($(this).hasClass('gray')) {
                boolCheckbox = true;
                count++;
            }
        });

        $.each(mMarker, function(i, item) {
            if(dataVal == item.fullAddress) {
                if(pTag.hasClass('gray')) {
                    pTag.removeClass('gray');
                    item.markers.setVisible(true);
                    count--;
                } else{
                    pTag.addClass('gray');
                    item.markers.setVisible(false);
                    item.infowindows.close(map, item.markers);
                    count++;
                }
                
            }           
        });

        if(boolCheckbox) { $('[data-name="'+parentId+'"]').prop('checked',true); } 
        if(childCount == count) { $('[data-name="'+parentId+'"]').prop('checked',false); }

        startbool = true;
    }

    function categoryEmpty() {
        $('.categoryDiv').each(function (i, item) {
            $(this).empty();
        });
    }

</script>

<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBo1pWZUjkz8HmsvfUGyV69YsRHtwZwe7U&callback=initMap" type="text/javascript"></script>
</body>
</html>
