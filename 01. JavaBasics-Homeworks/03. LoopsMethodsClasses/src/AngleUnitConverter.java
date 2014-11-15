import java.util.Locale;
import java.util.Scanner;


public class AngleUnitConverter {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		input.nextLine();
		
		String[] toConvert = new String[n]; 
		
		// input
		for (int i = 0; i < n; i++) {
			
			toConvert[i] = input.nextLine();
			
		}
		
		// convert
		for (int i = 0; i < toConvert.length; i++) {
			
			String[] data = toConvert[i].split(" ");
			
			if(data[1].equals("deg")){
				
				double deg = Double.parseDouble(data[0]);
				double rad = Math.toRadians(deg);
				System.out.printf("%.6f rad",rad);
				System.out.println();
				
			}
			else if(data[1].equals("rad")){
				
				double rad = Double.parseDouble(data[0]);
				double deg = Math.toDegrees(rad);
				System.out.printf("%.6f deg",deg);
				System.out.println();
				
			}
		}
	}

}
