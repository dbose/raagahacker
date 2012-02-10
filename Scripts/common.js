<!--


myRaagaUrl = base_url+"channels/myraaga/"
homeUrl 	 = base_url+"channels/home/"

function getPwd(){
	url = myRaagaUrl+"getPwd.asp"
	winW = 504
	winH = 220
	winName = 'raagaPwd'	
	raagaPwd = doWin(url, winName);
}

function getActivation(){
	url = myRaagaUrl+"getactivation.asp"
	winW = 504
	winH = 220
	winName = 'raagaAct'	
	raagaPwd = doWin(url, winName);
}

function register(){

	url = myRaagaUrl+"register.asp"
	if (isPopUp)
		window.open(url,'raagaRegister','');
	else
		window.location.href =  url;	

}

function getFeedback(){
	url = homeUrl+"feedback.asp"
	winW = 507
	winH = 437
	winName = 'raagaFB'	
	raagaFB = doWin(url, winName);
}

function informer(){

	url = homeUrl+"informer.asp"
	x = this.document.location
	
	url = url+"?mailUrl="+escape(x)	
	winW = 515
	winH = 336
	winName = 'raagaInformer'
	raagaInfomer = doWin(url, winName)
}



function mailSong(x){  
	listStr = homeUrl+"mailclip.asp?id="+x;
	winW = 400
	winH = 450
	
	rmail = doWin (listStr,'rmail');
}


function getChannel(channel){
 if (channel != ''){
	channel = escape(channel);
	winW = 468;
	winH = 280;
	winName = "rjb";
	rjb = doWin(homeUrl+"loadchannel.asp?channelid="+channel,winName);

 } else {
	alert("Please select a channel and try again");
 }
}

function launchChannel(){
	channelsUrl = homeUrl+"nonstop.asp"
	opnr = top.window.opener;
	if(opnr && !opnr.closed ){
		top.window.opener.location.href = channelsUrl
		top.window.opener.focus();
	} else{
	  	window.open(channelsUrl);
	}
}


var winW;
var winH;

function rate(id){
	winW = 472;
	winH = 350;
	winName = 'raagaRate'
	url = homeUrl+"rating.asp?id="+id;
	raagaRate = doWin(url,winName);	
}

function getImg(img,title,w,h){
  winName= "win"+w+"_"+h
  winW = w;
  winH = h;
  url = "getImg.asp?cast="+title+"&img="+escape(img)+"&w="+w+"&h="+h
  rcWin = doWin(url,winName);
}

function getGallery(gName){
	gName = escape(gName);
	window.location = "gallery.asp?cast="+gName
}

function doWin(x,winName,scrollable){

	isScroll=0;
	
	if(winH < 1)
		winH=1;
	if(winW < 1)
		winW=1;
	if (screen.availWidth && screen.availHeight)
		    var xMax = screen.availWidth, yMax = screen.availHeight;
		else
		if (document.layers)
		    var xMax = window.outerWidth, yMax = window.outerHeight;
		else
		    var xMax = 640, yMax=480;

	if (winW > xMax-20){
		isScroll = 1;
		winW = xMax-20;
	}
	if (winH > yMax-20){
		isScroll = 1;
		winH = yMax-30;
	}
		    
		var xOffset = (xMax/2)-(winW/2), yOffset = (yMax/2)-(winH/2);
		
		if ( scrollable )
			isScroll = 1;
		
		
		thisWin = window.open (x,winName,'width='+winW+',height='+winH+',directories=no,toolbar=no,menubar=no,location=no,scrollbars='+isScroll+',minimize=yes,resizable=no,copyhistory=no,status=no,titlebar=no,screenX='+xOffset+',screenY='+yOffset+',top='+yOffset+',left='+xOffset+'');
        return thisWin;
}


function popUp(url) {
	sealWin=window.open(url,"win",'toolbar=0,location=0,directories=0,status=1,menubar=1,scrollbars=1,resizable=1,width=500,height=450');
	self.name = "mainWin";
}

function setSort(fld){
	imgObj = eval("document."+fld+"_SORT")
	imgObj.src = base_url+"images/sortdown.gif";
}

function sortBy(fld){
	document.centerFrm.sortFld.value = fld
	document.centerFrm.submit();
}

var os;
var osv;
var browser;
var bversion;

function browserTest() {
  if (navigator.appName.indexOf("Netscape") != -1) {
    browser = "Netscape";
    bversion = parseFloat(navigator.appVersion);
  } else if (navigator.userAgent.indexOf("MSIE") != -1) {
    browser = "MSIE";
    var start = navigator.appVersion.indexOf("MSIE");
    var v = parseFloat(navigator.appVersion.substring(start + 4));
    bversion = v;
  } else {
    browser = false;
    bversion = false;
  }
}

// Determine the OS of the client machine
function osTest() {
  if (navigator.userAgent.indexOf("Win") != -1) {
    os = "Windows";
    if (navigator.userAgent.indexOf("Windows NT") != -1 ||
	navigator.userAgent.indexOf("WinNT") != -1)
      osv = "NT";
    else if (navigator.userAgent.indexOf("Windows 98") != -1 ||
	navigator.userAgent.indexOf("Win98") != -1)
      osv = "98";
    else if (navigator.userAgent.indexOf("Windows 95") != -1 ||
	navigator.userAgent.indexOf("Win95") != -1)
      osv = "95";
    else if (navigator.userAgent.indexOf("Windows 3.1") != -1 ||
	navigator.userAgent.indexOf("Win16") != -1)
      osv = "3.1";
  } else if (navigator.userAgent.indexOf("Mac") != -1) {
    os = "Macintosh";
    osv = "";
  } else if (navigator.userAgent.indexOf("FreeBSD") != -1) {
    os = "Unix";
    osv = "FreeBSD";
  } else if (navigator.userAgent.indexOf("Linux") != -1) {
    os = "Unix";
    osv = "Linux";
  } else if (navigator.userAgent.indexOf("Solaris") != -1) {
    os = "Unix";
    osv = "Solaris";
  } else if (navigator.userAgent.indexOf("SunOS") != -1) {
    os = "Unix";
    osv = "SunOS";
  } else if (navigator.userAgent.indexOf("IRIX") != -1) {
    os = "Unix";
    osv = "IRIX";
  } else if (navigator.userAgent.indexOf("HPUX") != -1) {
    os = "Unix";
    osv = "HPUX";
  } else if (navigator.userAgent.indexOf("AIX") != -1) {
    os = "Unix";
    osv = "AIX";
  } else if (navigator.userAgent.indexOf("Unix") != -1) {
    os = "Unix";
    osv = "";
  } else {
    os = "Other";
    osv = "";
  }
}


function openHelp( referenceUrl ){
	winName = "raagaHelp";
	winW = 400;
	winH = 300;
	doWin( referenceUrl, winName );
}

function getLyrics( songId ){
	lyricsURL = homeUrl+"lyrics.asp?id="+songId;
	winName = "raagaLyrics";
	winW = 468;
	winH = 500;
	rlWin = doWin( lyricsURL, winName, true );

}

function sortAlbumsBy( obj ){
    //alert( obj.options[obj.selectedIndex].value );
    document.rDisplay.submit();
}

//-->