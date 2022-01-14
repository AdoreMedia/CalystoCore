namespace Calysto.Net.WebService
{
	export interface ICalystoProgressEvent
	{
		/**
			false: download progres<br/>
			true: upload progress
		 */
		IsUpload: boolean;

		/** is length computable */
		IsComputable: boolean;

		/** loaded bytes count */
		Loaded: number;

		/** total bytes length*/
		Total: number;

		/** Percent (0-100), Loaded/Total */
		Percent: number;
	}
}
