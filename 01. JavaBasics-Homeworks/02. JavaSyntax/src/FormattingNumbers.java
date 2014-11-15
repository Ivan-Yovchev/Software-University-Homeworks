import java.util.Locale;
import java.util.Scanner;


public class FormattingNumbers {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int a = input.nextInt();
		double b = input.nextDouble();
		double c = input.nextDouble();
		
		// convert to hex, align left pad, with empty spaces 
		System.out.printf("|%-10H",a);
		
		//convert to binary, pad with zeros
		String binary = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
		System.out.printf("|%s",binary);
		
		// 2 digits after decimal point, right aligned
		String floatB = String.format("%.2f", b);
		System.out.printf("|%10s",floatB);
		
		// 3 digits after decimal point, left aligned
		String floatC = String.format("%.3f", c);
		System.out.printf("|%-10s|",floatC);
	}

}
