import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;


public class RandomHandsOf5Cards {

	public static void main(String[] args) {
		
		Random random = new Random();
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		ArrayList<Integer> cards = new ArrayList<Integer>();
		ArrayList<Integer> suits = new ArrayList<Integer>();
		
		for (int hand = 0; hand < n; hand++) {
			
			for (int card = 0; card < 5; card++) {
				
				int face = random.nextInt(13);
				int suit = random.nextInt(4);
				
				while(isUnique(face,suit,cards,suits) == false){
					
					face = random.nextInt(13);
					suit = random.nextInt(4);
					
				}
					
				cards.add(face);
				suits.add(suit);
				
				}
				
			for (int card = 0; card < 5; card++) {
				
				String newCard = "" + cardFace(cards.get(card)) + cardSuit(suits.get(card));
				
				System.out.print(newCard + " ");
				
			}
			System.out.println();
			
			cards = new ArrayList<Integer>();
			suits = new ArrayList<Integer>();
			
			}
			
		}

private static boolean isUnique(int face, int suit,ArrayList<Integer> cards, ArrayList<Integer> suits) {
		
		boolean unique = true;
		
		for (int card = 0; card < cards.size(); card++) {
			
			if(cards.get(card) == face && suits.get(card) == suit){
				unique = false;
			}
			
		}
		
		return unique;
	}

private static String cardSuit(int y) {
		
		String suit = null;
		
		switch(y){
		
			case 0: suit="\u2663"; break;
			case 1: suit="\u2666"; break;
			case 2: suit="\u2665"; break;
			case 3: suit="\u2660"; break;
		
		}
		
		return suit;
		
	}

private static String cardFace(int x) {
		
		String card = null;
		
		switch(x){
		
			case 0: card="2"; break;
			case 1: card="3"; break;
			case 2: card="4"; break;
			case 3: card="5"; break;
			case 4: card="6"; break;
			case 5: card="7"; break;
			case 6: card="8"; break;
			case 7: card="9"; break;
			case 8: card="10"; break;
			case 9: card="J"; break;
			case 10: card="Q"; break;
			case 11: card="K"; break;
			case 12: card="A"; break;
		
		}
		
		return card;
	}
	
}
