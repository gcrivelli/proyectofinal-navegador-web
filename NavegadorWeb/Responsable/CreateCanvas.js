var desplazandoCanvas=false;
var desplazandoBorrar=false;
var modificarTexto=false;
var dibujandoDiv=false;
var dibujandoDiv2=false;
var width=200;
var size=20;
var line=8;
var inclinacion=0;
var color="#000000";
var x=null;
var y=null;
var divX1=null;
var divY1=null;
var divX2=null;
var divY2=null;
var opacity=0.5;
var i=0;
var text="";

setInterval("desplazar()",50);

document.addEventListener("mousemove",onMouseUpdate, false);
document.addEventListener("mouseenter",onMouseUpdate, false);
document.addEventListener("keypress",onKeyPress, false);
document.addEventListener("click",onClick, false);
document.addEventListener("scroll",onScroll, false);

function onMouseUpdate(e) {                                 
  x=e.pageX;
  y=e.pageY;
}

function onScroll() {
  if (dibujandoDiv||dibujandoDiv2) {
    window.scrollTo(0, 0);
  }
}

function onKeyPress(e) {                          
  if (modificarTexto) {
    if (String.fromCharCode(e.keyCode).match(/(\w|\s)/g)) {
      text+=String.fromCharCode(e.keyCode).match(/(\w|\s)/g);
    }
    redibujarCanvas();
  }
}

function onClick(e) {
  if (desplazandoCanvas==true) {
    desplazandoCanvas=false;
    modificarTexto=false;
    var canvas=document.getElementById("canvas"+i);
    canvas.style.display="block";
    text="";    
    width=200;
    size=20;
    line=8;
    inclinacion=0;
    color="#000000";
  }  
  if (desplazandoBorrar==true) {
    Array.from(document.getElementsByClassName("canvas")).forEach(
        function(element, index, array) {
          var top = element.getBoundingClientRect().top;
          var left = element.getBoundingClientRect().left;
          var width = element.width;
            if (e.pageX>left && (left+width)>e.pageX && e.pageY>top && (top+width)>e.pageY) {
              element.parentNode.removeChild(element);
            }
        }
    );
  }
  if (dibujandoDiv2) {
    divX2=e.pageX;
    divY2=e.pageY;
    if (divX2<divX1) {
      divX2=divX1;
      divX1=e.pageX;
    }
    if (divY2<divY1) {
      divY2=divY1;
      divY1=e.pageY;
    }
    var elements = document.getElementsByClassName("div");
    while(elements.length > 0){
        elements[0].parentNode.removeChild(elements[0]);
    }
    var div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:100%;height:"+divY1+"px;top:0px;left:0px;opacity:"+opacity+";"; 
    div.className="div";  
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:100%;height:100%;top:"+divY2+"px;left:0px;opacity:"+opacity+";";   
    div.className="div";  
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:"+divX1+"px;height:"+(divY2-divY1)+"px;top:"+divY1+"px;left:0px;opacity:"+opacity+";";   
    div.className="div";  
    div.id="asistime-div";
    div.dataset.opacity=opacity;
    div.dataset.x1=divX1;
    div.dataset.y1=divY1;
    div.dataset.x2=divX2;
    div.dataset.y2=divY2;
    div.dataset.color=color;
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:100%;height:"+(divY2-divY1)+"px;top:"+divY1+"px;left:"+divX2+"px;opacity:"+opacity+";";   
    div.className="div";  
    document.body.appendChild(div);
    dibujandoDiv=false;
    dibujandoDiv2=false;
    var recuadrar=document.getElementById("recuadrar");
    recuadrar.parentNode.removeChild(recuadrar);
  } else if (dibujandoDiv) { 
    color="#000000";
    divX1=e.pageX;
    divY1=e.pageY;
    var div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:100%;height:"+divY1+"px;top:0px;left:0px;opacity:"+opacity+";"; 
    div.className="div";  
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:"+color+";width:"+divX1+"px;height:100%;top:"+divY1+"px;left:0px;opacity:"+opacity+";";   
    div.className="div";     
    document.body.appendChild(div);
    dibujandoDiv2=true;  
  }
}

