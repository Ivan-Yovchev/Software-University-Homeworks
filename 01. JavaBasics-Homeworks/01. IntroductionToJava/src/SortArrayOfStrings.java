import java.util.Arrays;
import java.util.Scanner;


public class SortArrayOfStrings {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		String[] arr = new String[n];
		
		for (int i = 0; i < n; i++) {
		
			arr[i] = input.next();
			
		}
		
		Arrays.sort(arr);
		
		for (int i = 0; i < arr.length; i++) {
			
			System.out.println(arr[i]);
			
		}

	}

}
