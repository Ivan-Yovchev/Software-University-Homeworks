package _01.Geometry;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
	public SpaceShape(Vertex[] vertices) {
		super(vertices);
	}
	
	@Override
	public abstract double getArea();
	
	@Override
	public abstract double getVolume();
}
