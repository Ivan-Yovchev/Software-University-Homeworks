package _02.OnelvShop;

public abstract class ElectronicsProduct extends Product {
	private int guarantee;

	public ElectronicsProduct(String name, double price, int quantity, AgeRestriction ageRestriction, int guarantee) {
		super(name, price, quantity, ageRestriction);
		this.setGuarantee(guarantee);
	}

	public int getGuarantee() {
		return guarantee;
	}

	public void setGuarantee(int guarantee) {
		this.guarantee = guarantee;
	}

	@Override
	public String toString() {
		return super.toString() + "Guarantee: " + this.guarantee + "\n";
	}
}
