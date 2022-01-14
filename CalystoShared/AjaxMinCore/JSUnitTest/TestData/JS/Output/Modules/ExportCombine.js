//! start my implicit module
function n(r,u){return r+u}export function mul(f,e){return f*e}function t(o){return mul(o,o)}function i(s,h){if(h==0)return 1;for(var c=1;--h;)c=mul(c,s);return c}export const pi=3.1415927,negOne=-1;export var accumulator=0,foo="bar";export{n as sum,t as square,i as pow};
//! end my implicit module
