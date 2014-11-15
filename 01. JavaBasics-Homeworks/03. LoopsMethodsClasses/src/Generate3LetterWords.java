import java.util.Scanner;


public class Generate3LetterWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String letters = input.nextLine();
		
		int format = 0;
		
		char[] symbols = letters.toCharArray();
		
		for (int a = 0; a < symbols.length; a++) {
			
			for (int b = 0; b < symbols.length; b++) {
				
				for (int c = 0; c < symbols.length; c++) {
					
					System.out.print("" + symbols[a] + symbols[b] + symbols[c] + " ");
					
					format++;
					
					if(format % 19 == 0){
						System.out.println();
					}
				}
				
			}
			
		}
		
	}

}
