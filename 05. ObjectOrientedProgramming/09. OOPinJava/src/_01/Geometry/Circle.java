package _01.Geometry;

public class Circle extends PlaneShape {
	private double radius;
	
	public Circle(Vertex[] vertices, double radius) {
		super(vertices);
		this.setRadius(radius);;
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getArea() {
		return Math.PI * this.radius * this.radius;
	}

	@Override
	public double getPerimeter() {
		return 2 * Math.PI * this.radius;
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
			   ". Center: " + super.getVertices()[0] +
			   " has perimeter: " + this.getPerimeter() +
			   " and area: " + this.getArea();
	}
}
