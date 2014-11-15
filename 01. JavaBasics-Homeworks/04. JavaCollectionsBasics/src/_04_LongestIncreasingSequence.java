import java.util.Scanner;


public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] numbers = input.nextLine().split(" ");
		
		String longestSequence = null;
		int maxCount = Integer.MIN_VALUE;
		
		for (int i = 0; i < numbers.length; i++) {
			
			int temp = Integer.parseInt(numbers[i]);
			int count = 1;
			String currentSequence = numbers[i] + " ";
			
			for (int j = i + 1; j < numbers.length; j++) {
				
				if(Integer.parseInt(numbers[j]) > temp){
					count++;
					currentSequence += numbers[j] + " ";
					temp = Integer.parseInt(numbers[j]);
				}
				else {
					break;
				}
				
			}
			
			System.out.println(currentSequence);
			
			if(count > maxCount){
				longestSequence = currentSequence;
				maxCount = count;
			}
			
			i = i + count - 1;
			
		}
		
		System.out.println("Longest: " + longestSequence);
		
	}

}
