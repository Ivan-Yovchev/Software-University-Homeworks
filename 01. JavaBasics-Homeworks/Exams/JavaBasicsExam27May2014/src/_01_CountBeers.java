import java.util.Scanner;


public class _01_CountBeers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int stacks = 0;
		int beers = 0;
		while(true){
			
			String inputLine = input.nextLine();
			if(inputLine.equals("End")){
				break;
			}
			
			String[] beerData = inputLine.split(" ");
			
			int getBeers = Integer.parseInt(beerData[0]);
			if(beerData[1].equals("stacks")){
				getBeers *= 20;
			}
			
			beers += getBeers;
			
		}
		
		stacks = beers/20;
		beers = beers%20;
		
		System.out.println(stacks + " stacks + " + beers + " beers");
		
	}

}
