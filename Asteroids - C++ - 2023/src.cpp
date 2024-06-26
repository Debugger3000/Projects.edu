

/*
//FINAL PROJECT
*/
// Carter McCauley
//December 12th, 2023. 
//
//

#include <LiquidCrystal.h>

//Left
int button2Pin = 7;//declare butt2pin as port 7
//UP
int button1Pin = 8; // declare button1pin as port 8.
//Right
int button3Pin = 6;
//Down
int button4Pin = 9;



//SPACESHIP Characters. 2 Overall for 4 lanes...
//custom Spaceship Character 1
byte spaceShipTop[8] = {
  0b11110,
  0b00111,
  0b00111,
  0b11110,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};

//custom Spaceship Character 2
byte spaceShipBottom[8] = {
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b11110,
  0b00111,
  0b00111,
  0b11110
  
};


//2 Trail Characters.
//custom spaceship smoke trail TOP
byte spaceShipTrailTop[8] = {
  0b01111,
  0b00000,
  0b00000,
  0b01111,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};


//custom spaceship smoke trail bottom
byte spaceShipTrailBottom[8] = {
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b01111,
  0b00000,
  0b00000,
  0b01111
};



// 2 Asteroid Characters.
//Asteroid -- Custom character
byte asteroidTop[8] = {
  0b11011,
  0b10100,
  0b11111,
  0b01000,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};

//Asteroid2 -- Custom character
byte asteroidBottom[8] = {
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b11000,
  0b11111,
  0b10010,
  0b11011
};



//Asteroid Control Section..
//Control timing and separation of Asteroids.

//Global Variable keeping track of Asteroid Cycles.. 15-0, = 16 movement = 1 Cycle
//To control timing of Levels...
int astCycle = 0;

//Global link variable for ^^^.
int sequenceTime = 0;

//Game speed.
int astDelay = 500;

//
//Asteroid control switches...
//switch for asteroid movement. Control variation for finite level..
int ast1Control = 0;

//switch for asteroid movement. Control variation for finite level..
int ast2Control = 0;

//switch for asteroid movement. Control variation for finite level..
int ast3Control = 0;

//switch for asteroid movement. Control variation for finite level..
int ast4Control = 0;

int ast5Control = 0;

int ast6Control = 0;

int ast7Control = 0;

int ast8Control = 0;

int ast9Control = 0;

int ast10Control = 0;

int ast11Control = 0;

int ast12Control = 0;
//
//


//Main game Loop Variable
int gameCond = true;

//End of game menu control
int winStage = 0;

//for asteroid LCD print.
int welcome = 0;

//Round variable to control main menu + game loop.
int stage = 0;

//wave variable to control sequence control + main game loop functionality.
int wave = 0;

//Points for scoreboard
int points = 0;

//Points for All Time Best Score..
int highScore = 0;

//temp variable to hold shipx to count points
int shipXPoints = 1;


//Variable for ship position counter
//int shipPos = 0;//start position. 

//Initialise the Serial LCD.
LiquidCrystal lcd( 12,11,5,4,3,2); //These pin numbers are hard coded in on the serial backpack board.



void setup()
{
lcd.begin (16,2); //Initialize the LCD.
  
pinMode(button1Pin, INPUT); // set button1 to input.
pinMode(button2Pin, INPUT); // set button2 to input.
pinMode(button3Pin, INPUT);//set button3 to input.
pinMode(button4Pin, INPUT);//set button4 to input.

Serial.begin(9600);
  
  
//SpaceShip Characters
// create top ship byte
lcd.createChar(0, spaceShipTop);

//create bottom byte ship
lcd.createChar(1,spaceShipBottom);

  
//SpaceTrailCharacters
//create spaceship trail TOP
lcd.createChar(2,spaceShipTrailTop);

//create spaceship trail BOTTOM
lcd.createChar(3,spaceShipTrailBottom);
  
  
//Asteroid Characters
//create asteroid 
lcd.createChar(4,asteroidTop);
//create Second Asteroid
lcd.createChar(5,asteroidBottom);

}





//class for spaceShip object.
class SpaceShip {
  private:
  	
