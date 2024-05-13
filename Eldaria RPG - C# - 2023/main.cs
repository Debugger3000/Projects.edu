


// This is my source code for my RPG text based game.


using System.Numerics;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading;
using System.Collections.Concurrent;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Data.Common;
using System.IO;
using System.Security.AccessControl;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;


// See https://aka.ms/new-console-template for more information





/*
int numberJen(){

     Random  num = new Random(); //Create new instance of Random method.
    int roll = num.Next(1,3);//Store the random number from 1 - 3.

    return roll;
}*/




//Class for Deadman mini-game. 
//Will be called with input to initialize the game, and will return 
class Deadman{

    public int countPicture = 0;
    public char [] wordGuess = {' ', ' ', ' ', ' ', ' ', ' ', ' '};

    //run main game loop in here by calling other functions in this class.
    public bool initializeGame(string userName){

        bool statusFinal = true;
        
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");
        Console.WriteLine("'Five body parts, five mistakes. Think quick, or else a Deadman, you may be... huahahua' Says Xerah, with a grin.");
        Console.WriteLine(" ");

        //contain whole game loop within here
        while(true){
            
            //get guess and have it validated before receiving.
            char guess = inputHandler();

            //send guess to compare to word. Return integer telling print picture to add a part to the  'deadman'.
            int lett = compareLetter(guess, wordGuess);

            //print function 
            int status = 0;
            status = printPicture(lett, userName);
        
            //Game is lost. All body parts are drawn. Break, and have it return false
            if(status == 2){
                statusFinal = false;
                break;
            }
            //Game has been won, break and have true returned to main game loop.
            else if(status == 1){
                statusFinal = true;
                Console.WriteLine("");
                Console.WriteLine($"'Well done {userName}. I look forward to seeing your journey.' says Xerah. She then gets up, puts a hand across your chest and says some foreign words...");
                Console.WriteLine("");
                break;
            }  
        }

        return statusFinal;
    }

    //handle errors from user input.
    private static char inputHandler ()
    {
        
        Console.WriteLine("'Choose a letter. Choose wisely.' Says Xerah.");
        char input2 = 'z';
        char input3 = 'z';

        //input loop, to keep asking for input, if wrong.
        while(true){

            Console.WriteLine("");
        //try / catch to test for wrong input.
        try
        {
            string input = Console.ReadLine();

            //test if its a number

            input2 = char.Parse(input);
            input3 = char.ToLower(input2);
            //Console.WriteLine("Before break");
            break;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(" ");
            Console.WriteLine(e.Message);
            Console.WriteLine("'Try picking a letter this time.' Says Xerah.");

            
        }
        //Console.WriteLine("After break");
        Console.WriteLine(" ");

        }
        //return input
        return input3;

    }

    //Print function. For the 'Deadman' Portrait.
    private int printPicture(int parts, string userName)
    {
        //game has been won. Return true.
        if(parts == 2){
            return 1;
        }

        
        //Add errors, up to 5. Then game is over.
        countPicture += parts;

        //empty frame at the start
        if(countPicture == 0){

        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");
        
        }
        //Display deadman with head
        if(countPicture == 1){
            Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|   {   }    |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");

        Console.WriteLine("'A mighty brain for a mighty man' - Xerah says.");
        Console.WriteLine(" ");

        }
        //display deadman with 2 mistakes.
        if(countPicture == 2){

        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|   {   }    |");
        Console.WriteLine("|     |      |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");

        Console.WriteLine("'And so the body is revealed.' - says Xerah.");
        Console.WriteLine(" ");
        }
        //display deadman with 3 mistakes.
        if(countPicture == 3){

        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|   {   }    |");
        Console.WriteLine("|     |      |");
        Console.WriteLine("|    /       |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");

        Console.WriteLine("Take a moment to think, if you would like, Mwhuhaha.' - Xerah says.");
        Console.WriteLine(" ");
        }
        //display deadman with 4 mistakes.
        if(countPicture == 4){

        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|   {   }    |");
        Console.WriteLine("|     |      |");
        Console.WriteLine(@"|    / \     |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");

        Console.WriteLine("'One last chance. The eyes will see, if you let them. Xerah says' ");
        
        }
        //display final deadman. 5 mistakes, you lose.
        if(countPicture == 5){


        Console.WriteLine(" ");
        Console.WriteLine("--------------");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("|   {- -}    |");
        Console.WriteLine("|     |      |");
        Console.WriteLine(@"|    / \     |");
        Console.WriteLine("|            |");
        Console.WriteLine("|            |");
        Console.WriteLine("--------------");
        Console.WriteLine(" ");
        Console.WriteLine($"'This is a shame. I was wishing for a different outcome. Farewell, {userName}'");
        Console.WriteLine(" ");


        //return 2 for game LOST.
        return 2;
        }

        //return sequence to keep game going
        return 0;

    }

