import java.util.Locale;
import java.util.Scanner;


public class TheSmallestOf3Numbers {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();
		
		double min = Math.min(a, b);
		
		min = Math.min(min, c);
		
		if(min == (int)min){
			System.out.println("Smallest: " + (int)min);
		}
		else {
			System.out.println("Smallest: " + min);
		}
	}

}
