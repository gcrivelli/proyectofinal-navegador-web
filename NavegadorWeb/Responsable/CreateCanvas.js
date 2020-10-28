﻿var desplazandoCanvas=false;
var desplazandoBorrar=false;
var modificarTexto=false;
var dibujandoDiv=false;
var dibujandoDiv2=false;
var width=200;
var size=20;
var line=8;
var inclinacion=0;
var color="000000";
var x=null;
var y=null;
var divX1=null;
var divY1=null;
var divX2=null;
var divY2=null;
var opacity=0.5;
var i=0;
var text="|";

setInterval("desplazar()",50);

document.addEventListener("mousemove",onMouseUpdate, false);
document.addEventListener("mouseenter",onMouseUpdate, false);
document.addEventListener("keypress",onKeyPress, false);
document.addEventListener("click",onClick, false);

function onMouseUpdate(e) {                                 
  x=e.pageX;
  y=e.pageY;
}

function onKeyPress(e) {                          
  if (modificarTexto) {
    if (String.fromCharCode(e.keyCode).match(/(\w|\s)/g)) {
      if (text=="|") {
        text="";
      }
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
    text="|";    
    width=200;
    size=20;
    line=8;
    inclinacion=0;
    color="000000";
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
    var div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:#"+color+";width:100%;height:"+divY1+"px;top:0px;left:0px;opacity:"+opacity+";"; 
    div.className="div";  
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:#"+color+";width:100%;height:100%;top:"+divY2+"px;left:0px;opacity:"+opacity+";";   
    div.className="div";  
    document.body.appendChild(div);
    div=document.createElement("div");
    div.style.cssText="position:absolute;z-index:9999;background-color:#"+color+";width:"+divX1+"px;height:"+(divY2-divY1)+"px;top:"+divY1+"px;left:0px;opacity:"+opacity+";";   
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
    div.style.cssText="position:absolute;z-index:9999;background-color:#"+color+";width:100%;height:"+(divY2-divY1)+"px;top:"+divY1+"px;left:"+divX2+"px;opacity:"+opacity+";";   
    div.className="div";  
    document.body.appendChild(div);
    dibujandoDiv=false;
    dibujandoDiv2=false;
  } else if (dibujandoDiv) {
    divX1=e.pageX;
    divY1=e.pageY;
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

function initFlecha() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=4;
  context.font=width+'px FontAwesome';
  context.fillText('\uf062',0,width-(width/5));
  context.strokeStyle=color;
  context.stroke();
}

function initBan() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=5;
  context.font=width+'px FontAwesome';
  context.fillText('\uf05e',0,width-(width/5));
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
  width=500;
  canvas.dataset.tipo=3;
  canvas.dataset.text=text;
  context.font = size+"px Arial";
  context.fillStyle = color;
  context.fillText(text, width/2, width/2);
  context.lineWidth = line;
  context.stroke();
  document.body.focus();
}

function initDiv() {
  if (dibujandoDiv==false) {    
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
    initFlecha();
  }
  if (tipo==5) {
    initBan();
  }
}

function setColor(code) {
  if (desplazandoCanvas==true) {
    color=code;
    redibujarCanvas();    
  }
}