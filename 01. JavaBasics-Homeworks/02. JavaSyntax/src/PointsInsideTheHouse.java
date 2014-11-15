import java.util.Locale;
import java.util.Scanner;


public class PointsInsideTheHouse {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		for (int i = 0; i < 28; i++) {
			
			double x = input.nextDouble();
			double y = input.nextDouble();
			
			// split shape into three smaller shapes
			
			// first shape (roof)
			if(y <= 8.5){
				
				// end points of triangle
				double aPointX = 12.5;
				double aPointY = 8.5;
				double bPointX = 17.5;
				double bPointY = 3.5;
				double cPointX = 22.5;
				double cPointY = 8.5;
				
				int AB = (int)((bPointX - aPointX)*(y -  aPointY) - (bPointY - aPointY)*(x - aPointX));
				int BC = (int)((cPointX - bPointX)*(y - bPointY) - (cPointY - bPointY)*(x - bPointX));
				
				if(AB >= 0 && BC >= 0){
					System.out.println("Inside");
				}
				else{
					System.out.println("Outside");
				}
			}
			else if(y >= 8.5 && y <= 13.5){

				// second shape (left wall) or third shape(right wall)
				if((x >= 12.5 && x <= 17.5) || (x >= 20 && x <= 22.5)){
					System.out.println("Inside");
				}
				else{
					System.out.println("Outside");
				}
				
			}
			else{
				System.out.println("Outside");
			}
			
		}
		
	}

}
