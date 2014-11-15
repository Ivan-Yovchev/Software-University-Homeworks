import java.util.Scanner;
import java.util.TreeMap;


public class _04_ActivityTracker {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		input.nextLine();
		
		TreeMap<Integer, TreeMap<String, Integer>> log = new TreeMap<>();
		
		for (int i = 0; i < n; i++) {
			
			String[] data = input.nextLine().split(" ");
			int date = Integer.parseInt(data[0].split("/")[1]);
			
			if(log.containsKey(date)){
				
				TreeMap<String, Integer> temp = log.get(date);
				
				if(temp.containsKey(data[1])){
					Integer oldDistance = temp.get(data[1]);
					oldDistance += Integer.parseInt(data[2]);
					temp.put(data[1], oldDistance);
				}
				else{
					Integer distance = Integer.parseInt(data[2]);
					temp.put(data[1], distance);
				}
				
			}
			else{
				TreeMap<String, Integer> newMap = new TreeMap<>();
				Integer distance = Integer.parseInt(data[2]);
				newMap.put(data[1], distance);
				log.put(date, newMap);
			}
		}
		
		for (Integer date : log.keySet()) {
			
			String line = "" + date + ": ";
			
			TreeMap<String, Integer> nameAndDistance = log.get(date);
			for (String name : nameAndDistance.keySet()) {
				line += name+"("+nameAndDistance.get(name)+"), ";
			}
			
			String output = line.substring(0,line.length() - 2);
			System.out.println(output);
		}
		
	}

}
