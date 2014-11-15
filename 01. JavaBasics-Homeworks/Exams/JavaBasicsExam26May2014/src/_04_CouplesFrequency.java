import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;


public class _04_CouplesFrequency {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] inputLine = input.nextLine().split(" ");
		int n = inputLine.length - 1;

		HashMap<String, String> couples = new HashMap<>();
		
		for (int i = 0; i < inputLine.length - 1; i++) {
			
			String couple = inputLine[i] + " " + inputLine[i + 1];
			
			if(couples.containsKey(couple)){
				continue;
			}
			else {
				Integer count = 1;
				
				for (int j = i + 1; j < inputLine.length - 1; j++) {
					
					String toCompare = inputLine[j] + " " + inputLine[j + 1];
					
					if(couple.equals(toCompare)){
						count++;
					}
					
				}
				
				double percent = (count * 100.0)/n;
				String outputPercent = String.format("%.2f", percent);
				
				couples.put(couple, outputPercent);
				
			}
			
		}
		
		for (int i = 0; i < inputLine.length - 1; i++) {
			String couple = inputLine[i] + " " + inputLine[i + 1];
			
			if(couples.containsKey(couple) && couples.get(couple) != "repeat"){
				System.out.println(couple + " -> " + couples.get(couple) + "%");
				
				couples.put(couple, "repeat");
			}
			
		}
		
	}

}
