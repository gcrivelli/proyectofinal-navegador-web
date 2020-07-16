var desplazandoCanvas=false;
var modificarTexto=false;
var width=200;
var line=1;
var color=null;
var x=null;
var y=null;
var i=0;
var text="|";
window.onclick=dibujar;

setInterval("desplazarCanvas()",300);

document.addEventListener("mousemove",onMouseUpdate, false);
document.addEventListener("mouseenter",onMouseUpdate, false);
document.addEventListener("keypress",onKeyPress, false);

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

function dibujar() {
  desplazandoCanvas=false;
  modificarTexto=false;
  var canvas=document.getElementById("canvas"+i);
  canvas.style.display="block";
  text="|";
}

function desplazarCanvas() { 
  if (desplazandoCanvas) {
    var canvas=document.getElementById("canvas"+i);
    canvas.style.left=(x-(width/2))+"px";
    canvas.style.top=(y-(width/2))+"px";    
  }
  if (modificarTexto) {
    if (canvas.style.display==="none") {
      canvas.style.display="block";
    } else {
      canvas.style.display="none";
    }    
  }
}

function init() {
  document.body.style["pointer-events"]="none";
}

function finishStep() {
    document.body.style["pointer-events"]="auto";
}

function initCuadrado() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=1;
  context.rect(0,0,width,width);
  context.strokeStyle="#"+color;
  context.lineWidth=line;
  context.stroke();
  
}

function initCirculo() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=2;
  context.arc((width-2)/2,(width-2)/2,(width-2)/2,0,2*Math.PI);
  context.strokeStyle="#"+color;
  context.lineWidth=line;
  context.stroke();
}

function initTexto() { 
  modificarTexto=true;  
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  width=500;
  canvas.dataset.tipo=3;
  context.font = "20px Arial";
  context.fillText(text, width/2, width/2);
  context.strokeStyle = "#"+color;
  context.lineWidth = line;
  context.stroke();
  document.body.focus();
}

function initEmoji() { 
  var canvas=document.getElementById("canvas"+i);
  var context=canvas.getContext("2d");
  canvas.dataset.tipo=4;
  
  context.beginPath();
  context.moveTo(75/200*width,25/200*width);
  context.quadraticCurveTo(25/200*width,25/200*width,25/200*width,62.5/200*width);
  context.quadraticCurveTo(25/200*width,100/200*width,50/200*width,100/200*width);
  context.quadraticCurveTo(50/200*width,120/200*width,30/200*width,125/200*width);
  context.quadraticCurveTo(60/200*width,120/200*width,65/200*width,100/200*width);
  context.quadraticCurveTo(125/200*width,100/200*width,125/200*width,62.5/200*width);
  context.quadraticCurveTo(125/200*width,25/200*width,75/200*width,25/200*width);
  context.strokeStyle = "#"+color;
  context.lineWidth = line;
  context.stroke();
}

function initCanvas() {
  if (desplazandoCanvas==false) {
    desplazandoCanvas=true;
    i++;
    var canvas=document.createElement("canvas");
    canvas.id="canvas"+i;
    canvas.className="canvas";
    canvas.style.cssText="position: absolute; z-index: 9999;";
    canvas.width=width;
    canvas.height=width;    
    canvas.dataset.color=color;
    canvas.dataset.weight=line;
    document.body.appendChild(canvas);    
    desplazarCanvas();
  }
}

function achicarCanvas() {
  if (desplazandoCanvas==true && width>30) {
    width-=30;
    redibujarCanvas();
  }
}

function agrandarCanvas() {
  if (desplazandoCanvas==true) {
    width+=30;
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
    initEmoji();
  }
}

function setColor(code) {
  if (desplazandoCanvas==true) {
    color=code;
    redibujarCanvas();
  }  
}