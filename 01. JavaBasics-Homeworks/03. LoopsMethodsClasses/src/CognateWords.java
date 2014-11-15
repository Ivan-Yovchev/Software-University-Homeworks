import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class CognateWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		// match all words
		String inputLine = input.nextLine();
        String textRegEx = "[a-zA-Z]+";
        Pattern textPattern = Pattern.compile(textRegEx);
        Matcher matcher = textPattern.matcher(inputLine);
       
        ArrayList<String> words = new ArrayList<>();
        
        // fill an array with all matching words
        while(matcher.find()){
        	words.add(matcher.group());
        }
        
        ArrayList<String> rememberPrintedWords = new ArrayList<>();
        boolean isOutput = false;
        
        // find all cognate words
        for (int i = 0; i < words.size(); i++) {
			
        	String a = words.get(i);
        	
        	for (int j = 0; j < words.size(); j++) {
			
        		String b = words.get(j);
        		
        		for (int k = 0; k < words.size(); k++) {
					
        			if(k == i || k == j){
        				continue;
        			}
        			else {
						String c = words.get(k);
						
						if((a + b).equals(c)){
							if(rememberPrintedWords.contains(c)){
								continue;
							}
							else {
								rememberPrintedWords.add(c);
								System.out.println(a + "|" + b + "=" + c);
								isOutput = true;
							}
						}
					}
				}
        		
			}
        	
		}
        
        if(isOutput == false){
        	System.out.println("No");
        }
        
	}

}
