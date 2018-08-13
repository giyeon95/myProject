$(document).ready(function() {
	 	$("#header").load("http://203.230.194.126/~kbstar13/top.html");
		//$("#contents").load("./top.php"); 
	});

	function bgcolor_yellow(obj) {

		var NT_date = new Date();
		var nt_year = NT_date.getYear()+1900;
		var nt_month = NT_date.getMonth()+1;
		var nt_day = NT_date.getDate();
		var stringDate;

		if(nt_month <10) {
			if(nt_day<10) {
				stringDate = nt_year+"-0"+nt_month+"-0"+nt_day;
			} else {
				stringDate = nt_year+"-0"+nt_month+"-"+nt_day;
			}
		} else {
			if(nt_day<10) {
				stringDate = nt_year+"-"+nt_month+"-0"+nt_day;
			} else {
				stringDate = nt_year+"-"+nt_month+"-"+nt_day;
			}
		}
		
		var t = $("#date").val();
		
		if(t<stringDate) {
			alert("수령 날짜가 신청 날짜보다 이전입니다.\n 다시 선택해주세요.");
			$("#date").val('');
		} else {
		   
		}
		obj.style.backgroundColor='yellow';
	}

	$(function() {
		$("#date").datepicker();
		
	});