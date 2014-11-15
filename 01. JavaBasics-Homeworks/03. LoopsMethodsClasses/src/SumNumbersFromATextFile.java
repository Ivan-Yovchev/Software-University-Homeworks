import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class SumNumbersFromATextFile {

	static int sum = 0;
	
	public static void main(String[] args) throws IOException {
		
		try( BufferedReader fileReader = new BufferedReader(new FileReader("Input.txt"));) {
			  while (true) {
				  
				  String line = fileReader.readLine();
					if(line == null){
						
						break;
						
					}
					else{
						
						int number  = Integer.parseInt(line);
						sum += number;
						
					}
			  }
			  
			  System.out.println(sum);
			    
			    
			} catch (IOException ioex) {
			  System.out.println("Error");
			}
		
	}

}