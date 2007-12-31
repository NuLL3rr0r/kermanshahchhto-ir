var http = new Array();

//var wsrv = (window.location.href.indexOf('http://www.') != -1) ? 'http://www.kermanshahchhto.ir/master.asmx' : 'http://kermanshahchhto.ir/master.asmx';
var wsrv = 'http://localhost:54029/krchhto/master.asmx';

String.prototype.trim = function () {
    return this.replace(/^\s*/, "").replace(/\s*$/, "");
};

String.prototype.isEmail = function () {
	return verifyRegExp('\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*', this);
};

String.prototype.isURL = function () {
	return verifyRegExp('http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?', this);
};

var lang = '';
var cookieName = 'lang=';
if (document.cookie.length > 0) { 
	offset = document.cookie.indexOf(cookieName);
    if (offset != -1) {
		offset += cookieName.length;
		end = document.cookie.indexOf(';', offset);
		if (end == -1)
			end = document.cookie.length;
		lang = unescape(document.cookie.substring(offset, end));
	}
}

switch (lang) {
	case 'fa':
		break;
	case 'en':
		break;
	case 'ar':
		break;
	default:
		lang = 'fa';
		break;
}

var errServer;
var errInvalidMail;
var errInvalidURL;
var errVerifySenderName;
var errVerifyMsgSbjct;
var errVerifyMsgBdy;

var loadingText;
var mainPage;
var reqType;
var fetchX;
var hasContex;

var prnHeader;
var prnTitle;

var msgCancelContact;
var msgSendMessage;
var msgSelectArchiveMonth;

var urlArrow;
var posArrow;

var urlWord;

var idFetchNewsBody = '';

switch (lang) {
	case 'fa':
		errServer = 'خطاي داخلي در سرور';
		errInvalidMail = 'آدرس ايميل نا معتبر مي باشد&hellip;';
		errInvalidURL = 'آدرس وب سايت نا معتبر مي باشد&hellip;';
		errVerifySenderName = 'لطفا نام خود را وارد نمائيد&hellip;';
		errVerifyMsgSbjct = 'لطفا موضوع پيام را وارد نمائيد&hellip;';
		errVerifyMsgBdy = 'لطفا پيام خود را وارد نمائيد&hellip;';
		
		msgCancelContact = 'آيا مايل به لغو پيام مي باشيد';
		msgSendMessage = 'با تشكر، پيام شما با موفقيت ارسال شد';
		msgSelectArchiveMonth = 'لطفا ماه مورد نظرتان را انتخاب نمائید.';
		
		//loadingText = '&nbsp;&nbsp;&nbsp;<img src="loading.gif" />&nbsp;در حال بارگذاري&hellip;';
		//loadingText = '<center><img src="loading.gif" style="border: 1px solid #000000;" /></center>';
		//loadingText = '<center><img src="loading.gif" /><br /><span style="font-size: 11px;">در حال بارگذاري&hellip;<span></center>';
		loadingText = '<center><span style="font-size: 11px;">در حال بارگذاري&hellip;<span><br /><img src="loading.gif" /></center>';

		
		mainPage = 'صفحه اصلی';
		prnHeader = 'نسخه ی قابل چاپ';
		prnTitle = 'چاپ';
		
		urlArrow = 'url(menu-arrow.gif)';
		posArrow = 'center left';
		
		urlWord = 'آدرس';
		break;
	case 'en':
		errServer = 'Internal Server Error';
		errInvalidMail = 'Invalid email address&hellip;';
		errInvalidURL = 'Invalid http address&hellip;';
		errVerifySenderName = 'Please enter your name&hellip;';
		errVerifyMsgSbjct = 'please enter subject&hellip;';
		errVerifyMsgBdy = 'please enter your message&hellip;';
		
		msgCancelContact = 'Your message has not been sent.\n\nDiscard your message?';
		msgSendMessage = 'Thanks for your comments.';
		msgSelectArchiveMonth = 'Please select month.';
		
//		loadingText = '&nbsp;&nbsp;&nbsp;<img src="loading.gif" />&nbsp;Loading&hellip;';
		loadingText = '<center><span style="font-size: 11px;">Loading&hellip;<span><br /><img src="loading.gif" /></center>';
		
		mainPage = 'Home Page';
		prnHeader = 'Printer Friendly Version';
		prnTitle = 'Print';

		urlArrow = 'url(menu-arrow_en.gif)';
		posArrow = 'center right';

		urlWord = 'URL';
		break;
	case 'ar':
		errServer = 'خطأ في الملقم الداخلي&hellip;';
		errInvalidMail = 'عنوان بريد الكتروني غير صحيح&hellip;';
		errInvalidURL = 'العنوان غير صحيح بروتوكول انتقال النص المتشعب&hellip;';
		errVerifySenderName = 'الرجاء ادخال اسمك&hellip;';
		errVerifyMsgSbjct = 'من فضلك ادخل الموضوع&hellip;';
		errVerifyMsgBdy = 'الرجاء ادخال رسالتك&hellip;';
		
		msgCancelContact = 'رسالتك لم يتم ارساله\n\nتجاهل رسالتك';
		msgSendMessage = 'شكرا لتعليقاتكم.';
		msgSelectArchiveMonth = 'الرجاء اختيار الشهر';
		
//		loadingText = '&nbsp;&nbsp;&nbsp;<img src="loading.gif" />&nbsp;تحميل&hellip;';
		loadingText = '<center><span style="font-size: 11px;">تحميل&hellip;<span><br /><img src="loading.gif" /></center>';

		mainPage = 'الصفحه الرئيسية';
		prnHeader = 'نسخة للطباعة';
		prnTitle = 'اطبع';
		
		urlArrow = 'url(menu-arrow.gif)';
		posArrow = 'center left';
		
		urlWord = 'العنوان';
		break;
	default:
		break;
}

var loadingSimple = '<img src="preprogress.gif" />';
var ajaxDivs;
var ajaxDivsLen;
var newsContent;

var browser = new detectBrowser();

function detectBrowser() {
	this.isKHTML = false;
	this.isGecko = false;
	this.isMSIE = false;
	this.isOpera = false;
	this.ver = null;
	this.platform = navigator.platform;
	this.engine = null;
	
	var browser = navigator.userAgent;
	
	if (browser.indexOf('KHTML') > -1) {
		this.isKHTML = true;
		this.engine = 'KHTML';
		return;
	}
	if (browser.indexOf('Gecko') > -1) {
		this.isGecko = true;
		this.engine = 'Gecko';
		return;
	}
	if (browser.indexOf('MSIE') > -1) {
		this.isMSIE = true;
		var pos1 = browser.indexOf('MSIE') + 5;
		var pos2 = browser.indexOf(';', pos1);
		this.ver = Number(browser.substring(pos1, pos2));
		this.engine = 'MSIE';
		return;
	}
	if (browser.indexOf('Opera') > -1) {
		this.isOpera = true;
		this.engine = 'Opera';
		return;
	}
}


function verifyRegExp(regExp, value) {
    var rx = new RegExp(regExp);
    var matches = rx.exec(value);
	return (matches != null && value == matches[0]);
}

function docPrint() {
	var prn = window.open('', 'prn', 'width=825, height=610, toolbar=0, location=0, status=0, menubar=0, scrollbars=1, resizable=1');

	var txt = new String("");
	var patch = new String("");
	var patchSiteMap = new String("");
	
	if (arguments[0] == null) {
		txt = document.getElementById('dvMainContents').innerHTML;
		patchSiteMap = '<style type="text/css">@import url(layout.add.css);' + (lang != 'en' ? '' : ' @import url(layout.add_en.css);') + '</style>';
	}
	else {
		txt = '<div id="dvNews" class="posts" style="visibility:visible;"><div id="dvNewsContents">' + document.getElementById(arguments[0]).innerHTML + '</div></div>';
		var enStyle = lang != 'en' ? '' : '@import url(layout_en.css);';
		patch = '<style type="text/css">@import url(layout.css);' + enStyle + '</style><style type="text/css">html, body { background: #ffffff !important; } .newsnav { visibility:hidden !important; } #dvNews { width: 80% !important; padding-top: 0 !important; color: #000000 !important; } .pic { float: left; margin-right: 10px; border: gray 1px solid; }</style>';
	}
	var dir = lang != 'en' ? 'rtl' : 'ltr';
 	
	var hStart = '<html lang="fa" xml:lang="' + lang +'" dir="' + dir + '"><head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>' + prnHeader + '</title>' + patch + patchSiteMap + '<style type="text/css">html, body { margin: 0px; font-family: Tahoma; } #dvMainContents { position: relative; border: 0px; width: 85%; line-height: 33px; text-align: justify; } .print { padding: 1em 0 3em 0; }</style><style type="text/css" media="print">.print{visibility:hidden;}</style><script language="javascript">function doPrintJob() {with(window) {print(); close();}}</script></head><body><center><div class="print"><a href="javascript:;" style="color:white" onclick="doPrintJob();" title=\"'+ prnTitle + '\"><img src="print.png" alt="'+ prnTitle + '" /></a></div><div id="dvMainContents">';
	var hStop = '</div></center></body></html>';
	
	if (txt.indexOf('dvNewsFromSearchDate') > -1)
	{
		txt = txt.replace('<div class="dvNewsFromSearchDate">', '<div style="border: none; border-top: 2px solid black; border-bottom: 1px solid black; direction: ' + (lang != 'en' ? 'ltr' : 'rtl') + '; margin: 5px 0 15px 0; padding: 0 0 0 5px; font-size: 9px; font-weight: bolder; line-height: 23px;">');
	}
	
	with(prn.document) {
		open();
		write(hStart + txt + hStop);
		close();
	}
}

