package _02.OnelvShop;

import java.math.BigDecimal;
import java.math.RoundingMode;

public abstract class Product implements Buyable {
	private String name;
	private BigDecimal price;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setPrice(new BigDecimal(price));
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}

	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		if(name.length() <=0 || name == null){
			throw new NullPointerException("Name cannot be null or empty");
		}
		else{
			this.name = name;
		}
	}
	
	public int getQuantity() {
		return quantity;
	}
	
	public void setQuantity(int quantity) {
		if(quantity < 0){
			throw new IllegalArgumentException("Quantity cannot be negative");
		}
		else{
			this.quantity = quantity;
		}
	}

	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}

	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}

	public void setPrice(BigDecimal price) {
		if(price.compareTo(new BigDecimal("0.0")) <= 0){
			throw new IllegalArgumentException("Price cannot be zero or negative");
		}
		else{
			this.price = price;
		}
	}

	@Override
	public double getPrice() {
		return this.price.doubleValue();
	}

	@Override
	public String toString() {
		return "Product Name: " + this.name + 
				"\nPrice: " + this.price.setScale(2, RoundingMode.FLOOR) + 
				"\nQuantity: " + this.quantity + 
				"\nAgeRestriction: " + this.ageRestriction + "\n";
	}
}