  	//Ships Y position. Default position
	int shipY = 0;

 	//ships Level status. 1 - 4. 1 of the 4 places it can be.
  	int shipPos = 0;
  
  	//ships X position.
	int shipX = 1;
	
  
  public:
  	// 0 - 15 columns
	// 2 rows.
  
  
  //call when game is restarted after win or loss.
  void shipReset(){
    //reset ship to default position
    shipY = 0;
    shipPos = 0;
    shipX = 1;
  }
  
  	//Move ship Y-axis.
	int moveShip(){
     
  		if(digitalRead(button4Pin) == HIGH){
    
    		shipPos++;
    
    	if(shipPos == 4){
     	    shipPos = 3;
    		}
  		}
  
  		if(digitalRead(button1Pin) == HIGH){
    
    		shipPos--;
    
    	if(shipPos == -1){
     		shipPos = 0;
    		}
    
  		}
      return shipPos;
  
	}
  
  //Function to move ship on X-axis, to increase score multiplier.
  int moveShipX(){
    
    //Move ship forward, to make game harder + increase score multiplier.
    if(digitalRead(button3Pin) == HIGH && shipX <= 7){
    
    	shipX++;
      	shipXPoints = shipX;
  	}
    //Move ship to the left, depending on boundary.
    if(digitalRead(button2Pin) == HIGH && shipX >= 2){
      shipX--;
      shipXPoints = shipX;
    
  	}
    
    return shipX;
  }
  
	//display function.
	void displayShip(){
 	
  		int tailX = shipX - 1;
  		int tailY = shipY;
  
  		//int shipByte = 0;
  	
    
    	lcd.clear();
  
  	//Ship in top spot
  	if(shipPos == 0){
    
    	//shipByte = 0;
    
    	lcd.setCursor(shipX, 0); //goto first column and first line (0,0)
		lcd.write(byte(0));  //Print at cursor Location
    	lcd.setCursor(tailX,0);
    	lcd.write(byte(2));
    
  	}
  
  	//ship in 2nd Down spot
  	if(shipPos == 1){
    
    	//shipByte = 1;
    
    	lcd.setCursor(shipX,0); //goto first column and first line (0,0)
		lcd.write(byte(1));  //Print at cursor Location
    	lcd.setCursor(tailX,0);
    	lcd.write(byte(3));
     
	  }
  
 	 //ship in 3rd Down spot
	  if(shipPos == 2){
    
  	  //shipByte = 0;
    
  	  lcd.setCursor(shipX,1); //goto first column and first line (0,0)
		lcd.write(byte(0));  //Print at cursor Location
  	  lcd.setCursor(tailX,1);
  	  lcd.write(byte(2));
    
  	}
  
  	 //ship in 4th Down spot
  	if(shipPos == 3){
    
  	  //shipByte = 1;
    
  	  lcd.setCursor(shipX,1); //goto first column and first line (0,0)
		lcd.write(byte(1));  //Print at cursor Location
  	  lcd.setCursor(tailX,1);
  	  lcd.write(byte(3));
    
 	 }
		//make asteroids faster once on wave 4
      
     delay(astDelay);
      
	}//end of function
 
};

//declare spaceShip object...
SpaceShip shipOb;




//Asteroid class to control asteroids.
//
class AsteroidMain{
  private:
  	
  	//Use constructor to set this for specific asteroid being created.
  	int astLevel;
  	//Organize asteroids by number.
  	int astNumber;
  
	// 1. control Asteroid X-axis movement. Main Axis...
	int astX = 16;
  
	
  	
  	//private function to add to points system. Inside here b/c needs astX info..
  void pointSystem(){
    
    if(shipXPoints == 1){
      points++;
    }
    if(shipXPoints == 2){
    	points = points + 2; 
    }
    if(shipXPoints == 3){
    	points = points + 3; 
    }
    if(shipXPoints == 4){
    	points = points + 4; 
    }
    if(shipXPoints == 5){
    	points = points + 5; 
    }
    if(shipXPoints == 6){
    	points = points + 6; 
    }
    if(shipXPoints == 7){
    	points = points + 7; 
    }
    if(shipXPoints == 8){
    	points = points + 8; 
    }
    
    
  }
  	
  
  public:
  