function getPageScroll() {
	var yScroll;
	if (self.pageYOffset) {
		yScroll = self.pageYOffset;
	} else if (document.documentElement && document.documentElement.scrollTop) {
		yScroll = document.documentElement.scrollTop;
	} else if (document.body) {
		yScroll = document.body.scrollTop;
	}
	arrayPageScroll = new Array('', yScroll);
	return arrayPageScroll;
}

function getPageSize() {
	var xScroll, yScroll;
	if (window.innerHeight && window.scrollMaxY) {
		xScroll = document.body.scrollWidth;
		yScroll = window.innerHeight + window.scrollMaxY;
	} else if (document.body.scrollHeight > document.body.offsetHeight) {
		xScroll = document.body.scrollWidth;
		yScroll = document.body.scrollHeight;
	} else {
		xScroll = document.body.offsetWidth;
		yScroll = document.body.offsetHeight;
	}
	var windowWidth, windowHeight;
	if (self.innerHeight) {
		windowWidth = self.innerWidth;
		windowHeight = self.innerHeight;
	} else if (document.documentElement && document.documentElement.clientHeight) {
		windowWidth = document.documentElement.clientWidth;
		windowHeight = document.documentElement.clientHeight;
	} else if (document.body) {
		windowWidth = document.body.clientWidth;
		windowHeight = document.body.clientHeight;
	}	
	if (yScroll < windowHeight) {
		pageHeight = windowHeight;
	} else { 
		pageHeight = yScroll;
	}
	if (xScroll < windowWidth) {
		pageWidth = windowWidth;
	} else {
		pageWidth = xScroll;
	}
	arrayPageSize = new Array(pageWidth, pageHeight, windowWidth, windowHeight);
	return arrayPageSize;
}

function fixPreLoader() {
	var arrayPageSize = getPageSize();
	var arrayPageScroll = getPageScroll();
	var obj = document.getElementById('dvPreLoader');
	obj.style.height = arrayPageSize[1] + 'px';
	obj.style.width = arrayPageSize[0] - 99 + 'px';
	var objLoadingImage = document.getElementById('loadingImage');
	objLoadingImage.style.visibility = '';
	objLoadingImage.style.display = 'block';
	objLoadingImage.style.top = Math.round(arrayPageScroll[1] + (arrayPageSize[3] - 35 - objLoadingImage.height) / 2) + 'px';
	objLoadingImage.style.left = Math.round((arrayPageSize[0] - 20 - objLoadingImage.width) / 2) + 'px';
	monitorPreLoader(0, 0, null, null);
}

function monitorPreLoader(xSpeed, ySpeed, xDir, yDir) {
	var arrayPageSize = getPageSize();
	var arrayPageScroll = getPageScroll();
	var objLoadingImage = document.getElementById('loadingImage');
	var top = Math.round(arrayPageScroll[1] + (arrayPageSize[3] - 35 - objLoadingImage.height) / 2);
	var left = Math.round((arrayPageSize[0] - 20 - objLoadingImage.width) / 2);
	var objTop = parseInt(objLoadingImage.style.top);
	var objLeft = parseInt(objLoadingImage.style.left);
	var maxSpeed = 3;
	var speedRate = 0.1;
	if (xSpeed < maxSpeed)
		xSpeed += speedRate;
	if (ySpeed < maxSpeed)
		ySpeed += speedRate;
	if (objTop < top) {
		if (yDir == 'D' || yDir == null)
			objLoadingImage.style.top = objTop + ySpeed + 'px';
		else
			objLoadingImage.style.top = top + 'px';
		yDir = 'D';
	}
	else if (objTop > top) {
		if (yDir == 'U' || yDir == null)
			objLoadingImage.style.top = objTop - ySpeed + 'px';
		else
			objLoadingImage.style.top = top + 'px';
		yDir = 'U';
	}
	else {
		ySpeed = 0;
		yDir = null;
	}
	if (objLeft < left) {
		if (xDir == 'R' || xDir == null)
			objLoadingImage.style.left = objLeft + xSpeed + 'px';
		else
			objLoadingImage.style.left = left + 'px';
		xDir = 'R';
	}
	else if (objLeft > left) {
		if (xDir == 'L' || xDir == null)
			objLoadingImage.style.left = objLeft - xSpeed + 'px';
		else
			objLoadingImage.style.left = left + 'px';
		xDir = 'L';
	}
	else {
		xSpeed = 0;
		xDir = null;
	}
	xs = xSpeed;
	ys = ySpeed;
	xd = xDir;
	yd = yDir;
	window.setTimeout('monitorPreLoader(xs, ys, xd, yd);', 9);
}

function hidePreloader() {
	var obj = document.getElementById('dvPreLoader');
	obj.style.visibility = 'hidden';
	obj.style.height = 0 + 'px';
	obj.style.width = 0 + 'px';
	obj.style.zIndex = 0;
	var html = document.getElementsByTagName("html");
	if (browser.isMSIE) {
		html[0].style.filter = '';
	}
	html[0].style.cursor = 'default';
	var objLoadingImage = document.getElementById('loadingImage');
	objLoadingImage.style.visibility = 'hidden';
}

function showPreLoader() {
	var obj = document.getElementById('dvPreLoader');
	obj.style.visibility = 'visible';
	obj.style.height = arrayPageSize[1] + 'px';
	obj.style.width = arrayPageSize[0] - 99 + 'px';
	obj.style.zIndex = 999;
	if (browser.isMSIE) {
		obj.style.background = 'url(prealpha.png) repeat';
	}
	var objLoadingImage = document.getElementById('loadingImage');
	objLoadingImage.style.visibility = 'visible';
}

function spacerScrText(count) {
	var space = '';
	for (i = 0; i < count; i++)
		space += '&nbsp;';
	document.write(space);
}

function getXMLHTTPRequest() {
	try {
		req = new XMLHttpRequest();
	}
	catch(e1) {
		try {
			req = new ActiveXObject('Msxml2.XMLHTTP');
		}
		catch(e2) {
			try {
				req = new ActiveXObject('Microsoft.XMLHTTP');
			}
			catch(e3) {
				req = false;
			}
		}
	}
	return req;
}

function initAjaxTargets() {
	for (var i = 0; i < arguments.length; i++)
		http[i] = getXMLHTTPRequest();
	ajaxDivs = arguments;
	ajaxDivsLen = ajaxDivs.length;
}

function detectChar(ch) {
	switch (ch) {
		case "&lt;":
			return '<';
			break;
		case "&gt;":
			return '>';
			break;
		case "&amp;nbsp;":
			return '&nbsp;';
			break;
		case "&amp;hellip;":
			return '&hellip;';
			break;
		default:
			break;
	}
}

function correctTags(str, ch) {
	parts = str.split(ch);
	var clnd = parts.join(detectChar(ch));
	return clnd;
}

function filterTalking(msg, tag) {
	if (msg != 'Internal Server Error')	{
		var pos1 = msg.indexOf('<' + tag + '>');
		var pos2 = msg.indexOf('</' + tag + '>');
		var tagLen = tag.length + 2;
		return msg.substr(pos1 + tagLen, pos2 - pos1 - tagLen);
	}
	else
		return errServer;
}

function correctPageTags(str, tag) {
	str = filterTalking(str, tag);
	str = correctTags(str, '&lt;');
	str = correctTags(str, '&gt;');
	str = correctTags(str, '&amp;nbsp;');
	str = correctTags(str, '&amp;hellip;');
	return str;
}

