


//Blackjack in PHP
//Omits rules of splitting...


<?php

//Create deck
//$deck = array();
//$deck2 = array();

//$cardsLeft = 52;

//Welcome menu
function startMenu(){

    echo "Welcome to Blackjack !\n";
    echo "\nThis is you versus me, Jack Blades, the Dealer...";
    echo "\nNow Who am I facing tonight...";

}


//Fill deck with 52 values from 2 - 11
function deckFiller(){

    $a1 = array();

    //Fill our original deck with 52 values..
    //Not using suite as it does not matter..
    array_push($a1,"Ace","Ace","Ace","Ace");
    array_push($a1,2,2,2,2);
    array_push($a1,3,3,3,3);
    array_push($a1,4,4,4,4);
    array_push($a1,5,5,5,5);
    array_push($a1,6,6,6,6);
    array_push($a1,7,7,7,7);
    array_push($a1,8,8,8,8);
    array_push($a1,9,9,9,9);
    array_push($a1,10,10,10,10);
    array_push($a1,"Jack","Jack","Jack","Jack");
    array_push($a1,"Queen","Queen","Queen","Queen");
    array_push($a1,"King","King","King","King");

    return $a1;
}





//push card value pulled up into counter array
//array_push($a, $deck);


// $value = $deck[$randSelect];
// echo $value;

// array_push($deck2, $value);
// array_splice($deck,$randSelect,1);


//Player Class
//Store player money amount.
class Player{

    //
    private $name;
    //chips in dollar amount
    private $chips;

    //wager in dollar amount
    private $wager;



    
    //construct player object with a name and initial chips in dollars...
    function __construct($name,$chips)
    {
        $this ->name = $name;
        $this ->chips = $chips;
    }



    function dealerBusts(){

        //return double wager to player...
        //increase total pot of chips by wager amount
        $this->chips = $this->chips + $this->wager*2;

        //Tell player their wager won, and new total pot.
        echo "\n\nTHE DEALER BUSTS! YOU WIN DOUBLE YOUR WAGER";
        echo "\nYou have won: ";
        echo $this->wager*2;
        echo "\nYour total pot is now: ";
        echo $this->chips;

    }

    //Deal with return of 0, 1 or 2 for win condition.
    //Call win, loss or tie functions
    function endComp($winCond){

        $retVal = true;

        if($winCond == 0){
            if(!$this->blackJackLoss()){
                $retVal = false;
            }
            
        }
        elseif($winCond == 1){
            $this->playerWin();
        }
        else{
            $this->gameTie();
        }

        return $retVal;
    }

    //tied game, no money is lost.
    function gameTie(){
        //game is tied..
        echo "ITS A TIE !!!\n";
        echo "You have won: 0";
        echo "\nYour total pot is: ";
        echo $this->chips;
    }

    //player wins
    function playerWin(){
        //increase total pot of chips by wager amount
        $this->setMoney(1);

        echo "\nYOU WON!";
        //Tell player their wager won, and new total pot.
        echo "\nYou have won: ";
        echo $this->wager;
        echo "\nYour total pot is now: ";
        echo $this->chips;
    }

    //player loses
    //subtract wager and see if they have enough to play again..
    function blackJackLoss(){
        //return request
        $request = true;

        //reduce total chips/pot by wager amount
        $this->setMoney(-1);

        //display text
        echo "\nThe dealer won this hand.....";
        echo "\nYou lost:";
        echo $this->wager;

        echo "\nYour total pot is now: ";
        echo $this->chips;
        
        //if user has no money left then they cant play again
        if($this->chips == 0){
            echo "\n\nYou are out of chips... Get outta here....";
            $request = false;
        }
        elseif($this->chips < 0){
            echo "\n\nYou owe us money... You have two weeks to pay up...";
            $request =  false;
        }

        
        
        
        return $request;
    }


