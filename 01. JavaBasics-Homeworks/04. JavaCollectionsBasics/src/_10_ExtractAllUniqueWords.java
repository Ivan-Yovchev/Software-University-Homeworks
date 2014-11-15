import java.util.Scanner;
import java.util.TreeSet;


public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] data = input.nextLine().split("[ .,:?]+");
		
		TreeSet<String> uniqueWords = new TreeSet<>();
		for (int i = 0; i < data.length; i++) {
			uniqueWords.add(data[i].toLowerCase());
		}
		
		
		for (String word : uniqueWords) {
			System.out.print(word + " ");
		}
		System.out.println();
	}

}
