package _02.OnelvShop;

import java.math.BigDecimal;
import java.util.Date;

public final class PurchaseManager {
	public static void ProcessPurchase(Product product, Customer customer) {
		if(product.getQuantity() <= 0){
			throw new IllegalArgumentException("Product is out of stock");
		}
		
		if(product instanceof FoodProduct){
			Date now = new Date();
			if(((Expirable) product).getExpirationDate().compareTo(now) < 0){
				throw new IllegalArgumentException("Product has expired");
			}
		}
		
		if(product.getPrice() > customer.getBalance()){
			throw new IllegalArgumentException("You do not have enough money to buy this product!");
		}
		
		if(customer.getAge() < 13 && product.getAgeRestriction() == AgeRestriction.TEENAGER) {
			throw new IllegalArgumentException("You have to be a teen to buy this product");
		}
		
		if(customer.getAge() < 18 && product.getAgeRestriction() == AgeRestriction.ADULT){
			throw new IllegalArgumentException("You are too young to buy this product!");
		}
		
		product.setQuantity(product.getQuantity() - 1);
		customer.setBalance((new BigDecimal(customer.getBalance()).subtract(new BigDecimal(product.getPrice()))).doubleValue());
	}
}
