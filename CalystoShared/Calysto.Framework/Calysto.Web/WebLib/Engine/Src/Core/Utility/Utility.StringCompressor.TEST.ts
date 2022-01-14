//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var text = '{"OriginalFilename":"20.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"120.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"20.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"120.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"20.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"120.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}{"OriginalFilename":"20.mp4","GuidFilename":"f553f4ac-0fda-486a-d501-f23afe25fb33.mp4","CreationDate":{"__calystotype":"Calysto_Date","Date":"2016-02-08 12:43:45.512"},"Size":405758,"Duration":5.534,"Description":"ywert","Items":[{"Url":"http://cms.24sata.hr/api/video-upload/get-media-id/","PostData":{"filename":"20.mp4","description":"ywert"},"ResponseXml":null,"Command":1,"FileID":null,"Extension":".mp4","Message":"The remote server returned an error: (403) Forbidden.","Path":null}],"FtpUploaders":[]}';

	var c = new Calysto.Utility.StringCompressor();

	var compr = c.Compress(text);
	if (compr == text)
	{
		throw new Error("StringCompressor selftest error, compressed result: " + compr);
	}

	var decompr = c.Decompress(compr);
	if (decompr != text)
	{
		throw new Error("StringCompressor selftest error, decompressed result: " + decompr);
	}

	console.log("StringCompressor test succesful");

});
//#endif
