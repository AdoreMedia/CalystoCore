function print(s){document.write(s)}try{print("Outer try running..");try{print("Nested try running...");throw"an error"}catch(e){print("Nested catch caught "+e);throw e+" re-thrown"}finally{print("Nested finally is running...")}}catch(e){print("Outer catch caught "+e)}finally{print("Outer finally running")}try{}finally{alert()}try{a=10/0}catch(e){}try{}catch(e){}finally{alert()}try{}catch(e){}try{}finally{}