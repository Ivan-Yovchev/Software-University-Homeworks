package _01.Geometry;

public abstract class Vertex {
	protected double x;
	protected double y;

	public Vertex(double x, double y) {
		this.setX(x);
		this.setY(y);
	}

	public double getX() {
		return x;
	}

	public void setX(double x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	public void setY(double y) {
		this.y = y;
	}
	
	public static double getDistanceBetweenPoints(Vertex vertex1, Vertex vertex2){
		double distance =
				Math.pow(vertex1.getX() - vertex2.getX(), 2) +
				Math.pow(vertex1.getY() - vertex2.getY(), 2);
		
		return Math.sqrt(distance);
	}
	
	@Override
	public String toString() {
		return "Vertex [x=" + this.x + ", y=" + this.y + "]";
	}
}