  	//Constructor to set asteroid Y-axis level.
  	//+ number the asteroids
  	AsteroidMain(int setLevel, int setNumber){
    	astLevel = setLevel;
    	astNumber = setNumber;
  	}
  
  //called to reset all astX values and close all their gates.
  void astReset(){
    //return this asteroids astX to default
    astX = 16;
    
    //switch all gates to 0.
    if(astNumber == 1){
          ast1Control = 0;
        }
        if(astNumber == 2){
          ast2Control = 0;
        }
        if(astNumber == 3){
          ast3Control = 0;
        }
        if(astNumber == 4){
          ast4Control = 0;
        }
        if(astNumber == 5){
          ast5Control = 0;
        }
        if(astNumber == 6){
          ast6Control = 0;
        }
        if(astNumber == 7){
          ast7Control = 0;
        }
        if(astNumber == 8){
          ast8Control = 0;
        }
        if(astNumber == 9){
          ast9Control = 0;
        }
        if(astNumber == 10){
          ast10Control = 0;
        }
        if(astNumber == 11){
          ast11Control = 0;
        }
        if(astNumber == 12){
          ast12Control = 0;
        }
    
  }
  
  
  	//asteroid move function.
  	int asteroidMove(){
      
      //move asteroid once leftwards when asteroid object calls 
      astX--;
      
    
      //reset asteroid to x = 16 (off lcd screen by one)
      if(astX == -1){
        
        //call point system to add to score, once asteroid gets off screen.
        pointSystem();
        //print points to let user know how they're doing, while playing.
        
        Serial.print("Points: ");
        Serial.println(points);
        Serial.println("");
        
        //reset astX once it reaches index -1.
        astX = 16;	
        
        //Check what asteroid object is calling, to deactivate their gate.
        if(astNumber == 1){
          ast1Control = 0;
        }
        if(astNumber == 2){
          ast2Control = 0;
        }
        if(astNumber == 3){
          ast3Control = 0;
        }
        if(astNumber == 4){
          ast4Control = 0;
        }
        if(astNumber == 5){
          ast5Control = 0;
        }
        if(astNumber == 6){
          ast6Control = 0;
        }
        if(astNumber == 7){
          ast7Control = 0;
        }
        if(astNumber == 8){
          ast8Control = 0;
        }
        if(astNumber == 9){
          ast9Control = 0;
        }
        if(astNumber == 10){
          ast10Control = 0;
        }
        if(astNumber == 11){
          ast11Control = 0;
        }
        if(astNumber == 12){
          ast12Control = 0;
        }
          
      }
  
  		
      return astX;
	}
  
  	//display asteroid Function.
  	//return level of asteroid specific to one calling function.
  	int asteroidDisplay(int ast){
  
    	//first asteroid
      if(ast == 0){
    	lcd.setCursor(astX,0);
  		lcd.write(byte(4));
        
      }
  
  		//second asteroid
  		//lcd.setCursor(astMoveX2,astMoveY2);
  		//lcd.write(byte(3));
      if(ast == 1){
        lcd.setCursor(astX,0);
  		lcd.write(byte(5));
        
      }
      
    	//third asteroid
      if(ast == 2){
        lcd.setCursor(astX,1);
  		lcd.write(byte(4));
        
      }
      
    	//fourth asteroid
      if(ast == 3){
        lcd.setCursor(astX,1);
  		lcd.write(byte(5));
        
      }
      	delay(50);
     	return astLevel;
  
	}
  
};

/////////////////////////
//Create Asteroid Objects
//12 in total for difficulty.
AsteroidMain asteroid01(0,1);
AsteroidMain asteroid02(1,2);
AsteroidMain asteroid03(2,3);
AsteroidMain asteroid04(3,4);

AsteroidMain asteroid05(0,5);
AsteroidMain asteroid06(1,6);
AsteroidMain asteroid07(2,7);
AsteroidMain asteroid08(3,8);

