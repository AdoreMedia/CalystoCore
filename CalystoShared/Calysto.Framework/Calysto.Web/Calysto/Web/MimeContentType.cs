﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Calysto.Web
{
	public class MimeContentType
	{
		#region MimeTypesByContentType

		static string mMimeTypesByContentType = @"

application/envoy  	evy
application/fractals 	fif
application/futuresplash 	spl
application/hta 	hta
application/internet-property-stream 	acx
application/mac-binhex40 	hqx
application/msword 	doc
application/msword 	dot
application/octet-stream 	*
application/octet-stream 	bin
application/octet-stream 	class
application/octet-stream 	dms
application/octet-stream 	exe
application/octet-stream 	lha
application/octet-stream 	lzh
application/oda 	oda
application/olescript 	axs
application/pdf 	pdf
application/pics-rules 	prf
application/pkcs10 	p10
application/pkix-crl 	crl
application/postscript 	ai
application/postscript 	eps
application/postscript 	ps
application/rtf 	rtf
application/set-payment-initiation 	setpay
application/set-registration-initiation 	setreg
application/vnd.ms-excel 	xla
application/vnd.ms-excel 	xlc
application/vnd.ms-excel 	xlm
application/vnd.ms-excel 	xls
application/vnd.ms-excel 	xlt
application/vnd.ms-excel 	xlw
application/vnd.ms-outlook 	msg
application/vnd.ms-pkicertstore 	sst
application/vnd.ms-pkiseccat 	cat
application/vnd.ms-pkistl 	stl
application/vnd.ms-powerpoint 	pot
application/vnd.ms-powerpoint 	pps
application/vnd.ms-powerpoint 	ppt
application/vnd.ms-project 	mpp
application/vnd.ms-works 	wcm
application/vnd.ms-works 	wdb
application/vnd.ms-works 	wks
application/vnd.ms-works 	wps
application/winhlp 	hlp
application/x-bcpio 	bcpio
application/x-cdf 	cdf
application/x-compress 	z
application/x-compressed 	tgz
application/x-cpio 	cpio
application/x-csh 	csh
application/x-director 	dcr
application/x-director 	dir
application/x-director 	dxr
application/x-dvi 	dvi
application/x-gtar 	gtar
application/x-gzip 	gz
application/x-hdf 	hdf
application/x-internet-signup 	ins
application/x-internet-signup 	isp
application/x-iphone 	iii
application/x-javascript 	js
application/x-latex 	latex
application/x-msaccess 	mdb
application/x-mscardfile 	crd
application/x-msclip 	clp
application/x-msdownload 	dll
application/x-msmediaview 	m13
application/x-msmediaview 	m14
application/x-msmediaview 	mvb
application/x-msmetafile 	wmf
application/x-msmoney 	mny
application/x-mspublisher 	pub
application/x-msschedule 	scd
application/x-msterminal 	trm
application/x-mswrite 	wri
application/x-netcdf 	cdf
application/x-netcdf 	nc
application/x-perfmon 	pma
application/x-perfmon 	pmc
application/x-perfmon 	pml
application/x-perfmon 	pmr
application/x-perfmon 	pmw
application/x-pkcs12 	p12
application/x-pkcs12 	pfx
application/x-pkcs7-certificates 	p7b
application/x-pkcs7-certificates 	spc
application/x-pkcs7-certreqresp 	p7r
application/x-pkcs7-mime 	p7c
application/x-pkcs7-mime 	p7m
application/x-pkcs7-signature 	p7s
application/x-sh 	sh
application/x-shar 	shar
application/x-shockwave-flash 	swf
application/x-stuffit 	sit
application/x-sv4cpio 	sv4cpio
application/x-sv4crc 	sv4crc
application/x-tar 	tar
application/x-tcl 	tcl
application/x-tex 	tex
application/x-texinfo 	texi
application/x-texinfo 	texinfo
application/x-troff 	roff
application/x-troff 	t
application/x-troff 	tr
application/x-troff-man 	man
application/x-troff-me 	me
application/x-troff-ms 	ms
application/x-ustar 	ustar
application/x-wais-source 	src
application/x-x509-ca-cert 	cer
application/x-x509-ca-cert 	crt
application/x-x509-ca-cert 	der
application/ynd.ms-pkipko 	pko
application/zip 	zip
audio/basic 	au
audio/basic 	snd
audio/mid 	mid
audio/mid 	rmi
audio/mpeg 	mp3
audio/x-aiff 	aif
audio/x-aiff 	aifc
audio/x-aiff 	aiff
audio/x-mpegurl 	m3u
audio/x-pn-realaudio 	ra
audio/x-pn-realaudio 	ram
audio/x-wav 	wav
image/bmp 	bmp
image/cis-cod 	cod
image/gif 	gif
image/ief 	ief
image/jpeg 	jpe
image/jpeg 	jpeg
image/jpeg 	jpg
image/pipeg 	jfif
image/png 	png
image/svg+xml 	svg
image/tiff 	tif
image/tiff 	tiff
image/x-cmu-raster 	ras
image/x-cmx 	cmx
image/x-icon 	ico
image/x-portable-anymap 	pnm
image/x-portable-bitmap 	pbm
image/x-portable-graymap 	pgm
image/x-portable-pixmap 	ppm
image/x-rgb 	rgb
image/x-xbitmap 	xbm
image/x-xpixmap 	xpm
image/x-xwindowdump 	xwd
message/rfc822 	mht
message/rfc822 	mhtml
message/rfc822 	nws
text/css 	css
text/h323 	323
text/html 	htm
text/html 	html
text/html 	stm
text/iuls 	uls
text/plain 	bas
text/plain 	c
text/plain 	h
text/plain 	txt
text/richtext 	rtx
text/scriptlet 	sct
text/tab-separated-values 	tsv
text/webviewhtml 	htt
text/x-component 	htc
text/x-setext 	etx
text/x-vcard 	vcf
video/mpeg 	mp2
video/mpeg 	mpa
video/mpeg 	mpe
video/mpeg 	mpeg
video/mpeg 	mpg
video/mpeg 	mpv2
video/quicktime 	mov
video/quicktime 	qt
video/x-la-asf 	lsf
video/x-la-asf 	lsx
video/x-ms-asf 	asf
video/x-ms-asf 	asr
video/x-ms-asf 	asx
video/x-msvideo 	avi
video/x-sgi-movie 	movie
x-world/x-vrml 	flr
x-world/x-vrml 	vrml
x-world/x-vrml 	wrl
x-world/x-vrml 	wrz
x-world/x-vrml 	xaf
x-world/x-vrml 	xofapplication/envoy  	evy
application/fractals 	fif
application/futuresplash 	spl
application/hta 	hta
application/internet-property-stream 	acx
application/mac-binhex40 	hqx
application/msword 	doc
application/msword 	dot
application/octet-stream 	*
application/octet-stream 	bin
application/octet-stream 	class
application/octet-stream 	dms
application/octet-stream 	exe
application/octet-stream 	lha
application/octet-stream 	lzh
application/oda 	oda
application/olescript 	axs
application/pdf 	pdf
application/pics-rules 	prf
application/pkcs10 	p10
application/pkix-crl 	crl
application/postscript 	ai
application/postscript 	eps
application/postscript 	ps
application/rtf 	rtf
application/set-payment-initiation 	setpay
application/set-registration-initiation 	setreg
application/vnd.ms-excel 	xla
application/vnd.ms-excel 	xlc
application/vnd.ms-excel 	xlm
application/vnd.ms-excel 	xls
application/vnd.ms-excel 	xlt
application/vnd.ms-excel 	xlw
application/vnd.ms-outlook 	msg
application/vnd.ms-pkicertstore 	sst
application/vnd.ms-pkiseccat 	cat
application/vnd.ms-pkistl 	stl
application/vnd.ms-powerpoint 	pot
application/vnd.ms-powerpoint 	pps
application/vnd.ms-powerpoint 	ppt
application/vnd.ms-project 	mpp
application/vnd.ms-works 	wcm
application/vnd.ms-works 	wdb
application/vnd.ms-works 	wks
application/vnd.ms-works 	wps
application/winhlp 	hlp
application/x-bcpio 	bcpio
application/x-cdf 	cdf
application/x-compress 	z
application/x-compressed 	tgz
application/x-cpio 	cpio
application/x-csh 	csh
application/x-director 	dcr
application/x-director 	dir
application/x-director 	dxr
application/x-dvi 	dvi
application/x-gtar 	gtar
application/x-gzip 	gz
application/x-hdf 	hdf
application/x-internet-signup 	ins
application/x-internet-signup 	isp
application/x-iphone 	iii
application/x-javascript 	js
application/x-latex 	latex
application/x-msaccess 	mdb
application/x-mscardfile 	crd
application/x-msclip 	clp
application/x-msdownload 	dll
application/x-msmediaview 	m13
application/x-msmediaview 	m14
application/x-msmediaview 	mvb
application/x-msmetafile 	wmf
application/x-msmoney 	mny
application/x-mspublisher 	pub
application/x-msschedule 	scd
application/x-msterminal 	trm
application/x-mswrite 	wri
application/x-netcdf 	cdf
application/x-netcdf 	nc
application/x-perfmon 	pma
application/x-perfmon 	pmc
application/x-perfmon 	pml
application/x-perfmon 	pmr
application/x-perfmon 	pmw
application/x-pkcs12 	p12
application/x-pkcs12 	pfx
application/x-pkcs7-certificates 	p7b
application/x-pkcs7-certificates 	spc
application/x-pkcs7-certreqresp 	p7r
application/x-pkcs7-mime 	p7c
application/x-pkcs7-mime 	p7m
application/x-pkcs7-signature 	p7s
application/x-sh 	sh
application/x-shar 	shar
application/x-shockwave-flash 	swf
application/x-stuffit 	sit
application/x-sv4cpio 	sv4cpio
application/x-sv4crc 	sv4crc
application/x-tar 	tar
application/x-tcl 	tcl
application/x-tex 	tex
application/x-texinfo 	texi
application/x-texinfo 	texinfo
application/x-troff 	roff
application/x-troff 	t
application/x-troff 	tr
application/x-troff-man 	man
application/x-troff-me 	me
application/x-troff-ms 	ms
application/x-ustar 	ustar
application/x-wais-source 	src
application/x-x509-ca-cert 	cer
application/x-x509-ca-cert 	crt
application/x-x509-ca-cert 	der
application/ynd.ms-pkipko 	pko
application/zip 	zip
audio/basic 	au
audio/basic 	snd
audio/mid 	mid
audio/mid 	rmi
audio/mpeg 	mp3
audio/x-aiff 	aif
audio/x-aiff 	aifc
audio/x-aiff 	aiff
audio/x-mpegurl 	m3u
audio/x-pn-realaudio 	ra
audio/x-pn-realaudio 	ram
audio/x-wav 	wav
image/bmp 	bmp
image/cis-cod 	cod
image/gif 	gif
image/ief 	ief
image/jpeg 	jpe
image/jpeg 	jpeg
image/jpeg 	jpg
image/pipeg 	jfif
image/png 	png
image/svg+xml 	svg
image/tiff 	tif
image/tiff 	tiff
image/x-cmu-raster 	ras
image/x-cmx 	cmx
image/x-icon 	ico
image/x-portable-anymap 	pnm
image/x-portable-bitmap 	pbm
image/x-portable-graymap 	pgm
image/x-portable-pixmap 	ppm
image/x-rgb 	rgb
image/x-xbitmap 	xbm
image/x-xpixmap 	xpm
image/x-xwindowdump 	xwd
message/rfc822 	mht
message/rfc822 	mhtml
message/rfc822 	nws
text/css 	css
text/h323 	323
text/html 	htm
text/html 	html
text/html 	stm
text/iuls 	uls
text/plain 	bas
text/plain 	c
text/plain 	h
text/plain 	txt
text/richtext 	rtx
text/scriptlet 	sct
text/tab-separated-values 	tsv
text/webviewhtml 	htt
text/x-component 	htc
text/x-setext 	etx
text/x-vcard 	vcf
video/mpeg 	mp2
video/mpeg 	mpa
video/mpeg 	mpe
video/mpeg 	mpeg
video/mpeg 	mpg
video/mpeg 	mpv2
video/quicktime 	mov
video/quicktime 	qt
video/x-la-asf 	lsf
video/x-la-asf 	lsx
video/x-ms-asf 	asf
video/x-ms-asf 	asr
video/x-ms-asf 	asx
video/x-msvideo 	avi
video/x-sgi-movie 	movie
x-world/x-vrml 	flr
x-world/x-vrml 	vrml
x-world/x-vrml 	wrl
x-world/x-vrml 	wrz
x-world/x-vrml 	xaf
x-world/x-vrml 	xof
video/mp4			mp4
";
		#endregion

		#region MimeTypesByExtension

		static string mMimeTypesByExtension = @"
unknown		application/unknown
default		application/octet-stream
*		   	application/octet-stream
323 	text/h323
acx 	application/internet-property-stream
ai 	application/postscript
aif 	audio/x-aiff
aifc 	audio/x-aiff
aiff 	audio/x-aiff
asf 	video/x-ms-asf
asr 	video/x-ms-asf
asx 	video/x-ms-asf
au 	audio/basic
avi 	video/x-msvideo
axs 	application/olescript
bas 	text/plain
bcpio 	application/x-bcpio
bin 	application/octet-stream
bmp 	image/bmp
c 	text/plain
cat 	application/vnd.ms-pkiseccat
cdf 	application/x-cdf
cer 	application/x-x509-ca-cert
class 	application/octet-stream
clp 	application/x-msclip
cmx 	image/x-cmx
cod 	image/cis-cod
cpio 	application/x-cpio
crd 	application/x-mscardfile
crl 	application/pkix-crl
crt 	application/x-x509-ca-cert
csh 	application/x-csh
css 	text/css
dcr 	application/x-director
der 	application/x-x509-ca-cert
dir 	application/x-director
dll 	application/x-msdownload
dms 	application/octet-stream
doc 	application/msword
docx 	application/msword
dot 	application/msword
dvi 	application/x-dvi
dxr 	application/x-director
eps 	application/postscript
etx 	text/x-setext
evy 	application/envoy
exe 	application/octet-stream
fif 	application/fractals
flr 	x-world/x-vrml
gif 	image/gif
gtar 	application/x-gtar
gz 	application/x-gzip
h 	text/plain
hdf 	application/x-hdf
hlp 	application/winhlp
hqx 	application/mac-binhex40
hta 	application/hta
htc 	text/x-component
htm 	text/html
html 	text/html
htt 	text/webviewhtml
ico 	image/x-icon
ief 	image/ief
iii 	application/x-iphone
ins 	application/x-internet-signup
isp 	application/x-internet-signup
jfif 	image/pipeg
jpe 	image/jpeg
jpeg 	image/jpeg
jpg 	image/jpeg
js 	application/x-javascript
latex 	application/x-latex
lha 	application/octet-stream
lsf 	video/x-la-asf
lsx 	video/x-la-asf
lzh 	application/octet-stream
m13 	application/x-msmediaview
m14 	application/x-msmediaview
m3u 	audio/x-mpegurl
man 	application/x-troff-man
mdb 	application/x-msaccess
me 	application/x-troff-me
mht 	message/rfc822
mhtml 	message/rfc822
mid 	audio/mid
mny 	application/x-msmoney
mov 	video/quicktime
movie 	video/x-sgi-movie
mp2 	video/mpeg
mp3 	audio/mpeg
mpa 	video/mpeg
mpe 	video/mpeg
mpeg 	video/mpeg
mpg 	video/mpeg
mpp 	application/vnd.ms-project
mpv2 	video/mpeg
ms 	application/x-troff-ms
mvb 	application/x-msmediaview
nws 	message/rfc822
oda 	application/oda
p10 	application/pkcs10
p12 	application/x-pkcs12
p7b 	application/x-pkcs7-certificates
p7c 	application/x-pkcs7-mime
p7m 	application/x-pkcs7-mime
p7r 	application/x-pkcs7-certreqresp
p7s 	application/x-pkcs7-signature
pbm 	image/x-portable-bitmap
pdf 	application/pdf
pfx 	application/x-pkcs12
pgm 	image/x-portable-graymap
pko 	application/ynd.ms-pkipko
pma 	application/x-perfmon
pmc 	application/x-perfmon
pml 	application/x-perfmon
pmr 	application/x-perfmon
pmw 	application/x-perfmon
pnm 	image/x-portable-anymap
pot, 	application/vnd.ms-powerpoint
ppm 	image/x-portable-pixmap
pps 	application/vnd.ms-powerpoint
ppt 	application/vnd.ms-powerpoint
pptx 	application/vnd.ms-powerpoint
prf 	application/pics-rules
ps 	application/postscript
pub 	application/x-mspublisher
qt 	video/quicktime
ra 	audio/x-pn-realaudio
ram 	audio/x-pn-realaudio
ras 	image/x-cmu-raster
rgb 	image/x-rgb
rmi 	audio/mid
roff 	application/x-troff
rtf 	application/rtf
rtx 	text/richtext
scd 	application/x-msschedule
sct 	text/scriptlet
setpay 	application/set-payment-initiation
setreg 	application/set-registration-initiation
sh 	application/x-sh
shar 	application/x-shar
sit 	application/x-stuffit
snd 	audio/basic
spc 	application/x-pkcs7-certificates
spl 	application/futuresplash
src 	application/x-wais-source
sst 	application/vnd.ms-pkicertstore
stl 	application/vnd.ms-pkistl
stm 	text/html
svg 	image/svg+xml
sv4cpio 	application/x-sv4cpio
sv4crc 	application/x-sv4crc
swf 	application/x-shockwave-flash
t 	application/x-troff
tar 	application/x-tar
tcl 	application/x-tcl
tex 	application/x-tex
texi 	application/x-texinfo
texinfo 	application/x-texinfo
tgz 	application/x-compressed
tif 	image/tiff
tiff 	image/tiff
tr 	application/x-troff
trm 	application/x-msterminal
tsv 	text/tab-separated-values
txt 	text/plain
uls 	text/iuls
ustar 	application/x-ustar
vcf 	text/x-vcard
vrml 	x-world/x-vrml
wav 	audio/x-wav
wcm 	application/vnd.ms-works
wdb 	application/vnd.ms-works
wks 	application/vnd.ms-works
wmf 	application/x-msmetafile
wps 	application/vnd.ms-works
wri 	application/x-mswrite
wrl 	x-world/x-vrml
wrz 	x-world/x-vrml
xaf 	x-world/x-vrml
xbm 	image/x-xbitmap
xla 	application/vnd.ms-excel
xlc 	application/vnd.ms-excel
xlm 	application/vnd.ms-excel
xls 	application/vnd.ms-excel
xlsx 	application/vnd.ms-excel
xlt 	application/vnd.ms-excel
xlw 	application/vnd.ms-excel
xml  text/xml
xof 	x-world/x-vrml
xpm 	image/x-xpixmap
xwd 	image/x-xwindowdump
z 	application/x-compress
zip 	application/zip
mp4		video/mp4
svg	image/svg+xml
ttf		application/x-font-ttf
otf		application/x-font-opentype
woff		application/font-woff
woff2		application/font-woff2
eot		application/vnd.ms-fontobject
sfnt		application/font-sfnt
scss		text/x-scss
sass		text/x-sass
less		text/x-less
map		application/octet-stream

";
		#endregion

		// key: extension, value: mime type
		private static Dictionary<string, string> mDicMimeTypesByExtension;

		class KV
		{
			public string Extension;
			public string Mime;
		}

		static MimeContentType()
		{
			List<KV> list = new List<KV>();

			Regex re = new Regex("([^\\s]+)[\\s]+([^\\s]+)[\\r\\n]+");
			
			// MIME by extension
			MatchCollection mcoll = re.Matches(mMimeTypesByExtension);
			foreach (Match m in mcoll)
			{
				// extension, mime
				list.Add(new KV() { Extension = m.Groups[1].Value, Mime = m.Groups[2].Value });
			}

			mcoll = re.Matches(mMimeTypesByContentType);

			foreach (Match m in mcoll)
			{
				// mime, extension
				list.Add(new KV() { Extension = m.Groups[2].Value, Mime = m.Groups[1].Value });
			}

			mDicMimeTypesByExtension = list.GroupBy(o => o.Extension).ToDictionary(o => o.Key, o => o.First().Mime);
		}

		private static string FixExtension(string extension)
		{
			return extension.Replace(".", "").ToLower();
		}

		public static string GetMime(string extension)
		{
			string mime;
			if (mDicMimeTypesByExtension.TryGetValue(FixExtension(extension), out mime))
			{
				return mime;
			}
			else
			{
				return mDicMimeTypesByExtension["default"]; // default content type
			}
		}


	}
}