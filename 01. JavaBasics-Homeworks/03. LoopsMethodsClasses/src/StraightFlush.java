import java.util.ArrayList;
import java.util.Scanner;


public class StraightFlush {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] cards = input.nextLine().split("[ ,]+");
		
		boolean isOutput = false;
		
		if(cards.length < 5){
			System.out.println("No Straight Flushes");
		}
		else{
			
			for (int i = 0; i < cards.length; i++) {
				
				ArrayList<String> currentHand = new ArrayList<>();
				
				String card = cards[i];
				currentHand.add(card);
				
				for (int j = 0; j < cards.length; j++) {
					
					String cardToCompare = cards[j];
					
					if(compareCards(card, cardToCompare) == true){
						card = cardToCompare;
						currentHand.add(card);
						
						if(currentHand.size() == 5){
							System.out.println(currentHand);
							isOutput = true;
							break;
						}
						
						j =-1;
					}
					
				}
			}
			
			if(isOutput == false){
				System.out.println("No Straight Flushes");
			}
		}
	}

	private static boolean compareCards(String card1, String card2) {
		
		boolean areIncreasing = false;
		String face1 = "";
		String face2 = "";
		char suit1 = 'x';
		char suit2 = 'y';
		
		// first card
		if(card1.length() == 3){
			face1 += "10";
			suit1 = card1.charAt(2);
		}
		else if(card1.length() == 2){
			face1 += card1.charAt(0);
			suit1 = card1.charAt(1);
		}
		
		//second card
		if(card2.length() == 3){
			face2 += "10";
			suit2 = card2.charAt(2);
		}
		else if(card2.length() == 2){
			face2 += card2.charAt(0);
			suit2 = card2.charAt(1);
		}
		
		if(getFace(face1,face2) == true && suit1 == suit2){
			areIncreasing = true;
		}
		
		return areIncreasing;
	}

	private static boolean getFace(String suit1, String suit2) {
		
		boolean increasingFace = false;
		
		int a = getSwitch(suit1);
		int b = getSwitch(suit2);
		
		if(a == (b - 1)){
			increasingFace = true;
		}
		
		return increasingFace;
	}

	private static int getSwitch(String suit1) {
		
		int card = 0;
		
		switch (suit1) {
		
		case "2": card = 1; break;
		case "3": card = 2; break;
		case "4": card = 3; break;
		case "5": card = 4; break;
		case "6": card = 5; break;
		case "7": card = 6; break;
		case "8": card = 7; break;
		case "9": card = 8; break;
		case "10": card = 9; break;
		case "J": card = 10; break;
		case "Q": card = 11; break;
		case "K": card = 12; break;
		case "A": card = 13; break;
	
		}
	
		return card;
	}
}