    //player decision functions
    function playDecision(){

        //return value
        $returnVal = 0;
        

        echo "\nIts your turn.";
        echo "\n\nSTAY - Enter 0";
        echo "\nHIT - Enter 1";
        echo "\nDouble Down - Enter 2.";

        //while control
        $loopCon = true;
        while($loopCon){

            //take user input
            $playerInput = readline("\n\nPlease enter 0, 1 or 2: ");
            
            //if correct input then flip switch for 
            if($playerInput == 1 || $playerInput == 0 || $playerInput == 2){
                $loopCon = false;
            }
        
        }
        
        // STAY - player can stay 
        if($playerInput == 0){
            //return for dealer to do soemthing
            $returnVal = 0;
        }
        
        // HIT - player gets one more card
        if($playerInput == 1){

            $returnVal = 1;
        }

        // DOUBLE DOWN - player can double wager and draw ONE more card only
        elseif($playerInput == 2){
            $returnVal = 2;
        }

        return $returnVal;
    }

    //win or loss calculate new difference in player chips/dollars
    // WIN - $state = 1
    // LOSS - $state = -1
    function setMoney($state){
        
        if($state == 1){
            $this->chips = $this->chips + $this->wager;
        }
        else{
            $this->chips = $this->chips - $this->wager;
        }
    }

    //return players chips
    //Use after win or loss to check if player is above 0 dollars. If they are they can play again.
    function getMoney(){
        return $this->chips;
    }

    function getWager(){
        return $this->wager;
    }

    //set initial wager before game starts.
    //amount of dollars their bet is
    function wager(){

        //validate wager amount here. Make sure it is at least a quarter of chips.
        $amount = readline("How much are you betting this round?");
        //control input
        $loopControl = true;
        while($loopControl){

            if((($this->chips * 0.25) <= $amount) && $amount <= $this->chips){
                $loopControl = false;
            }

            //
            if($loopControl == true){
                $amount = readline("Your bet needs to be at least a quarter of your chips: ");
            }
        }
        //set wager to amount inputted.
        $this->wager = $amount;
        //subtract wager from pot
        
    }

    //change wager if player wants to bet more
    //1.5, increase by 50%
    //2.0, increase by 100%...
    function wagerMultiply($multiplier){
        $this->wager = $this->wager * $multiplier;

    }



}



//Dealer Class
//Store both arrays, deal with rand card draw, and deck switch
//deals with player and dealers hands.
class Dealer{

    //Two decks to control randomness
    private $deck1 = array();
    private $deck2 = array();

    //dealers hand
    private $hand = array();
    //players hand
    private $playersHand = array();

    //start at 52. Once 0 switch decks and grab from that deck.
    private $deckCount = 52;

    //start on deck 1, switch to deck 2 once deck 1 has all values drawn from it
    private $deckSwitch = 1;

    //object only created with no arguments given.
    //Therefore fill deck with 52 values of cards on instance creation.
    function __construct()
    {
    array_push($this->deck1,"Ace","Ace","Ace","Ace");
    array_push($this->deck1,2,2,2,2);
    array_push($this->deck1,3,3,3,3);
    array_push($this->deck1,4,4,4,4);
    array_push($this->deck1,5,5,5,5);
    array_push($this->deck1,6,6,6,6);
    array_push($this->deck1,7,7,7,7);
    array_push($this->deck1,8,8,8,8);
    array_push($this->deck1,9,9,9,9);
    array_push($this->deck1,10,10,10,10);
    array_push($this->deck1,"Jack","Jack","Jack","Jack");
    array_push($this->deck1,"Queen","Queen","Queen","Queen");
    array_push($this->deck1,"King","King","King","King");
    }


    //Reset hands to have zero cards...
    function resetHands(){

        //reset players hand. 
        array_splice($this->playersHand, 0, 10);

        //reset dealers hand
        array_splice($this->hand, 0, 10);



    }

    //Final comparison...
    // Compare dealer and players hands
    function finalComp(){

        //return var. default dealer wins when 0 is returned..
        // PLAYER WIN - return 1
        // TIE - return 2
        $retVal = 0;

        //Get dealers total
        $dealersHand = $this->countHand(0);
        //Get players total
        $playersHand = $this->countHand(1);

        if($playersHand > $dealersHand){
            $retVal = 1;
        }
        elseif($playersHand == $dealersHand){
            $retVal = 2;
        }
        //return value for who won...
        return $retVal;
    }


