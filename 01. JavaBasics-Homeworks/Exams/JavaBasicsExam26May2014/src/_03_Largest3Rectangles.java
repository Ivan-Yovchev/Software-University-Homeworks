import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _03_Largest3Rectangles {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String inputLine = input.nextLine().replace(" ", "");
		
		ArrayList<String> rectangles = new ArrayList<>();
		
		Matcher matcher = Pattern.compile("[0-9]+x[0-9]+").matcher(inputLine);
		
		while(matcher.find()){
			rectangles.add(matcher.group());
		}
		
		int maxArea = Integer.MIN_VALUE;
		for (int a = 0; a < rectangles.size(); a++) {
			for (int b = 0; b < rectangles.size(); b++) {
				for (int c = 0; c < rectangles.size(); c++) {
					
					if(a == b + 1 && b == c + 1){
						String[] rect1 = rectangles.get(a).split("x");
						int areaOne = Integer.parseInt(rect1[0])*Integer.parseInt(rect1[1]);
						
						String[] rect2 = rectangles.get(b).split("x");
						int areaTwo = Integer.parseInt(rect2[0])*Integer.parseInt(rect2[1]);
						
						String[] rect3 = rectangles.get(c).split("x");
						int areaThree = Integer.parseInt(rect3[0])*Integer.parseInt(rect3[1]);
						
						if((areaOne + areaTwo + areaThree) > maxArea){
							maxArea = areaOne + areaTwo + areaThree;
						}
					}
					
				}
			}
		}
		
		System.out.println(maxArea);
		
	}

}