AsteroidMain asteroid09(0,9);
AsteroidMain asteroid10(1,10);
AsteroidMain asteroid11(2,11);
AsteroidMain asteroid12(3,12);
//////////////////////////



//////////////////////////
//Control sequence of asteroids waves... Level control.
//////////////////////////
void asteroidSeq(){
    //Keep track of cycle...
  	//one cycle = 17.
    
  	//debug help
  	//Serial.println(astCycle);
 	
  //Wave 1 
  
  	if(astCycle == 1){
    	ast1Control = 1;
    }
    if(astCycle == 7){
      ast2Control = 1;
    }
    
    if(astCycle == 10){
      ast3Control = 1;
    }
    
    if(astCycle == 13){
      ast4Control = 1;
      
    }
  	//Switch to next wave
  	if(astCycle == 29){
      
      //go to next wave
      wave++;
    }
  
  	//13+16=29. off 
  	//Stage 1 - second wave
  
  	if(astCycle == 29){
    	ast3Control = 1;
  	}
  	if(astCycle == 31){
   		ast4Control = 1; 
  	}
  	if(astCycle == 34){
   		ast2Control = 1; 
  	}
  	if(astCycle == 36){
  	  	ast1Control = 1;
  	}
  	//Switch to next wave
  	if(astCycle == 51){
  	  	//go to next wave
      	wave++;
      
  	}
  	
  	//37+16 = 53
  	//Stage 1 - Third wave
  
  	if(astCycle == 51){
    	ast2Control = 1;
    }
  	if(astCycle == 55){
    	ast1Control = 1;
    }
  	if(astCycle == 56){
    	ast3Control = 1;
    }
  	if(astCycle == 58){
      	ast4Control = 1;
    }
  	//Switch to next wave
    if(astCycle == 77){
    	//go to next wave
      	wave++;
    }
  
}//end of asteroid sequence function


void secondSeq(){
  
  
   	//Stage 2 - wave 4
  if(wave == 4){
  	if(astCycle == 77){
  		//astDelay = 450;
      	ast4Control = 1;
  	}
  	if(astCycle == 79){
    	ast1Control = 1;
    }
  	if(astCycle == 81){
    	ast2Control = 1;
    }
  	if(astCycle == 82){
    	ast3Control = 1;
    }
  	if(astCycle == 85){
    	ast8Control = 1;
    }
  	if(astCycle == 87){
    	ast7Control = 1;
    }
  	if(astCycle == 89){
    	ast6Control = 1;
    }
  	if(astCycle == 92){
    	ast5Control = 1;
    }
  	//Switch to next wave
  	if(astCycle == 105){
      	//go to next wave.
    	wave++;
    }
   
   }//end of wave 4
  	
  
  	//94 + 16 = 110
  	//stage 2 - wave 5
  	//limit other sections with stage if, to increase efficiency.
  if(wave == 5){
  	if(astCycle == 105){
    	ast1Control = 1;
    }
  	if(astCycle == 107){
    	ast2Control = 1;
    }
  	if(astCycle == 109){
    	ast3Control = 1;
    }
  	if(astCycle == 113){
    	ast4Control = 1;
    }
  	if(astCycle == 114){
    	ast7Control = 1;
    }
  	if(astCycle == 115){
    	ast6Control = 1;
    }
  	if(astCycle == 119){
    	ast5Control = 1;
    }
  	if(astCycle == 126){
    	ast3Control = 1;
      	//Go to next wave
      	//wave++;
    }
  	//Switch to next wave
  	if(astCycle == 144){
    	//go to next wave
      	wave++;
    }
    
  }
  
  	//stage 2 - wave 6
  if(wave == 6){
  	if(astCycle == 144){
    	ast4Control = 1;
    }
  	if(astCycle == 146){
    	ast6Control = 1;
    }
  	if(astCycle == 148){
    	ast7Control = 1;
    }
  	if(astCycle == 149){
    	ast8Control = 1;
    }
  	if(astCycle == 150){
    	ast5Control = 1;
    }
  	if(astCycle == 153){
    	ast1Control = 1;
    }
  	if(astCycle == 157){
    	ast3Control = 1;
    }
  	if(astCycle == 159){
    	ast2Control = 1;
    }
  	if(astCycle == 163){
    	ast6Control = 1;
    }
  	if(astCycle == 165){
    	ast4Control = 1;
    }
  	if(astCycle == 166){
    	ast7Control = 1;
    }
  	//Switch to next wave
  	if(astCycle == 184){
    	//go to next wave
      	wave++;
    }
  }
 
  
  
  
  
  
  
}



