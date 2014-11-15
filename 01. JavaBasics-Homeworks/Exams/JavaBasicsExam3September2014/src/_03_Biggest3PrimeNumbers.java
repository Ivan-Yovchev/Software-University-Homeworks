import java.util.Collections;
import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _03_Biggest3PrimeNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String data = input.nextLine();
		
		Matcher match = Pattern.compile("-?[0-9]+").matcher(data);
		
		TreeSet<Integer> numbers = new TreeSet<>(Collections.reverseOrder());
		
		while (match.find()){
			Integer number = Integer.parseInt(match.group());
			if(isPrime(number) == true){
				numbers.add(number);
			}
		}
		
		int maxSum = 0;
		int primeCounter = 0;
		for (Integer number : numbers) {
			primeCounter++;
			maxSum += number;
			
			if(primeCounter == 3){
				break;
			}
		}
	
		if(primeCounter != 3){
			System.out.println("No");
		}
		else {
			System.out.println(maxSum);
		}
		
		}

	private static boolean isPrime(int number) {
		boolean prime = true;
		
		if(number <= 1){
			prime = false;
		}
		else{
				for (int i = 2; i <= Math.sqrt(number); i++) {
				
				if(number % i == 0){
					prime = false;
					break;
			}
		}
	}
		
		return prime;
	}

}
