package _01.Geometry;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;
	
	public Rectangle(Vertex[] vertices, double width, double height) {
		super(vertices);
		this.setWidth(width);
		this.setHeight(height);
	}
	
	public double getWidth() {
		return width;
	}
	
	public void setWidth(double width) {
		this.width = width;
	}
	
	public double getHeight() {
		return height;
	}
	
	public void setHeight(double height) {
		this.height = height;
	}
	
	@Override
	public double getArea() {
		double area = this.width * this.height;
		
		return area;
	}
	
	@Override
	public double getPerimeter() {
		double perimeter = this.width * 2 + this.height * 2;
		
		return perimeter;
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
			   ". Center:" + super.getVertices()[0] +
			   " has perimeter: " + this.getPerimeter() +
			   " and area: " + this.getArea();
	}
	
}