function parseXML(text, tag) {
	if (!window.ActiveXObject) {
		var parser = new DOMParser();
		var doc = parser.parseFromString(text, "text/xml");
	}
	else
	{
		var doc = new ActiveXObject("Microsoft.XMLDOM");
		doc.async = 'false';
		doc.loadXML(text);
	}
	var x = doc.documentElement;
	return x.getElementsByTagName(tag)[0].childNodes[0].nodeValue;
}

function writeFLVMovie(movie) {
	var fo = new SWFObject("flvplayer.swf", movie, "320", "240", "9", "#000000");
	fo.useExpressInstall('expressinstall.swf');
	fo.setAttribute('xiRedirectUrl', 'http://www.kermanshahchhto.ir/');
	fo.addVariable("config", "{videoFile: '" + "movies/" + movie + "' ,controlBarGloss: 'high', controlsOverVideo: 'ease', showFullScreenButton: false, showMenu: false}");
	fo.write(movie);
}

function DetectMovies(msg) {
	var pos1 = -1;
	var pos2 = 0;
	if (msg.toLowerCase().indexOf("<div") > -1)
	{
		var p1 = -1;
		var p2 = -1;
		var flvObjectId = '';
		while (true)
		{
			pos1 = msg.toLowerCase().indexOf("<div", pos2);
			if (pos1 == -1)
				break;
			pos2 = msg.toLowerCase().indexOf("</div>", pos1) + "</div>".length;
			if (pos2 == -1)
				break;
			var swf = msg.substring(pos1, pos2);
			if (swf.indexOf(".flv") > -1)
			{
				p1 = swf.indexOf("id=\"") + "id=\"".length;
				p2 = swf.indexOf("\"", p1);
				flvObjectId = swf.substring(p1, p2);
				
				var obj = document.getElementById(flvObjectId);
				obj.innerHTML = '<a href="javascript:writeFLVMovie(\'' + flvObjectId + '\');"><img src="flvplayer.png" /></a>';
			}
		}
	}
}

function resultOnTalkingServer(code, msg, op, target) {
	if (code == 1) {
		target.innerHTML = errServer;
		return;
	}
	switch (op) {
		case 'FetchPage':
			target.innerHTML = correctPageTags(msg, op + 'Result');
			DetectMovies(target.innerHTML);
			break;
		case 'FetchNews':
			target.innerHTML = correctPageTags(msg, op + 'Result');
			break;
			case 'FetchGallery':
			target.innerHTML = parseXML(msg, op + 'Result');
			thumbnailviewer.init();
			break;			
		case 'Find':
			target.innerHTML = correctPageTags(msg, op + 'Result');
			break;
		case 'FetchNewsFromSearch':
			target.innerHTML = parseXML(msg, op + 'Result');
			break;
		case 'SiteMap':
			target.innerHTML = correctPageTags(msg, op + 'Result');
			ddtreemenu.createTree("siteMapTree", false);
			ddtreemenu.flatten('siteMapTree', 'expand');
			break;
		case 'ContactUSForm':
			target.innerHTML = parseXML(msg, op + 'Result');
			break;
		case 'SendMessage':
			setErr('dvStatusContactForm', false);
			msg = parseXML(msg, op + 'Result');
			if (msg == 'sent')
				window.alert(msgSendMessage);
			setFormStatus('dvStatusContactForm', true, 'cmbWMail');
			clearForm('dvStatusContactForm');
			setFormStatus('dvStatusContactForm', false);
			break;
		default:
			break;
	}
}

function talkingServer(op, param, target) {
	if (param.indexOf(mainPage) > -1 && target == 'dvMainContents') {
		document.getElementById('dvMainContents').style.width = '359px';
		document.getElementById('dvNews').style.width = '300px';
		document.getElementById('dvNews').style.visibility = 'visible';
		document.getElementById('dvMarquee').style.visibility = 'visible';
		fetchNews();
	}
	else if (target == 'dvMainContents') {
		document.getElementById('dvMainContents').style.width = '659px';
		document.getElementById('dvNews').style.width = '0';
		document.getElementById('dvNews').style.visibility = 'hidden';
		document.getElementById('dvNewsContents').innerHTML = '';
		document.getElementById('dvMarquee').style.visibility = 'hidden';
	}
	
	var obj = document.getElementById(target);
	
	switch (op)
	{
		case 'SendMessage':
			setErr('dvStatusContactForm', true, loadingSimple);
			break;
		default:
		    obj.innerHTML = loadingText;
			break;
	}
	var index = cancelTalkingServer(target);
	http[index].open('POST', wsrv, true);
	http[index].onreadystatechange = function() {
		if (http[index].readyState == 4) {
			if (http[index].status == 200) {
				resultOnTalkingServer(0, http[index].responseText, op, obj);
			}
			else
				resultOnTalkingServer(1, http[index].statusText, op, obj);
			return;
		}
	};
	http[index].setRequestHeader("Content-Type", "text/xml; charset=utf-8");
	var sendSOAP = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><' + op + ' xmlns="' + 'http://tempuri.org/' + '">' + param + '</' + op + '></soap:Body></soap:Envelope>';
	http[index].send(sendSOAP);
}

function cancelTalkingServer(target) {
	var index = -1;
	while (index < ajaxDivsLen) {
		if (target == ajaxDivs[++index])
			break;
	}
	http[index].abort();
	http[index] = getXMLHTTPRequest();
	return index;
}

function fetchPage(pg) {
	talkingServer('FetchPage', '<pg>' + pg + '</pg><tbl>pages' + lang + '</tbl>', 'dvMainContents');
}

function fetchNews() {
	talkingServer('FetchNews', '<tbl>news' + lang + '</tbl>', 'dvNewsContents');
}

function eraseNewsBody(target) {
	var obj = document.getElementById(target);
	var pos1 = obj.innerHTML.toLowerCase().indexOf('<noscript>');
	var pos2 = obj.innerHTML.toLowerCase().indexOf('</noscript>');
	obj.innerHTML = obj.innerHTML.substring(0, pos1) + '<break>' + obj.innerHTML.substring(pos1 + 10, pos2) + '</break>';
	if (browser.isOpera)
		obj.innerHTML = obj.innerHTML.replace("&lt;", "<").replace("&gt;", ">").replace("&lt;", "<").replace("&gt;", ">");
}

function resultOnTalkingServerSingle(code, msg, op, target) {
	var obj = document.getElementById(target);
	
	if (code == 1) {
		obj.innerHTML = errServer;
		return;
	}
	
	switch (op) {
		case 'FetchNewsBody':
			obj.innerHTML = obj.innerHTML.substr(0, obj.innerHTML.toLowerCase().lastIndexOf('<loading>')) + correctPageTags(msg, op + 'Result');
			document.getElementById('dvURLSourceNews' + idFetchNewsBody).style.visibility = 'hidden';

			var strBack;
			var strPrint;
			switch (lang)
			{
				case 'fa':
					strBack = 'بازگشت';
					strPrint = 'چاپ';
					strURL = 'آدرس خبر';
					break;
				case 'en':
					strBack = 'Return';
					strPrint = 'Print';
					strURL = 'News URL';
					break;
				case 'ar':
					strBack = 'يعود ادراجه';
					strPrint = 'اطبع';
					strURL = 'أخبار عنوان';
					break;
				default:
					break;
			}
			var pos1 = obj.innerHTML.indexOf('#', obj.innerHTML.toLowerCase().indexOf('<noscript>'));
			var pos2 = obj.innerHTML.indexOf('"', pos1);
			var strAnchor = obj.innerHTML.substring(pos1, pos2);
			obj.innerHTML += '<div class="newsnav">' +
							 '<a href="javascript:;" onclick="docPrint(\'' + target + 'prn\');" title="' + strPrint + '"><img src="newsprint.png" alt="' + strPrint + '" title="' + strPrint + '" /></a>' +
							 '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' +
							 '<a href="' + document.getElementById('dvURLSourceNews' + idFetchNewsBody).innerHTML + '"><img src="newsurl.png" alt="' + strURL + '" title="' + strURL + '" /></a>' +
							 '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' +
							 '<a href="' + strAnchor + '" onclick="eraseNewsBody(\'' + target + '\');" title="' + strBack + '"><img src="newsback' + (lang != 'en' ? '' : '.en') + '.png" alt="' + strBack + '" title="' + strBack + '" /></a>' +
								 '</div>';
			document.getElementById('dvURLSourceNews' + idFetchNewsBody).innerHTML = '';
			break;
		case 'FetchNewsArchiveMonths':
			setNewsArchiveMonthsCMB(parseXML(msg, op + 'Result'));
			obj.innerHTML = msgSelectArchiveMonth;
			break;
		case 'FetchNewsArchive':
			obj.innerHTML = correctPageTags(msg, op + 'Result');
			setNewsFormStatus(true);
			break;
		default:
			break;
	}	
}

