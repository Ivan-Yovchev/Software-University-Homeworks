import java.util.Scanner;


public class _05_CountAllWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] text = input.nextLine().split("[., !()-?']+");
		
		System.out.println(text.length);
		
	}

}
