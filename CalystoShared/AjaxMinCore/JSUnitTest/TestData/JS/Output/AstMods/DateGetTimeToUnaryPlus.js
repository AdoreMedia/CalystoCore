function foo(){function Date(){}ticks=(new Date).getTime()}function bar(dt){var ack=new Date(dt).getTime(),gag=(new Date).getTime("foo"),loo=gag+(new Date).getTime()}var ticks=(new Date).getTime(),nextYear=new Date((new Date).getTime()+31536e6)