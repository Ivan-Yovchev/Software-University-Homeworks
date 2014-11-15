import java.util.Scanner;


public class _14_StuckNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		int[] numbers = new int[n];
		
		boolean isOutput = false;
		
		// get numbers
		for (int i = 0; i < n; i++) {
			numbers[i] = input.nextInt();
		}
		
		// get stuck numbers
		for (int firstNum = 0; firstNum < numbers.length; firstNum++) {
			for (int secondNum = 0; secondNum < numbers.length; secondNum++) {
				for (int thirdNum = 0; thirdNum < numbers.length; thirdNum++) {
					for (int forthNum = 0; forthNum < numbers.length; forthNum++) {
						
						int a = numbers[firstNum];
						int b = numbers[secondNum];
						int c = numbers[thirdNum];
						int d = numbers[forthNum];
						
						
						if(a != b && a != c && a != d && b != c && b != d && c != d){
							String left = "" + a + b;
							String right = "" + c + d;
							
							if(left.equals(right)){
								System.out.println(a + "|" + b + "==" + c + "|" + d);
								isOutput = true;
							}
						}
					}
				}
			}
		}
		
		if(isOutput == false){
			System.out.println("No");
		}
		
	}

}
