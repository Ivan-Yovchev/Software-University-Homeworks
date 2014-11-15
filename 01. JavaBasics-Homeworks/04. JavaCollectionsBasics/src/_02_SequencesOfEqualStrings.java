import java.util.Scanner;


public class _02_SequencesOfEqualStrings {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] strings = input.nextLine().split(" ");
		
		for (int i = 0; i < strings.length; i++) {
			
			String element = strings[i];
			int count = 1;
			
			for (int j = i + 1; j < strings.length; j++) {
				
				if(element.equals(strings[j])){
					count++;
				}
				else{
					break;
				}
			}
			
			for (int print = 0; print < count; print++) {
				System.out.print(element + " ");
			}
			System.out.println();
			
			i = i + count - 1;
			
		}
		
	}

}
