package _01.Geometry;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable{
	public PlaneShape(Vertex[] vertices) {
		super(vertices);
	}

	@Override
	public abstract double getArea();
	
	@Override
	public abstract double getPerimeter();
}
