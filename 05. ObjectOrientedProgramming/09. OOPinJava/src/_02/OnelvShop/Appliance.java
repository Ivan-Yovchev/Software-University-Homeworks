package _02.OnelvShop;

import java.math.BigDecimal;

public class Appliance extends ElectronicsProduct{
	private final static int APPLIANCE_GUARANTEE = 6;
	
	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, APPLIANCE_GUARANTEE);
		
		if(super.getQuantity() < 50){
			super.setPrice(new BigDecimal(super.getPrice()).multiply(new BigDecimal("1.05")));
		}
	}
}
