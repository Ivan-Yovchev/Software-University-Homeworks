import java.util.Scanner;


public class TriangleArea {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int Ax = input.nextInt();
		int Ay = input.nextInt();
		int Bx = input.nextInt();
		int By = input.nextInt();
		int Cx = input.nextInt();
		int Cy = input.nextInt();
		
		int area = Math.abs(((Ax*(By-Cy)) + (Bx*(Cy-Ay)) + (Cx*(Ay-By)))/2); 
		
		if(area > 0){
			System.out.println("Area: " + area);
		}
		else{
			System.out.println("Area: " + 0);
		}
		
	}

}
