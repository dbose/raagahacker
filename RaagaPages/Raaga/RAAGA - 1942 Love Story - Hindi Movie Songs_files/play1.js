<!--


 if (parent!=self){ 
   parent.location.replace(this.document.location.href)
 }




 function SelectAll() { 
  for (var i=0;i<document.raaga.elements.length;i++) 
    { 
    var flds = document.raaga.elements[i]; 
    if ((flds.name != 'loop') && (flds.name !='random') && (flds.name !='append')) 
      flds.checked = 1;//document.forms[0].checkAll.checked; 
    } 
  } 

 function InvertSelect() { 
  for (var i=0;i<document.raaga.elements.length;i++) 
    { 
    var flds = document.raaga.elements[i]; 
    if ((flds.name != 'loop') && (flds.name !='random') && (flds.name !='append')) {
	
      if (flds.checked == 1){
      	flds.checked = 0
      } else {
      	flds.checked = 1
      }
    }


    } 
  } 

c = 0;
songlist = new Array;
function getList() {

	theForm = this.document.raaga
        for (var i=0;i<document.raaga.elements.length;i++) {
                if (document.raaga.elements[i].name == 'pick') {
                        if (document.raaga.elements[i].checked) {
                         songlist[c] = document.raaga.elements[i].value;
                         c++;
                        }
                }
        }

	if (c <1)
		checkList();
	else
		setList();

}

function checkList(){
	SelectAll();
	getList();
}


function setList(){

winW = 468;
winH = 280;
	mode = this.document.raaga.mode.value;
        sel = songlist[0];
        for (var j=1;j<c;j++) {
		sel += ","+songlist[j];
        }
	liststr = base_url+"playerV31/index.asp?pick="+sel+"&mode="+mode+"&rand="+Math.random();
	sel="";
	c=0;
	rjb = doWin(liststr,'rjb');	
}


function setList1(x){
winW = 468;
winH = 280;
	mode = 0;
	if (this.document.raaga.mode)
		mode = this.document.raaga.mode.value;
	
    liststr = base_url+"playerV31/index.asp?pick="+x+"&mode="+mode+"&rand="+Math.random();
	sel="";
	c=0;
	rjb = doWin(liststr,'rjb');
}



function pickThis(x){

	pick = document.raaga.pick;
	pick1 = document.raaga.pick1;
	pickLen = pick.length;

 if( pickLen > 1){
	for(i=0;i<pickLen;i++){
	  if(pick[i].value == x){
		pick1.value=x;
		document.raaga.submit();
		return createTarget(document.raaga);
	  }
	}
 } else {
	pick1.value=x;
	document.raaga.submit;
	return createTarget(document.raaga);
 }
return false
}

function saveList() {
	theForm = this.document.raaga
        for (var i=0;i<document.raaga.elements.length;i++) {
                if (document.raaga.elements[i].name == 'pick') {
                        if (document.raaga.elements[i].checked) {
                         songlist[c] = document.raaga.elements[i].value;
                         c++;
                        }
                }
        }
	if (c <1){
	    alert("Select the songs to add to your collection!");
	}
	else{
	    openAddWin();
	}
}


function openAddWin(){

         sel = songlist[0];
         for (var j=1;j<c;j++) {
						sel += ","+songlist[j];
         }
	liststr = base_url+"channels/myraaga/addToUser.asp?id="+sel;
	sel="";
	c=0;
	winW = 400;
	winH = 450;

        MyRaaga = doWin(liststr,'MyRaaga');
}


function validate(form){
	theForm = this.document.raaga
        for (var i=0;i<document.raaga.elements.length;i++) {
                if (document.raaga.elements[i].name == 'pick') {
                        if (document.raaga.elements[i].checked) {
                         songlist[c] = document.raaga.elements[i].value;
                         c++;
                        }
                }
        }
	if (c < 1)
		SelectAll();	
	getList();
	return false;
}

function gotoPage(frmName, pageNum){

	frmObj = eval("document."+frmName)
	if (frmObj && frmObj.whichpage){
		frmObj.whichpage.value = pageNum;
		frmObj.submit();
	} else {
		return false;
	}	
}

function mailSong(x){  
	listStr = "mailclip.asp?id="+x;
        rmail = window.open (listStr,'rmail','width=400,height=450,resizeable=yes,scrollbars=no,status=no');
}

function doSearch(frm){
	
	var actionURL = "";
	lang   = frm.Lang;
	langInd = lang.selectedIndex;
	
	var langDir = new String(lang.options[langInd].text);	
	actionURL = base_url+"channels/"+langDir.toLowerCase()+"/searchresults.asp";
	
	if (actionURL == "" ){
		alert("Please select a language and try again!");
	}
	
	kw = frm.search.value;

	if (kw != "" && kw.length >= 3){
		frm.action = actionURL;
		frm.submit();
	} else {
		alert("Search term needs to have 3 or more letters! Please try again");
	}
}
//-->
