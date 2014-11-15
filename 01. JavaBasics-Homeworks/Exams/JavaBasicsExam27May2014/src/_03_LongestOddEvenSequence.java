import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _03_LongestOddEvenSequence {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String inputLine = input.nextLine();
		
		ArrayList<Integer> numbers = new ArrayList<>();
		
		Matcher match = Pattern.compile("-?[0-9]+").matcher(inputLine);
		
		while(match.find()){
			numbers.add(Integer.parseInt(match.group()));
		}
		
		int maxCount = 0 ;
		for (int i = 0; i < numbers.size() - 1; i++) {
			
			int number = numbers.get(i);
			int count = 1;
		
			for (int j = i + 1; j < numbers.size(); j++) {
				
				int numberToCompare = numbers.get(j);
				
				if(numberToCompare == 0){
					count++;
					number++;
				}
				else{
					
					if(number % 2 == 0 && numberToCompare % 2 != 0){
						count++;
						number++;
					}
					else if(number % 2 != 0 && numberToCompare % 2 == 0){
						count++;
						number++;
					}
					else{
						break;
					}
					
				}
				
			}
			
			if(count > maxCount){
				maxCount = count;
			}
			
		}
		
		System.out.println(maxCount);
		
	}

}
