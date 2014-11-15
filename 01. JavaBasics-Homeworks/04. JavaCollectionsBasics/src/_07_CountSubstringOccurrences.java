import java.util.Scanner;


public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String str = input.nextLine().toLowerCase();
        String word = input.nextLine().toLowerCase();
        int counter = 0;
       
        for (int i = 0; i <= str.length() - word.length(); i++) {
                if(str.substring(0 + i, word.length() + i).contains(word)){
                        counter++;
                }
        }
        System.out.println(counter);
		
	}

}
