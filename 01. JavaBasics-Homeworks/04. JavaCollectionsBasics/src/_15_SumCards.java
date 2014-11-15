import java.util.ArrayList;
import java.util.Scanner;


public class _15_SumCards {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] inputLine = input.nextLine().split(" ");
		
		ArrayList<String> cards = new ArrayList<>();
		
		// get cards
		for (int i = 0; i < inputLine.length; i++) {
			
			String face = "";
			
			if(inputLine[i].length() == 3){
				face += "10";
			}
			else{
				face += inputLine[i].charAt(0);
			}
			
			cards.add(face);
		}
		
		// calculate sum
		long sum = 0;
		for (int i = 0; i < cards.size(); i++) {
			
			String face = cards.get(i);
			int count = 1;
			
			for (int j = i + 1; j < cards.size(); j++) {
				if(face.equals(cards.get(j))){
					count++;
				}
				else{
					break;
				}
			}
			
			if(count > 1){
				sum += (getFaceValue(face)*count)*2;
				i += count - 1;
			}
			else if(count == 1){
				sum += getFaceValue(face);
			}
		}
		
		System.out.println(sum);
		
	}

	private static int getFaceValue(String face) {
		
		int value = 0;
		
		switch (face) {
		
			case "2": value = 2; break;
			case "3": value = 3; break;
			case "4": value = 4; break;
			case "5": value = 5; break;
			case "6": value = 6; break;
			case "7": value = 7; break;
			case "8": value = 8; break;
			case "9": value = 9; break;
			case "10": value = 10; break;
			case "J": value = 12; break;
			case "Q": value = 13; break;
			case "K": value = 14; break;
			case "A": value = 15; break;
		
		}
		
		return value;
	}

}
