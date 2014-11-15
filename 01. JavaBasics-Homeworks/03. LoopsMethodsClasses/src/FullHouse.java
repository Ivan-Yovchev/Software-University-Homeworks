public class FullHouse {

	public static void main(String[] args) {
		
		int count = 0;
		
		// card
		for (int firstCard = 0; firstCard < 13; firstCard++) {
			
			for (int secondCard = 0; secondCard < 13; secondCard++) {
				
				for (int thirdCard = 0; thirdCard < 13; thirdCard++) {
					
					for (int forthCard = 0; forthCard < 13; forthCard++) {
						
						for (int fifthCard = 0; fifthCard < 13; fifthCard++) {
							
							if(card(firstCard) == card(secondCard) && card(secondCard) == card(thirdCard) && card(forthCard) == card(fifthCard) && card(firstCard) != card(forthCard)){
								
								// suit
								for (int suitOne = 0; suitOne < 4; suitOne++) {
									
									for (int suitTwo = suitOne + 1; suitTwo < 4; suitTwo++) {
										
										for (int suitThree = suitTwo + 1; suitThree < 4; suitThree++) {
											
											for (int suitFour = 0; suitFour < 4; suitFour++) {
												
												for (int suitFive = suitFour + 1; suitFive < 4; suitFive++) {
													
													if(suitOne != suitTwo && suitOne != suitThree && suitTwo != suitThree && suitFour != suitFive){
														
														System.out.print("(" + card(firstCard)+suit(suitOne) + " " + card(secondCard)+suit(suitTwo) + " " + 
																card(thirdCard)+suit(suitThree) + " " + card(forthCard)+suit(suitFour) + " " + 
																card(fifthCard)+suit(suitFive) + ")   ");
														
														count++;
														
														if(count%3==0){
															System.out.println();
														}
														
													}
													
												}
												
											}
											
										}
										
									}
									
								}
							}
							
						}
						
					}
					
				}
				
			}
			
		}
		
		System.out.println(count + " full houses");
		
	}

	private static String suit(int y) {
		
		String suit = null;
		
		switch(y){
		
			case 0: suit="\u2663"; break;
			case 1: suit="\u2666"; break;
			case 2: suit="\u2665"; break;
			case 3: suit="\u2660"; break;
		
		}
		
		return suit;
		
	}

	private static String card(int x) {
		
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