function desplazar() { 
  if (desplazandoCanvas) {
    var canvas=document.getElementById("canvas"+i);
    canvas.style.left=(x-(width/2))+"px";
    canvas.style.top=(y-(width/2))+"px";    
  }
  if (desplazandoBorrar) {
    var canvas=document.getElementById("borrar");
    canvas.style.left=(x-20)+"px";
    canvas.style.top=(y-20)+"px";    
  }
  if (dibujandoDiv) {
    var canvas=document.getElementById("recuadrar");
    canvas.style.left=(x-20)+"px";
    canvas.style.top=(y-20)+"px";    
  }
}

function init() {
  document.body.style["pointer-events"]="none";
}

function finishStep() {
    document.body.style["pointer-events"]="auto";
}

function initBorrar() { 
  if (desplazandoCanvas==true) { 
    var canvas=document.getElementById("canvas"+i);
    canvas.parentNode.removeChild(canvas);
    desplazandoCanvas=false; 
    i--;
  } 
  var canvas=document.createElement("canvas");    
  desplazandoBorrar=true;
  canvas.id="borrar";
  canvas.style.cssText="position: absolute; z-index: 9999;";  
  canvas.width=40;
  canvas.height=40;    
  document.body.appendChild(canvas);    

  var context=canvas.getContext("2d");
  context.font='30px FontAwesome';
  context.fillText('\uf12d',0,25);
}

