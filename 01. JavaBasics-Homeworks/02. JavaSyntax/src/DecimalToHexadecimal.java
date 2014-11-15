import java.util.Scanner;


public class DecimalToHexadecimal {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		System.out.printf("%1$H",n);
		System.out.println();
		
	}

}
