package _02.OnelvShop;

import java.math.BigDecimal;

public class Customer {
	private String name;
	private int age;
	private BigDecimal balance;
	
	public Customer(String name, int age, double balance) {
		this.setName(name);
		this.setAge(age);
		this.setBalance(balance);
	}

	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		if(name.length() <= 0 || name == null){
			throw new IllegalArgumentException("Name cannot be null or empty");
		}
		else{
			this.name = name;
		}
	}
	
	public int getAge() {
		return age;
	}
	
	public void setAge(int age) {
		if(age < 0){
			throw new IllegalArgumentException("Age cannot be nagative");
		}
		else{
			this.age = age;
		}
	}
	
	public double getBalance() {
		return balance.doubleValue();
	}
	
	public void setBalance(double balance) {
		if(balance < 0){
			throw new IllegalArgumentException("Balance cannot be negative");
		}
		else{
			this.balance = new BigDecimal(balance);
		}
	}

	@Override
	public String toString() {
		return "Name: " + this.name + ", Age: " + this.age + ", Balance: " + this.balance + "\n";
	}
}
