import java.util.Scanner;


public class _01_VideoDurations {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int hours = 0;
		int minutes = 0;
		
		while(true){
			
			String inputLine = input.nextLine();
			if(inputLine.equals("End")){
				break;
			}
			
			String[] data = inputLine.split(":");
			int hour = Integer.parseInt(data[0]);
			int minute = Integer.parseInt(data[1]);
			
			hours += hour;
			minutes += minute;
		}
		
		if(minutes >= 60){
			hours += minutes/60;
			minutes = minutes%60;
		}
		
		String finalHours = Integer.toString(hours);
		String finalMinutes = String.format("%02d", minutes);
		
		System.out.println(finalHours + ":" + finalMinutes);
		
	}

}
