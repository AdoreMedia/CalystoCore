function foo(bar,bell){var x="|"+bar+"-"+bell;/*@ function ieOnly(t){function acr(txt){return"IE: "+txt}return acr(t)}@*/return x+typeof ieOnly}var a="start";/*@cc_on@if(@_jscript_version<5.6)@*/function onlyIE(foo){alert(foo+" BAR!")}/*@end@*/