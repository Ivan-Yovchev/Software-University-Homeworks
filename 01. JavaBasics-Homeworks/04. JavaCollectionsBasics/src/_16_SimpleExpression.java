import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _16_SimpleExpression {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String data = input.nextLine().replace(" ", "");
		Matcher match = Pattern.compile("(-?[0-9]+)(\\.[0-9]+)?").matcher(data);
		
		ArrayList<String> expression = new ArrayList<>();
		
		while(match.find()){
			expression.add(match.group());
		}
		
		BigDecimal sum = new BigDecimal("0");
		for (int i = 0; i < expression.size(); i++) {
			BigDecimal temp = new BigDecimal(expression.get(i));
			sum = sum.add(temp);
		}
		
		System.out.println(sum);
	}
	
}
