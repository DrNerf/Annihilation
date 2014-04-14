#pragma strict

var character: CharacterController;
var stepHeight = 0.1;
var deltaStep = 0.3;
private var toggle = false;
 
function Start(){
    character = GetComponent(CharacterController);
}
 
function Update(){
    character.stepOffset = stepHeight + (toggle? 0 :  deltaStep);
    toggle = !toggle;
}