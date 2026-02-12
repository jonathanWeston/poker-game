// in this program we are going to use camelCase for vairable names PascalCase for array and list names and snake_case for methords, classes and functions 
// once gets a working prototype up will need to figure out a better player system because it is a mess
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

game_poker_run.poker_execution();

public class poker_tools
{
    public static int[,,] deck =
    {
        {{0,0,0,0,0,0,0,0,0,0,0,0,0}, {1,2,3,4,5,6,7,8,9,10,11,12,13}},
        {{0,0,0,0,0,0,0,0,0,0,0,0,0}, {1,2,3,4,5,6,7,8,9,10,11,12,13}},
        {{0,0,0,0,0,0,0,0,0,0,0,0,0}, {1,2,3,4,5,6,7,8,9,10,11,12,13}},
        {{0,0,0,0,0,0,0,0,0,0,0,0,0}, {1,2,3,4,5,6,7,8,9,10,11,12,13}}
    };
    public static int assignments = 0;
    public static int betPool = 0;
    public static int roundRaise = 0;
}

public class poker_player
{
    public class poker_cards
    {
        public int cardNumber = 0;
        public int cardClass = 0;
    }
    public poker_cards firstHand = new poker_cards();
    public poker_cards secondHand = new poker_cards();
    
    public static int balence = 500;
    public static int totalBet = 0;
}

public class game_poker_run
{
    public static (int type, int number) assign_random_cards()
    {
        Random rand = new Random();
        while(true)
        {
            int cardType = rand.Next(0,4);
            int cardNumber = rand.Next(0,13);
            if (0 == poker_tools.deck[cardType, 0, cardNumber])
            {
                
                poker_tools.deck[cardType, 0, cardNumber] = 1;
                poker_tools.assignments++;
                return (cardType, cardNumber);
            }
            else if(poker_tools.assignments >= 56)
            {

                throw new Exception("");
            }
        }
    }
    public static void card_assignment(poker_player jon)
    {
        var cardFirstAssignment = assign_random_cards();
        var cardSeccondAssignment = assign_random_cards();
        
        jon.firstHand.cardClass = cardFirstAssignment.type;
        jon.firstHand.cardNumber = cardFirstAssignment.number;

        jon.secondHand.cardClass = cardSeccondAssignment.type;
        jon.secondHand.cardNumber = cardSeccondAssignment.number;

        return;
    }
    public static poker_player[] amount_players()
    {
        poker_player player_charater = new poker_player();
        poker_player ai_1 = new poker_player();
        poker_player ai_2 = new poker_player();
        poker_player ai_3 = new poker_player();
        poker_player ai_4 = new poker_player();
        poker_player ai_5 = new poker_player();
        poker_player ai_6 = new poker_player();
        poker_player ai_7 = new poker_player();
        poker_player ai_8 = new poker_player();
        poker_player ai_9 = new poker_player();
        poker_player[] PotentualPlayers = {player_charater, ai_1,ai_2,ai_3,ai_4,ai_5,ai_6,ai_7,ai_8,ai_9};
        int amountPlayers = 0;
        while(true)
        {
            Console.Write("please enter how many people do you want to include in your game?(has to be between 1 and 10) ");
            string amountPlayersTemp = Console.ReadLine()!;

            if(int.TryParse(amountPlayersTemp, out amountPlayers))
            {
                if(0 < amountPlayers && amountPlayers < 11)
                {
                    poker_player[] Gameplayers;
                    poker_player[] GamePlayers = new poker_player[amountPlayers];
                    for(int i = 0; i < amountPlayers; i++)
                    {
                        GamePlayers[i] = PotentualPlayers[i];
                    }
                    return GamePlayers;
                }
            }
            else
            {
                Console.WriteLine($"You have enterd {amountPlayersTemp}, this is not a interger input please enter a interger");
            }
        }
    }
    public static void betting()
    {
        if(poker_tools.roundRaise != 0)
        {
            Console.WriteLine("you have 3 here, you can either match the current bets, you can match and raise, or you can fold ");
            while(true)
            {
                Console.WriteLine("do you want to 1) match, 2) match and raise or 3) fold ");
                string tempChoice = Console.ReadLine()!.ToLower();
                if(tempChoice == "1" || tempChoice == "match")
                {
                    Console.WriteLine($"you have chosen to match the bet that has been placed {poker_tools.roundRaise} will be taken");
                    
                }
            }
        }

        while(true)
        {
            Console.WriteLine("How much do you want to raise? (if you dont want to raise put 0 and has to be a multiple of 5)");
            string tempBet = Console.ReadLine()!;
            
            if(int.TryParse(tempBet, out int bet))
            {
                if(bet == 0)
                {
                    Console.WriteLine("you have chosen to check it over to the next player");
                    return;
                }
                
                else if(bet % 5 == 0)
                {
                    if(poker_player.balence >=  bet)
                    {
                        poker_player.balence -= bet;
                        poker_player.totalBet += bet;
                        poker_tools.betPool += bet;
                        poker_tools.roundRaise = bet;
                        Console.WriteLine("is valid bet");
                        Console.WriteLine($"your current ballance is {poker_player.balence} and your total bet is {poker_player.totalBet}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("you do not have the ballence for you to do this opperation");
                    }

                }
            }
        }
    }
    
    public static void poker_execution()
    {
        
        poker_player[] GamePlayers = amount_players();
        foreach(poker_player e in GamePlayers)
        {
            card_assignment(e);
        }
        
        
        Console.WriteLine($"your cards are class:{GamePlayers[1].firstHand.cardClass} card number:{GamePlayers[1].firstHand.cardNumber} and class:{GamePlayers[1].secondHand.cardClass} Number:{GamePlayers[1].secondHand.cardNumber}");
        
        
    }
}

