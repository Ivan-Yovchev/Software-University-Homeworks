package _01.Geometry;

public class Triangle extends PlaneShape {
	private double a;
	private double b;
	private double c;
	
	public Triangle(Vertex[] vertices) {
		super(vertices);
	}

	@Override
	public double getArea() {
		double p = this.getPerimeter() / 2;
		double area = Math.sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
		
		return area;
	}

	@Override
	public double getPerimeter() {
		this.a = Vertex.getDistanceBetweenPoints(super.getVertices()[0], super.getVertices()[1]);
		this.b = Vertex.getDistanceBetweenPoints(super.getVertices()[1], super.getVertices()[2]);
		this.c = Vertex.getDistanceBetweenPoints(super.getVertices()[2], super.getVertices()[0]);
		
		return a + b + c;
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
				". Coordinates- A: " + super.getVertices()[0] +
							  " B: " + super.getVertices()[1] +
							  " C: " + super.getVertices()[2] +
			   " has perimeter: " + this.getPerimeter() +
			   " and area: " + this.getArea();
	}
}