function talkingServerSingle(op, param, target) {
	var obj = document.getElementById(target);

	if (op != 'FetchNewsBody') {
		obj.innerHTML = loadingText;
	}
	else {
			var pos1 = obj.innerHTML.toLowerCase().indexOf('<break>');
			var pos2 = obj.innerHTML.toLowerCase().indexOf('</break>');
			
			obj.innerHTML = obj.innerHTML.substring(0, pos1) + '<noscript>' + obj.innerHTML.substring(pos1 + 7, pos2) + '</noscript>' + obj.innerHTML.substring(pos2 + 8);
			obj.innerHTML += "<br /><loading>" + loadingText + "</loading>";
	}
	
	var http = getXMLHTTPRequest();
	
	http.open('POST', wsrv, true);
	http.onreadystatechange = function() {
		if (http.readyState == 4) {
			if (http.status == 200) {
				resultOnTalkingServerSingle(0, http.responseText, op, target);
			}
			else
				resultOnTalkingServerSingle(1, http.statusText, op, target);
			return;
		}
	};
	http.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
	var sendSOAP = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><' + op + ' xmlns="' + 'http://tempuri.org/' + '">' + param + '</' + op + '></soap:Body></soap:Envelope>';
	http.send(sendSOAP);
}

function fetchNewsBody(id, target) {
	idFetchNewsBody = id;
	talkingServerSingle("FetchNewsBody", '<tbl>news' + lang + '</tbl><id>' + id + '</id>', target);
}

function ResetComboAlignForGecko(cmb) {
	var n = cmb.selectedIndex;
	cmb.selectedIndex = -1;
	cmb.selectedIndex = n;
}

function setNewsFormStatus(status) {
	document.frmNewsArchive.archiveYears.disabled = !status;
	document.frmNewsArchive.archiveMonths.disabled = !status;
	if (status && browser.isGecko) {
		ResetComboAlignForGecko(document.frmNewsArchive.archiveYears);
		ResetComboAlignForGecko(document.frmNewsArchive.archiveMonths);
	}
}

function setNewsArchiveMonths(wYear) {
	var obj = document.getElementById('dvNewsInner');
	if (wYear != '') {
		newsContent = obj.innerHTML;
		setNewsFormStatus(false);
		talkingServerSingle('FetchNewsArchiveMonths', '<tbl>news' + lang + '</tbl><wYear>' + wYear + '</wYear>', 'dvNewsInner');
	}
	else {
		var cmb = document.frmNewsArchive.archiveMonths;
		if (browser.isMSIE)
			setNewsFormStatus(false);
		obj.selectedIndex = 0;
		cmb.options.length = 1;
		if (browser.isMSIE)
			setNewsFormStatus(true);
		obj.innerHTML = newsContent;
	}
}

function setNewsArchiveMonthsCMB(msg) {
	var obj = document.frmNewsArchive.archiveMonths;
	if (msg != '') {
		obj.selectedIndex = 0;
		obj.options.length = 1;
		var pos1 = 0;
		var pos2;
		var len = msg.length;
		var month;
		var i = 0;
		var num;
		var months = new Array();
		months = msg.split('#');
		for (i = 0; i < months.length; i++) {
			month = months[i].substring(0, months[i].indexOf('-'));
			num = months[i].substring(months[i].indexOf('-') + 1);
			obj.options[i + 1] = new Option(month, num, false, false);
		}
	}
	setNewsFormStatus(true);
}

function showNewsArchive(wMonth) {
	if (wMonth != '') {
		setNewsFormStatus(false);
		talkingServerSingle("FetchNewsArchive", '<tbl>news' + lang + '</tbl><wYear>' + document.frmNewsArchive.archiveYears.value + '</wYear><wMonth>' + wMonth + '</wMonth>', 'dvNewsInner');
	}
	else {
		document.getElementById('dvNewsInner').innerHTML = msgSelectArchiveMonth;
	}
}

function fetchGallery(wch) {
	talkingServer('FetchGallery', '<wch>' + wch + '</wch>', 'dvMainContents');
}

function siteMap() {
	talkingServer('SiteMap', '<tbl>pages' + lang + '</tbl>', 'dvMainContents');
}

function findKeywords() {
    cancelTalkingServer('dvMainContents');
	var keywords = document.getElementById('searchquery').value;
	talkingServer('Find', '<keywords>' + keywords + '</keywords><tbl>pages' + lang + '</tbl><tblNews>news' + lang + '</tblNews>', 'dvMainContents');
}

function fetchNewsFromSearch(id) {
	talkingServer('FetchNewsFromSearch', '<id>' + id + '</id><tbl>news' + lang + '</tbl>', 'dvMainContents');
}

function contactForm() {
	talkingServer('ContactUSForm', '<tbl>contactlist' + lang + '</tbl>', 'dvMainContents');
}

function setErr(obj, state, err) {
	var msg = document.getElementById(obj);
	if (state) {
		msg.innerHTML = err;
		msg.style.visibility = 'visible';
	}
	else {
		msg.innerHTML = '';
		msg.style.visibility = 'hidden';
	}
}

function setFormStatus(form, state, args) {
	switch (form) {
		case 'dvStatusContactForm':
			if (args == 'cmbWMail')
				document.getElementById('cmbWMail').disabled = !state;
			if (args == 'reset')
				setErr('dvStatusContactForm', false);
			document.getElementById('txtName').disabled = !state;
			document.getElementById('txtEmail').disabled = !state;
			document.getElementById('txtURL').disabled = !state;
			document.getElementById('txtMsgSbjct').disabled = !state;
			document.getElementById('txtMsgBdy').disabled = !state;
			document.getElementById('btnSend').disabled = !state;
			document.getElementById('btnClear').disabled = !state;
			break;
		default:
			break;
	}
}

function clearForm(form, user) {
	switch (form) {
		case 'dvStatusContactForm':
			if (user) {
				var result = window.confirm(msgCancelContact);
				if (!result)
					return;
			}
			setFormStatus('dvStatusContactForm', false, 'reset');
			document.getElementById('cmbWMail').selectedIndex = 0;
			document.getElementById('txtName').value = '';
			document.getElementById('txtEmail').value = '';
			document.getElementById('txtURL').value = '';
			document.getElementById('txtMsgSbjct').value = '';
			document.getElementById('txtMsgBdy').value = '';
			try {
				document.getElementById('cmbWMail').focus();
			}
			catch (ex) {
			}
			finally {
			}
			break;
		default:
			break;
	}
}

function focusObject(object) {
	var obj = document.getElementById(object);
	obj.focus();
	obj.select();
}

function sendMessage() {
	setErr('dvStatusContactForm', false);
	wMail = document.getElementById('cmbWMail').value.trim();
	sender = document.getElementById('txtName').value.trim();
	mail = document.getElementById('txtEmail').value.trim();
	url = document.getElementById('txtURL').value.trim();
	subject = document.getElementById('txtMsgSbjct').value.trim();
	body = document.getElementById('txtMsgBdy').value.trim();
	if (sender == '') {
		setErr('dvStatusContactForm', true, errVerifySenderName);
		focusObject('txtName');
		return;
	}
	if (!mail.isEmail()) {
		setErr('dvStatusContactForm', true, errInvalidMail);
		focusObject('txtEmail');
		return;
	}
	if (url != '') {
		if (!url.isURL()) {
			setErr('dvStatusContactForm', true, errInvalidURL);
			focusObject('txtURL');
			return;
		}
	}
	if (subject == '') {
		setErr('dvStatusContactForm', true, errVerifyMsgSbjct);
		focusObject('txtMsgSbjct');
		return;
	}
	if (body == '') {
		setErr('dvStatusContactForm', true, errVerifyMsgBdy);		
		focusObject('txtMsgBdy');
		return;
	}
	setFormStatus('dvStatusContactForm', false, 'cmbWMail');
	talkingServer('SendMessage', '<to>' + wMail + '</to><sender>' + sender + '</sender><from>' + mail + '</from><url>' + url + '</url><subject>' + subject + '</subject><body>' + body + '</body>', 'dvStatusContactForm');
}

