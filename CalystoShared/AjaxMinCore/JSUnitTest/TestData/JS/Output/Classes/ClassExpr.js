var base=class{construtor(n){this.arf=n}},derv=class extends base{constructor(n){super(n)}get Arf(){return this.arf}},noref=class extends derv{constructor(t){super(t*t)}},self=class n extends derv{constructor(t,i){super(t+i)}static Bat(r){alert(this.Arf+r);return r}DoIt(u){return n.Bar(u)}}