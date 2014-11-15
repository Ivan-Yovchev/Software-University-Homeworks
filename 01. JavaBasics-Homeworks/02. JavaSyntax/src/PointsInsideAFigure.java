import java.util.Locale;
import java.util.Scanner;


public class PointsInsideAFigure {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		double x = input.nextDouble();
		double y = input.nextDouble();
		
		// split shape into three smaller shapes
		
		//first shape (roof)
		if(y >= 6 && y<=8.5 && x >=12.5 && x <=22.5){
			System.out.println("Inside");
		}
		//second shape (left wall)
		else if(y>=8.5 && y<=13.5 && x>=12.5 && x<=17.5){
			System.out.println("Inside");
		}
		// third shape (right wall)
		else if(y>=8.5 && y<=13.5 && x >= 20 && x<=22.5){
			System.out.println("Inside");
		}
		else{
			System.out.println("Outside");
		}
		
	}

}