window.onload = function() {
	hidePreloader();
	initAjaxTargets('dvMainContents', 'dvNewsContents', 'dvStatusContactForm');
	switch (reqType) {
		case 'fetchpage':
			fetchPage(fetchX);
			break;
		case 'fetchgallery':
			fetchGallery(fetchX);
			break;
		case 'fetchnews':
			fetchNewsFromSearch(fetchX);
			break;
		case 'sitemap':
			siteMap();
			break;
		case 'links':
			fetchPage(fetchX);
			break;
		case 'contactus':
			contactForm();
			break;
		case 'aboutus':
			fetchPage(fetchX);
			break;
		default:
			fetchPage(mainPage);
			break;
	}
	if (hasContex)
		setContexMenu();
};






function spacer(count) {
	var space = '';
	for (i = 0; i < count; i++)
		space += '&nbsp;';
	return space;
}

function fixIESearch() {
	if (browser.isMSIE && browser.ver < 7)
		document.write(spacer(84));
}

if (window.addEventListener) {
    window.addEventListener("load", mladdevents, false);
}
else if (window.attachEvent) {
    window.attachEvent("onload", mladdevents);
}
else {
	window.onload = mladdevents;
}

function mladdevents() {
	if (!window.mlrunShim) {
		window.mlrunShim = false;
	}
	if (window.mlrunShim == true) {
		var Iframe = document.createElement("iframe");
		Iframe.setAttribute("src","about:blank");
		Iframe.setAttribute("scrolling","no");
		Iframe.setAttribute("frameBorder","0");
	}
	var effects_a = new Array();
	var divs = document.getElementsByTagName('div');
	for(var j = 0; j < divs.length; j++) {
		if (divs[j].className.indexOf('mlmenu') != -1) {
			divs[j].className = divs[j].className.replace('mlmenu','mlmenujs');
			divs[j].getElementsByTagName('ul')[0].className = divs[j].className;
			var lis = divs[j].getElementsByTagName('li');
			for(var i = 0; i < lis.length; i++) {
				lis[i].onmouseover = mlover;
				lis[i].onmouseout = mloutSetTimeout;
				if (window.mlrunShim == true) {
					lis[i].appendChild(Iframe.cloneNode(false));
				}
				if (lis[i].parentNode.getElementsByTagName('li')[0] == lis[i]) {
					lis[i].getElementsByTagName('a')[0].className += 'first';
					if (lis[i].parentNode.className.indexOf('mlmenujs') != -1) {
						lis[i].className += 'pixelfix';
					}
				}
				if (lis[i] == findLast(lis[i].parentNode)) {
					lis[i].className += 'last';
				}
				if (lis[i].getElementsByTagName('ul').length > 0) {
					lis[i].className += ' haschild';
					if (divs[j].className.indexOf('arrow') != -1) {
						if (divs[j].className.indexOf('vertical') != -1 || lis[i].parentNode.parentNode.nodeName != 'DIV') {
							lis[i].getElementsByTagName('a')[0].style.backgroundImage = urlArrow;
							lis[i].getElementsByTagName('a')[0].style.backgroundRepeat = 'no-repeat';
							lis[i].getElementsByTagName('a')[0].style.backgroundPosition = posArrow;
						}
					}
				}
				if (divs[j].className.indexOf('arrow') != -1) {
					lis[i].getElementsByTagName('a')[0].innerHTML += '<span class="noshow">&darr;</span>';
				}
				var uls = lis[i].getElementsByTagName('ul');
				for(var k=0;k<uls.length;k++) {
					var found = 'no';
					for(var z = 0; z < effects_a.length; z++) {
						if (effects_a[z] == uls[k]) {
							found = 'yes';
						}
					}
					if (found == 'no') {
						effects_a[effects_a.length] = uls[k];
						uls[k].style.zIndex = '100';
						mlEffectLoad(uls[k]);
					}
				}
			}
		}
	}
}
function mloutSetTimeout(e) {
	if (!e) {
		var the_e = window.event;
	}
	else{
		var the_e = e;
	}
	var reltg = (the_e.relatedTarget) ? the_e.relatedTarget : the_e.toElement;
	if (reltg) {
		var under = ancestor(reltg,this);
		if (under === false && reltg != this) {
			window.mlLast = this;
			var parent = this.parentNode;
			while(parent.parentNode && parent.className.indexOf('mlmenujs') == -1) {
				parent = parent.parentNode;
			}
			if (parent.className.indexOf('delay') != -1) {
				window.mlTimeout = setTimeout(function() {mlout()}, 1000);
			}
			else {
				mlout();
			}
		}
	}
}
function mlout() {
	if (window.mlLast == null) return false;
	var links = window.mlLast.getElementsByTagName('a');
	for(var i = 0; i < links.length; i++) {
		links[i].className = links[i].className.replace('hover','');
	}
	var uls = window.mlLast.getElementsByTagName('ul');
	var sib;
	for(var i = 0; i < uls.length; i++) {
		mlEffectOut(uls[i]);
		window.mlLast.className += ' hide';
		window.mlLast.className = window.mlLast.className.replace('hide hide','hide');
		if (window.mlrunShim == true) {
			sib = uls[i];
			while(sib.nextSibling && sib.nodeName != 'IFRAME') {
				sib = sib.nextSibling;
			}
			sib.style.display = 'none';
		}
	}
	window.lastover = null;
	return true;
}
function mlover(e) {

	if (!e) {
		var the_e = window.event;
	}
	else{
		var the_e = e;
	}
	the_e.cancelBubble = true;
	if (the_e.stopPropagation) {
		the_e.stopPropagation();
	}
	clearTimeout(window.mlTimeout);
	if (window.mlLast && window.mlLast != this && ancestor(this,window.mlLast) === false) {
		mlout();
	}
	else {
		window.mlLast = null;
	}
	var reltg = (the_e.relatedTarget) ? the_e.relatedTarget : the_e.fromElement;
	var under = ancestor(reltg,this);
	if (under == false) {
		var hovered = byClass(this.parentNode,'hover','a');
		for(var i = 0; i < hovered.length; i++) {
			if (ancestor(this,hovered[i].parentNode) == false) {
				window.mlLast = hovered[i].parentNode;
				mlout();
			}
		}
		var ob = this.getElementsByTagName('ul');
		var link = this.getElementsByTagName('a')[0];
		link.className += ' hover';
		if (ob[0]) {
			if (window.lastover != ob[0]) {
				if (window.mlrunShim == true) {
					var sib = ob[0];
					while(sib.nextSibling && sib.nodeName != 'IFRAME') {
						sib = sib.nextSibling;
					}
					ob[0].style.display = 'block';
					sib.style.top = ob[0].offsetTop+'px';
					sib.style.left = ob[0].offsetLeft-2+'px';
					sib.style.width = ob[0].offsetWidth+2+'px';
					sib.style.height = ob[0].offsetHeight-2+'px';
					sib.style.display = 'block';
				}
				this.className = this.className.replace(/hide/g,'');
				mlEffectOver(ob[0],this);
				window.lastover = ob[0];
			}
		}
	}
}
function mlSetOpacity(ob,level) {
	if (ob) {
		var standard = level/10;
		var ie = level*10;
		ob.style.opacity = standard;
		ob.style.filter = "alpha(opacity="+ie+")";
	}
}
function mlIncreaseOpacity(ob) {
	var current = ob.style.opacity;
	current = current * 10;
	var upone = current + 1;
	mlSetOpacity(ob,upone);
}
function mlIncreaseHeight(ob) {
	var current = parseInt(ob.style.height);
	if (!isNaN(current)) {
		var newh = current + 1;
		ob.style.height = newh+'px';
	}
}
function mlIncreaseWidth(ob) {
	var current = parseInt(ob.style.width);
	if (!isNaN(current)) {
		var newh = current + 1;
		ob.style.width = newh+'px';
	}
}
function mlShake(ob) {
	var newp = '5px';
	var old = '';
	if (ob.style.paddingLeft==old) {
		ob.style.paddingLeft=newp;
	}
	else{
		ob.style.paddingLeft=old;
	}
}
function mlEffectOver(ob,parent) {
	switch(ob.className) {
	case 'fade':
		ob.style.display = 'block';
		for(var i = 1; i <= 10; i++) {
			window.fadeTime = setTimeout(function() {mlIncreaseOpacity(ob)}, i*50);
		}
		setTimeout(function() {ob.style.filter = ''}, 500);
		break;
	case 'shake':
		ob.style.display = 'block';
		var shake = setInterval(function() {mlShake(ob)}, 50);
		setTimeout(function() {clearInterval(shake)}, 510);
		break;
	case 'blindv':
		ob.style.display = 'block';
		if (ob.offsetHeight) {
			var height = ob.offsetHeight;
			ob.style.height = '0px';
			ob.style.overflow = 'hidden';
			for(var i = 0; i < height; i++) {
				setTimeout(function() {mlIncreaseHeight(ob)}, i*3);
			}
			setTimeout(function() {ob.style.overflow='';ob.style.height='auto'}, (height-1)*3);
		}
		break;
	case 'blindh':
		ob.style.display = 'block';
		if (ob.offsetWidth) {
			var width = ob.offsetWidth;
			ob.style.width = '0px';
			ob.style.overflow = 'hidden';
			for(var i=0; i < width; i++) {
				setTimeout(function() {mlIncreaseWidth(ob)}, i*3);
			}
			setTimeout(function() {ob.style.overflow='visible';}, width*3);
		}
		break;
	default:
		ob.style.display = 'block';
		break;
	}
}
function mlEffectOut(ob) {
	switch(ob.className) {
		case 'fade':
			clearTimeout(window.fadeTime);
			mlSetOpacity(ob,0);
			ob.style.display = 'none';
			break;
		case 'shake':
			ob.style.paddingLeft = '';
			ob.style.display = 'none';
			break;
		default:
			ob.style.display = 'none';
			break;
	}
}
function mlEffectLoad(ob) {
	var parent = ob.parentNode;
	while(parent.parentNode && parent.className.indexOf('mlmenu') == -1) {
		parent = parent.parentNode;
	}
	if (parent.className.indexOf('fade') != -1) {
		ob.style.display = 'none';
		ob.className = 'fade';
		mlSetOpacity(ob,0);
	}
	else if (parent.className.indexOf('shake') != -1) {
		ob.className = 'shake';
	}
	else if (parent.className.indexOf('blindv') != -1) {
		ob.className = 'blindv';
	}
	else if (parent.className.indexOf('blindh') != -1) {
		ob.className = 'blindh';
	}
	else if (parent.className.indexOf('box') != -1) {
		ob.className = 'box';
	}
	ob.style.display = 'none';
}
function ancestor(child, parent) {
	try{
		if (child==null)return false;
		for(; child.parentNode; child = child.parentNode) {
				if (child.parentNode === parent) return true;
			}
		return false;
	}
	catch(error) {
		return false;
	}
}
function byClass(parent,c,tag) {
	var all = parent.getElementsByTagName(tag);
	var returna = new Array();
	for(var i = 0; i < all.length; i++) {
		if (all[i].className.indexOf(c) != -1) {
			returna[returna.length] = all[i];
		}
	}
	return returna;
}
function findLast(ob) {
	if (ob.lastChild.nodeType == 1) {
		return ob.lastChild;
	}
	return ob.lastChild.previousSibling;
}






