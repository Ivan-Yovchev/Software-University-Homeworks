import java.util.Scanner;


public class SymmetricNumbersInRange {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int start = input.nextInt();
		int end = input.nextInt();
		
		int format = 0;
		
		for (int i = start; i <= end; i++) {
			
			String number = Integer.toString(i);
			
			if(isSymmetric(number) == true){
				
				System.out.print(i + " ");
				
				format++;
				
				if(format % 18 == 0){
					System.out.println();
				}
			}
		}

		System.out.println();
	}

	private static boolean isSymmetric(String str) {
		
		boolean symmetric = false;
		
		if(str.length() == 1){
			symmetric = true;
		}
		else if(str.length() == 2){
			
			if(str.charAt(0) == str.charAt(1)){
				symmetric = true;
			}
			
		}
		else if(str.length() == 3){
		
			if(str.charAt(0) == str.charAt(2)){
				symmetric = true;
			}
			
		}
		
		return symmetric;
	}

}
