import java.util.Scanner;


public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] elements = input.nextLine().split(" ");
		
		String maxElement = null;
		int maxCount = Integer.MIN_VALUE;
		
		for (int i = 0; i < elements.length; i++) {
			
			String temp = elements[i];
			int count = 1;
			
			for (int j = i + 1; j < elements.length; j++) {
				
				if(temp.equals(elements[j])){
					count++;
				}
				else{
					break;
				}
				
			}
			
			if(count > maxCount){
				maxCount = count;
				maxElement = temp;
			}
			
			i = i + count - 1;
			
		}
		
		for (int i = 0; i < maxCount; i++) {
			
			System.out.print(maxElement + " ");
			
		}
		System.out.println();
		
	}

}