//sequence function for 2nd last wave
void lastSeq2(){
  
  	//stage 3 - wave 8
  
  	if(astCycle == 216){
    	ast12Control = 1;
    }
  	if(astCycle == 219){
    	ast10Control = 1;
    }
  	if(astCycle == 219){
    	ast11Control = 1;
    }
  	if(astCycle == 222){
    	ast9Control = 1;
    }
  	if(astCycle == 224){
    	ast2Control = 1;
    }
  	if(astCycle == 225){
    	ast3Control = 1;
    }
  	if(astCycle == 228){
    	ast4Control = 1;
    }
  	if(astCycle == 229){
    	ast7Control = 1;
    }
  	if(astCycle == 231){
    	ast1Control = 1;
    }
  	if(astCycle == 233){
    	ast6Control = 1;
    }
  	if(astCycle == 234){
    	ast8Control = 1;
    }
  	if(astCycle == 236){
    	ast5Control = 1;
    }
  	//Switch to next wave
  	if(astCycle == 254){
    	//go to next wave
      	wave++;
    }
  
  
  
  
}


//sequence function for 3rd last wave
void lastSeq(){
  
  	//stage 3 - wave 7
  	
  	if(astCycle == 184){
    	ast12Control = 1;
    }
  	if(astCycle == 186){
    	ast9Control = 1;
    }
  	if(astCycle == 187){
    	ast11Control = 1;
    }
  	if(astCycle == 189){
    	ast10Control = 1;
    }
  	
  	if(astCycle == 190){
    	ast4Control = 1;
    }
  	if(astCycle == 192){
    	ast1Control = 1;
    }
  	if(astCycle == 193){
    	ast2Control = 1;
    }
  	if(astCycle == 193){
    	ast3Control = 1;
    }
  	if(astCycle == 196){
    	ast6Control = 1;
    }
  	if(astCycle == 196){
    	ast8Control = 1;
    }
  	if(astCycle == 198){
    	ast5Control = 1;
    }
  	//Switch to next wave
  	if(astCycle == 216){
    	//go to next wave
      	wave++;
    }
  
}


//sequence function for last wave
void lastSeq3(){
  
  	//stage 3 - wave 9
  	if(astCycle == 254){
    	ast11Control = 1;
    }
  	if(astCycle == 255){
    	ast10Control = 1;
    }
  	if(astCycle == 257){
    	ast9Control = 1;
    }
  	if(astCycle == 257){
    	ast3Control = 1;
    }
  	if(astCycle == 261){
    	ast12Control = 1;
    }
  	if(astCycle == 263){
    	ast2Control = 1;
    }
  	if(astCycle == 264){
    	ast7Control = 1;
    }
  	if(astCycle == 265){
    	ast1Control = 1;
    }
  	if(astCycle == 268){
    	ast4Control = 1;
    }
  	if(astCycle == 267){
    	ast6Control = 1;
    }
  	if(astCycle == 268){
    	ast8Control = 1;
    }
  	if(astCycle == 269){
    	ast5Control = 1;
    }
  	//Switch to next wave
  	if(astCycle == 290){
    	//go to next wave
      	wave++;
    }
}

//////////////////////////

//////////////////////////
//Function to check if any collisions occur.                 
bool collisionCheck(int astX, int shipX, int shipPos, int astPos){
  
  //check if select asteroid hits the ships position.
  if((astX == shipX || astX == shipX-1) && (shipPos - astPos) == 0){
    //Game over
    return false;
    
  }
  else{
    //continue game
    return true; 
  }
  
	return true;
}

//////////////////////////

//////////////////////////

