import java.util.Scanner;
import java.util.TreeMap;


public class _11_MostFrequentWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		TreeMap<String, Integer> words = new TreeMap<String,Integer>();
		
		// fill tree with words
		String[] data = input.nextLine().toLowerCase().split("[ .,:?]+");
		for (int i = 0; i < data.length; i++) {
			
			Integer count = words.get(data[i]);
			if(count == null){
				count = 0;
			}
			
			words.put(data[i], count + 1);
			
		}
		
		//get the highest count of a word
		Integer maxCount = Integer.MIN_VALUE;
		for(String word : words.keySet()){
			
            int count = words.get(word);
            if(count > maxCount) {
            	
                    maxCount = count;
                    
            }
    }
		
		for(String word : words.keySet()){                
            int count = words.get(word);
            if(count == maxCount){
                    System.out.printf("%s -> %d times", word, count);
                    System.out.println();
            }
    }
		
	}

}
