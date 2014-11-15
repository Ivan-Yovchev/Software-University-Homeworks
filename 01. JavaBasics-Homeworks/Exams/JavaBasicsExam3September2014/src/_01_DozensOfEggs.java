import java.util.Scanner;


public class _01_DozensOfEggs {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int eggsWeekly = 0;
		
		for (int i = 0; i < 7; i++) {
			
			String[] countMeasure = input.nextLine().split(" ");
			int eggs = Integer.parseInt(countMeasure[0]);
			if(countMeasure[1].equals("dozens")){
				eggs *= 12;
			}
			
			eggsWeekly += eggs;
			
		}
		
			int dozens = eggsWeekly/12;
			int eggs = eggsWeekly%12;
			System.out.println(dozens + " dozens + " + eggs + " eggs");
	}

}