        //dealers turn, draw until they are 17 or higher...
    function dealersTurn(){

        $retVal = true;

        //count dealers hand
        $total = $this->countHand(0);

        //while total is less than 16, draw cards
        while($total < 17){
            //draw a card for dealer
            $this->getRandomCard(0);

            //count dealers hand
            $total = $this->countHand(0);

        }

        //check if over 21
        if(!$this->checkTotal($total)){
            //return false if over 21, and player wins...
            $retVal = false;
        }

        return $retVal;

    }





    //function to count a hand of cards and return the total value.
    //Considering ace logic, if 11 is over 21 then it will be one.
    function countHand($type){
        $total = 0;

        //Count dealers hand
        if($type == 0){

            for($i = 0; $i < count($this->hand); $i++){

                $curCard = $this->hand[$i];
                //use face converter to get back INT value
                $temp2 = $this->faceConverter($curCard,$this->hand,$i);
                //add to total
                $total = $total + $temp2;

            }

        }
        //count players hand
        else{

            for($i = 0; $i < count($this->playersHand); $i++){

                $curCard = $this->playersHand[$i];
                //use face converter to get back INT value
                $temp3 = $this->faceConverter($curCard,$this->playersHand,$i);
                //add to total
                $total = $total + $temp3;

            }
        }

        

        return $total;
    }

    
    //

    



    //Check if ace can be 11. If total is greater than 21 then it has to be 1.
    function aceLogic($deck,$index){
        $value = 11;
        $deckTotal = 0;

        for ($i = 0; $i<count($deck); $i++){

            if($i == $index){
                $deckTotal = $deckTotal + 11;
            }
            else{
                $deckTotal = $deckTotal + $this->faceConverterAce($deck[$i]);
            }
        }
        //if over 21 then it has to be 1.
        if($deckTotal > 21){
            $value = 1;
        }

        return $value;
    }


    //face converter for ace logic function
    function faceConverterAce($card){

        $cardInt = $card;
        if($card == "Jack"){
            $cardInt = 10;
        }
        elseif($card == "Queen"){
            $cardInt = 10;
        }
        elseif($card == "King"){
            $cardInt = 10;
        }


        return $cardInt;
    }


    //call when grabbing values from hand to always get an integer value.
    //If card value is a face or ace, it will deal with the logic and return INT value.
    function faceConverter($card,$deck,$index){
        $cardInt = $card;

        if($card == "Jack"){
            $cardInt = 10;
        }
        elseif($card == "Queen"){
            $cardInt = 10;
        }
        elseif($card == "King"){
            $cardInt = 10;
        }
        
        elseif($card == "Ace"){

            $cardInt = $this->aceLogic($deck,$index);
        }

        return $cardInt;
    }


    //Display dealer and players cards
    function displayHands($display){

        //Dealer's hand title.
        echo "\nDealer's Hand\n";
        echo "--------\n";

        //Go through dealers hand and display values. Skip first,
        for($i=0; $i < count($this->hand); $i++){

            if($i == 0 and $display == 0){
                echo "X - ";
            }
            elseif($i < count($this->hand)-1){
                echo $this->hand[$i], " - ";
            }
            else{
                echo $this->hand[$i];
            }
        }
        echo "\n";
 
        echo "\nPlayers's Hand\n";
        echo "--------\n";

        //Go through Players hand and display values.
        for($i=0; $i < count($this->playersHand); $i++){

            if($i < count($this->playersHand)-1){
                echo $this->playersHand[$i], " - ";
            }
            else{
                echo $this->playersHand[$i];
            }
            
        }
        echo "\n";


    }


    //Get random card to put into either player or dealers hand.
    function getRandomCard($type){

        $card = null;


        if(count($this->deck2) < 52 and count($this->deck1) > 0){

            $cardIndex = rand(0,count($this->deck1)-1);
            $value = $this->deck1[$cardIndex];

            //push value into deck2
            array_push($this->deck2, $value);

            //push value into either dealer or player.
            // 0 - for dealers turn
            // 1 - Players turn
            if($type == 0){
                array_push($this->hand,$value);
            }
            else{
                array_push($this->playersHand,$value);
            }

            //remove value from deck1
            array_splice($this->deck1,$cardIndex,1);

            //return value 
            $card = $value;

        }
        else{

            $cardIndex = rand(0,count($this->deck2)-1);
            $value = $this->deck2[$cardIndex];

            //push value back into deck 1
            array_push($this->deck2,$value);

            //push value into either dealer or player.
            // 0 - for dealers turn
            // 1 - Players turn
            if($type == 0){
                array_push($this->hand,$value);
            }
            else{
                array_push($this->playersHand,$value);
            }

            //remove value from deck2 because it was drawn
            array_splice($this->deck1, $cardIndex,1);

            //return that card value
            $card = $value;
        }
        
        return $card;
    }

