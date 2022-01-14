interface Date
{
	/** Gets the month, using local time. Warning: 0-11, January is 0 */
	getMonth(): number;

	/** Gets the month of a Date object using Universal Coordinated Time (UTC). Warning: 0-11, January is 0 */
	getUTCMonth(): number;

	/** Gets the day-of-the-month, using local time. (from 1-31)*/
	getDate(): number;

	/** Gets the day-of-the-month, using Universal Coordinated Time (UTC). (from 1-31). */
	getUTCDate(): number;

	/**
	* Gets the day of the week, using local time. (0-7)
	* 0 - Sunday
	* 1 - Monday
	* 2 - Tuesday
	* 3 - Wednesday
	* 4 - Thursday
	* 5 - Friday
	* 6 - Saturday
	*/
	getDay(): number;

	/** 
	* Gets the day of the week using Universal Coordinated Time (UTC). (0-7)
	* 0 - Sunday
	* 1 - Monday
	* 2 - Tuesday
	* 3 - Wednesday
	* 4 - Thursday
	* 5 - Friday
	* 6 - Saturday
	*/
	getUTCDay(): number;

	/** 
	* Gets the difference in minutes between the time on the local computer and Universal Coordinated Time (UTC).
	* For example, If your time zone is GMT+2, -120 will be returned.
	* Note: The returned value is not a constant, because of the practice of using Daylight Saving Time.
	* Tip: The Universal Coordinated Time (UTC) is the time set by the World Time Standard.
	* Note: UTC time is the same as GMT time.
	*/
	getTimezoneOffset(): number;

	/**
	  * Sets a date to a specified number of milliseconds after/before January 1, 1970
	  * @param time A numeric value representing the number of elapsed milliseconds since midnight, January 1, 1970 GMT.
	  */
	setTime(time: number): number;
}

