import java.util.Scanner;


public class CountOfEqualBitPairs {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		int count = 0;
		
		System.out.println("Binary representation of n: " + Integer.toBinaryString(n));
		
		while(n != 0){
			
			if(((n & 1) != 0) && ((n & 2) != 0)){
				count++;
			}
			else if(((n & 1) == 0) && ((n & 2) == 0)){
				count++;
			}
			
			n >>=1;
			
		}
		
		System.out.println("Count of equal bits: " + count);
		
	}

}
