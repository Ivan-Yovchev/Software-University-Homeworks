import java.util.Date;

public class CurrentDateTime {

	public static void main(String[] args) {
		
		Date now = new Date();
		
		System.out.printf("%1$td/%1$tm/%1$tY %1$tH:%1$tM", now);

	}

}
