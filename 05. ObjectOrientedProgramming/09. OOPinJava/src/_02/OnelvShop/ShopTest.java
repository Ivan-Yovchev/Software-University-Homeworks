package _02.OnelvShop;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Comparator;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.stream.Collectors;

public class ShopTest {

	public static void main(String[] args) {
		Calendar calendar = GregorianCalendar.getInstance();
		calendar.set(2015, 1, 15);
		Date date = calendar.getTime();
		
		FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT, date);
		Customer pecata = new Customer("Pecata", 17, 30.00);
		
		try {
			PurchaseManager.ProcessPurchase(cigars, pecata);
		} catch (Exception e) {
			System.err.println(e.getMessage());
		}

		Customer gopeto = new Customer("Gopeto", 18, 0.44);
		
		try {
			PurchaseManager.ProcessPurchase(cigars, gopeto);
		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
		
		List<Product> products = new ArrayList<Product>();
		
		calendar.set(2016, 4, 7);
		products.add(new FoodProduct("Toothpaste Aquafresh", 5.00, 10, AgeRestriction.NONE, calendar.getTime()));
		calendar.set(2014, 9, 20);
		products.add(new FoodProduct("Vita bread", 1.10, 2, AgeRestriction.ADULT, calendar.getTime()));
		calendar.set(2014, 4, 12);
		products.add(new FoodProduct("7Days", 0.79, 111, AgeRestriction.TEENAGER, calendar.getTime()));
		products.add(new Computer("ExtraDelux XF 11", 699.90, 20, AgeRestriction.NONE));
		products.add(new Computer("TheBesto", 1699.90, 2, AgeRestriction.ADULT));
		products.add(new Appliance("Eldom Oven", 299.90, 60, AgeRestriction.NONE));
		
		Comparator<Product> byDateOfExpiry = (p1, p2) -> 
		(((FoodProduct) p1).getExpirationDate().after(((FoodProduct) p2).getExpirationDate())?-1:
		 ((FoodProduct) p1).getExpirationDate().after(((FoodProduct) p2).getExpirationDate())?1:0);
		Comparator<Product> byPrice = (p1, p2) -> Double.compare(p1.getPrice(), (p2.getPrice()));
		
		Product expirableProduct = products.stream()
				.filter(p -> p instanceof Expirable)
				.sorted(byDateOfExpiry)
				.findFirst()
				.get();
		
		System.out.println(expirableProduct);
		System.out.println("\n ----------------");
		
		List<Product> adultAgerestrictionByPrice = products.stream()
				.filter(p -> p.getAgeRestriction() == AgeRestriction.ADULT)
				.sorted(byPrice)
				.collect(Collectors.toList());
		
		for (Product product : adultAgerestrictionByPrice) {
			System.out.println(product + "\n");
		}
				
	}

}
