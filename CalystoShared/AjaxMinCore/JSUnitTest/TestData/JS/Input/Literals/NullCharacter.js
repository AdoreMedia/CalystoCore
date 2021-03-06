// the null character cannot be escaped as \x00 or \0 or \u0000. If it is, it becomes a null
// character in the string and browsers simply end the string there when you go to display it.
// but an actual '\0' character gets displayed as a \ufffd (replacement character). So keep it!
// The \x00 also behaves differently cross-browser, whereas the actual '\0' character pretty much 
// is always shown as a replacement character.
var msg = "Null character ==> <== Whoo!";
alert(msg);

// and don't combine strings with null characters in them, because we're
// going to want to maintain that null character. Escaped nulls are okay.
var foo = "null char" + "-null\u0000escape" + 42;

