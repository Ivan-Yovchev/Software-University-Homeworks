import java.util.ArrayList;
import java.util.Scanner;


public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String temp = input.nextLine();
		ArrayList<Character> letters1 = new ArrayList<Character>();
		for (int i = 0; i < temp.length(); i+=2) {
			letters1.add(temp.charAt(i));
		}
		
		temp = input.nextLine();
		ArrayList<Character> letters2 = new ArrayList<Character>();
		for (int i = 0; i < temp.length(); i+=2) {
			letters2.add(temp.charAt(i));
		}
		
		ArrayList<Character> finalArrayList = new ArrayList<Character>();
		finalArrayList.addAll(letters1);
		for (int i = 0; i < letters2.size(); i++) {
			
			char letter = letters2.get(i);
			boolean repeat = false;
			
			for (int j = 0; j < letters1.size(); j++) {
				
				if(letter == letters1.get(j)){
					repeat = true;
					break;
				}
				else{
					continue;
				}
				
			}
			
			if(repeat == false){
				finalArrayList.add(letter);
			}
			
		}
		
		for (Character ch : finalArrayList) {
			System.out.print(ch + " ");
		}
		System.out.println();
	}

}
