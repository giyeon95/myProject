
<?php
    include "./dbConnect.php";   
?>

<?php
    $roomName = isset($_GET['roomName']) ? $_GET['roomName'] : '';
?>

<html>
<head>
    <style>
        body {
            padding: 30px;

        }
        .contentsMain {
            margin-top: 5px;
            margin-bottom: 5px;
            padding-left: 15px;
            font-weight:700;
        }
        .contentsNick {
            border-bottom: 1px solid black;
            margin-top: 5px;
            padding-bottom: 5px;
            margin-bottom: 10px;
            font-size: 13px;
            padding-left: 15px;
        }
        .CommentContainer {
            border: 1px solid #000;
            margin-bottom: 10px;
        }

    </style>


     <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
</head>

<body>
    <div class="repleContainer">
       
    </div>

    <form method=post id="sendCommnet" name="form" action="./insertComment.php">
        <div class="table">
            <table>
                <thead></thead>
                <tbody>
                <tr><td>글쓴이 : <INPUT TYPE = 'textbox' name='writter' id='writter' size='5' maxlength='5' placeholder='닉네임'></td></tr>
                <tr><td>Commnet</td></tr>
                <tr><td><textArea cols='260' rows='10' name='contants' id='contants'></textArea></td></tr>
                <tr><td><input type='hidden' name='roomName' value='<?= $roomName ?>'></td></tr>
                </tbody>
            </table>
        </div>
    <INPUT TYPE="submit" value="등록">
    </form>
    
    <a href='#' id="testA">test</a>

<script>

        var array = [];

        $(document).ready(function () {
           
            let roomName = '<?= $roomName ?>';
            let addNum = 0;
           
            $.ajax({
                method:"POST",
                url : "./getJson.php",
                data: {
                    roomName : roomName
                },
                success: function(data) {
                    $.each(data, function(i,item) {
                        let obj = new Object();
                        obj.num = addNum;
                        obj.writter =item.writter;
                        obj.contants = item.contants;
                        array[addNum] = obj;
                        addNum++;

                        
                    });
                    addView();
                },
                error:function(request,status,error) {
                    console.log(request);
                }
                
            });
        });
        
        $(document).on({
            click : function() {
                
            }
        },'#testA');

        function addView() {
            let newDiv = ['<div class='+'newDiv'+'>'];

            $.each(array, function(i, item) {
                newDiv.push('<div class='+'CommentContainer'+'><p class='+'contentsNick'+'>'+'작성자 : '+item.writter+'<br></p>');
                newDiv.push('<p class='+'contentsMain'+'>'+'후기<br> '+item.contants+'</p></div>');
            });
               
            
            newDiv.push('</div>');
            $('.repleContainer').html(newDiv.join(''));
        }
</script>

</body>
</html>