import java.util.Scanner;


public class CountOfBitsOne {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		
		int count = 0;
		
		String binary = String.format("%16s", Integer.toBinaryString(n)).replace(' ', '0');
		System.out.printf("Binary representation of n: %1$10s",binary);
		System.out.println();
		
		while(n != 0){
			
			if((n & 1) == 1){
				count++;
			}
			
			n >>=1;
		}
		
		System.out.println("Count of bits 1: " + count);
		
	}

}
