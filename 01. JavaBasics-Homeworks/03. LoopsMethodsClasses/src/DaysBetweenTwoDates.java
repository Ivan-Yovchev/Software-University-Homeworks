import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.Locale;
import java.util.Scanner;


public class DaysBetweenTwoDates {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] date = input.nextLine().split("-");
		
		LocalDate startDate = LocalDate.of(Integer.parseInt(date[2]),Integer.parseInt(date[1]), 
				Integer.parseInt(date[0]));
		
		date = input.nextLine().split("-");
		
		LocalDate endDate = LocalDate.of(Integer.parseInt(date[2]),Integer.parseInt(date[1]),
				Integer.parseInt(date[0]));
		
		long days = ChronoUnit.DAYS.between(startDate, endDate);
		
		System.out.println(days);
	}

}