    //Function to handle letter to word comparison.
    private int compareLetter(char letter, char [] wordGuess)
    {
        int countRight = 0;
        int countWin = 0;
        char[] word = {'j', 'u', 's', 't', 'i', 'c', 'e'};

        //Search for correct letter guesses, and then change blank array values for matches.
        for(int i = 0; i < wordGuess.Length; i++){

            if(letter == word[i]){

                wordGuess[i] = letter;
                //variable to use to check for correct guesses.
                countRight = 1;
            }
        }

        Console.WriteLine(" ");
        Console.WriteLine(" ");

        //Print out guessed letters.
        for(int i = 0; i < wordGuess.Length; i++){
            char temp = wordGuess[i];
            Console.Write($"{temp}");
            Console.Write(" ");  

            if(temp == ' '){

                countWin++;
            }
        }
        Console.WriteLine(" "); 
        Console.WriteLine("_ _ _ _ _ _ _");
        Console.WriteLine(" "); 
        //user got all letters. Game won.
        if(countWin == 0){
            return 2;
        }
        //User guessed an incorrect letter.
        if(countRight != 1){
            return 1;
        }
        //user guessed a correct letter.
        return 0;
    }
}


//class to control dialog and test input 
class DialogInputControl{
    string input = " ";
    char input2 = ' ';
    char input3 = ' ';
    //Function to let user control flow of game Dialog.
            public static void dialogWait(){
                string cond = "z";
                
                while(cond == "z"){
                cond = Console.ReadLine();
                }
                Console.WriteLine(" ");
            }
    //Handle decision test input.
    public char multipleDecisionHandler(){
        
        while(true){

        try
        {
            input = Console.ReadLine();

            //test if its a string.
            input2 = char.Parse(input);
            //tests to make sure its a single alpha.
            input3 = char.ToLower(input2);
            //Console.WriteLine("Before break");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(" ");
            Console.WriteLine(e.Message);
            //Console.WriteLine("Choose either: 'A' , 'B' , or 'C'.");

            
        }
        //pass these items to return if they are true.
        if(input3 == 'a' || input3 == 'b' || input3 == 'c'){
            break;
            
        }
        //different alpha characters, pick error.
        else{Console.WriteLine("Error: Choose: 'A' , 'B' , or 'C'.");}
        }
        return input3;
    }
}

//Class to hold dialog code.
static class Dialog{

