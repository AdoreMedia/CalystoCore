function test1(){var n=10;(function n(e){--e>0&&n(e)})(10);alert(n);var i=function(){};(function r(o){--o>0&&r(o)})(10);var u=function(){};u.bar=10;var t=function t(){t()};t.bar=11;return i()}var foo=function(){};foo=function global_one_self_ref(n){--n>0&&global_one_self_ref(n)};var ack=function(){};ack.bar=function(){return ack[12]};var trap=function trap(){trap()};trap.bar=13;function test1(){var n,t=function(){}}function test2(){var t=function n(){alert(n)},n}function test3(){var t=function n(){alert(n)},i=function(){},r=function(){}}function test4(){var n=function(){},t=function(){},i=function(){},r}function test5(){var n=function(){}}