var display_url = 0;

var ie5 = document.all && document.getElementById;
var ns6 = document.getElementById && !document.all;
if (ie5 || ns6)
	var menuobj;

function showmenuie5(e) {
	var rightedge = ie5 ? document.body.clientWidth - event.clientX : window.innerWidth - e.clientX;
	var bottomedge = ie5 ? document.body.clientHeight - event.clientY : window.innerHeight - e.clientY;

	if (rightedge < menuobj.offsetWidth)
		menuobj.style.left = ie5 ? document.body.scrollLeft + event.clientX - menuobj.offsetWidth : window.pageXOffset + e.clientX - menuobj.offsetWidth + 'px';
	else
		menuobj.style.left = ie5 ? document.body.scrollLeft + event.clientX : window.pageXOffset + e.clientX + 'px';

	if (bottomedge < menuobj.offsetHeight)
		menuobj.style.top = ie5 ? document.body.scrollTop + event.clientY - menuobj.offsetHeight : window.pageYOffset + e.clientY - menuobj.offsetHeight + 'px';
	else
		menuobj.style.top = ie5 ? document.body.scrollTop + event.clientY : window.pageYOffset + e.clientY + 'px';

	menuobj.style.visibility = "visible";
	return false;
}

function hidemenuie5(e) {
	menuobj.style.visibility = "hidden";
}

function highlightie5(e) {
	var firingobj = ie5 ? event.srcElement : e.target;
	if (firingobj.className == "menuitems" || ns6 && firingobj.parentNode.className == "menuitems") {
		if (ns6 && firingobj.parentNode.className == "menuitems")
			firingobj = firingobj.parentNode ;
		firingobj.style.backgroundColor = "highlight";
		firingobj.style.color = "white";
		if (display_url == 1)
			window.status = event.srcElement.url;
	}
}

function lowlightie5(e) {
	var firingobj = ie5 ? event.srcElement : e.target;
	if (firingobj.className == "menuitems" || ns6 && firingobj.parentNode.className == "menuitems") {
		if (ns6 && firingobj.parentNode.className == "menuitems")
			firingobj = firingobj.parentNode;
		firingobj.style.backgroundColor = "";
		firingobj.style.color = "black";
		window.status = '';
	}
}

function jumptoie5(e){
	var firingobj = ie5 ? event.srcElement : e.target;
	if (firingobj.className == "menuitems" || ns6 && firingobj.parentNode.className == "menuitems") {
		if (ns6&&firingobj.parentNode.className == "menuitems")
			firingobj = firingobj.parentNode;
		if (firingobj.getAttribute("target"))
			window.open(firingobj.getAttribute("url"), firingobj.getAttribute("target"));
		else
			window.location = firingobj.getAttribute("url");
	}
}

function setContexMenu () {
	menuobj = document.getElementById("ie5menu");
	if (ie5 || ns6) {
		menuobj.style.display = '';
		document.oncontextmenu = showmenuie5;
		document.onclick = hidemenuie5;
	}
}





function fixRecommends() {
	if (!browser.isGecko)
		document.write('كاربر گرامي جهت استفاده ي بهينه از وب سايت مرورگر فاير فاكس را توصيه مي نمائيم؛&nbsp;<a href="http://www.getfirefox.com/" target="_blank">دريافت فاير فاكس</a><br/>Tips:&nbsp;for best performance,&nbsp;we recommends&nbsp;<a href="http://www.getfirefox.com/" target="_blank" title="Get Firefox">Firefox</a>');
}



