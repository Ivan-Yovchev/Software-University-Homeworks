import java.util.Scanner;


public class Durts {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		double crossX = input.nextDouble();
		double crossY = input.nextDouble();
		double crossR = input.nextDouble();
		
		int thrownDarts = input.nextInt();
		
		// split cross into two rectangles
		
		// end points of horizontal rect.
		double startXHor = crossX - crossR;
		double endXHor = crossX + crossR;
		double startYHor = crossY - (crossR/2);
		double endYHor = crossY + (crossR/2);
		
		// end points of vertical rect.
		double startXVer = crossX - (crossR/2);
		double endXVer = crossX + (crossR/2);
		double startYVer = crossY - crossR;
		double endYVer = crossY + crossR;
		
		for (int i = 0; i < thrownDarts; i++) {
			
			int dartX = input.nextInt();
			int dartY = input.nextInt();
			
			if(dartX >= startXHor && dartX <= endXHor && dartY >= startYHor && dartY <= endYHor){
				System.out.println("yes");
			}
			else if(dartX >= startXVer && dartX <= endXVer && dartY >= startYVer && dartY <= endYVer){
				System.out.println("yes");
			}
			else{
				System.out.println("no");
			}
			
		}
		
	}

}
