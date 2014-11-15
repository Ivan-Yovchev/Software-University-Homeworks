import java.util.Arrays;
import java.util.Scanner;


public class _01_SortArrayOfNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		int[] numbers = new int[n];
		
		for (int i = 0; i < numbers.length; i++) {
			
			numbers[i] = input.nextInt();
			
		}
		
		Arrays.sort(numbers);
		
		for (int num : numbers) {
			System.out.print(num + " ");
		}
		System.out.println();

	}

}