var thumbnailviewer = {
	enableTitle: true,
	enableAnimation: true,
	definefooter: '<div class="footerbar">X&nbsp;&nbsp;&nbsp;Close</div>',
	defineLoading: '<img src="preprogress.gif" />',
	
	
	scrollbarwidth: 16,
	opacitystring: 'filter:progid:DXImageTransform.Microsoft.alpha(opacity=10); -moz-opacity: 0.1; opacity: 0.1',
	targetlinks:[],

	createthumbBox: function() {
		document.write('<div id="thumbBox" onClick="thumbnailviewer.closeit()"><div id="thumbImage"></div>' + this.definefooter + '</div>');
		document.write('<div id="thumbLoading">' + this.defineLoading + '</div>');
		this.thumbBox = document.getElementById("thumbBox");
		this.thumbImage = document.getElementById("thumbImage");
		this.thumbLoading = document.getElementById("thumbLoading");
		this.standardbody = (document.compatMode == "CSS1Compat")? document.documentElement : document.body;
	},

	centerDiv: function(divobj) {
		var ie = document.all && !window.opera;
		var dom = document.getElementById;
		var scroll_top = (ie) ? this.standardbody.scrollTop : window.pageYOffset;
		var scroll_left = (ie) ? this.standardbody.scrollLeft : window.pageXOffset;
		var docwidth = (ie) ? this.standardbody.clientWidth : window.innerWidth-this.scrollbarwidth;
		var docheight = (ie) ? this.standardbody.clientHeight : window.innerHeight;
		var docheightcomplete = (this.standardbody.offsetHeight > this.standardbody.scrollHeight) ? this.standardbody.offsetHeight : this.standardbody.scrollHeight;
		var objwidth = divobj.offsetWidth;
		var objheight = divobj.offsetHeight;
		var topposition = (docheight > objheight) ? scroll_top + docheight / 2 - objheight / 2 + "px" : scroll_top + 10 + "px";
		divobj.style.left = docwidth / 2 - objwidth / 2 + "px";
		divobj.style.top = Math.floor(parseInt(topposition)) + "px";
		divobj.style.visibility = "visible";
	},

	showthumbBox: function() {
		this.centerDiv(this.thumbBox);
		if (this.enableAnimation) {
			this.currentopacity = 0.1;
			this.opacitytimer = setInterval("thumbnailviewer.opacityanimation()", 20);
		}
	},

	loadimage: function(link) {
		if (this.thumbBox.style.visibility == "visible")
			this.closeit();
		var imageHTML = '<img src="' + link.getAttribute("href") + '" style="' + this.opacitystring + '" />';
		if (this.enableTitle && link.getAttribute("title"))
			imageHTML += '<br /><div class="gTitle">' + link.getAttribute("title") + '</div>';
		this.centerDiv(this.thumbLoading);
		this.thumbImage.innerHTML = imageHTML;
		this.featureImage = this.thumbImage.getElementsByTagName("img")[0];
		this.featureImage.onload = function() {
			thumbnailviewer.thumbLoading.style.visibility = "hidden";
			thumbnailviewer.showthumbBox();
		};
		if (document.all && !window.createPopup)
			this.featureImage.src = link.getAttribute("href");
		this.featureImage.onerror = function() {
			thumbnailviewer.thumbLoading.style.visibility = "hidden";
		};
	},

	setimgopacity: function(value) {
		var targetobject = this.featureImage;
		if (targetobject.filters && targetobject.filters[0]) {
			if (typeof targetobject.filters[0].opacity == "number")
				targetobject.filters[0].opacity = value * 100;
			else
				targetobject.style.filter = "alpha(opacity=" + value * 100 +")";
		}
		else if (typeof targetobject.style.MozOpacity != "undefined")
			targetobject.style.MozOpacity = value;
		else if (typeof targetobject.style.opacity != "undefined")
			targetobject.style.opacity = value;
		else
			this.stopanimation();
	},

	opacityanimation: function() {
		this.setimgopacity(this.currentopacity);
		this.currentopacity += 0.1;
		if (this.currentopacity > 1)
			this.stopanimation();
	},

	stopanimation: function() {
		if (typeof this.opacitytimer != "undefined")
			clearInterval(this.opacitytimer);
	},

	closeit: function() {
		this.stopanimation();
		this.thumbBox.style.visibility = "hidden";
		this.thumbImage.innerHTML = "";
		this.thumbBox.style.left = "-2000px";
		this.thumbBox.style.top = "-2000px";
		hidePreloader();
	},

	cleanup: function() {
		this.thumbLoading = null;
		if (this.featureImage)
			this.featureImage.onload = null;
		this.featureImage = null;
		this.thumbImage = null;
		for (var i = 0; i < this.targetlinks.length; i++)
			this.targetlinks[i].onclick = null;
		this.thumbBox = null;
	},

	dotask: function(target, functionref, tasktype) {
		var tasktype = (window.addEventListener) ? tasktype : "on" + tasktype;
		if (target.addEventListener)
			target.addEventListener(tasktype, functionref, false);
		else if (target.attachEvent)
			target.attachEvent(tasktype, functionref);
	},

	init: function() {
		if (!this.enableAnimation)
			this.opacitystring = "";
		var pagelinks = document.getElementsByTagName("a");
		for (var i = 0; i < pagelinks.length; i++) {
			if (pagelinks[i].getAttribute("rel") && pagelinks[i].getAttribute("rel") == "thumbnail") {
				pagelinks[i].onclick = function() {
					
					var obj = document.getElementById('dvPreLoader');
					obj.style.visibility = 'visible';
					obj.style.height = arrayPageSize[1] + 'px';
					obj.style.width = arrayPageSize[0] - 99 + 'px';
					obj.style.zIndex = 999;
					if (browser.isMSIE) {
						if (browser.ver > 6) {
							obj.style.background = 'url(prealpha.png) repeat';
						}
					}
					
					thumbnailviewer.stopanimation();
					thumbnailviewer.loadimage(this);
					return false;
				};
				this.targetlinks[this.targetlinks.length] = pagelinks[i];
			}
		}
		this.dotask(window, function() {if (thumbnailviewer.thumbBox.style.visibility == "visible") thumbnailviewer.centerDiv(thumbnailviewer.thumbBox)}, "resize");
	}
	
};

thumbnailviewer.createthumbBox();
thumbnailviewer.dotask(window, function() {thumbnailviewer.init()}, "load");
thumbnailviewer.dotask(window, function() {thumbnailviewer.cleanup()}, "unload");










var persisteduls = new Object();
var ddtreemenu = new Object();

if (lang != 'en') {
	ddtreemenu.closefolder = "smclosed.fa.gif";
	ddtreemenu.openfolder = "smopen.fa.gif";
}
else {
	ddtreemenu.closefolder = "smclosed.gif";
	ddtreemenu.openfolder = "smopen.gif";
}

ddtreemenu.createTree = function(treeid, enablepersist, persistdays) {
	var ultags = document.getElementById(treeid).getElementsByTagName("ul");
	if (typeof persisteduls[treeid] == "undefined")
		persisteduls[treeid] = (enablepersist == true && ddtreemenu.getCookie(treeid) != "") ? ddtreemenu.getCookie(treeid).split(",") : "";
	for (var i = 0; i < ultags.length; i++)
		ddtreemenu.buildSubTree(treeid, ultags[i], i);
	if (enablepersist == true) {
		var durationdays = (typeof persistdays == "undefined") ? 1 : parseInt(persistdays);
		ddtreemenu.dotask(window, function() {ddtreemenu.rememberstate(treeid, durationdays)}, "unload");
	}
};

ddtreemenu.buildSubTree = function(treeid, ulelement, index) {
	ulelement.parentNode.className = "submenu";
	if (typeof persisteduls[treeid] == "object") {
		if (ddtreemenu.searcharray(persisteduls[treeid], index)) {
			ulelement.setAttribute("rel", "open");
			ulelement.style.display = "block";
			ulelement.parentNode.style.backgroundImage = "url(" + ddtreemenu.openfolder + ")";
		}
		else
			ulelement.setAttribute("rel", "closed");
	}
	else if (ulelement.getAttribute("rel") == null || ulelement.getAttribute("rel") == false)
		ulelement.setAttribute("rel", "closed");
	else if (ulelement.getAttribute("rel") == "open")
		ddtreemenu.expandSubTree(treeid, ulelement);
	ulelement.parentNode.onclick = function(e) {
		var submenu = this.getElementsByTagName("ul")[0];
		if (submenu.getAttribute("rel") == "closed") {
			submenu.style.display="block";
			submenu.setAttribute("rel", "open");
			ulelement.parentNode.style.backgroundImage = "url(" + ddtreemenu.openfolder + ")";
		}
		else if (submenu.getAttribute("rel") == "open") {
			submenu.style.display = "none";
			submenu.setAttribute("rel", "closed");
			ulelement.parentNode.style.backgroundImage = "url(" + ddtreemenu.closefolder + ")";
		}
		ddtreemenu.preventpropagate(e);
	};
	ulelement.onclick = function(e) {
		ddtreemenu.preventpropagate(e);
	};
};

ddtreemenu.expandSubTree = function(treeid, ulelement) {
	var rootnode = document.getElementById(treeid);
	var currentnode = ulelement;
	currentnode.style.display = "block";
	currentnode.parentNode.style.backgroundImage = "url(" + ddtreemenu.openfolder + ")";
	while (currentnode != rootnode) {
		if (currentnode.tagName == "UL") {
			currentnode.style.display = "block";
			currentnode.setAttribute("rel", "open");
			currentnode.parentNode.style.backgroundImage = "url(" + ddtreemenu.openfolder + ")";
		}
		currentnode = currentnode.parentNode;
	}
};

ddtreemenu.flatten = function(treeid, action) {
	var ultags = document.getElementById(treeid).getElementsByTagName("ul");
	for (var i = 0; i < ultags.length; i++) {
		ultags[i].style.display = (action == "expand") ? "block" : "none";
		var relvalue = (action == "expand") ? "open" : "closed";
		ultags[i].setAttribute("rel", relvalue);
		ultags[i].parentNode.style.backgroundImage = (action == "expand") ? "url(" + ddtreemenu.openfolder + ")" : "url(" + ddtreemenu.closefolder + ")";
	}
};

ddtreemenu.rememberstate = function(treeid, durationdays) {
	var ultags = document.getElementById(treeid).getElementsByTagName("ul");
	var openuls = new Array();
	for (var i = 0; i < ultags.length; i++) {
		if (ultags[i].getAttribute("rel") == "open")
			openuls[openuls.length] = i;
	}
	if (openuls.length == 0 )
		openuls[0] = "none open";
	ddtreemenu.setCookie(treeid, openuls.join(","), durationdays);
};

ddtreemenu.getCookie = function(Name) {
	var re = new RegExp(Name + "=[^;]+", "i");
	if (document.cookie.match(re))
		return document.cookie.match(re)[0].split("=")[1];
	return "";
};