function initBell() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=4;
  context.font='100px FontAwesome';
  context.fillText('\uf0f3',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initBan() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=5;
  context.font='100px FontAwesome';
  context.fillText('\uf05e',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initCheck() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=6;
  context.font='100px FontAwesome';
  context.fillText('\uf00c',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initComment() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=7;
  context.font='100px FontAwesome';
  context.fillText('\uf075',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initFrown() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=8;
  context.font='100px FontAwesome';
  context.fillText('\uf119',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initGrin() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=15;
  context.font='100px FontAwesome';
  context.fillText('\uf118',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initHandpaper() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=10;
  context.font='100px FontAwesome';
  context.fillText('\uf256',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initHandpoint() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=11;
  context.font='100px FontAwesome';
  context.fillText('\uf0a6',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initShopping() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=13;
  context.font='100px FontAwesome';
  context.fillText('\uf07a',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initThumbs() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=14;
  context.font='100px FontAwesome';
  context.fillText('\uf164',60,140);
  context.strokeStyle=color;
  context.stroke();
}

function initCuadrado() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=1;
  context.rect(0,0,width,width);
  context.strokeStyle=color;
  context.lineWidth=line;
  context.stroke();
}

function initCirculo() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=2;
  context.arc(width/2,width/2,(width-line)/2,0,2*Math.PI);
  context.strokeStyle=color;
  context.lineWidth=line;
  context.stroke();
}

function initTexto() { 
  modificarTexto=true;  
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  if (text.length>0) {
    width=20+(10*text.length);
  } else {
    width=20;
  }
  canvas.dataset.tipo=3;
  canvas.dataset.text=text;
  canvas.width=width;
  canvas.height=80;  
  context.font = size+"px Arial";
  context.fillStyle = color;
  context.fillText(text, 10, 40);
  context.rect(0,0,width,70);
  context.stroke();
  document.body.focus();
}

function initDiv() {

  if (desplazandoCanvas==true) { 
    var canvas=document.getElementById("canvas"+i);
    canvas.parentNode.removeChild(canvas);
    desplazandoCanvas=false; 
    i--;
  } else {
    var canvas=document.createElement("canvas");  
    i++;  
  }   
  if (desplazandoBorrar==true) {
    desplazandoBorrar=false; 
    var borrar=document.getElementById("borrar");
    borrar.parentNode.removeChild(borrar);
    desplazandoCanvas=false; 
  }
  canvas.id="recuadrar";
  canvas.style.cssText="position: absolute; z-index: 9999;";  
  canvas.width=40;
  canvas.height=40;    
  document.body.appendChild(canvas);    

  var context=canvas.getContext("2d");
  context.font='30px FontAwesome';
  context.fillText('\uf065',0,25);

  if (dibujandoDiv==false) {   
    window.scrollTo(0, 0);
    var elements = document.getElementsByClassName("div");
    while(elements.length > 0){
        elements[0].parentNode.removeChild(elements[0]);
    }
    dibujandoDiv=true;  
  }
}

function initCanvas() {
  if (desplazandoCanvas==true) { 
    var canvas=document.getElementById("canvas"+i);
    canvas.parentNode.removeChild(canvas);
    canvas=document.createElement("canvas");  
  } else {
    var canvas=document.createElement("canvas");  
    i++;  
  }
  if (desplazandoBorrar==true) {
    desplazandoBorrar=false; 
    var borrar=document.getElementById("borrar");
    borrar.parentNode.removeChild(borrar);
    desplazandoCanvas=false; 
  }
  desplazandoCanvas=true;
  canvas.id="canvas"+i;
  canvas.className="canvas";
  canvas.style.cssText="position: absolute; z-index: 9999;";  
  canvas.style.transform="rotate("+inclinacion+"deg)";
  canvas.width=width;
  canvas.height=width;    
  canvas.dataset.color=color;
  canvas.dataset.weight=line;
  canvas.dataset.inclinacion=inclinacion;
  document.body.appendChild(canvas);    
  desplazar();
  
}

function achicarCanvas() {
  if (desplazandoCanvas==true && width>30) {
    width-=30;
    redibujarCanvas();
  }
}

function achicarAngulo() {
  if (desplazandoCanvas==true) {
    inclinacion-=30;
    redibujarCanvas();
  }
}

function agrandarCanvas() {
  if (desplazandoCanvas==true) {
    width+=30;    
    redibujarCanvas();
  }
}

function agrandarAngulo() {
  if (desplazandoCanvas==true) {
    inclinacion+=30;
    redibujarCanvas();
  }
}

function achicarLine() {
  if (desplazandoCanvas==true && line>1) {
    line-=1;
    redibujarCanvas();
  }
}

function agrandarLine() {
  if (desplazandoCanvas==true) {
    line+=1;
    redibujarCanvas();
  }
}

function achicarLetra() {
  if (desplazandoCanvas==true && size>1) {
    size-=1;
    redibujarCanvas();
  }
}

function agrandarLetra() {
  if (desplazandoCanvas==true) {
    size+=1;
    redibujarCanvas();
  }
}

function achicarOpacity() {
  if (dibujandoDiv==true && opacity>0.1) {
    opacity-=0.1;
  }
}

function agrandarOpacity() {
  if (dibujandoDiv==true && opacity<1) {
    opacity+=0.1;
  }
}

function redibujarCanvas() {
  desplazandoCanvas=false;
  var canvas=document.getElementById("canvas"+i);
  var tipo=canvas.dataset.tipo;
  canvas.parentNode.removeChild(canvas);
  i--;
  initCanvas();

  if (tipo==1) {
    initCuadrado();
  }  
  if (tipo==2) {
    initCirculo();
  }  
  if (tipo==3) {
    initTexto();
  }  
  if (tipo==4) {
    initBell();
  }
  if (tipo==5) {
    initBan();
  }
  if (tipo==6) {
    initCheck();
  }
  if (tipo==7) {
    initComment();
  }
  if (tipo==8) {
    initFrown();
  }
  if (tipo==15) {
    initGrin();
  }
  if (tipo==10) {
    initHandpaper();
  }
  if (tipo==11) {
    initHandpoint();
  }
  if (tipo==13) {
    initShopping();
  }
  if (tipo==14) {
    initThumbs();
  }
}

function setColor(code) {
  if (desplazandoCanvas==true) {
    color=code;
    redibujarCanvas();    
  }
}