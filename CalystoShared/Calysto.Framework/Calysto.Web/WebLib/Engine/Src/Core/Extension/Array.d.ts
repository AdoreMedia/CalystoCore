interface Array<T>
{
    /**
      * Appends new elements to the end of an array, and returns the new length of the array.
	  * Note: Changes the original array.
      * @param items New elements of the Array.
      */
	push(...items: T[]): number;

	/**
      * Removes the last element from an array and returns it.
	  * Note: Changes the original array.
      */
	pop(): T | undefined;

	/**
      * Combines two or more arrays.
	  * Returns a copy of the joined arrays.
      * @param items Additional items to add to the end of array1.
      */
	concat(...items: T[][]): T[];

	/**
      * Combines two or more arrays.
	  * Returns a copy of the joined arrays.
      * @param items Additional items to add to the end of array1.
      */
	concat(...items: (T | T[])[]): T[];

	/**
      * Reverses the elements in an Array.
	  * Returns the same array.
	  * Note: Changes the original array.
      */
	reverse(): T[];

	/**
      * Removes the first element from an array and returns it.
	  * Note: Changes the original array.
      */
	shift(): T | undefined;

	/**
      * Returns a section of an array.
      * @param start The beginning of the specified portion of the array. (Included index)
      * @param end The end of the specified portion of the array. (Excluded index)
      */
	slice(start?: number, end?: number): T[];

	/**
      * Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
      * @param start The zero-based location in the array from which to start removing elements.
      */
	splice(start: number): T[];

    /**
      * Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
	  * Note: Changes the original array.
      * @param start The zero-based location in the array from which to start removing elements.
      * @param deleteCount The number of elements to remove.
      * @param items Elements to insert into the array in place of the deleted elements.
      */
	splice(start: number, deleteCount: number, ...items: T[]): T[];

    /**
      * Inserts new elements at the start of an array.
	  * Note: Changes the original array.
      * @param items  Elements to insert at the start of the Array.
      */
	unshift(...items: T[]): number;
}
