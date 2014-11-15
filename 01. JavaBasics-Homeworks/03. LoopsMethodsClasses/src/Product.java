
public class Product implements Comparable<Product>{
	
	private String name;
	private float price;
	
	public Product(String name, float price) {
		this.name = name;
		this.price = price;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public float getPrice() {
		return price;
	}

	public void setPrice(float price) {
		this.price = price;
	}
	
	 public int compareTo(Product compareProduct) {
         
         float otherPrice = ((Product) compareProduct).getPrice();

         //ascending order
         if(this.price>otherPrice) return 1;
         else
         if(this.price==otherPrice) return 0;
         return -1;
	 }
	
}