    //count cards at start of game, where dealer and player only have two cards.
    function startCheck(){
        // RETURN -1 if games CONTINUES
        $condition = -1;

        $playerCount = $this->countHand(1);
        $dealersCount = $this->countHand(0);

        //Player gets blackjack and dealer does not.. PLAYER WINS
        if($playerCount == 21 and $dealersCount != 21){
            $condition = 1;
        }
        //Dealer gets blackjack, player does not... DEALER WINS.
        elseif($dealersCount == 21 and $playerCount != 21){
            $condition = 0;
        }
        //TIE ON 21... GAME ENDS... PLAYER GETS WAGER RETURNED...
        elseif($dealersCount == 21 and $playerCount == 21){
            $condition = -2;
        }
        
        return $condition;
    }


    //check for over 21
    //return false if over...
    function checkTotal($total){
        $ret = true;

        if($total > 21){
            $ret = false;
        }

        return $ret;
    }

}//end of dealer class




//
class blackMethods{

    static function playAgain(){

        //return value
        $request = false;
        //user input prompt
        $userIn = readline("\n\nEnter 1 to play again, or any other key to leave: ");
            
    
        if($userIn == 1){
            $request = true;
        }
        return $request;
    }

    //make player object, return player
    //static function getPlayer(){

        
    
    
        
    //}
    
    //make dealer, return dealer
    //static static function getDealer(){
        //make dealer object...
        
    
        
    //}


    //get name from user
    static function askForName(){
        $name = readline("\n\nWhat is your name?");
    
        return $name;
    }

//get users money pool
    static function askForChips($playerName){
        echo "\n\nVery well... ";
        $money = readline("\nNow how much in chips do you want...." . $playerName ."...?");

        return $money;
    }


}





