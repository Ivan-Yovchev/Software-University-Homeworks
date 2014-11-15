import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_Orders {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		input.nextLine();
		
		LinkedHashSet<String> order = new LinkedHashSet<>();
		HashMap<String, TreeMap<String,Integer>> customers = new HashMap<>();
		
		for (int i = 0; i < n; i++) {
			
			String[] data = input.nextLine().split(" ");
			
			if(customers.containsKey(data[2])){
				
				TreeMap<String, Integer> temp = customers.get(data[2]);
				Integer oldAmount = temp.get(data[0]);
				if(oldAmount == null){
					oldAmount = 0;
				}
				oldAmount += Integer.parseInt(data[1]);
				temp.put(data[0], oldAmount);
				customers.put(data[2], temp);
				
			}
			else {
				
				TreeMap<String, Integer> temp = new TreeMap<>();
				Integer amount = Integer.parseInt(data[1]);
				temp.put(data[0], amount);
				customers.put(data[2], temp);
				order.add(data[2]);
				
			}
			
		}
		
		Iterator<String> itr = order.iterator();
		while (itr.hasNext()){
			
			String index = itr.next();
			String output = index + ": ";
			
			TreeMap<String, Integer> temp = customers.get(index);
			for (Map.Entry<String, Integer> data : temp.entrySet()) {
				
				output += data.getKey() + " " + data.getValue() + ", ";
			}
			
			String finalOutput = output.substring(0,output.length() - 2);
			
			System.out.println(finalOutput);
			
		}
		
	}
	
}