ddtreemenu.setCookie = function(name, value, days) {
	var expireDate = new Date();
	var expstring = expireDate.setDate(expireDate.getDate() + parseInt(days));
	document.cookie = name + "=" + value + "; expires=" + expireDate.toGMTString() + "; path=/";
};

ddtreemenu.searcharray = function(thearray, value) {
	var isfound = false;
	for (var i = 0; i < thearray.length; i++) {
		if (thearray[i] == value) {
			isfound = true;
			thearray.shift();
			break;
		}
	}
	return isfound;
};

ddtreemenu.preventpropagate = function(e) {
	if (typeof e != "undefined")
		e.stopPropagation();
	else
		event.cancelBubble = true;
};

ddtreemenu.dotask = function(target, functionref, tasktype) {
	var tasktype = (window.addEventListener) ? tasktype : "on" + tasktype;
	if (target.addEventListener)
		target.addEventListener(tasktype, functionref, false);
	else if (target.attachEvent)
		target.attachEvent(tasktype, functionref);
};








if(typeof deconcept=="undefined"){var deconcept=new Object();}if(typeof deconcept.util=="undefined"){deconcept.util=new Object();}if(typeof deconcept.SWFObjectUtil=="undefined"){deconcept.SWFObjectUtil=new Object();}deconcept.SWFObject=function(_1,id,w,h,_5,c,_7,_8,_9,_a){if(!document.getElementById){return;}this.DETECT_KEY=_a?_a:"detectflash";this.skipDetect=deconcept.util.getRequestParameter(this.DETECT_KEY);this.params=new Object();this.variables=new Object();this.attributes=new Array();if(_1){this.setAttribute("swf",_1);}if(id){this.setAttribute("id",id);}if(w){this.setAttribute("width",w);}if(h){this.setAttribute("height",h);}if(_5){this.setAttribute("version",new deconcept.PlayerVersion(_5.toString().split(".")));}this.installedVer=deconcept.SWFObjectUtil.getPlayerVersion();if(!window.opera&&document.all&&this.installedVer.major>7){deconcept.SWFObject.doPrepUnload=true;}if(c){this.addParam("bgcolor",c);}var q=_7?_7:"high";this.addParam("quality",q);this.setAttribute("useExpressInstall",false);this.setAttribute("doExpressInstall",false);var _c=(_8)?_8:window.location;this.setAttribute("xiRedirectUrl",_c);this.setAttribute("redirectUrl","");if(_9){this.setAttribute("redirectUrl",_9);}};deconcept.SWFObject.prototype={useExpressInstall:function(_d){this.xiSWFPath=!_d?"expressinstall.swf":_d;this.setAttribute("useExpressInstall",true);},setAttribute:function(_e,_f){this.attributes[_e]=_f;},getAttribute:function(_10){return this.attributes[_10];},addParam:function(_11,_12){this.params[_11]=_12;},getParams:function(){return this.params;},addVariable:function(_13,_14){this.variables[_13]=_14;},getVariable:function(_15){return this.variables[_15];},getVariables:function(){return this.variables;},getVariablePairs:function(){var _16=new Array();var key;var _18=this.getVariables();for(key in _18){_16[_16.length]=key+"="+_18[key];}return _16;},getSWFHTML:function(){var _19="";if(navigator.plugins&&navigator.mimeTypes&&navigator.mimeTypes.length){if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","PlugIn");this.setAttribute("swf",this.xiSWFPath);}_19="<embed type=\"application/x-shockwave-flash\" src=\""+this.getAttribute("swf")+"\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\" style=\""+this.getAttribute("style")+"\"";_19+=" id=\""+this.getAttribute("id")+"\" name=\""+this.getAttribute("id")+"\" ";var _1a=this.getParams();for(var key in _1a){_19+=[key]+"=\""+_1a[key]+"\" ";}var _1c=this.getVariablePairs().join("&");if(_1c.length>0){_19+="flashvars=\""+_1c+"\"";}_19+="/>";}else{if(this.getAttribute("doExpressInstall")){this.addVariable("MMplayerType","ActiveX");this.setAttribute("swf",this.xiSWFPath);}_19="<object id=\""+this.getAttribute("id")+"\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\""+this.getAttribute("width")+"\" height=\""+this.getAttribute("height")+"\" style=\""+this.getAttribute("style")+"\">";_19+="<param name=\"movie\" value=\""+this.getAttribute("swf")+"\" />";var _1d=this.getParams();for(var key in _1d){_19+="<param name=\""+key+"\" value=\""+_1d[key]+"\" />";}var _1f=this.getVariablePairs().join("&");if(_1f.length>0){_19+="<param name=\"flashvars\" value=\""+_1f+"\" />";}_19+="</object>";}return _19;},write:function(_20){if(this.getAttribute("useExpressInstall")){var _21=new deconcept.PlayerVersion([6,0,65]);if(this.installedVer.versionIsValid(_21)&&!this.installedVer.versionIsValid(this.getAttribute("version"))){this.setAttribute("doExpressInstall",true);this.addVariable("MMredirectURL",escape(this.getAttribute("xiRedirectUrl")));document.title=document.title.slice(0,47)+" - Flash Player Installation";this.addVariable("MMdoctitle",document.title);}}if(this.skipDetect||this.getAttribute("doExpressInstall")||this.installedVer.versionIsValid(this.getAttribute("version"))){var n=(typeof _20=="string")?document.getElementById(_20):_20;n.innerHTML=this.getSWFHTML();return true;}else{if(this.getAttribute("redirectUrl")!=""){document.location.replace(this.getAttribute("redirectUrl"));}}return false;}};deconcept.SWFObjectUtil.getPlayerVersion=function(){var _23=new deconcept.PlayerVersion([0,0,0]);if(navigator.plugins&&navigator.mimeTypes.length){var x=navigator.plugins["Shockwave Flash"];if(x&&x.description){_23=new deconcept.PlayerVersion(x.description.replace(/([a-zA-Z]|\s)+/,"").replace(/(\s+r|\s+b[0-9]+)/,".").split("."));}}else{if(navigator.userAgent&&navigator.userAgent.indexOf("Windows CE")>=0){var axo=1;var _26=3;while(axo){try{_26++;axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash."+_26);_23=new deconcept.PlayerVersion([_26,0,0]);}catch(e){axo=null;}}}else{try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7");}catch(e){try{var axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6");_23=new deconcept.PlayerVersion([6,0,21]);axo.AllowScriptAccess="always";}catch(e){if(_23.major==6){return _23;}}try{axo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash");}catch(e){}}if(axo!=null){_23=new deconcept.PlayerVersion(axo.GetVariable("$version").split(" ")[1].split(","));}}}return _23;};deconcept.PlayerVersion=function(_29){this.major=_29[0]!=null?parseInt(_29[0]):0;this.minor=_29[1]!=null?parseInt(_29[1]):0;this.rev=_29[2]!=null?parseInt(_29[2]):0;};deconcept.PlayerVersion.prototype.versionIsValid=function(fv){if(this.major<fv.major){return false;}if(this.major>fv.major){return true;}if(this.minor<fv.minor){return false;}if(this.minor>fv.minor){return true;}if(this.rev<fv.rev){return false;}return true;};deconcept.util={getRequestParameter:function(_2b){var q=document.location.search||document.location.hash;if(_2b==null){return q;}if(q){var _2d=q.substring(1).split("&");for(var i=0;i<_2d.length;i++){if(_2d[i].substring(0,_2d[i].indexOf("="))==_2b){return _2d[i].substring((_2d[i].indexOf("=")+1));}}}return "";}};deconcept.SWFObjectUtil.cleanupSWFs=function(){var _2f=document.getElementsByTagName("OBJECT");for(var i=_2f.length-1;i>=0;i--){_2f[i].style.display="none";for(var x in _2f[i]){if(typeof _2f[i][x]=="function"){_2f[i][x]=function(){};}}}};if(deconcept.SWFObject.doPrepUnload){if(!deconcept.unloadSet){deconcept.SWFObjectUtil.prepUnload=function(){__flash_unloadHandler=function(){};__flash_savedUnloadHandler=function(){};window.attachEvent("onunload",deconcept.SWFObjectUtil.cleanupSWFs);};window.attachEvent("onbeforeunload",deconcept.SWFObjectUtil.prepUnload);deconcept.unloadSet=true;}}if(!document.getElementById&&document.all){document.getElementById=function(id){return document.all[id];};}var getQueryParamValue=deconcept.util.getRequestParameter;var FlashObject=deconcept.SWFObject;var SWFObject=deconcept.SWFObject;