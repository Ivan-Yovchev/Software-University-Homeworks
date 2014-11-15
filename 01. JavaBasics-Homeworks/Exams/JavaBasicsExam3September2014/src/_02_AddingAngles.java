import java.util.Scanner;


public class _02_AddingAngles {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		input.nextLine();
		
		boolean isOutput = false;
		
		int[] degrees = new int[n];
		
		String[] data = input.nextLine().split(" ");
		for (int i = 0; i < data.length; i++) {
			degrees[i] = Integer.parseInt(data[i]);
		}
		
		for (int a = 0; a < degrees.length; a++) {
			for (int b = a + 1; b < degrees.length; b++) {
				for (int c = b + 1; c < degrees.length; c++) {
					
					int circle = degrees[a] + degrees[b] + degrees[c];
					
					if(circle%360 == 0){
						System.out.println(degrees[a] + " + " + degrees[b] + " + " + degrees[c] + " = " + circle + " degrees");
						isOutput = true;
					}
					
				}
			}
		}
		
		if(isOutput == false){
			System.out.println("No");
		}
		
	}

}
