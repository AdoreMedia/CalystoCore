interface Blob
{
	name: string;

	filename: string;

	blobIndex: number;

	/**
	 * save blob to file
	 * @param {string} filename
	 */
	SaveFileAs(filename?: string): void;
}

if (typeof (Blob) != "undefined" && !Blob.prototype.SaveFileAs)
{
	Blob.prototype.SaveFileAs = function (filename)
	{
		/// <summary>
		/// Save blob as filename.
		/// </summary>
		/// <param name="filename" type="string" optional="true">if not set, will use blob.filename</param>

		var blob = this;

		// IE 10+ (native saveAs)
		if (navigator && (<any>navigator).msSaveOrOpenBlob)
		{
			(<any>navigator).msSaveOrOpenBlob(blob, filename || blob.filename);
		}
		else
		{
			var el = document.createElement("a");
			el.style.position = "absolute";
			el.style.opacity = "0";
			el.href = window.URL.createObjectURL(blob);
			el.download = filename || blob.filename;
			document.body.appendChild(el);
			el.click();
			if (el.parentNode)
			{
				el.parentNode.removeChild(el);
			}
		}
	};
}

