function foo(a){var b,d,c;if(a!==null){for(b=a*a,d=1,c=0;c<b;++c)d+=c;return d}}function bar(a,b){var d,c;if(a!==null&&b!==null){for(d=1,c=0;c<b;++c)d+=c;return d}}function ack(a,b,c){if(a===null||b===null)return"null"+c;var foo=a+b;c!=null&&(foo+=c);return foo}function ret(a,b){a&&a(b)}