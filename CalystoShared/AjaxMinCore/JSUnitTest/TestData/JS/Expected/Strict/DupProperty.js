"use strict";function test1(){return{one:1,two:2,one:1}}function test2(){return{one:1,get myget(){return!0},two:2,get myget(){return!1}}}function test3(){var bar=42;return{one:1,set myset(v){bar=v},two:2,set myset(v){bar=2*v}}}function test4(){var ack=42;return{it:1,get it(){return ack},set it(v){ack=v}}}function test5(){return{get it(){return!0},it:1}}function test6(){var k;return{set it(v){k=v},it:1}}function testOK(){var foo=0;return{one:1,two:2,get my(){return foo},set my(v){foo=v}}}