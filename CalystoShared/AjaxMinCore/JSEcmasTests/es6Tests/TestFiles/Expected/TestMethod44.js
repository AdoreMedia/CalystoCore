function Skip(n){return CalystoEnumerable.From(()=>function*(t){let i=-1;for(let r of t.AsIterableIterator()){if(++i<n){continue}else yield r}}(this))}