package _01.Geometry;

public class Sphere extends SpaceShape {
	private double radius;

	public Sphere(Vertex[] vertices, double radius) {
		super(vertices);
		this.setRadius(radius);
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getArea() {
		return 4 * Math.PI * this.radius * this.radius;
	}

	@Override
	public double getVolume() {
		return (4 * Math.PI * Math.pow(this.radius, 3)) / 3;
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
			   ". Center: " + super.getVertices()[0] +
			   " has volume: " + this.getVolume() +
			   " and area: " + this.getArea();
	}
}