    //start of game dialog.
    public static void startDialog(){
        
        //DialogInputControl waitText = new DialogInputControl();
        

        Console.WriteLine("*caww*... *caww*... *caww*...");
        Console.WriteLine(" ");
            Console.WriteLine("You slowly awake from the sound of crows in the trees above. You forgot that you even fell asleep, but after escaping the Brave Companions camp last night and having no food for 3 days, you collapsed after a few hours of fleeing.\n");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("After shifting your body to the side, you get a flash of pain through your torso, and you quickly come back to the realization of your condition.");
            Console.WriteLine(" ");
            Console.WriteLine("You think to yourself, 'That damn bastard Fleece, if only he was the guard on watch last night, that I had the pleasure of dealing with.'");
            DialogInputControl.dialogWait();
            Console.WriteLine(" ");
            Console.WriteLine("He was Vargo Hoat's second in command. 'He sure loved the feeling, and the sound, of his knuckles hitting an unarmed man, bound to a wooden pole.\nGive me a sword, and two legs to stand on and I'm sure his joy would turn to ashes.'");
            Console.WriteLine(" ");
            Console.WriteLine("'If there was someone to watch out for, it is him. He's an experienced fighter, and he knows his way around a scent with those hounds of his.\nI will have to watch out for him on my way back to King Stannis.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("You quickly remember mount Florent off to the east, that you noticed last night. You know exactly what direction to go. The only problem is that\nyou are still within the Red Forest. Named after the end result of the always expected conflict here, regardless of who you are or serve.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("You step out of the brush you slept in off the faint trail, and start walking. Your journey has begun.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();

    }
    //Second phase dialog, for the witch test or Deadman minigame.
    public static void witchDialog(string userName){

        Console.WriteLine(" ");
        Console.WriteLine($"*{userName}* *{userName}* *{userName}*");
        DialogInputControl.dialogWait();
        Console.WriteLine("You have past Mount Florent and it is about noon. Your body is sore, you're slowing down and feel the need to rest.");
        DialogInputControl.dialogWait();
        Console.WriteLine($"*{userName}* *{userName}* *{userName}*");
        Console.WriteLine(" ");

        Console.WriteLine("You notice the crows are saying your name... You get a chill down your spine. 'What is this madness?'.");
        DialogInputControl.dialogWait();
        Console.WriteLine($"*{userName}*... ... ... Purple sticks... purple sticks...");
        DialogInputControl.dialogWait();
        Console.WriteLine("You then notice the faintly colored sticks along the right side of the hardly visible trail... ");
        Console.WriteLine(" ");
        Console.WriteLine("'These sticks, they have a purple tinge.... A Witches Nest is nearby... I have heard stories about the Violet Witches in this forest. I should stay away.'");
        DialogInputControl.dialogWait();
        Console.WriteLine("But then a violent wave of pain shoots through your torso again, as when you woke up. You collapse to your knees, struggling through the pain.");
        Console.WriteLine(" ");
        Console.WriteLine("'I can't go on much longer like this. I am getting worse.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine($"*{userName}*...   Oldtown...   Blood...   Oath...");
        Console.WriteLine(" ");
        Console.WriteLine("'How do they know... What is this...'. Then a flood of speculative relief overcomes you. Then you begin following the purple sticks. 'I have no choice'.");
        DialogInputControl.dialogWait();
        Console.WriteLine("You reach the witches nest, and enter it slowly, painfully. You notice the witch sitting at a table.");
        Console.WriteLine(" ");
        Console.WriteLine("'The name is Xerah, please sit with me.' Says the witch.");
        DialogInputControl.dialogWait();
        Console.WriteLine("'You have something important to do, I have seen. But it seems you might not have the strength to do so.'");
        Console.WriteLine(" ");
        Console.WriteLine("'If you give me what I want, then I will make sure that wound of yours is healed, and back to normal.' Xerah says. The pain comes back in a rush,\nand you forcefully agree with her.");
        DialogInputControl.dialogWait();
        Console.WriteLine($"She looks deep into your soul. 'If you can solve my riddle, then you can serve truly, and justly... knight of Stannis.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("'If a Maester fights for knowledge, and a king fights for his people, then what does a knight fight for?'");
        DialogInputControl.dialogWait();
    }
    //Orc dialog. Third phase. Old friend, but sadly an Orc.
    public static void orcDialog(string userName){

        Console.WriteLine("As you leave the witches nest, you notice how much better you feel. 'My head still hurts, but my chest is a lot better. She seems to have followed through.");
        Console.WriteLine(" ");
        Console.WriteLine("You begin again on your journey. Back to where you were headed.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("Its been a few hours. You ate some blueberries, and found a sword on a corpse, but still no armour. You know you are headed in the right direction, but don't know where you are....");
        DialogInputControl.dialogWait();
        Console.WriteLine("All of a sudden you hear someone come out of the foliage a few meters behind you, so you turn around to see.");
        DialogInputControl.dialogWait();
        Console.WriteLine("Next thing you know you are surrounded by a band of Orcs....");
        DialogInputControl.dialogWait();
        Console.WriteLine($"'Iff itt ain't the biig baad Knight, {userName}.... '");
        Console.WriteLine(" ");
        Console.WriteLine("'I've been a waitin for this daay a looong time... auhauha. How about a hug for your old friend, Thrail.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("You turn to him, smirk, and finally say, 'I'd be expecting a knife in my gut If I were to do that. Considering you lost that eye of yours because of me.'");
        Console.WriteLine(" ");
        Console.WriteLine("Thrail steps foward. Now two meters away from you and says, 'Well aint that thaa truth. To be honest, I've never looked more fierce.\nMen tremble before me more than ever now. auhauhauha'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();

        Console.WriteLine("Thrail stops smiling, and looks at you, through you. He speaks, and says, 'but you know how us Orcs are. I want to settle this right now.\nI promise I will take it easy you, considering our history and all'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("Thrail hands his curved sword to his ally, takes off his gauntlets, his breastplate, and cracks a few knuckles while staring at you.\nThen says, 'Hoow booout it oold pal, its either this or the swoord, don't maake mee do it.");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine("You return the stare, drop your sword, and reply, 'No need. It seems my vitality has returned to me since a few hours ago. I'm sorry about the eye,\nbut you know I had to do it.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("Thrail, cold as a stone, says 'Thaaanks, Paaal, but I will return the faaavoor ahuahua.' ");
        Console.WriteLine(" ");
        Console.WriteLine("Thrail begins walking foward, with viciousness in his eye, and stride...");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine("You step forward as well, and speak to yourself, 'And so it has begun'....");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    //Final dialog section.
    public static void hunterDialog(string userName){

        Console.WriteLine(" ");
        Console.WriteLine("After parting ways with Thrail, you are in the final reach to Stannis' land.");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine("The witch Xerah, seemed to heal up your body pretty good, but after taking that beating from Thrail, you're almost back to where you were before.");
        Console.WriteLine(" ");
        Console.WriteLine("You can see the rise of the land, and where the forest ceases. 'The beginning of his land. Only a few miles out.', you think to yourself. 'I'm almost there.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("But a few minutes later, you hear a horse galloping a distance behind you. It comes racing down the bend a hundred meters out. 'He has sight of me.'\nYou mutter to yourself.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine($"Within the few seconds of hearing, and then seeing the horse riding at you. He has largely closed the gap and is now fifty meters from you,\nwith his sword unsheathed and his arm out, screaming {userName}...");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("You could tell from the pointy metal helmet that it is Fleece riding at you. 'May the gods give him strength, for I will not show mercy...'");
        DialogInputControl.dialogWait();
    }

}


class Problems{

    //variable to hold user input.       
    char decision = 'z';
    
    //first trial. 
    public bool riverProblem(){
        
        Console.WriteLine("You've been walking for a few hours, and come upon a river with a fast and strong current.\nYou will need to find a way across.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("There is a makeshift bridge, but it seems to have been burned to some degree, yet it still stands. You also notice there are some rocks creating a path,\nbut they will be slippery.");
        Console.WriteLine(" ");
        Console.WriteLine("You look downstream and notice the river is shallower there, but it seems to be about waist height, and the current is still strong.");
        DialogInputControl.dialogWait();

        
        Console.WriteLine("Choose either: 'A' , 'B' , or 'C'.");
        Console.WriteLine("----------------------");
        Console.WriteLine("'A': The Bridge");
        Console.WriteLine("'B' : The Rock Path");
        Console.WriteLine("'C' : The Shallow Water");
        Console.WriteLine("----------------------");
        Console.WriteLine(" ");

        //create new instance of inputcontrol class.
        DialogInputControl river = new DialogInputControl();
        decision = river.multipleDecisionHandler();

        Console.WriteLine(" ");

        //check for what character it is.
        if(decision == 'A' || decision == 'a'){

            Console.WriteLine("As you step onto the bridge, you notice it shifts a bit. So you take each step slowly, and carefully, and eventually reach the river bank.");
            Console.WriteLine("You then begin onward through the forest, to King Stannis' land!");
            DialogInputControl.dialogWait();
            return true;

        }
        //other choices make player lose.
        else{
            Console.WriteLine(" ");
            Console.WriteLine("The current is too strong, and you are too weak. You lose balance, and the tide takes you away...");
            DialogInputControl.dialogWait();
            Console.WriteLine(" ");
            return false;
        }
    }

    //orc trial.
    public bool OrcProblem(string userName){

        //variable for bad decisions.
        int rageMeter = 0;

        //create new instance
        DialogInputControl orcFight = new DialogInputControl();
        
        Console.WriteLine("'I won't be able to win this fight. Not in the condition I'm in. So I am gonna want to hurt him a bit, and make this a good fight, or else he will kill me.\nI better be careful.");
        Console.WriteLine(" ");
        Console.WriteLine("Thrail begins with a big right hand, and you block most of it... but the force stuns you for a second.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();

        Console.WriteLine(" ");
        //decision text, A B or C.
        Console.WriteLine("There is an opening for either; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - A straight punch to his face. ");
        Console.WriteLine("'B' - A hook to his body. ");
        Console.WriteLine("'C' - A heel to his knee. ");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");
        Console.WriteLine(" ");

        decision = orcFight.multipleDecisionHandler();
        if(decision == 'c'){
            Console.WriteLine("Thrail screams in pain as he drops down, but then stumbles up just as quickly to tackle you, and begins pummeling you relentlessly.");
            DialogInputControl.dialogWait();
            Console.WriteLine("The flurry is too much. You can't do anything. You enraged him too much.");
            DialogInputControl.dialogWait();
            Console.WriteLine("...");
            Console.WriteLine("You lose consiousness...");
            return false;
        }

        Console.WriteLine("Thrail takes the hit. And then says, 'Nice hit Paaal, ahuahauha'. Then returns a wicked hook to your body. That hurt you good, but suprisingly you take\nit well, and think to yourself, 'That witch'.");
        DialogInputControl.dialogWait();
        Console.WriteLine("Thrail then takes a step back, and begins a roundhouse kick to your right side... You see it coming and have time.");
        DialogInputControl.dialogWait();
        //decision text, A B or C
        Console.WriteLine("You can: ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Duck while sweeping his stationary leg. ");
        Console.WriteLine("'B' - Step back, and then follow up with your own side kick to his face.");
        Console.WriteLine("'C' - Walk into the kick, blocking it prematurely, while throwing another hook to his body.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        decision = orcFight.multipleDecisionHandler();
        if(decision == 'b'){
            Console.WriteLine("You caught him good. Right in the jaw, on the side of his face that lost the eye, and was injured, from you...... Thrail is stumbles back, looks up and says, 'Lets see hooow you like it now'");
            DialogInputControl.dialogWait();
            Console.WriteLine("Thrail rushes at you, stuns you with a hook to the body, and an overhand to your face. Then follows it with a devastating kick to your jaw...");
            DialogInputControl.dialogWait();
            Console.WriteLine("Your jaw is hanging, and half your face is broken and bloody... and blood starts pooling beneath your head.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("You never wake.");
            return false;

        }
        else if(decision == 'c'){
            rageMeter++;
        }
        
        Console.WriteLine("Thrail is sweating, and tired. And so are you. Thrail looks up at you, and says, 'Its almost over friend, I just need one mooore goood one, ahauaha'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("Thrail quickly moves at you, closing the gap, and grabs you by the body. And slams you down to the ground, and now has half mount...");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("He begins throwing at you, again and again, at your head, and at your body.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        //decision text, A B or C
        Console.WriteLine("You can; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Slide out the half guard, and knee him to the body, once more.");
        Console.WriteLine("'B' - Take your chances, and let him get some damage in, and hope he will show you mercy.");
        Console.WriteLine("'C' - Catch the slow arm, and flip around him, putting him into an arm bar. ");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        decision = orcFight.multipleDecisionHandler();
        if(decision == 'b'){
            Console.WriteLine("You do nothing. And let Thrail have free reign over you. 'ahuahuaa, why you just laying there. Don't think I give mercy to those who doont fight baaack. Especially for knights'");
            DialogInputControl.dialogWait();
            Console.WriteLine("Thrail keeps hitting you, and eventually only starts to punch you in the face, and harder...");
            DialogInputControl.dialogWait();
            Console.WriteLine("It's not long before you go unconsious.");
            return false;

        }
        else if(decision == 'a'){
            rageMeter++;
            if(rageMeter == 2){
                Console.WriteLine("Thrail jerks his body, as you knee him right in the same spot as before. You got him good.");
                DialogInputControl.dialogWait();
                Console.WriteLine("'A knight, whoo, forgoot how to fight... ahuauhaahah.'. Said Thrail.");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("Thrail gets up, and charges you with overwhelming ferocity. Throwing you back a few feet, and as you stop sliding, he lands on you with a life ending knee to the body.");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();

                Console.WriteLine("You spit blood instantly, and remain on the ground, while Thrail walks away laughing. You soon lose your breath and die.");
                Console.WriteLine(" ");
                return false;
            }
        }

        Console.WriteLine("You land your last good shot. Inventive too. And Thrail seems to like it.");
        Console.WriteLine(" ");
        Console.WriteLine("'Ahauhauha', Thrail laughs once more. 'Thats the man that I used to know.'");
        DialogInputControl.dialogWait();
        Console.WriteLine($"Thrail re-equips himself with his gear, and says 'You know me, and my ways too well, {userName}. Would be a shame to kill yaa, ahauha.'");
        Console.WriteLine(" ");
        Console.WriteLine("You respond, 'It really would be, Thrail. You both laugh.");
        DialogInputControl.dialogWait();
        Console.WriteLine("You both shake hands at the end, and Thrail wishes you luck on your journey north, as he parts ways headed southeast.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");

        //You got through the trial, and can move on.
        return true;
    
    }
    
    //final trial before reaching safety.
    public bool hunterProblem(string userName){

        //count mistakes.
        int mistakeCount = 0;
        //int to control decision path.
        int path = 0;

        //create new instance of inputcontrol for this problem.
        DialogInputControl hunterFight = new DialogInputControl();

        Console.WriteLine(" ");
        Console.WriteLine("Fleece is fast approaching, sword in hand, riding at you with speed. You have your sword, but no armour...");
        DialogInputControl.dialogWait();
        
        //decision text, A B or C
        Console.WriteLine("Your options are; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Stand your ground, and hope to throw your sword at fleece when he is in range.");
        Console.WriteLine("'B' - Make for the high ground on the side of the trail, and try to match Fleece's charge.");
        Console.WriteLine("'C' - Move into the lower ground brush that sharply drops off the trail, on the otherside, forcing Fleece onto foot.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        //Decision event number ONE. For hunterFight.
        decision = hunterFight.multipleDecisionHandler();
        if(decision == 'c'){
        Console.WriteLine(" ");
        Console.WriteLine("You make it down, into the low ground, and now a deep dike separates you from the trail.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        
        Console.WriteLine("You hear Fleece call out... 'If it weren't for that orc friend of yours, my hounds would already have your legs in pieces.'");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine("You say nothing. You only tighten your grip on your sword, and begin waiting. As you start to hear him come over the ridge of the deep ditch\nparallel to the trail.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        }
        else if(decision == 'b'){
            Console.WriteLine("You get onto the high sloped ground to the side of the trail. You ready your sword as Fleece comes down the trail yelling with blood driven hatred.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("As he rides in with speed, you swing your sword, but you swing too late and Fleece's sword lands furiously across your upper chest and neck.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("You hit the ground, and start bleeding uncontrollably on the ground as you hear Fleece laughing and starting to circle back with his horse. You die with Fleece staring down at you smiling.");
            Console.WriteLine(" ");
            return false;
        }
        else if(decision == 'a'){

            Console.WriteLine("Fleece charges at you, with his sword out and arm ready to swing. As he gets within 5 meters, you throw your dagger sharply, and quickly, aiming for the horses eye.");
            Console.WriteLine(" ");
            Console.WriteLine("But it grazes its cheek instead. And the horse rides truly, as Fleece swings for your head and takes it clean off.");
            DialogInputControl.dialogWait();
            return false;
        }


        Console.WriteLine(" ");
        Console.WriteLine("Fleece takes the ridge, looks at you and smiles and begins walking up towards you, onto level ground. ");
        Console.WriteLine(" ");

        Console.WriteLine($"As he gets a few meters away, he says 'Good old {userName}. Why did you leave, I thought you enjoyed my hospiltality ahahuhauha.'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();


        Console.WriteLine("You don't even blink, and respond slowly and confidently, 'No I didn't, but I will enjoy cutting you down.'. ");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine("You think to yourself. 'Fleece is a well known sell sword, hes crazy, but quite skilled with a sword. I will have to fight smart.\nHe has plate armour on his chest, but his legs only have boiled leather...'");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("You slowly approach him, and he meets your pace... He slashes over head, swingly down upon you.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();

        //decision text, A B or C
        Console.WriteLine("Your options are; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Parry the over head slash, and counter with a slash across the opposite side.");
        Console.WriteLine("'B' - Side step the swing, and thrust at him.");
        Console.WriteLine("'C' - Thrust your sword at him, hoping to land the first strike.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        //Decision event number ONE. For hunterFight.
        decision = hunterFight.multipleDecisionHandler();
        if(decision == 'a'){
            Console.WriteLine("You parry successfully, and Fleece quickly parries. ");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
        
        }
        if(decision == 'b'){
            Console.WriteLine("As you side step, your thrust hits Fleece into his plate breastplate and bounces off. At the same time, Fleece follows you\nwith his blade and slices you along the your off hand arm. Your arm is weakened, but still usable.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("Fleece steps over to you, laughs, and then stabs you through the heart, with a smirk on his face.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            mistakeCount++;
        
        }
        else if(decision == 'c'){
            Console.WriteLine(" ");
            Console.WriteLine("Your thrust bounces of his breastplate, and his swing follows you and slashes through half your face. You drop instantly,\nand he walks over and stabs you through the heart. ");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            return false;
        }

        Console.WriteLine("Fleece then swings his sword downward with the momentum from the parry, going for your leg... ");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");

        //decision text, A B or C
        Console.WriteLine("Your options are; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Parry low, and swing around his sword upward, locking it with yours.");
        Console.WriteLine("'B' - Jump over his sword, slashing down onto him.");
        Console.WriteLine("'C' - Swing your leg out of the way, and then counter to his leg.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        decision = hunterFight.multipleDecisionHandler();
        if(decision == 'a'){
            Console.WriteLine("You lock his sword with yours, and you guys are face to face, struggling for control of each others sword...");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
        
        }
        else{
            Console.WriteLine("Your move is unsuccessful, and Fleece parries, and catches you off balance with a counter, and slashes your throat.");
            Console.WriteLine(" ");
            Console.WriteLine("You quickly bleed out, with Fleece over you laughing, 'ahuahuaha'.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            return false;
        }


        Console.WriteLine(" ");
        Console.WriteLine("Fleece is a few inches from your face. He is sweating, and has a devilish look in his eyes. You stand firm with your sword\npushed against his, waiting for the right moment...");     
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        //decision text, A B or C
        Console.WriteLine("Your options are; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Go for a knee into his pelvic area, while the swords are locked.");
        Console.WriteLine("'B' - Push off, into his face, and strike for above his knee");
        Console.WriteLine("'C' - Push off, into his face, and strike for his neck.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        decision = hunterFight.multipleDecisionHandler();
        if(decision == 'a'){
            Console.WriteLine("Fleece pushes you away with his sword, while you throw the knee. You fall back, and stumble.");
            Console.WriteLine(" ");
            mistakeCount++;
            DialogInputControl.dialogWait();

            if(mistakeCount == 2){
                Console.WriteLine("The wound in your leg inhibits you from getting back up, and his massive down swing catches your sword close to the tip...");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("Your sword doesn't catch enough, and his sword lands strongly, deep into your left collar bone...");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("You drop to down face first, and die within 10 seconds face down, in the dirt, with Fleece laughing behind you, 'ahauha'.");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                return false;
            }
            Console.WriteLine("You get back up in time to move back from his blade. It missed by inches.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
        }

        if(decision == 'b'){

            Console.WriteLine("Fleece steps back with the shove, meanwhile you successfully cut his quad. He stumbles back, and grunts with pain.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
        }

        if(decision == 'c'){

            Console.WriteLine(" ");
            mistakeCount++;
            
            if(mistakeCount == 2){
                Console.WriteLine("Fleece stumbles back a step, and easily parries your strike, and counters slicing hard across your chest. He slices your left pec, right in half...");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("Your sword drops, and as you go to pick it up with your right arm, fleece knees you in the head, sending you flying back. You are dazed, and on the ground. Fleece walks up, places a foot on your chest, stepping hard, and then puts his sword right through your throat, while smirking.");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                return false;
            
            }
            Console.WriteLine("Fleece stumbles back a step, and easily parries your strike, and counters slicing your forearm. You stumble back, flinching with pain.");
            mistakeCount++;

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();

        }

        Console.WriteLine("Fleece is breathing heavily, and looks tired. He looks up at you and says 'Now the fun is over'.");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();
        Console.WriteLine("Then rushes at you with again, with a massive thrust, the speed almost catches you off guard.");
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        DialogInputControl.dialogWait();

        Console.WriteLine("Your options are; ");
        Console.WriteLine("------------------------------"); 
        Console.WriteLine("'A' - Quickly side step the thrust, and then go for his hamstring.");
        Console.WriteLine("'B' - Try to parry downward his thrust, and go for his neck.");
        Console.WriteLine("'C' - Side step the thrust, and try to take off his hands.");
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");

        decision = hunterFight.multipleDecisionHandler();
        if(decision == 'a'){
            Console.WriteLine("You dodge the thrust, and cut his hamstring deep. He falls hard, and grunts in pain. Sword drops down in front of him.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            Console.WriteLine("He tries to speak, 'May youuUU...', but you interrupt his words with a thick slash, down into his head.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            return true;
        
        }

        else if(decision == 'b'){
            mistakeCount++;

            if(mistakeCount == 2){
                Console.WriteLine("You try to take his sword down, but your arm is too weak, and his thrust lands into your left thigh. It cuts deep.");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("You fall to the ground, with sword in hand. He swings viciously downward, taking half your shoulder off...");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                return false;
            }
            mistakeCount++;
            if(mistakeCount == 2){
                Console.WriteLine("His gorgot blocks, the blow and he cuts your leg deep in counter..");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                Console.WriteLine("You fall to the ground, with sword in hand. He swings viciously downward, taking half your shoulder off...");
                Console.WriteLine(" ");
                DialogInputControl.dialogWait();
                return false;
            }
        
        }

        else if(decision == 'c'){
            mistakeCount++;

            if(mistakeCount == 2){
            Console.WriteLine("Fleece predicts your attack, and pulls back his sword, and then swings his body around with his blade, catching you clean in the neck... You die instantly.");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            return false;
            }
            Console.WriteLine("Fleece predicts it, but you strike fast, and take his sword out of his hands. You then swing violently, at his head, taking it clean off...");
            Console.WriteLine(" ");
            DialogInputControl.dialogWait();
            return true;

        }

        return true;
    }
    





}



//main program class.
class Program : DialogInputControl
    {
        static void Main(string[] args)
        {
            //control game stop / start.
            bool gameCondition = true;

            string userName = "blank";//username variable
            string input = " ";//input variable

            //Main Menu text.
            Console.WriteLine("--------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Eldaria !");
            Console.WriteLine(" ");
            Console.WriteLine("--------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Instructions: ");
            Console.WriteLine(" ");
            Console.WriteLine(" - After finished reading the dialog, and prompts, you will have to press 'Enter', in order to move to the next.");
            Console.WriteLine(" ");
            Console.WriteLine(" - Read the dialog carefully throughout the game. There are hints as to what decisions you should make.");
            Console.WriteLine(" ");
            Console.WriteLine(" - And most importantly, have fun !");
            Console.WriteLine(" ");
            Console.WriteLine("--------------------");
            Console.WriteLine(" ");
            Console.WriteLine("If you are Ready to Begin. Please enter any key.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            
            //Move on, by users input to character name input.
            while(input == " "){
                input = Console.ReadLine();
            }

            //Get a name for the users character in the game.
            Console.WriteLine("Please enter a name for your character !");
            while(userName == "blank" || userName == "" || userName == " "){
                userName = Console.ReadLine();
            }
            
            //welcome user
            Console.WriteLine(" ");
            Console.WriteLine($"Welcome {userName} !");
            Console.WriteLine(" ");
            Console.WriteLine($"Please Press 'Enter'. To begin the game {userName}");
            Console.WriteLine(" ");
            
            dialogWait();//program pause, waiting for user.

            //Start the story. The game. Call Dialog class /  first function.
            Dialog.startDialog();

            //Main game loop control. Checks if gameCondition is true, after each trial. If user ever fails a test, it breaks.
            while(gameCondition){

                //create firstTrial instance, run riverProblem scenario from Problem class.
                Problems firstTrial = new Problems();
                gameCondition = firstTrial.riverProblem();

                //check if user completed the trial. Break if not.
                if(gameCondition == false){break;}   

                //Start next dialog.
                Dialog.witchDialog(userName);

                //Start second trial.
                Deadman start = new Deadman();
                //call start function for deadman, mini game.
                gameCondition = start.initializeGame(userName);

                if(gameCondition == false){break;}   //if returns false, break.

                //start Orc dialog
                Dialog.orcDialog(userName);
                //launch second trial.
                gameCondition = firstTrial.OrcProblem(userName);
                if(gameCondition == false){break;}//if returns false, break.

                //start hunter dialog.
                Dialog.hunterDialog(userName);
                //launch last trial.
                gameCondition = firstTrial.hunterProblem(userName);
                if(gameCondition == false){break;}//if returns false, break.

                //end of game text for winner.
                Console.WriteLine(" ");
                Console.WriteLine("After seeing Fleece go stiff. You reach the path once again, and finally begin towards the end of the forest.");
                Console.WriteLine(" ");
                Console.WriteLine("You are refreshed by a wave and relief, and realize you will make it back to your own lands.");
                DialogInputControl.dialogWait();
                Console.WriteLine(" ");
                Console.WriteLine("After an hour of walking, you can see fort Dillon. The fort you know so well. A smile comes naturally upon your face.");
                DialogInputControl.dialogWait();
                
                //break to display end of game winner text.
                if(gameCondition == true){
                    break;
                }   
            }

            //end of game text, for winner
            if(gameCondition == true){
                Console.WriteLine("----------------------");
                Console.WriteLine("Congratulations !!!");
                Console.WriteLine(" ");
                Console.WriteLine("You have won the trials of the Red Forest !!!");
                Console.WriteLine(" ");
                Console.WriteLine("Thank you for playing !!");
                Console.WriteLine("----------------------");
            }
            else{
                Console.WriteLine(" ");
                //text when user loses.
                Console.WriteLine("Game over !");
            }
        }
    }
