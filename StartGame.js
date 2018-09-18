#pragma strict

//this script is for the main menu and handles both starting and quitting the game, this is what happens when a game over occurs
var isQuitButton = false;

function OnMouseEnter(){
	GetComponent.<Renderer>().material.color = Color.green;
}

function OnMouseExit(){
	GetComponent.<Renderer>().material.color = Color.white;
}

function OnMouseUp(){

	if(isQuitButton){
		Application.Quit();
	}
	else{
		Application.LoadLevel(1);
	}
}