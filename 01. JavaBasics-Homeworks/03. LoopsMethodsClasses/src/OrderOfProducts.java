import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;


public class OrderOfProducts {

	public static void main(String[] args) {
		
		Locale.setDefault(Locale.ROOT);
		
		ArrayList<Product> products = new ArrayList<Product>();
		
		double outPutSum = 0;
		
		// get products
		try( BufferedReader fileReader = new BufferedReader(new FileReader("Products.txt"))){
			
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
			  
			  
			  
			} catch (IOException ioex) {
			  System.out.println("Error");
			}
		
		// get product and price
		try( BufferedReader fileReader = new BufferedReader(new FileReader("Order.txt"));
				BufferedWriter writer = new BufferedWriter(new FileWriter("Output.txt"));){
			
			  while (true) {
				  
				  String line = fileReader.readLine();
					if(line == null){
						
						break;
						
					}
					else{
						
						String[] split = line.split(" ");
						
						// sum
						for (Product product : products) {
							
							if(product.getName().equals(split[1])){
								outPutSum += product.getPrice() * Double.parseDouble(split[0]);
							}
							
						}
						
					}
			  }
			  
			  String sum = String.format("%.1f", outPutSum);
			  writer.write(sum);
			  writer.close();
			  
			  
			} catch (IOException ioex) {
			  System.out.println("Error");
			}
		
	}

}