import java.util.Scanner;


public class _02_PythagoreanNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		int[] numbers = new int[n];
		
		for (int i = 0; i < n; i++) {
			numbers[i] = input.nextInt();
		}
		
		boolean isOutput = false;
		
		for (int a = 0; a < numbers.length; a++) {
			for (int b = 0; b < numbers.length; b++) {
				for (int c = 0; c < numbers.length; c++) {
					
					if(numbers[a] <= numbers[b]){
						
						int result = (numbers[a]*numbers[a]) + (numbers[b]*numbers[b]);
						
						if(result == numbers[c]*numbers[c]){
							
							System.out.printf("%1$d*%1$d + %2$d*%2$d = %3$d*%3$d",numbers[a],numbers[b],numbers[c]);
							System.out.println();
							isOutput = true;
						}
						
					}
					
				}
			}
		}
		
		if(isOutput == false){
			System.out.println("No");
		}
		
	}

}
