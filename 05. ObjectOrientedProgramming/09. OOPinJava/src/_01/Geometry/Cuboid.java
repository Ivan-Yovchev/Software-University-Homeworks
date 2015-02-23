package _01.Geometry;

public class Cuboid extends SpaceShape {
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(Vertex[] vertices, double width, double height, double depth) {
		super(vertices);
		this.setWidth(width);
		this.setHeight(height);
		this.setDepth(depth);
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
	
	public double getDepth() {
		return depth;
	}
	
	public void setDepth(double depth) {
		this.depth = depth;
	}

	@Override
	public double getArea() {
		return 2 * (this.depth * this.width + this.height * this.width + this.height * this.depth);
	}

	@Override
	public double getVolume() {
		return this.width * this.height * this.depth;
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
			   ". Center: " + super.getVertices()[0] +
			   " has volume: " + this.getVolume() +
			   " and area: " + this.getArea();
	}
}
