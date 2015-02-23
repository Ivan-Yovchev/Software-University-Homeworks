package _02.OnelvShop;

import java.math.BigDecimal;

public class Computer extends ElectronicsProduct {

	private final static int COMPUTER_GUARANTEE = 24;
	
	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, COMPUTER_GUARANTEE);
		
		if(super.getQuantity() > 1000){
			super.setPrice(new BigDecimal(super.getPrice()).multiply(new BigDecimal("0.95")));
		}
	}
	
}
