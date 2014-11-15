import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Locale;


public class ListOfProducts {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		ArrayList<Product> products = new ArrayList<Product>();
		
		try( BufferedReader fileReader = new BufferedReader(new FileReader("Input.txt"));
				BufferedWriter writer = new BufferedWriter(new FileWriter("Output.txt"));){
			
			  while (true) {
				  
				  String line = fileReader.readLine();
					if(line == null){
						
						break;
						
					}
					else{
						
						String[] split = line.split(" ");
						Product newProduct = new Product(split[0], Float.parseFloat(split[1]));
						products.add(newProduct);
						
					}
			  }
			  
			  Collections.sort(products);
			    
			  for(Product product : products){
				  
				  String producString = String.format("%.2f ", product.getPrice());
				  
                  writer.write(producString + product.getName() +  "\r\n");
			  		}
			  writer.close();
			  
			} catch (IOException ioex) {
			  System.out.println("Error");
			}
		
	}

}