//main game loop
void loop(){
 
  //comparer variables to send to collisionCheck().
  int astXcomp = 0;
  int shipXcomp = 0;
  int shipPoscomp = 0;
  int astPoscomp = 0;
  
  
  //RESET SEQUENCE
  if(stage > 0){
    
    //Accessing class to change everything to default..
    shipOb.shipReset();
    asteroid01.astReset();
    asteroid02.astReset();
    asteroid03.astReset();
    asteroid04.astReset();
    
    asteroid05.astReset();
    asteroid06.astReset();
    asteroid07.astReset();
    asteroid08.astReset();
    
    asteroid09.astReset();
    asteroid10.astReset();
    asteroid11.astReset();
    asteroid12.astReset();
  }
  

  //set these if player wants to restart game within SIM.
  //astCycle = 0;
  astCycle = 0;
  
  
  //if first play. Send player to main menu...
  if(stage == 0){
    Serial.println("-------");
    Serial.println("");
    Serial.println("Hello ! Welcome to Asteroids !");
    Serial.println("");
    Serial.println("You play by moving the ship with the buttons above the LCD Screen");
    Serial.println("");
    Serial.println("You gather more points if you move your ship closer to the asteroids !");
    Serial.println("");
    Serial.println("Have fun !");
    Serial.println("");
    Serial.println("-------");
    Serial.println("");
    
    
  	wave = 0;
  }
  
  
  //Welcome Menu
  while(wave == 0){
    
    //display once...
    if(welcome == 0){
        lcd.clear();
		lcd.setCursor(3,0); //goto first column and first line (0,0)
		lcd.print("Welcome to");
      	lcd.setCursor(3,1);
      	lcd.print("Asteroidss");
    	lcd.setCursor(1,1);
    	lcd.write(byte(5));
    
    	lcd.setCursor(14,1);
    	lcd.write(byte(5));
    	delay(3000);//delay
      	welcome++;
    }
    
    	if(digitalRead(button2Pin) == HIGH){
          wave = 1; 
        }	
    
    	lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("INFO @ SM->");
    	delay(2000);
    
    	if(digitalRead(button2Pin) == HIGH){
          wave = 1; 
        }
    
    	lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Hold Left to");
    	lcd.setCursor(0,1); //goto first column and first line (0,0)
		lcd.print("Play Asteroids!");
    	delay(1500);
    
    	if(digitalRead(button2Pin) == HIGH){
          wave = 1; 
        }
  }
  
 
  //main game WHILE loop. all movement and class interaction within here.
  while(gameCond == true){
    
  	//
  	//Main Code.
  	//
  	//  
    
    //Run global sequencing events. Change functions as waves increase. Efficiency...
    if(wave > 0 && wave < 4){
    	asteroidSeq();
    }
    if(wave > 3 && wave < 7){
      secondSeq();
    }
    if(wave == 7){
      lastSeq();
    }
    if(wave == 8){
      lastSeq2();
    }
    if(wave == 9){
      lastSeq3();
    }
    
    //update time
    astCycle++;
    
    //break game loop is end of game is reached...
    if(wave == 10){
      break;
    }
    
  	//Move the ship
  	shipPoscomp = shipOb.moveShip();
  	shipXcomp = shipOb.moveShipX();
  	//Display Spaceship method within class.
  	shipOb.displayShip();
    
    
    
    
  //If selectors to specify rounds of choice.
    if(wave > 0){
      
      
      if(ast1Control == 1){
    	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid01.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid01.asteroidDisplay(0);
        
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
  
    	if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      if(ast2Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 2
  		astXcomp = asteroid02.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid02.asteroidDisplay(1);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
        
      
      
      if(ast3Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid03.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid03.asteroidDisplay(2);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
        
      
      
      
      if(ast4Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid04.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid04.asteroidDisplay(3);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
        
      }
    }//end of stage 1
    
    //stage 2 control efficiency
    if(wave > 3){
      if(ast5Control == 1){
    	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid05.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid05.asteroidDisplay(0);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
  
    	if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
       
      
      if(ast6Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 2
  		astXcomp = asteroid06.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid06.asteroidDisplay(1);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      
      if(ast7Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid07.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid07.asteroidDisplay(2);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      if(ast8Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid08.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid08.asteroidDisplay(3);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
        
      }
      
    }//end of stage 2
      
     
    if(wave > 6 && wave < 10){
      if(ast9Control == 1){
    	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid09.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid09.asteroidDisplay(0);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
  
    	if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      if(ast10Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 2
  		astXcomp = asteroid10.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid10.asteroidDisplay(1);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      if(ast11Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid11.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid11.asteroidDisplay(2);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
      
      
      if(ast12Control == 1){
      	//Move each asteroid in sequence. Then display it.
  		//Move Asteroid 1
  		astXcomp = asteroid12.asteroidMove();
  		//Display Asteroid
  		astPoscomp = asteroid12.asteroidDisplay(3);
  
  		gameCond = collisionCheck(astXcomp,shipXcomp,shipPoscomp,astPoscomp);
       
        if(gameCond == false){
      	//break out of main game loop
      	break;
    	}
      }
       
      
    }//end of stage 3
       
    delay(250);
    
  }//End of the while
  
  
  //Game won menu. Display scores...
  if(wave == 10){
    
    while(wave == 10){
      
      //stage 1 of win stage
      if(winStage == 0){
      	
        //Get highscore 
        if(points > highScore){
        	highScore = points; 
        }
        
      	lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Congratulations!");
      	lcd.setCursor(0,1);
      	lcd.print("You have Won!");
    	delay(2500);//delay
        winStage++;
      }
      
      if(winStage == 1){
        
        if(digitalRead(button2Pin) == HIGH){
        	wave = 1;  
          	winStage = 0;
          	stage = 1;	
          	points = 0;
        }
        
        //print score on LCD
        lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Your Score is:");
      	lcd.setCursor(0,1);
      	lcd.print(points);
    	delay(3000);//delay
        
        if(digitalRead(button2Pin) == HIGH){
        	wave = 1;  
          	winStage = 0;
          	stage = 1;
          	points = 0;
        }
        
        //print highscore on LCD
        lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("HighScore:");
      	lcd.setCursor(0,1);
      	lcd.print(highScore);
    	delay(3000);//delay
        
        if(digitalRead(button2Pin) == HIGH){
            wave = 1;
          	winStage = 0;
          	stage = 1;
          	points = 0;
        }
        
        //print instructions on LCD
        lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Hold Left");
      	lcd.setCursor(0,1);
      	lcd.print("To play again");
    	delay(1000);//delay 
      }
      
      
    }
    
    
  }//end of if statement for wave 10 WIN
  
  //when game is lost
  while(gameCond == false){
    
    if(winStage == 0){
      	delay(25);
      	//Get highscore 
        if(points > highScore){
        	highScore = points; 
        }	
      	//print on LCD
    	lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("You hit... an");
      	lcd.setCursor(0,1); //goto first column and first line (0,0)
		lcd.print("Asteroid");
      	lcd.setCursor(9,1);
    	lcd.write(byte(5));
      	lcd.setCursor(11,1);
    	lcd.write(byte(4));
    	delay(3000);//delay
      
      	//print on LCD
      	lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Hold Left");
      	lcd.setCursor(0,1);
      	lcd.print("To play again");
    	delay(2000);//delay
      	winStage++;
    }
    
    
    
    if(winStage == 1){
      
      	if(digitalRead(button2Pin) == HIGH){
            wave = 1;
          	winStage = 0;
          	stage = 1;
          	gameCond = true;
          	points = 0;
          
        }
     
      	//print score on LCD
		lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("Your Score is:");
      	lcd.setCursor(0,1);
      	lcd.print(points);
    	delay(2500);//delay      
      
      	//print highscore on LCD
        lcd.clear();
		lcd.setCursor(0,0); //goto first column and first line (0,0)
		lcd.print("HighScore:");
      	lcd.setCursor(11,0);
      	lcd.print(highScore);
    	delay(2500);//delay
      	
      	if(digitalRead(button2Pin) == HIGH){
            wave = 1;
          	winStage = 0;
          	stage = 1;
          	gameCond = true;
          	points = 0;
          	
        }
    }
     
  }//end of LOSS while loop.

}//end of main loop.               
//end of code...










