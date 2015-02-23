package _02.OnelvShop;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.Date;

public class FoodProduct extends Product implements Expirable {
	private Date expirationDate;
	
	public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction, Date expirationDate) {
		super(name, price, quantity, ageRestriction);
		this.setExpirationDate(expirationDate);
	}

	public void setExpirationDate(Date expirationDate) {
		this.expirationDate = expirationDate;
		Date now = new Date();
		long differance = expirationDate.getTime() - now.getTime();
		int days = (int) differance / (24 * 60 * 60 * 1000);
		if(days < 0){
			this.setPrice(new BigDecimal(this.getPrice()).multiply(new BigDecimal("0.7")));
		}
	}
	
	@Override
	public Date getExpirationDate() {
		return this.expirationDate;
	}

	@Override
	public String toString() {
		SimpleDateFormat DATE_FORMAT = new SimpleDateFormat("dd-MMMM-YYY");
		String date = DATE_FORMAT.format(this.expirationDate);
		
		return super.toString() + "ExpirationDate: " + date + "\n";
	}
}