//main game flow function...
function playGame(){

    $gameCon = true;

    //welcome menu text.
    startMenu();

    //Get player object
    //$player1 = blackMethods::getPlayer();
    $playerName = blackMethods::askForName();
    $playerChips = blackMethods::askForChips($playerName);
    
    $player1 = new Player($playerName,$playerChips);


    //get Dealer object.
    //$dealer1 = blackMethods::getDealer();
    $dealer1 = new Dealer();

    //MAIN game flow...
    while($gameCon){

    //empty hands.. if game just starts empty array is just empty
    //if game continues, the arrays are properly emptied...
    $dealer1->resetHands();

    //Player places bet before cards are drawn.
    $player1->wager();

    //
    //Dealer draws for player
    $dealer1->getRandomCard(1);

    //Draws for dealer
    $dealer1->getRandomCard(0);

    //Draws for player
    $dealer1->getRandomCard(1);

    //Draws for dealer.. last deal...
    $dealer1->getRandomCard(0);

    //
    //Display both hands with two cards. Except just one for dealer.
    $dealer1->displayHands(0);

    //Check for blackjacks on either hand.
    //if both get 21, then its a draw.
    //if dealer gets 21, then player loses wager.
    //4 conditions. Dealer win, player win, tie or game continues...
    $blackjackCheck = $dealer1->startCheck();

    //dealer wins off blackjack
    if($blackjackCheck == 0){
        $dealer1->displayHands(1);
        if($player1->blackJackLoss()){
            //continue another iteration of while loop... Next round
            if(blackMethods::playAgain()){
                continue;
            }
            else{
                echo "\nYour total Pot is: ";
                echo $player1->getMoney();
                break;
            }
        }
        //player has no money... end session...
        else{
            break;
        }
    }
    //player win with blackjack
    elseif($blackjackCheck == 1){
        echo "\n\nCongratulations you won! You hit blackjack on first draw!!! ";
        $player1->playerWin();
        //Ask user if they want to play again
        if(blackMethods::playAgain()){
            continue;
        }
        else{
            echo "\nYour total Pot is: ";
            echo $player1->getMoney();
            break;
        }
    }
    //Ties on blackjack first draw
    elseif($blackjackCheck == -2){
        echo "\n\nYou both got blackjack, WOW. Game Tied. Your wager is returned.";

        $player1->gameTie();
        //ask user if they want to play again
        if(blackMethods::playAgain()){
            continue;
        }
        else{
            echo "\nYour total Pot is: ";
            echo $player1->getMoney();
            break;
        }
    }
    


    //Players turn
    //Can double down, 2x his bet, and get one more card...
    //Hit, get another card until players wants to stop
    //Stand, stay with those cards
    
    //display cards, then ask user what their decision is.
    

    //take player decision
        //return true or false
    //keep taking decision until STAY or DOUBLE DOWN

    //for while loop
    $cond = true;
    //Variable to check if game should end or continue after player decision
    $playCon = 1;

    while($cond){

        //take player decision
        $playerDecision = $player1->playDecision();

        //Dealer does something or nothing
        if($playerDecision == 1){
            //add card to players hand
            $dealer1->getRandomCard(1);

        }
        elseif($playerDecision == 2){
            //call dealer to hit you
            $dealer1->getRandomCard(1);

            //increase wager by 2x...
            $player1->wagerMultiply(2);

            //end while loop
            $cond = false;

        }
        else{
            //stop loop, player stays
            //count hands when dealer goes...
            break;
        }

        //display hands
        echo "\n";
        $dealer1->displayHands(0);

        //count players hands, check total return...
        //if false, PLAYER BUSTSthen stop while loop, and player loses.
        if(!$dealer1->checkTotal($dealer1->countHand(1))){
            //player loses
            echo "\nYou busted over 21!!!\n";

            if(!$player1->blackJackLoss()){
                //Player lost all money, end game...
                $playCon = -1;
                $cond = false;
                echo "\nYour total Pot is: ";
                echo $player1->getMoney();
                
            }
            else{
                //if player wants to play again, continue main loop...
                if(blackMethods::playAgain()){
                    $playCon = 0;
                    $cond = false;
                }
                //if player wants to quit, then break main loop
                else{
                    $playCon = -1;
                    $cond = false;
                    echo "\nYour total Pot is: ";
                    echo $player1->getMoney();
                }
            }

            
        }

        //if true then loop continue so player can make another decision

    }//end of player decision while loop.

    //make sure main game loop restarts
    if($playCon == 0){
        continue;
    }
    //player wants to quit, so break main game loop...
    elseif($playCon == -1){
        break;
    }


    //dealers turn
    //check cards, if they're 16 or lower, they draw a card
    // if they're 17 or higher they stay
    //if dealer busts then player wins 2x their wager...
    
    //check if dealer busts, and is over21
    if(!$dealer1->dealersTurn()){
        
        //
        $dealer1->displayHands(1);
        //player wins double their wager...
        $player1->dealerBusts();


        //Ask user if they want to play again
        if(blackMethods::playAgain()){
            continue;
        }
        else{
            echo "\nYour total Pot is: ";
            echo $player1->getMoney();
            break;
        }
        

    }

    
    //display hands
    $dealer1->displayHands(1);

    //compare both hands and see who has highest hand...
    //then send to end comp to deal with player win, loss or tie.
    //If returns false, then player cannot play again and has lost all their money.
    $endCondition = $player1->endComp($dealer1->finalComp());

    //player out of money... end of loop, so game just ends...
    if(!$endCondition){
        $gameCon = false;
        break;
    }
    else{
        //if user has more money to play ask them...
        if(blackMethods::playAgain()){
            //do nothing... since at end of while loop...
        }
        else{
            echo "\nYour total Pot is: ";
            echo $player1->getMoney();
            break;
        }
    }


    


    }//end of while loop
}

//Start game...
playGame();

//end of game text...
echo "\nThe program has ended.\n";
echo "\nRestart to play again !"


?>
