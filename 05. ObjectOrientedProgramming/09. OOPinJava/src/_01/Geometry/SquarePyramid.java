package _01.Geometry;

public class SquarePyramid extends SpaceShape {
	private double baseWidth;
	private double pyramidHight;
	
	public SquarePyramid(Vertex[] vertices, double baseWidth,
			double pyramidHight) {
		super(vertices);
		this.setBaseWidth(baseWidth);
		this.setPyramidHight(pyramidHight);
	}

	public double getBaseWidth() {
		return baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		this.baseWidth = baseWidth;
	}

	public double getPyramidHight() {
		return pyramidHight;
	}

	public void setPyramidHight(double pyramidHight) {
		this.pyramidHight = pyramidHight;
	}

	@Override
	public double getArea() {
		double sideTriangleHight = 
				Math.sqrt(Math.pow(this.baseWidth / 2, 2) + Math.pow(this.pyramidHight, 2));
		double area = (this.baseWidth * sideTriangleHight * 2) + (this.baseWidth * this.baseWidth);
		return area;
	}

	@Override
	public double getVolume() {
		return (this.baseWidth * this.baseWidth) * (this.pyramidHight / 3);
	}
	
	@Override
	public String toString(){
		return "Type: " + this.getClass() + 
			   ". Center: " + super.getVertices()[0] +
			   " has volume: " + this.getVolume() +
			   " and area: " + this.getArea();
	}
}
