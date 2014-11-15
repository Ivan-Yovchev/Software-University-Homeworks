import java.util.Scanner;


public class SumTwoNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int a = input.nextInt();
		int b = input.nextInt();
		
		int sum = a + b;
		
		System.out.println(sum);
		
	}

}