import java.util.Scanner;


public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] text = input.nextLine().split("[., !()-?']+");
		String word = input.nextLine();
		
		int count = 0;
		for (String stringWord : text) {
			
			if(stringWord.toUpperCase().equals(word.toUpperCase())){
				count++;
			}
			
		}
		
		System.out.println(count);
		
	}

}
